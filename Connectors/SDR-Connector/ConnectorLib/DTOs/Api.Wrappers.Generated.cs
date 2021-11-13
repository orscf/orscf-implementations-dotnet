using MedicalResearch.SubjectData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.SubjectData {
  
  namespace SubjectParticipation {
  
  /// <summary>
  /// Contains arguments for calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetApiVersion' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'HasAccess' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  }
  
}
