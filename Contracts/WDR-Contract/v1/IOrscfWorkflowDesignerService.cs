﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;

namespace MedicalResearch.Workflow {

  /// <summary> Provides an workflow-level API for interating with a  'WorkflowDefinitionRepository' (WDR) </summary>
  public partial interface IOrscfWorkflowDesignerService {



    //hie drafts!!!!!








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
