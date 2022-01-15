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
        (StudyExecutionScopeEntity e) => e.SiteUid, "Site"
      );

      EntityAccessControl.RegisterPropertyAsAccessControlClassification(
        (StudyExecutionScopeEntity e) => e.ResearchStudyUid, "Study"
      );

    }

  }

  public static class AccessControlContextExtensions {

    public static bool ValidateEntityScope<TEntity>(this AccessControlContext context, TEntity entity) {
      var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<TEntity>(context);
      if (!filterExpression.Compile().Invoke(entity)) {
        return false;
      }
      return true;
    }

  }

}
