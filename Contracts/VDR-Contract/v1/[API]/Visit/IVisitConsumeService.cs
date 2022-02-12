using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.VisitData.Model;

namespace MedicalResearch.VisitData {

  /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
  public partial interface IVisitConsumeService {

    /// <summary>
    /// Searches Visits by a given 'filter' (if provided),
    /// sorts the results by the given 'sortingField' (if provided) and 
    /// returns an array of VisitUids for the matching records.
    /// </summary>
    /// <param name="filter"> values by field name (can also be a 'CustomField') which will used as AND-linked filter </param>
    /// <param name="sortingField">
    /// A fieldname, which should be used to sort the result (can also be a 'CustomField').
    /// If not provided, the result will be sorted by the creation date of the records
    /// </param>
    /// <param name="sortDescending"> toggles the sorting direction </param>
    /// <param name="includeArchivedRecords"> includes archived records in the result</param>
    /// <param name="limitResults"> a value greather than zero will represent a maximum count of results, that sould be returned</param>
    /// <param name="result"> </param>
    /// <returns></returns>
    void SearchVisits(
      out VisitMetaRecord[] result,
      string sortingField = null,
      bool sortDescending = false,
      VisitFilter filter = null,
      bool includeArchivedRecords = false,
      int limitResults = 0
    );

    /// <summary>
    /// Searches Visits which have been modified after(or at) the given 'minTimestampUtc',
    /// matching to the given 'filter' (if provided).
    /// The result is sorted descenting by the timestamp of the modification (latest first) and will
    /// include archived records.
    /// </summary>
    /// <param name="minTimestampUtc"> start of the timespan to search (as UNIX-Timestamp) </param>
    /// <param name="latestTimestampUtc"> the exact timestamp of the search (as UNIX-Timestamp) </param>
    /// <param name="createdRecords"> </param>
    /// <param name="modifiedRecords"> </param>
    /// <param name="archivedRecords"> </param>
    /// <param name="filter"> values by field name (can also be a 'CustomField') which will used as AND-linked filter </param>
    /// <returns></returns>
    void SearchChangedVisits(
      long minTimestampUtc,
      out long latestTimestampUtc,
      out VisitMetaRecord[] createdRecords,
      out VisitMetaRecord[] modifiedRecords,
      out VisitMetaRecord[] archivedRecords,
      VisitFilter filter = null
    );

    /// <summary>
    /// </summary>
    /// <param name="languagePref">
    /// Preferred language for the 'DisplayLabel' and 'InputDescription' 
    /// fields of the returned descriptors. The default is 'EN'.
    /// </param>
    /// <returns></returns>
    CustomFieldDescriptor[] GetCustomFieldDescriptorsForVisit(
      string languagePref = "EN"
    );

    /// <summary>
    /// Checks the existence of 'Visits' for a given list of visitUids
    /// </summary>
    /// <param name="visitUids"></param>
    /// <param name="unavailableVisitUids"></param>
    /// <param name="availableVisitUids"></param>
    void CheckVisitExisitence(
      Guid[] visitUids,
      out Guid[] unavailableVisitUids,
      out Guid[] availableVisitUids
    );

    /// <summary>
    /// loads the requested visits and returns lightweight json objects (without childs),
    /// which are optimized to be displayed as table (the most common UI use case).
    /// This models containig a combination of:
    ///  essential fieds from the record,
    ///  calculated fields (numbers of child records),
    ///  custom fields (choosen by the service)
    /// </summary>
    /// <param name="visitUids"></param>
    /// <param name="unavailableVisitUids"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    void GetVisitFields(
      Guid[] visitUids,
      out Guid[] unavailableVisitUids,
      out VisitFields[] result
    );

    /// <summary>
    /// exports full 'VisitStructures'
    /// </summary>
    /// <param name="visitUids"></param>
    /// <param name="unavailableVisitUids"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    void ExportVisits(
      Guid[] visitUids,
      out Guid[] unavailableVisitUids,
      out VisitStructure[] result
      );

  }

}
