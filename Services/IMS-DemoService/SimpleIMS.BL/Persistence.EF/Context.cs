using System;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MedicalResearch.IdentityManagement.Persistence.EF {

  partial class IdentityManagementDbContext {

    static IdentityManagementDbContext() {

      EntityAccessControl.RegisterPropertyAsAccessControlClassification(
        (StudyExecutionScopeEntity e) => e.ExecutingInstituteIdentifier, "Institute"
      );

      EntityAccessControl.RegisterPropertyAsAccessControlClassification(
        (StudyExecutionScopeEntity e) => e.StudyWorkflowName, "Study"
      );

    }

  }

}
