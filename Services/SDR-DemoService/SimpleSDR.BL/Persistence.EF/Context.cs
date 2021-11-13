using System;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MedicalResearch.SubjectData.Persistence.EF {

  partial class SubjectDataDbContext {

    static SubjectDataDbContext() {

      //EntityAccessControl.RegisterPropertyAsAccessControlClassification(
      //  (StudyExecutionScopeEntity e) => e.ExecutingInstituteIdentifier, "Institute"
      //);

      //EntityAccessControl.RegisterPropertyAsAccessControlClassification(
      //  (StudyExecutionScopeEntity e) => e.StudyWorkflowName, "Study"
      //);

    }

  }

}
