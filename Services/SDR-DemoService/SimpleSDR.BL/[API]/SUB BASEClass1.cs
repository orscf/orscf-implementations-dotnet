using MedicalResearch.SubjectData.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.AccessControl;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MedicalResearch.SubjectData {

  internal partial class SubscriptionManager {

    private List<Subscription> _Subscriptions = new List<Subscription>();
    private string _OfficialPublisherUrl;
    private string _SubscriptionStorageDirectory;
    private DateTime unixEpochUtc = new DateTime(1970, 01, 01, 0, 0, 0, DateTimeKind.Utc);

    public SubscriptionManager(string officialPublisherUrl, string subscriptionStorageDirectory) {

      subscriptionStorageDirectory = Path.GetFullPath(subscriptionStorageDirectory);
      Directory.CreateDirectory(subscriptionStorageDirectory);

      _OfficialPublisherUrl = officialPublisherUrl;
      _SubscriptionStorageDirectory = subscriptionStorageDirectory;
      if(!String.IsNullOrWhiteSpace(_SubscriptionStorageDirectory)) {
        this.LoadSubscriptions();
      }
    }

    public long GetCurrentTimestamp() {
      return Convert.ToInt64(DateTime.UtcNow.Subtract(unixEpochUtc).TotalSeconds);
    }

    private void LoadSubscriptions() {
      //TODO------------------
    }

    private void SaveSubscriptions() {
      if (!String.IsNullOrWhiteSpace(_SubscriptionStorageDirectory)) {
        //TODO------------------
      }
    }

    public Guid CreateSubscription<TSubscription>(string subscriberUrl, Action<TSubscription> customizer = null) where TSubscription : Subscription, new() {

      TSubscription sub = new TSubscription();
      sub.CurrentTimestamp = this.GetCurrentTimestamp();
      sub.Secret = null; //unconfirmed!
      sub.SubscriberRootUrl = subscriberUrl;
      sub.SubscriptionUid = Guid.NewGuid();

      if (customizer != null) {
        customizer.Invoke(sub);
      }

      Task.Run(()=> {
        System.Threading.Thread.Sleep(500);

          var req = new SubscriptionConfirmationRequest();
          req.subscriptionUid = sub.SubscriptionUid;
          req.publisherUrl = _OfficialPublisherUrl;
          string rawMessage = JsonConvert.SerializeObject(req);
          string targetUrl = sub.SubscriberRootUrl + "/ConfirmAsSubscriber";
          string rawResponse = null;

        try {
          using (WebClient wc = new WebClient()) {
            rawResponse = wc.UploadString(targetUrl, rawMessage);
          }
          if (rawResponse != null && rawResponse.StartsWith("{")) {
            var resp = JsonConvert.DeserializeObject<SubscriptionConfirmationResponse>(rawResponse);
            sub.Secret = resp.secret;
            lock (_Subscriptions) {
              _Subscriptions.Add(sub);
            }
            this.SaveSubscriptions();
            sub.EvaluateAsync(this);
          }
        }
        catch (Exception ex) {
        }
      });

      return sub.SubscriptionUid;
    }

    public Guid[] GetSubsriptionsBySubscriberUrl(string subscriberUrl, string secret) {
      var result = new List<Guid>();
      lock (_Subscriptions) {
        foreach (Subscription s in _Subscriptions) {
          if (s.SubscriberRootUrl == subscriberUrl && s.Secret == secret) {
            result.Add(s.SubscriptionUid);
            break;
          }
        }
      }
      return result.ToArray();
    }

    public bool TerminateSubscription(Guid subscriptionUid, string secret) {
      bool success = false;
      lock (_Subscriptions) {
        Subscription found = null;
        foreach (Subscription s in _Subscriptions) {
          if(s.SubscriptionUid == subscriptionUid) {
            found = s;
            break;
          }
        }
        if (found != null && found.Secret == secret) {
          _Subscriptions.Remove(found);
          success = true;
        }
      }
      if (success) {
        this.SaveSubscriptions();
      }
      return success;
    }

    public bool SendEvent<TEvent>(Subscription subscription, out bool terminate, Action<TEvent> contentSetter = null) where TEvent : SubscriptionEvent, new() {
      TEvent evt = new TEvent();
      terminate = false;

      if (string.IsNullOrWhiteSpace(subscription.Secret)) {
        return false; //subscription is unconfirmed
      }

      evt.eventUid = Guid.NewGuid();
      evt.subscriptionUid = subscription.SubscriptionUid;
      evt.publisherUrl = _OfficialPublisherUrl;

      if (contentSetter != null) {
        contentSetter.Invoke(evt);
      }

      this.SignEvent(evt, subscription.Secret);

      string rawMessage = JsonConvert.SerializeObject(evt);
      string targetUrl = subscription.GetFullNotificationUrl();
      string rawResponse = null;

      try {
        using (WebClient wc = new WebClient()) {
          rawResponse = wc.UploadString(targetUrl, rawMessage);
        }

      }
      catch (Exception ex) {
        return false; //delivery error
      }

      if (rawResponse != null && rawResponse.StartsWith("{")) {
        var resp = JsonConvert.DeserializeObject<SubscriptionEventResponse>(rawResponse);
        terminate = resp.terminateSubscription;
      }

      return true;
    }

    private SHA256Managed _SHA256Managed = new SHA256Managed();
    private void SignEvent(SubscriptionEvent targetEvent, string subscriptionSecret) {
      //a SHA256 Hash of SubscriptionSecret + EventUid(in lower string representation, without '-' characters!) 
      //Sample: SHA256('ThEs3Cr3T' + 'c997dfb1c445fea84afe995307713b59') = 'a320ef5b0f563e8dcb16d759961739977afc98b90628d9dc3be519fb20701490'
      var signatureContent = subscriptionSecret + targetEvent.eventUid.ToString().Replace("-", "").ToLower();
      byte[] signatureContentBytes = Encoding.Unicode.GetBytes(signatureContent);
      byte[] eventSignatureBytes = _SHA256Managed.ComputeHash(signatureContentBytes);
      targetEvent.eventSignature = Convert.ToHexString(eventSignatureBytes);
    }

  }


  internal abstract class Subscription {

    protected abstract void Evaluate(SubscriptionManager subscriptionManager);

    public void EvaluateAsync(SubscriptionManager subscriptionManager) {
      Task.Run(()=> {
        try {
          this.Evaluate(subscriptionManager);
        }
        catch (Exception ex) {
        }
      });
    }

    public Guid SubscriptionUid { get; set; } = Guid.NewGuid();
    public string Secret { get; set; } = null;
    public string SubscriberRootUrl { get; set; } = null;
    public abstract string GetFullNotificationUrl();
    public long CurrentTimestamp { get; set; } = 0;

  }

  internal partial class SubscriptionEvent {
    public Guid eventUid { get; set; } = Guid.NewGuid();
    public Guid subscriptionUid { get; set; }
    public string publisherUrl { get; set; } = null;
    public string eventSignature { get; set; } = null;
  }

  internal partial class SubscriptionEventResponse {
    public bool terminateSubscription { get; set; } = false;
  }

  internal partial class SubscriptionConfirmationRequest {
    public string publisherUrl { get; set; }
    public Guid subscriptionUid { get; set; }
  }

  internal partial class SubscriptionConfirmationResponse {
    public string secret { get; set; }
  }

}