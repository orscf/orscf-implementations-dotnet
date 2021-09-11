using MedicalResearch.Workflow;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.Workflow.WebAPI.DTOs {
  
  /// <summary>
  /// Contains arguments for calling 'get_Id'.
  /// </summary>
  public class get_IdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Id'.
  /// </summary>
  public class get_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Id' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Id'.
  /// </summary>
  public class set_IdRequest {
  
    /// <summary> Required Argument for 'set_Id' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Id'.
  /// </summary>
  public class set_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_TaskScheduleId'.
  /// </summary>
  public class get_TaskScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_TaskScheduleId'.
  /// </summary>
  public class get_TaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_TaskScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_TaskScheduleId'.
  /// </summary>
  public class set_TaskScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_TaskScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_TaskScheduleId'.
  /// </summary>
  public class set_TaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedDataRecordingName'.
  /// </summary>
  public class get_InducedDataRecordingNameRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedDataRecordingName'.
  /// </summary>
  public class get_InducedDataRecordingNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedDataRecordingName' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedDataRecordingName'.
  /// </summary>
  public class set_InducedDataRecordingNameRequest {
  
    /// <summary> Required Argument for 'set_InducedDataRecordingName' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedDataRecordingName'.
  /// </summary>
  public class set_InducedDataRecordingNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Offset'.
  /// </summary>
  public class get_OffsetRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Offset'.
  /// </summary>
  public class get_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Offset' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Offset'.
  /// </summary>
  public class set_OffsetRequest {
  
    /// <summary> Required Argument for 'set_Offset' (Int32) </summary>
    [Required]
    public Int32 value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Offset'.
  /// </summary>
  public class set_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_OffsetUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitRequest {
  
    /// <summary> Required Argument for 'set_OffsetUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityBefore' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityBefore' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityAfter' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityAfter' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedTaskExecutionTitle'.
  /// </summary>
  public class get_InducedTaskExecutionTitleRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedTaskExecutionTitle'.
  /// </summary>
  public class get_InducedTaskExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedTaskExecutionTitle' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedTaskExecutionTitle'.
  /// </summary>
  public class set_InducedTaskExecutionTitleRequest {
  
    /// <summary> Required Argument for 'set_InducedTaskExecutionTitle' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedTaskExecutionTitle'.
  /// </summary>
  public class set_InducedTaskExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Skipable' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableRequest {
  
    /// <summary> Required Argument for 'set_Skipable' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnSkip' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipRequest {
  
    /// <summary> Required Argument for 'set_EventOnSkip' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnLost' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostRequest {
  
    /// <summary> Required Argument for 'set_EventOnLost' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetType'.
  /// </summary>
  public class GetTypeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetType'.
  /// </summary>
  public class GetTypeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetType' (Type) </summary>
    public Type @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ToString'.
  /// </summary>
  public class ToStringRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'ToString'.
  /// </summary>
  public class ToStringResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ToString' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'Equals'.
  /// </summary>
  public class EqualsRequest {
  
    /// <summary> Required Argument for 'Equals' (Object) </summary>
    [Required]
    public Object obj { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'Equals'.
  /// </summary>
  public class EqualsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'Equals' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetHashCode' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Id'.
  /// </summary>
  public class get_IdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Id'.
  /// </summary>
  public class get_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Id' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Id'.
  /// </summary>
  public class set_IdRequest {
  
    /// <summary> Required Argument for 'set_Id' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Id'.
  /// </summary>
  public class set_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_TaskScheduleId'.
  /// </summary>
  public class get_TaskScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_TaskScheduleId'.
  /// </summary>
  public class get_TaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_TaskScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_TaskScheduleId'.
  /// </summary>
  public class set_TaskScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_TaskScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_TaskScheduleId'.
  /// </summary>
  public class set_TaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedDrugApplymentName'.
  /// </summary>
  public class get_InducedDrugApplymentNameRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedDrugApplymentName'.
  /// </summary>
  public class get_InducedDrugApplymentNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedDrugApplymentName' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedDrugApplymentName'.
  /// </summary>
  public class set_InducedDrugApplymentNameRequest {
  
    /// <summary> Required Argument for 'set_InducedDrugApplymentName' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedDrugApplymentName'.
  /// </summary>
  public class set_InducedDrugApplymentNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Offset'.
  /// </summary>
  public class get_OffsetRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Offset'.
  /// </summary>
  public class get_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Offset' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Offset'.
  /// </summary>
  public class set_OffsetRequest {
  
    /// <summary> Required Argument for 'set_Offset' (Int32) </summary>
    [Required]
    public Int32 value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Offset'.
  /// </summary>
  public class set_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_OffsetUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitRequest {
  
    /// <summary> Required Argument for 'set_OffsetUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityBefore' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityBefore' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityAfter' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityAfter' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedTaskExecutionTitle'.
  /// </summary>
  public class get_InducedTaskExecutionTitleRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedTaskExecutionTitle'.
  /// </summary>
  public class get_InducedTaskExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedTaskExecutionTitle' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedTaskExecutionTitle'.
  /// </summary>
  public class set_InducedTaskExecutionTitleRequest {
  
    /// <summary> Required Argument for 'set_InducedTaskExecutionTitle' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedTaskExecutionTitle'.
  /// </summary>
  public class set_InducedTaskExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Skipable' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableRequest {
  
    /// <summary> Required Argument for 'set_Skipable' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnSkip' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipRequest {
  
    /// <summary> Required Argument for 'set_EventOnSkip' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnLost' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostRequest {
  
    /// <summary> Required Argument for 'set_EventOnLost' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetType'.
  /// </summary>
  public class GetTypeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetType'.
  /// </summary>
  public class GetTypeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetType' (Type) </summary>
    public Type @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ToString'.
  /// </summary>
  public class ToStringRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'ToString'.
  /// </summary>
  public class ToStringResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ToString' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'Equals'.
  /// </summary>
  public class EqualsRequest {
  
    /// <summary> Required Argument for 'Equals' (Object) </summary>
    [Required]
    public Object obj { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'Equals'.
  /// </summary>
  public class EqualsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'Equals' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetHashCode' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Id'.
  /// </summary>
  public class get_IdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Id'.
  /// </summary>
  public class get_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Id' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Id'.
  /// </summary>
  public class set_IdRequest {
  
    /// <summary> Required Argument for 'set_Id' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Id'.
  /// </summary>
  public class set_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_ParentProcedureScheduleId'.
  /// </summary>
  public class get_ParentProcedureScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_ParentProcedureScheduleId'.
  /// </summary>
  public class get_ParentProcedureScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_ParentProcedureScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_ParentProcedureScheduleId'.
  /// </summary>
  public class set_ParentProcedureScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_ParentProcedureScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_ParentProcedureScheduleId'.
  /// </summary>
  public class set_ParentProcedureScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedProcedureScheduleId'.
  /// </summary>
  public class get_InducedProcedureScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedProcedureScheduleId'.
  /// </summary>
  public class get_InducedProcedureScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedProcedureScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedProcedureScheduleId'.
  /// </summary>
  public class set_InducedProcedureScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_InducedProcedureScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedProcedureScheduleId'.
  /// </summary>
  public class set_InducedProcedureScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Offset'.
  /// </summary>
  public class get_OffsetRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Offset'.
  /// </summary>
  public class get_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Offset' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Offset'.
  /// </summary>
  public class set_OffsetRequest {
  
    /// <summary> Required Argument for 'set_Offset' (Int32) </summary>
    [Required]
    public Int32 value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Offset'.
  /// </summary>
  public class set_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_OffsetUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitRequest {
  
    /// <summary> Required Argument for 'set_OffsetUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityBefore' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityBefore' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityAfter' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityAfter' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SharedSkipCounters'.
  /// </summary>
  public class get_SharedSkipCountersRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SharedSkipCounters'.
  /// </summary>
  public class get_SharedSkipCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SharedSkipCounters' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SharedSkipCounters'.
  /// </summary>
  public class set_SharedSkipCountersRequest {
  
    /// <summary> Required Argument for 'set_SharedSkipCounters' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SharedSkipCounters'.
  /// </summary>
  public class set_SharedSkipCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SharedLostCounters'.
  /// </summary>
  public class get_SharedLostCountersRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SharedLostCounters'.
  /// </summary>
  public class get_SharedLostCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SharedLostCounters' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SharedLostCounters'.
  /// </summary>
  public class set_SharedLostCountersRequest {
  
    /// <summary> Required Argument for 'set_SharedLostCounters' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SharedLostCounters'.
  /// </summary>
  public class set_SharedLostCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetType'.
  /// </summary>
  public class GetTypeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetType'.
  /// </summary>
  public class GetTypeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetType' (Type) </summary>
    public Type @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ToString'.
  /// </summary>
  public class ToStringRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'ToString'.
  /// </summary>
  public class ToStringResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ToString' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'Equals'.
  /// </summary>
  public class EqualsRequest {
  
    /// <summary> Required Argument for 'Equals' (Object) </summary>
    [Required]
    public Object obj { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'Equals'.
  /// </summary>
  public class EqualsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'Equals' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetHashCode' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Id'.
  /// </summary>
  public class get_IdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Id'.
  /// </summary>
  public class get_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Id' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Id'.
  /// </summary>
  public class set_IdRequest {
  
    /// <summary> Required Argument for 'set_Id' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Id'.
  /// </summary>
  public class set_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_ParentTaskScheduleId'.
  /// </summary>
  public class get_ParentTaskScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_ParentTaskScheduleId'.
  /// </summary>
  public class get_ParentTaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_ParentTaskScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_ParentTaskScheduleId'.
  /// </summary>
  public class set_ParentTaskScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_ParentTaskScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_ParentTaskScheduleId'.
  /// </summary>
  public class set_ParentTaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedTaskScheduleId'.
  /// </summary>
  public class get_InducedTaskScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedTaskScheduleId'.
  /// </summary>
  public class get_InducedTaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedTaskScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedTaskScheduleId'.
  /// </summary>
  public class set_InducedTaskScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_InducedTaskScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedTaskScheduleId'.
  /// </summary>
  public class set_InducedTaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Offset'.
  /// </summary>
  public class get_OffsetRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Offset'.
  /// </summary>
  public class get_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Offset' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Offset'.
  /// </summary>
  public class set_OffsetRequest {
  
    /// <summary> Required Argument for 'set_Offset' (Int32) </summary>
    [Required]
    public Int32 value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Offset'.
  /// </summary>
  public class set_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_OffsetUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitRequest {
  
    /// <summary> Required Argument for 'set_OffsetUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityBefore' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityBefore' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityAfter' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityAfter' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SharedSkipCounters'.
  /// </summary>
  public class get_SharedSkipCountersRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SharedSkipCounters'.
  /// </summary>
  public class get_SharedSkipCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SharedSkipCounters' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SharedSkipCounters'.
  /// </summary>
  public class set_SharedSkipCountersRequest {
  
    /// <summary> Required Argument for 'set_SharedSkipCounters' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SharedSkipCounters'.
  /// </summary>
  public class set_SharedSkipCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SharedLostCounters'.
  /// </summary>
  public class get_SharedLostCountersRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SharedLostCounters'.
  /// </summary>
  public class get_SharedLostCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SharedLostCounters' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SharedLostCounters'.
  /// </summary>
  public class set_SharedLostCountersRequest {
  
    /// <summary> Required Argument for 'set_SharedLostCounters' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SharedLostCounters'.
  /// </summary>
  public class set_SharedLostCountersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetType'.
  /// </summary>
  public class GetTypeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetType'.
  /// </summary>
  public class GetTypeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetType' (Type) </summary>
    public Type @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ToString'.
  /// </summary>
  public class ToStringRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'ToString'.
  /// </summary>
  public class ToStringResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ToString' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'Equals'.
  /// </summary>
  public class EqualsRequest {
  
    /// <summary> Required Argument for 'Equals' (Object) </summary>
    [Required]
    public Object obj { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'Equals'.
  /// </summary>
  public class EqualsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'Equals' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetHashCode' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Id'.
  /// </summary>
  public class get_IdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Id'.
  /// </summary>
  public class get_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Id' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Id'.
  /// </summary>
  public class set_IdRequest {
  
    /// <summary> Required Argument for 'set_Id' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Id'.
  /// </summary>
  public class set_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_TaskScheduleId'.
  /// </summary>
  public class get_TaskScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_TaskScheduleId'.
  /// </summary>
  public class get_TaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_TaskScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_TaskScheduleId'.
  /// </summary>
  public class set_TaskScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_TaskScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_TaskScheduleId'.
  /// </summary>
  public class set_TaskScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedTreatmentName'.
  /// </summary>
  public class get_InducedTreatmentNameRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedTreatmentName'.
  /// </summary>
  public class get_InducedTreatmentNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedTreatmentName' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedTreatmentName'.
  /// </summary>
  public class set_InducedTreatmentNameRequest {
  
    /// <summary> Required Argument for 'set_InducedTreatmentName' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedTreatmentName'.
  /// </summary>
  public class set_InducedTreatmentNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Offset'.
  /// </summary>
  public class get_OffsetRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Offset'.
  /// </summary>
  public class get_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Offset' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Offset'.
  /// </summary>
  public class set_OffsetRequest {
  
    /// <summary> Required Argument for 'set_Offset' (Int32) </summary>
    [Required]
    public Int32 value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Offset'.
  /// </summary>
  public class set_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_OffsetUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitRequest {
  
    /// <summary> Required Argument for 'set_OffsetUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityBefore' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityBefore' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityAfter' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityAfter' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedTaskExecutionTitle'.
  /// </summary>
  public class get_InducedTaskExecutionTitleRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedTaskExecutionTitle'.
  /// </summary>
  public class get_InducedTaskExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedTaskExecutionTitle' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedTaskExecutionTitle'.
  /// </summary>
  public class set_InducedTaskExecutionTitleRequest {
  
    /// <summary> Required Argument for 'set_InducedTaskExecutionTitle' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedTaskExecutionTitle'.
  /// </summary>
  public class set_InducedTaskExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Skipable' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableRequest {
  
    /// <summary> Required Argument for 'set_Skipable' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnSkip' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipRequest {
  
    /// <summary> Required Argument for 'set_EventOnSkip' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnLost' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostRequest {
  
    /// <summary> Required Argument for 'set_EventOnLost' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetType'.
  /// </summary>
  public class GetTypeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetType'.
  /// </summary>
  public class GetTypeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetType' (Type) </summary>
    public Type @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ToString'.
  /// </summary>
  public class ToStringRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'ToString'.
  /// </summary>
  public class ToStringResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ToString' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'Equals'.
  /// </summary>
  public class EqualsRequest {
  
    /// <summary> Required Argument for 'Equals' (Object) </summary>
    [Required]
    public Object obj { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'Equals'.
  /// </summary>
  public class EqualsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'Equals' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetHashCode' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Id'.
  /// </summary>
  public class get_IdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Id'.
  /// </summary>
  public class get_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Id' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Id'.
  /// </summary>
  public class set_IdRequest {
  
    /// <summary> Required Argument for 'set_Id' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Id'.
  /// </summary>
  public class set_IdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_ProcedureScheduleId'.
  /// </summary>
  public class get_ProcedureScheduleIdRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_ProcedureScheduleId'.
  /// </summary>
  public class get_ProcedureScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_ProcedureScheduleId' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_ProcedureScheduleId'.
  /// </summary>
  public class set_ProcedureScheduleIdRequest {
  
    /// <summary> Required Argument for 'set_ProcedureScheduleId' (Guid) </summary>
    [Required]
    public Guid value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_ProcedureScheduleId'.
  /// </summary>
  public class set_ProcedureScheduleIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Offset'.
  /// </summary>
  public class get_OffsetRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Offset'.
  /// </summary>
  public class get_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Offset' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Offset'.
  /// </summary>
  public class set_OffsetRequest {
  
    /// <summary> Required Argument for 'set_Offset' (Int32) </summary>
    [Required]
    public Int32 value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Offset'.
  /// </summary>
  public class set_OffsetResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_OffsetUnit'.
  /// </summary>
  public class get_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_OffsetUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitRequest {
  
    /// <summary> Required Argument for 'set_OffsetUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_OffsetUnit'.
  /// </summary>
  public class set_OffsetUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityBefore'.
  /// </summary>
  public class get_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityBefore' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityBefore' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityBefore'.
  /// </summary>
  public class set_SchedulingVariabilityBeforeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityAfter'.
  /// </summary>
  public class get_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityAfter' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityAfter' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityAfter'.
  /// </summary>
  public class set_SchedulingVariabilityAfterResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_SchedulingVariabilityUnit'.
  /// </summary>
  public class get_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_SchedulingVariabilityUnit' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitRequest {
  
    /// <summary> Required Argument for 'set_SchedulingVariabilityUnit' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_SchedulingVariabilityUnit'.
  /// </summary>
  public class set_SchedulingVariabilityUnitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedVisitProdecureName'.
  /// </summary>
  public class get_InducedVisitProdecureNameRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedVisitProdecureName'.
  /// </summary>
  public class get_InducedVisitProdecureNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedVisitProdecureName' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedVisitProdecureName'.
  /// </summary>
  public class set_InducedVisitProdecureNameRequest {
  
    /// <summary> Required Argument for 'set_InducedVisitProdecureName' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedVisitProdecureName'.
  /// </summary>
  public class set_InducedVisitProdecureNameResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_InducedVisitExecutionTitle'.
  /// </summary>
  public class get_InducedVisitExecutionTitleRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_InducedVisitExecutionTitle'.
  /// </summary>
  public class get_InducedVisitExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_InducedVisitExecutionTitle' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_InducedVisitExecutionTitle'.
  /// </summary>
  public class set_InducedVisitExecutionTitleRequest {
  
    /// <summary> Required Argument for 'set_InducedVisitExecutionTitle' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_InducedVisitExecutionTitle'.
  /// </summary>
  public class set_InducedVisitExecutionTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_Skipable'.
  /// </summary>
  public class get_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_Skipable' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableRequest {
  
    /// <summary> Required Argument for 'set_Skipable' (Boolean) </summary>
    [Required]
    public Boolean value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_Skipable'.
  /// </summary>
  public class set_SkipableResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnSkip'.
  /// </summary>
  public class get_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnSkip' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipRequest {
  
    /// <summary> Required Argument for 'set_EventOnSkip' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnSkip'.
  /// </summary>
  public class set_EventOnSkipResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'get_EventOnLost'.
  /// </summary>
  public class get_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'get_EventOnLost' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostRequest {
  
    /// <summary> Required Argument for 'set_EventOnLost' (String) </summary>
    [Required]
    public String value { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'set_EventOnLost'.
  /// </summary>
  public class set_EventOnLostResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetType'.
  /// </summary>
  public class GetTypeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetType'.
  /// </summary>
  public class GetTypeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetType' (Type) </summary>
    public Type @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ToString'.
  /// </summary>
  public class ToStringRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'ToString'.
  /// </summary>
  public class ToStringResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ToString' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'Equals'.
  /// </summary>
  public class EqualsRequest {
  
    /// <summary> Required Argument for 'Equals' (Object) </summary>
    [Required]
    public Object obj { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'Equals'.
  /// </summary>
  public class EqualsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'Equals' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetHashCode'.
  /// </summary>
  public class GetHashCodeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetHashCode' (Int32) </summary>
    public Int32 @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Loads a specific ResearchStudyDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
  
    /// <summary> Required Argument for 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinitionIdentity): Composite Key, which represents the primary identity of a ResearchStudyDefinition </summary>
    [Required]
    public ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Loads a specific ResearchStudyDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinition) </summary>
    public ResearchStudyDefinition @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions.
  /// </summary>
  public class GetResearchStudyDefinitionsRequest {
  
    /// <summary> Optional Argument for 'GetResearchStudyDefinitions' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetResearchStudyDefinitions' (Int32?): Max count of ResearchStudyDefinitions which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions.
  /// </summary>
  public class GetResearchStudyDefinitionsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetResearchStudyDefinitions' (ResearchStudyDefinition[]) </summary>
    public ResearchStudyDefinition[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions where values matching to the given filterExpression
  /// </summary>
  public class SearchResearchStudyDefinitionsRequest {
  
    /// <summary> Required Argument for 'SearchResearchStudyDefinitions' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchResearchStudyDefinitions' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchResearchStudyDefinitions' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchResearchStudyDefinitions' (Int32?): Max count of ResearchStudyDefinitions which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions where values matching to the given filterExpression
  /// </summary>
  public class SearchResearchStudyDefinitionsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchResearchStudyDefinitions' (ResearchStudyDefinition[]) </summary>
    public ResearchStudyDefinition[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewResearchStudyDefinition'.
  /// Method: Adds a new ResearchStudyDefinition and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewResearchStudyDefinitionRequest {
  
    /// <summary> Required Argument for 'AddNewResearchStudyDefinition' (ResearchStudyDefinition): ResearchStudyDefinition containing the new values </summary>
    [Required]
    public ResearchStudyDefinition researchStudyDefinition { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewResearchStudyDefinition'.
  /// Method: Adds a new ResearchStudyDefinition and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewResearchStudyDefinitionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewResearchStudyDefinition' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateResearchStudyDefinition'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionRequest {
  
    /// <summary> Required Argument for 'UpdateResearchStudyDefinition' (ResearchStudyDefinition): ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be used to address the target record) </summary>
    [Required]
    public ResearchStudyDefinition researchStudyDefinition { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateResearchStudyDefinition'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateResearchStudyDefinition' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
  
    /// <summary> Required Argument for 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinitionIdentity): Composite Key, which represents the primary identity of a ResearchStudyDefinition </summary>
    [Required]
    public ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity { get; set; }
  
    /// <summary> Required Argument for 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinition): ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be ignored) </summary>
    [Required]
    public ResearchStudyDefinition researchStudyDefinition { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
  
    /// <summary> Required Argument for 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinitionIdentity): Composite Key, which represents the primary identity of a ResearchStudyDefinition </summary>
    [Required]
    public ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
}
