using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;

namespace MedicalResearch.StudyManagement {

  /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
  public partial interface IStudyAccessService {





    /* TODO:
 *   Listgin
 * 
 *   consume of ORSCF Store-root-urls!!
 * 
 * 
 * 
 */



    /// <summary>
    /// Subscribes the Event when the State of a Study was changed
    /// to the given "EventQueue" which is accessable via "EventQueueService"
    /// (including http notifications)
    /// </summary>
    bool SubscribeStudyStateChangedEvents(Guid eventQueueId);

    /// <summary>
    /// Unsubscribes the Event when the State of a Study was changed
    /// for the given "EventQueue"
    /// </summary>
    bool UnsubscribeStudyStateChangedEvents(Guid eventQueueId);







  }

}
