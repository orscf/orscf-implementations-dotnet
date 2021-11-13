using System;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MedicalResearch.StudyManagement.Persistence.EF {

  partial class StudyManagementDbContext {

    static StudyManagementDbContext() {

      //EntityAccessControl.RegisterPropertyAsAccessControlClassification(
      //  (StudyExecutionScopeEntity e) => e.ExecutingInstituteIdentifier, "Institute"
      //);

      //EntityAccessControl.RegisterPropertyAsAccessControlClassification(
      //  (StudyExecutionScopeEntity e) => e.StudyWorkflowName, "Study"
      //);

    }

  }

}
