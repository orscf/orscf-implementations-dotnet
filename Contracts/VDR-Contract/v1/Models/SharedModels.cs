using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.VisitData.Model {

  public class CustomFieldDescriptor {

    [Required]
    public string TechnicalName { get; set; }

    [Required]
    public bool IsRequired { get; set; }

    [Required]
    public string DisplayLabel { get; set; }

    public string InputDescription { get; set; }

    public string DefaultValue { get; set; }

    public string[] Presets { get; set; } = null;

    public bool PresetsOnly { get; set; } = false;

    public string RegularExpression { get; set; } = null;

  }

  #region " Filters "

  public class StringFieldFilter {

    /// <summary>
    /// Specifies one or more values to match.
    /// DEFAULT (if this is undefined or null) will include everything (but NULL) to enable filtering based on 'excluded values'.
    /// An empty array which just has no elements will be treaded as valid input and results in no value matching, so this
    /// only makes sense when including NULL instead (if supported).
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public StringValueCriteria[] IncludedValues { get; set; }

    /// <summary>
    /// Specifies one or more values to be removed from the result set which was evaulated using the 'included values'.
    /// DEFAULT (if this is undefined or null) will just leave the filtering based on 'included values'.
    /// An empty array which just has no elements will also be ignored.
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public StringValueCriteria[] ExcludedValues { get; set; }

    /// <summary>
    /// Enables, that the included and excluded values are processed case-insenstive.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool IgnoreCasing { get; set; } = true;

    /// <summary>
    /// Negates the outcome of the whole filter.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool Negate { get; set; } = false;
  }

  public class NullableStringFieldFilter : StringFieldFilter {

    /// <summary>
    /// Can be set to true, if NULL should also treaded as match.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// NOTE: for filtering just NULL-values, set this to true and specify an empty array for the included values.
    /// Filtering just non-NULL-values can be achieved when also setting the 'negate' flag to true.
    /// </summary>
    public bool IncludeNull { get; set; } = false;

  }

  public class StringValueCriteria {

    /// <summary>
    /// The value to match.
    /// </summary>
    [Required]
    public string Value { get; set; } = null;

    /// <summary>
    /// Enables, that the given value can just be a substring within the content of the target field.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool MatchSubstring { get; set; } = false;

  }

  public class IntegerFieldFilter {

    /// <summary>
    /// Specifies one or more values to match.
    /// DEFAULT (if this is undefined or null) will include everything (but NULL) to enable filtering based on 'excluded values'.
    /// An empty array which just has no elements will be treaded as valid input and results in no value matching, so this
    /// only makes sense when including NULL instead (if supported).
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public IntegerValueCriteria[] IncludedValues { get; set; }

    /// <summary>
    /// Specifies one or more values to be removed from the result set which was evaulated using the 'included values'.
    /// DEFAULT (if this is undefined or null) will just leave the filtering based on 'included values'.
    /// An empty array which just has no elements will also be ignored.
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public IntegerValueCriteria[] ExcludedValues { get; set; }

    /// <summary>
    /// Negates the outcome of the whole filter.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool Negate { get; set; } = false;
  }

  public class NullableIntegerFieldFilter : IntegerFieldFilter {

    /// <summary>
    /// Can be set to true, if NULL should also treaded as match.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// NOTE: for filtering just NULL-values, set this to true and specify an empty array for the included values.
    /// Filtering just non-NULL-values can be achieved when also setting the 'negate' flag to true.
    /// </summary>
    public bool IncludeNull { get; set; } = false;

  }

  public class IntegerValueCriteria {

    /// <summary>
    /// The value to match.
    /// </summary>
    [Required]
    public int Value { get; set; } = 0;

    /// <summary>
    /// Declares, how the corresponding 'value' should be compared.
    /// DEFAULT (if this is undefined or null) is 'Equal'(1).
    /// </summary>
    public RangeMatchingBehaviour MatchingBehaviour { get; set; } = 0M;

  }

  public class DecimalFieldFilter {

    /// <summary>
    /// Specifies one or more values to match.
    /// DEFAULT (if this is undefined or null) will include everything (but NULL) to enable filtering based on 'excluded values'.
    /// An empty array which just has no elements will be treaded as valid input and results in no value matching, so this
    /// only makes sense when including NULL instead (if supported).
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public DecimalValueCriteria[] IncludedValues { get; set; }

    /// <summary>
    /// Specifies one or more values to be removed from the result set which was evaulated using the 'included values'.
    /// DEFAULT (if this is undefined or null) will just leave the filtering based on 'included values'.
    /// An empty array which just has no elements will also be ignored.
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public DecimalValueCriteria[] ExcludedValues { get; set; }

    /// <summary>
    /// Negates the outcome of the whole filter.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool Negate { get; set; } = false;
  }

  public class NullableDecimalFieldFilter : DecimalFieldFilter {

    /// <summary>
    /// Can be set to true, if NULL should also treaded as match.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// NOTE: for filtering just NULL-values, set this to true and specify an empty array for the included values.
    /// Filtering just non-NULL-values can be achieved when also setting the 'negate' flag to true.
    /// </summary>
    public bool IncludeNull { get; set; } = false;

  }

  public class DecimalValueCriteria {

    /// <summary>
    /// The value to match.
    /// </summary>
    [Required]
    public decimal Value { get; set; } = 0;

    /// <summary>
    /// Declares, how the corresponding 'value' should be compared.
    /// DEFAULT (if this is undefined or null) is 'Equal'(1).
    /// </summary>
    public RangeMatchingBehaviour MatchingBehaviour { get; set; } = 0M;

  }


  public class UidFieldFilter {

    /// <summary>
    /// Specifies one or more values to match.
    /// DEFAULT (if this is undefined or null) will include everything (but NULL) to enable filtering based on 'excluded values'.
    /// An empty array which just has no elements will be treaded as valid input and results in no value matching, so this
    /// only makes sense when including NULL instead (if supported).
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public UidValueCriteria[] IncludedValues { get; set; }

    /// <summary>
    /// Specifies one or more values to be removed from the result set which was evaulated using the 'included values'.
    /// DEFAULT (if this is undefined or null) will just leave the filtering based on 'included values'.
    /// An empty array which just has no elements will also be ignored.
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public UidValueCriteria[] ExcludedValues { get; set; }

    /// <summary>
    /// Negates the outcome of the whole filter.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool Negate { get; set; } = false;
  }

  public class NullableUidFieldFilter : UidFieldFilter {

    /// <summary>
    /// Can be set to true, if NULL should also treaded as match.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// NOTE: for filtering just NULL-values, set this to true and specify an empty array for the included values.
    /// Filtering just non-NULL-values can be achieved when also setting the 'negate' flag to true.
    /// </summary>
    public bool IncludeNull { get; set; } = false;

  }

  public class UidValueCriteria {

    /// <summary>
    /// The value to match.
    /// </summary>
    [Required]
    public Guid Value { get; set; } = Guid.Empty;

  }

  public class DateFieldFilter {

    /// <summary>
    /// Specifies one or more values to match.
    /// DEFAULT (if this is undefined or null) will include everything (but NULL) to enable filtering based on 'excluded values'.
    /// An empty array which just has no elements will be treaded as valid input and results in no value matching, so this
    /// only makes sense when including NULL instead (if supported).
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public DateValueCriteria[] IncludedValues { get; set; }

    /// <summary>
    /// Specifies one or more values to be removed from the result set which was evaulated using the 'included values'.
    /// DEFAULT (if this is undefined or null) will just leave the filtering based on 'included values'.
    /// An empty array which just has no elements will also be ignored.
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public DateValueCriteria[] ExcludedValues { get; set; }

    /// <summary>
    /// Negates the outcome of the whole filter.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool Negate { get; set; } = false;
  }

  public class NullableDateFieldFilter : DateFieldFilter {

    /// <summary>
    /// Can be set to true, if NULL should also treaded as match.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// NOTE: for filtering just NULL-values, set this to true and specify an empty array for the included values.
    /// Filtering just non-NULL-values can be achieved when also setting the 'negate' flag to true.
    /// </summary>
    public bool IncludeNull { get; set; } = false;

  }

  public class DateValueCriteria {

    /// <summary>
    /// The value to match.
    /// </summary>
    [Required]
    public DateTime Value { get; set; }

    /// <summary>
    /// Declares, how the corresponding 'value' should be compared.
    /// DEFAULT (if this is undefined or null) is 'Equal'(1).
    /// </summary>
    public RangeMatchingBehaviour MatchingBehaviour { get; set; } = RangeMatchingBehaviour.Equal;

    ///// <summary>
    ///// Declares, which portion of the corresponding 'value' should be compared.
    ///// DEFAULT (if this is undefined or null) is 'Date'(3).
    ///// </summary>
    //public DateMatchingPrecision MatchingPrecision { get; set; } = DateMatchingPrecision.Date;

  }

  public class BooleanFieldFilter {

    /// <summary>
    /// Specifies one or more values to match.
    /// DEFAULT (if this is undefined or null) will include everything (but NULL) to enable filtering based on 'excluded values'.
    /// An empty array which just has no elements will be treaded as valid input and results in no value matching, so this
    /// only makes sense when including NULL instead (if supported).
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public BooleanValueCriteria[] IncludedValues { get; set; }

    /// <summary>
    /// Specifies one or more values to be removed from the result set which was evaulated using the 'included values'.
    /// DEFAULT (if this is undefined or null) will just leave the filtering based on 'included values'.
    /// An empty array which just has no elements will also be ignored.
    /// An array containing multiple elements, will require at least ONE of the criteria to match (OR-linked)!
    /// </summary>
    public BooleanValueCriteria[] ExcludedValues { get; set; }

    /// <summary>
    /// Negates the outcome of the whole filter.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// </summary>
    public bool Negate { get; set; } = false;
  }

  public class NullableBooleanFieldFilter : BooleanFieldFilter {

    /// <summary>
    /// Can be set to true, if NULL should also treaded as match.
    /// DEFAULT (if this is undefined or null) is 'false'.
    /// NOTE: for filtering just NULL-values, set this to true and specify an empty array for the included values.
    /// Filtering just non-NULL-values can be achieved when also setting the 'negate' flag to true.
    /// </summary>
    public bool IncludeNull { get; set; } = false;

  }

  public class BooleanValueCriteria {

    /// <summary>
    /// The value to match.
    /// </summary>
    [Required]
    public bool Value { get; set; } = false;

  }

  /// <summary>
  /// Declares, how the corresponding 'value' should be compared.
  /// DEFAULT (if this is undefined or null) is 'Equal'(1).
  /// </summary>
  public enum RangeMatchingBehaviour {
    /// <summary> Matching only the exactly given value. (DEFAULT) </summary>
    Equal = 1,
    /// <summary> Matching all values lower than the given value. </summary>
    Less = 2,
    /// <summary> Matching the given value or any value lower than it. </summary>
    LessOrEqual = 3,
    /// <summary> Matching all values more than the given value. </summary>
    More = 4,
    /// <summary> Matching the given value or any value more than it. </summary>
    MoreOrEqual = 5
  }

  /// <summary>
  /// Declares, which portion of the corresponding 'value' should be compared.
  /// DEFAULT (if this is undefined or null) is 'Date'(3).
  /// </summary>
  //public enum DateMatchingPrecision {
  //  / <summary> Matching only the YEAR portion of the given value. </summary>
  //  Year = 1,
  //  / <summary> Matching the YEAR and MONTH portion of the given value. </summary>
  //  YearAndMonth = 2,
  //  / <summary> Matching the DATE (year+month+day) portion of the given value. (DEFAULT)</summary>
  //  Date = 3,
  //  / <summary> Matching the complete DATE and TIME of the given value. </summary>
  //  DateAndTime = 4
  //}

  #endregion

  public enum DataEnrollmentValidationState {

    /// <summary> rejected manually </summary>
    Invalid_Rejected = -1,

    /// <summary> the validation is outstanding </summary>
    NotValidated = 0,

    /// <summary> validation successfull </summary>
    Validated = 1,

    /// <summary> manulles queittieren von warnungen nötig </summary>
    OnHold_DubiousContentData = 2,

    /// <summary> waiting for manual approval </summary>
    OnHold_ManualApproval = 3,

    Invalid_UnassignableTarget = 11,
    Invalid_UnassignableTimeframe = 12,
    Invalid_AssignmentCollision = 13,

    /// <summary> schema is unknown </summary>
    Invalid_UnsupportedSchema = 21,

    /// <summary> schema is known, but outdated and there is no compatibility any more </summary>
    Invalid_OutdatedSchema = 22,

    /// <summary> the content has syntactical issues or has a missmatch to the addresses schema </summary>
    Invalid_BadContentFormat = 23,

    /// <summary> the content/data is not plausible for the business logic </summary>
    Invalid_BadData = 24

  }


}
