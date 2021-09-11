using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;

namespace MedicalResearch.StudyManagement {

  /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
  public partial interface IEventQueueService {


    /// <summary>
    /// creatre new reewnt event-queue and returns its guid
    /// </summary>
    /// <param name="studyIdentifier"></param>
    /// <returns></returns>
    Guid CreateEventQueue(); 'dazu wird dann gesopechter wer!!!
    Guid[] GetEventQueueIds();
    bool DeleteEventQueue(Guid eventQueueId); 'dazu wird dann gesopechter wer!!! darf nur vom eignen token bearbeitet wrden



    /// <summary>
    /// - push subscribers will automacially get a push event names "STILL_ALLIVE" every 14h
    /// - if there is no puish subscription, a periodic pull must be implemented on cosumer side
    /// - queus which are not checktd wia FetchNextEvent for more than 7d will be automatically deleted
    /// including all PushSubscribers when they havent at loeast one other eventQueue subscribed!
    /// 
    /// </summary>
    /// <param name="eventQueueId"></param>
    /// <param name="lastEventDateUtc"></param>
    /// <param name="eventName"></param>
    /// <param name="eventPayload"></param>
    /// <returns></returns>
    DateTime? FetchNextEvent(Guid eventQueueId, DateTime? lastEventDateUtc, out string eventName, out string eventPayload);



    /// <summary>
    /// unittelbar dagach geht ein post ein bei dem die Guid der eventqueue din ist 
    /// 
    /// 
    /// bekommt pushSubscriberkey geschickt
    /// 
    /// true wenn created oder da, false wenn post fehlgeshcvlagen ist!!!
    /// 
    /// </summary>
    /// <param name="subscriberUrl"></param>
    /// <param name="bearerSecret">optional, if set then a bearer token will be generated using the gibe nsecret</param>
    /// <returns></returns>
    bool RegisterPushSubscriber(string subscriberUrl, string? bearerSecret);
    bool DeletePushSubscriber(Guid pushSubscriberkey);

    bool EnablePush(Guid eventQueueId, Guid pushSubscriberkey);
    bool DisablePush(Guid eventQueueId, Guid pushSubscriberkey);





  










    Guid SubscribeForStudyEndEvent(string studyIdentifier, Guid eventQueueId);








    Guid subscribeForStudyTermination(string studyIdentifier)

      //UnsubscribeForStudyTermination(string studyIdentifier)





    bool SubscribeEventQueue(Guid queueId, Guid subscriberkey);
    bool UnsubscribeEventQueue(Guid queueId, Guid subscriberkey);


    bool DeleteEventQueue(Guid queueId);















    /// <summary>
    /// returns the Version of the API itself, which can be used for 
    /// backward compatibility within inhomogeneous infrastructures
    /// </summary>
    string GetApiVersion();

    /// <summary>
    /// returns if the authenticated accessor of the
    /// API has the permission to use this service
    /// </summary>
    /// <returns></returns>
    bool HasAccess();

  }

}
