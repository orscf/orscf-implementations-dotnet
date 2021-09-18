using MedicalResearch.BillingData.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.BillingData.StoreAccess {

/// <summary> Provides CRUD access to stored BillableTasks (based on schema version '1.5.0') </summary>
public partial interface IBillableTasks {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding BillableTasks.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific BillableTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  BillableTask GetBillableTaskByTaskGuid(Guid taskGuid);

  /// <summary> Loads BillableTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of BillableTasks which should be returned </param>
  BillableTask[] GetBillableTasks(int page = 1, int pageSize = 20);

  /// <summary> Loads BillableTasks where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of BillableTasks which should be returned</param>
  BillableTask[] SearchBillableTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new BillableTask and returns its primary identifier (or null on failure). </summary>
  /// <param name="billableTask"> BillableTask containing the new values </param>
  bool AddNewBillableTask(BillableTask billableTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the primary identifier fields within the given BillableTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="billableTask"> BillableTask containing the new values (the primary identifier fields within the given BillableTask will be used to address the target record) </param>
  bool UpdateBillableTask(BillableTask billableTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="billableTask"> BillableTask containing the new values (the primary identifier fields within the given BillableTask will be ignored) </param>
  bool UpdateBillableTaskByTaskGuid(Guid taskGuid, BillableTask billableTask);

  /// <summary> Deletes a specific BillableTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteBillableTaskByTaskGuid(Guid taskGuid);

}

/// <summary> Provides CRUD access to stored BillableVisits (based on schema version '1.5.0') </summary>
public partial interface IBillableVisits {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding BillableVisits.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific BillableVisit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  BillableVisit GetBillableVisitByVisitGuid(Guid visitGuid);

  /// <summary> Loads BillableVisits. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of BillableVisits which should be returned </param>
  BillableVisit[] GetBillableVisits(int page = 1, int pageSize = 20);

  /// <summary> Loads BillableVisits where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of BillableVisits which should be returned</param>
  BillableVisit[] SearchBillableVisits(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new BillableVisit and returns its primary identifier (or null on failure). </summary>
  /// <param name="billableVisit"> BillableVisit containing the new values </param>
  bool AddNewBillableVisit(BillableVisit billableVisit);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the primary identifier fields within the given BillableVisit. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="billableVisit"> BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be used to address the target record) </param>
  bool UpdateBillableVisit(BillableVisit billableVisit);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="billableVisit"> BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be ignored) </param>
  bool UpdateBillableVisitByVisitGuid(Guid visitGuid, BillableVisit billableVisit);

  /// <summary> Deletes a specific BillableVisit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteBillableVisitByVisitGuid(Guid visitGuid);

}

/// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
public partial interface IStudyExecutionScopes {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding StudyExecutionScopes.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  StudyExecutionScope GetStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier);

  /// <summary> Loads StudyExecutionScopes. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of StudyExecutionScopes which should be returned </param>
  StudyExecutionScope[] GetStudyExecutionScopes(int page = 1, int pageSize = 20);

  /// <summary> Loads StudyExecutionScopes where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyExecutionScopes which should be returned</param>
  StudyExecutionScope[] SearchStudyExecutionScopes(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new StudyExecutionScope and returns its primary identifier (or null on failure). </summary>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values </param>
  bool AddNewStudyExecutionScope(StudyExecutionScope studyExecutionScope);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be used to address the target record) </param>
  bool UpdateStudyExecutionScope(StudyExecutionScope studyExecutionScope);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be ignored) </param>
  bool UpdateStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier, StudyExecutionScope studyExecutionScope);

  /// <summary> Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier);

}

/// <summary> Provides CRUD access to stored BillingDemands (based on schema version '1.5.0') </summary>
public partial interface IBillingDemands {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding BillingDemands.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific BillingDemand addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a BillingDemand </param>
  BillingDemand GetBillingDemandById(Guid id);

  /// <summary> Loads BillingDemands. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of BillingDemands which should be returned </param>
  BillingDemand[] GetBillingDemands(int page = 1, int pageSize = 20);

  /// <summary> Loads BillingDemands where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of BillingDemands which should be returned</param>
  BillingDemand[] SearchBillingDemands(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new BillingDemand and returns its primary identifier (or null on failure). </summary>
  /// <param name="billingDemand"> BillingDemand containing the new values </param>
  bool AddNewBillingDemand(BillingDemand billingDemand);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the primary identifier fields within the given BillingDemand. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="billingDemand"> BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be used to address the target record) </param>
  bool UpdateBillingDemand(BillingDemand billingDemand);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a BillingDemand </param>
  /// <param name="billingDemand"> BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be ignored) </param>
  bool UpdateBillingDemandById(Guid id, BillingDemand billingDemand);

  /// <summary> Deletes a specific BillingDemand addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a BillingDemand </param>
  bool DeleteBillingDemandById(Guid id);

}

/// <summary> Provides CRUD access to stored Invoices (based on schema version '1.5.0') </summary>
public partial interface IInvoices {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding Invoices.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific Invoice addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a Invoice </param>
  Invoice GetInvoiceById(Guid id);

  /// <summary> Loads Invoices. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Invoices which should be returned </param>
  Invoice[] GetInvoices(int page = 1, int pageSize = 20);

  /// <summary> Loads Invoices where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Invoices which should be returned</param>
  Invoice[] SearchInvoices(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new Invoice and returns its primary identifier (or null on failure). </summary>
  /// <param name="invoice"> Invoice containing the new values </param>
  bool AddNewInvoice(Invoice invoice);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the primary identifier fields within the given Invoice. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="invoice"> Invoice containing the new values (the primary identifier fields within the given Invoice will be used to address the target record) </param>
  bool UpdateInvoice(Invoice invoice);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a Invoice </param>
  /// <param name="invoice"> Invoice containing the new values (the primary identifier fields within the given Invoice will be ignored) </param>
  bool UpdateInvoiceById(Guid id, Invoice invoice);

  /// <summary> Deletes a specific Invoice addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a Invoice </param>
  bool DeleteInvoiceById(Guid id);

}

}
