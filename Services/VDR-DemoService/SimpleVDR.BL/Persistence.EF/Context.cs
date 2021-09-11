using System;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MedicalResearch.VisitData.Persistence.EF {

  partial class VisitDataDbContext {

    static VisitDataDbContext() {

      EntityAccessControl.RegisterPropertyAsAccessControlClassification(
        (StudyExecutionScopeEntity e) => e.ExecutingInstituteIdentifier, "Institute"
      );

      EntityAccessControl.RegisterPropertyAsAccessControlClassification(
        (StudyExecutionScopeEntity e) => e.StudyWorkflowName, "Study"
      );

    }

  }

}
