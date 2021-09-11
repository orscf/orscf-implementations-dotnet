using MedicalResearch.BillingData;
using MedicalResearch.BillingData.WebAPI;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MedicalResearch.BillingData.TestClient {

  public partial class FormMain : Form {

    public FormMain() {
      this.InitializeComponent();
    }

    #region " UI Events "

    private void FormMain_Load(object sender, EventArgs e) {
      try {
        this.Text = this.Text.Replace("{V}" , typeof(IVisits).Assembly.GetName().Version.ToString(3));
        this.InitModelClasses();
        this.LoadProfiles();
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gBtnLoad_Click(object sender, EventArgs e) {
      try {
        this.LoadTable();
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      try {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo {  UseShellExecute = true , FileName = linkLabel2.Text });
      }
      catch {
      }
    }
    private void gBtnDelete_Click(object sender, EventArgs e) {
      try {
        if (MessageBox.Show(this, "This action DELETES the current record from the store!\nDo you want to continue?", "ARE YOU SURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
          this.Delete();
        }
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void QueryBoxes_KeyDown(object sender, KeyEventArgs e) {
      if (e.KeyCode == Keys.Return) {
        try {
          this.LoadTable();
        }
        catch (Exception ex) {
          MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void gBtnTemplate_Click(object sender, EventArgs e) {
      try {
        this.GenerateTemplate();
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gTable_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
      try {     
        if (e.RowIndex > -1 && gTable.Rows[e.RowIndex].DataBoundItem != null) {
          gTxtJson.Text = JsonConvert.SerializeObject(gTable.Rows[e.RowIndex].DataBoundItem, Formatting.Indented);
        }
        else {
          gTxtJson.Text = "";
        }
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gTable_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      try { 
        if (e.RowIndex > -1 && gTable.Rows[e.RowIndex].DataBoundItem != null) {
          gTxtJson.Text = JsonConvert.SerializeObject(gTable.Rows[e.RowIndex].DataBoundItem, Formatting.Indented);
        }
        else {
          gTxtJson.Text = "";
        }

      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gTable_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      
    }

    private void gTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
      try {       
        var propName = gTable.Columns[e.ColumnIndex].Name;
        this.ToggleSortingForField(propName);
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gTable_SelectionChanged(object sender, EventArgs e) {
      try {
        if (gTable.SelectedRows.Count > 0 && gTable.SelectedRows[0].DataBoundItem != null) {
          gTxtJson.Text = JsonConvert.SerializeObject(gTable.SelectedRows[0].DataBoundItem, Formatting.Indented);
        }
        else {
          gTxtJson.Text = "";
        }
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gBtnUpdate_Click(object sender, EventArgs e) {
      try {
        if (MessageBox.Show(this, "This action WRITES data for the current record into the store!\nDo you want to continue?", "ARE YOU SURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
          this.UpdateRecord();
        }
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gBtnSaveAsNew_Click(object sender, EventArgs e) {
      try {
        if (MessageBox.Show(this, "This action WRITES a new record into the store!\nDo you want to continue?", "ARE YOU SURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
          this.SaveNew();
        }
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gBtnRemberUrl_Click(object sender, EventArgs e) {
      try {
        this.SaveCurrentProfile();
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gCboProfile_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        this.LoadSelectedProfile();
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void gCboClass_SelectedIndexChanged(object sender, EventArgs e) {
      try {
        gTable.DataSource = new Object() { };
        gTxtJson.Text = "";
        gTxtSearch.Text = "";
        gTxtSort.Text = "";
      }
      catch (Exception ex) {
        MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void groupBox2_Enter(object sender, EventArgs e) {
    }

    private void gTxtUrl_TextChanged(object sender, EventArgs e) {
      _CurrentConnector = null;
    }

    private void gTxtToken_TextChanged(object sender, EventArgs e) {
      _CurrentConnector = null;
    }

    #endregion

    private BdrConnector _CurrentConnector = null;

    private BdrConnector GetOrCreateCurrentConnector() {
      if(_CurrentConnector == null) {
        _CurrentConnector = new BdrConnector(gTxtUrl.Text, gTxtToken.Text);
      }
      return _CurrentConnector;
    }

    private void LoadProfiles() {
      gCboProfile.Items.Clear();

      gCboProfile.Items.Add("default");

      var registryNode = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\ORSCF\\BdrTestClient");
      var names = registryNode.GetValueNames().
        Where((n) => n.EndsWith(".Url")).
        Select((n) => n.Substring(0, n.LastIndexOf(".Url"))).
        Where((n) => n != "default").
        OrderBy((n) => n).
        ToArray();
      registryNode.Close();
      registryNode.Dispose();

      foreach (string name in names) {
        gCboProfile.Items.Add(name);
      }

      gCboProfile.SelectedIndex = 0;
    }

    private void LoadSelectedProfile() {
      var registryNode = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\ORSCF\\BdrTestClient");
      gTxtUrl.Text = registryNode.GetValue(gCboProfile.Text + ".Url", "") as string;
      gTxtToken.Text = registryNode.GetValue(gCboProfile.Text + ".Token","") as string;
      registryNode.Close();
      registryNode.Dispose();
    }

    private void SaveCurrentProfile() {
      if (string.IsNullOrWhiteSpace(gCboProfile.Text)) {
        return;
      }

      var registryNode = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\ORSCF\\BdrTestClient");

      if(string.IsNullOrWhiteSpace(gTxtUrl.Text) && string.IsNullOrWhiteSpace(gTxtToken.Text)) {
        registryNode.DeleteValue(gCboProfile.Text + ".Url", false);
        registryNode.DeleteValue(gCboProfile.Text + ".Token", false);
      }
      else {
        registryNode.SetValue(gCboProfile.Text + ".Url", gTxtUrl.Text);
        registryNode.SetValue(gCboProfile.Text + ".Token", gTxtToken.Text);
        if (!gCboProfile.Items.Contains(gCboProfile.Text)) {
          gCboProfile.Items.Add(gCboProfile.Text);
          gCboProfile.SelectedIndex = (gCboProfile.Items.Count - 1);
        }
      }

      registryNode.Close();
      registryNode.Dispose();

    }

    private void ToggleSortingForField(string propName) {

      string setDesc = "";
      if (gTxtSort.Text.Contains(propName)) {
        if (gTxtSort.Text.Trim().StartsWith(propName) && !gTxtSort.Text.Trim().StartsWith(propName + "^")) {
          setDesc = "^";
        }
        gTxtSort.Text = gTxtSort.Text.Replace(propName + "^", "").Replace(propName, "");
      }
      gTxtSort.Text = gTxtSort.Text.Replace(" ", "").Replace(",,", ",");
      gTxtSort.Text = string.Join(", ", gTxtSort.Text.Split(',').Select((t) => t.Trim()).Where((t) => !string.IsNullOrWhiteSpace(t)).Take(2).ToArray());

      if (string.IsNullOrWhiteSpace(gTxtSort.Text)) {
        gTxtSort.Text = propName + setDesc;
      }
      else {
        gTxtSort.Text = propName + setDesc + ", " + gTxtSort.Text;
      }

      this.LoadTable();
    }

    private void GenerateTemplate() {
      gTxtJson.Text = "";
      if (gCboClass.SelectedItem == null) {
      }
      else {
        var t = (gCboClass.SelectedItem as Type);
        var obj = Activator.CreateInstance(t);
        gTxtJson.Text = JsonConvert.SerializeObject(obj, Formatting.Indented);
      }
    }

    private void InitModelClasses() {
      gCboClass.Items.Clear();

      gCboClass.Items.Add(typeof(BillableTask));
      gCboClass.Items.Add(typeof(BillableVisit));
      gCboClass.Items.Add(typeof(StudyExecutionScope));
      gCboClass.Items.Add(typeof(BillingDemand));
      gCboClass.Items.Add(typeof(Invoice));

      gCboClass.DisplayMember = "Name";

      gCboClass.SelectedIndex = 0;
    }

    private void SaveNew() {
      if (string.IsNullOrEmpty(gTxtJson.Text)) {
        throw new Exception("No Data within the JSON-Window!");
      }
      if (gCboClass.SelectedItem == null) {
        return;
      }
      bool success = true;
      Type modelType = (gCboClass.SelectedItem as Type);

      if (modelType == typeof(BillableTask)) {
        var record = JsonConvert.DeserializeObject<BillableTask>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillableTasks.AddNewBillableTask(record);
      }
      else if (modelType == typeof(BillableVisit)) {
        var record = JsonConvert.DeserializeObject<BillableVisit>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillableVisits.AddNewBillableVisit(record);
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        var record = JsonConvert.DeserializeObject<StudyExecutionScope>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyExecutionScopes.AddNewStudyExecutionScope(record);
      }
      else if (modelType == typeof(BillingDemand)) {
        var record = JsonConvert.DeserializeObject<BillingDemand>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillingDemands.AddNewBillingDemand(record);
      }
      else if (modelType == typeof(Invoice)) {
        var record = JsonConvert.DeserializeObject<Invoice>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Invoices.AddNewInvoice(record);
      }

      if (!success) {
        throw new Exception("Server responded non-success!");
      }
      else {
        this.LoadTable();
      }

    }

    private void UpdateRecord() {
      if (string.IsNullOrEmpty(gTxtJson.Text)) {
        throw new Exception("No Data within the JSON-Window!");
      }
      if (gCboClass.SelectedItem == null) {
        return;
      }
      bool success = true;
      Type modelType = (gCboClass.SelectedItem as Type);

      if (modelType == typeof(BillableTask)) {
        var record = JsonConvert.DeserializeObject<BillableTask>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillableTasks.UpdateDataRecording(record);
      }
      else if (modelType == typeof(BillableVisit)) {
        var record = JsonConvert.DeserializeObject<BillableVisit>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillableVisits.UpdateVisit(record);
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        var record = JsonConvert.DeserializeObject<StudyExecutionScope>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyExecutionScopes.UpdateDrugApplyment(record);
      }
      else if (modelType == typeof(BillingDemand)) {
        var record = JsonConvert.DeserializeObject<BillingDemand>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillingDemands.UpdateStudyEvent(record);
      }
      else if (modelType == typeof(Invoice)) {
        var record = JsonConvert.DeserializeObject<Invoice>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Invoices.UpdateTreatment(record);
      }

      if (!success) {
        throw new Exception("Server responded non-success!");
      }
      else {
        this.LoadTable();
      }

    }

    private void Delete() {
      if (string.IsNullOrEmpty(gTxtJson.Text)) {
        throw new Exception("No Data within the JSON-Window!");
      }
      if (gCboClass.SelectedItem == null) {
        return;
      }
      bool success = true;
      Type modelType = (gCboClass.SelectedItem as Type);

      if (modelType == typeof(BillableTask)) {
        var record = JsonConvert.DeserializeObject<BillableTask>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillableTasks.DeleteDataRecordingByTaskGuid(record.TaskGuid);
      }
      else if (modelType == typeof(BillableVisit)) {
        var record = JsonConvert.DeserializeObject<BillableVisit>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillableVisits.DeleteVisitByVisitGuid(record.VisitGuid);
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        var record = JsonConvert.DeserializeObject<StudyExecutionScope>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyExecutionScopes.DeleteDrugApplymentByTaskGuid(record.TaskGuid);
      }
      else if (modelType == typeof(BillingDemand)) {
        var record = JsonConvert.DeserializeObject<BillingDemand>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().BillingDemands.DeleteStudyEventByEventGuid(record.EventGuid);
      }
      else if (modelType == typeof(Invoice)) {
        var record = JsonConvert.DeserializeObject<Invoice>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Invoices.DeleteTreatmentByTaskGuid(record.TaskGuid);
      }

      if (!success) {
        throw new Exception("Server responded non-success!");
      }
      else {
        this.LoadTable();
      }

    }

    private void LoadTable() {
      if(String.IsNullOrWhiteSpace (gTxtSearch.Text)) {
        gTxtSearch.Text = "*";
      }
      gTable.DataSource = new Object() {};
      if (gCboClass.SelectedItem == null) {
        return;
      }
      Type modelType = (gCboClass.SelectedItem as Type);

      if (modelType == typeof(BillableTask)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().BillableTasks.SearchDataRecordings(gTxtSearch.Text,gTxtSort.Text,int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(BillableVisit)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().BillableVisits.SearchVisits(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().StudyExecutionScopes.SearchDrugApplyments(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(BillingDemand)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().BillingDemands.SearchStudyEvents(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().StudyExecutionScopes.SearchStudyExecutionScopes(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(Invoice)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().Invoices.SearchTreatments(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }

      if (gTable.DataSource == null) {
        throw new Exception("Server responded non-success!");
      }
      gTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

      if(modelType != null) {
        foreach (var p in modelType.GetProperties()) {
          gTable.Columns[p.Name].ToolTipText = p.GetDocumentation();
        }
      }

    }

  }

 }
