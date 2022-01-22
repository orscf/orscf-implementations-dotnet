using MedicalResearch.VisitData.Model;
using System;
using System.Data.AccessControl;
using System.Linq;

namespace MedicalResearch.VisitData {

  public partial class ApiService : IVdrEventSubscriptionService {

    public void ConfirmAsSubscriber(string publisherUrl, Guid subscriptionUid, out string secret) {
      throw new NotImplementedException();
    }

    public Guid[] GetSubsriptionsBySubscriberUrl(string subscriberUrl, string secret) {
      throw new NotImplementedException();
    }

    public void NoticeChangedVisits(Guid eventUid, string eventSignature, Guid subscriptionUid, string publisherUrl, VisitMetaRecord[] createdRecords, VisitMetaRecord[] modifiedRecords, VisitMetaRecord[] archivedRecords, out bool terminateSubscription) {
      throw new NotImplementedException();
    }

    public Guid SubscribeForChangedVisits(string subscriberUrl, VisitFilter scopeToStudyUid = null) {
      throw new NotImplementedException();
    }

    public bool TerminateSubscription(Guid subscriptionUid, string secret) {
      throw new NotImplementedException();
    }

  }

}
