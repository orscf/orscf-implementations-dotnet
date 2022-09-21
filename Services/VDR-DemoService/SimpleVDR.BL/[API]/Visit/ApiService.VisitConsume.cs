using MedicalResearch.VisitData.Model;
using MedicalResearch.VisitData.Persistence;
using System;
using System.Collections.Generic;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MedicalResearch.VisitData {

  public partial class ApiService : IVisitConsumeService {




    public CustomFieldDescriptor[] GetCustomFieldDescriptorsForVisit(string languagePref = "EN") {
      return new CustomFieldDescriptor[] { };
    }

    public void SearchVisits(
      out VisitMetaRecord[] result,
      string sortingField = null,
      bool sortDescending = false,
      VisitFilter filter = null,
      bool includeArchivedRecords = false,
      int limitResults = 0
    ) {

      //var filterExpression = LinqFilteringHelper.FilterObjectToLinqExpression<VisitEntity>(filter);

      throw new NotImplementedException();





    }

    public void SearchChangedVisits(
      long minTimestampUtc,
      out long latestTimestampUtc,
      out VisitMetaRecord[] createdRecords,
      out VisitMetaRecord[] modifiedRecords,
      out VisitMetaRecord[] archivedRecords,
      VisitFilter filter = null
    ) {

      throw new NotImplementedException();

    }

    public void CheckVisitExisitence(
      Guid[] visitUids,
      out Guid[] unavailableVisitUids,
      out Guid[] availableUids
    ) {
      throw new NotImplementedException();

    }

    public void GetVisitFields(
      Guid[] visitUids,
      out Guid[] unavailableVisitUids,
      out VisitFields[] result
    ) {
      throw new NotImplementedException();


    }

    public void ExportVisits(
      Guid[] visitUids,
      out Guid[] unavailableVisitUids,
      out VisitStructure[] result
    ) {


      throw new NotImplementedException();


    }

  }

}
