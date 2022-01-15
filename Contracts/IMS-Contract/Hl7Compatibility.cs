//using System;
//using System.ComponentModel.DataAnnotations;
//using System.Collections.ObjectModel;
//using System.Collections.Generic;
//using H7 = Hl7.Fhir.Model;
//using MedicalResearch.IdentityManagement.Model;
//using Hl7.Fhir.Model;
//using System.Linq;

//namespace MedicalResearch.IdentityManagement.Model.HL7Compatibility {





//    public class HumanName {

//      private H7.HumanName _WrappedObject;
//      public HumanName() {
//      _WrappedObject = new H7.HumanName();
//      }
//      public HumanName(H7.HumanName hl7ObjectToWrap) {
//       _WrappedObject = hl7ObjectToWrap;
//      }
//      public H7.HumanName UnwrapHl7Object() {
//      return _WrappedObject;
//      }

//    /// <summary>
//    ///  "official"
//    /// </summary>
//    [Required]
//    public string Use {
//      get {
//        return _WrappedObject.Family;
//      }
//      set {
//        _WrappedObject.Family = value;
//      }
//    }

//    [Required]
//    public string Family {
//        get {
//          return _WrappedObject.Family;
//        }
//        set {
//          _WrappedObject.Family = value;
//        }
//      }

//    [Required]
//    public string[] Given {
//        get {
//          return _WrappedObject.Given.ToArray();
//        }
//        set {
//          _WrappedObject.Given = value;
//        }
//      }

//  }


//  /// <summary>
//  /// COMPATIBLITY CONSTRAINTS:
//  ///   there must be at lease one element within 'Name' where 'Use' is "official"
//  /// </summary>
//  public class Patient {

//      private H7.Patient _WrappedObject;

//      public string[] GetCompatibilityIssues() {


//        return null;

//      }

//      public Patient() {
//      _WrappedObject = new H7.Patient();
//      }
//      public Patient(H7.Patient hl7ObjectToWrap) {
//        _WrappedObject = hl7ObjectToWrap;
//      }
//      public H7.Patient UnwrapHl7Object() {
//        return _WrappedObject;
//      }

//    /// <summary>
//    /// COMPATIBLITY CONSTRAINTS:
//    /// there must be at lease one element within 'Name' where 'Use' is "official"
//    /// </summary>
//    [Required]
//    public HumanName[] Name {
//        get {
//          return _WrappedObject.Name.Select(e=> new HumanName(e)).ToArray();
//        }
//        set {
//         // _WrappedObject.Name = value.UnwrapHl7Object();
//        }
//      }



//    [Required]
//    public String BirthDate { get; set; }

//    //[Required]
//    //public ImsCompatibleHl7Date BirthDate {
//    //  get {
//    //    return new ImsCompatibleHl7Date(_WrappedObject.BirthDateElement);
//    //  }
//    //  set {
//    //    _WrappedObject.BirthDate = value.UnwrapHl7Object();
//    //  }
//    //}

//    public DateTime GetBirthDate() {
//      return DateTime.Parse(this.BirthDate);
//    }
//    public void SetBirthDate(DateTime newValue) {
//      this.BirthDate = newValue.ToString("yyyy-MM-dd");
//    }


//  }






















//  public class ImsCompatibleHl7Date {


//    private H7.Date _WrappedObject;
//    public ImsCompatibleHl7Date() {
//      _WrappedObject = new H7.Date();
//    }
//    public ImsCompatibleHl7Date(H7.Date hl7ObjectToWrap) {
//      _WrappedObject = hl7ObjectToWrap;
//    }
//    public H7.Date UnwrapHl7Object() {
//      return _WrappedObject;
//    }


//    [Required]
//    public String Value {
//      get {
//        return _WrappedObject.Value;
//      }
//      set {
//        _WrappedObject.Value = value;
//      }
//    }

//  }













//}