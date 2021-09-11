using MedicalResearch.VisitData;
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

namespace TestClient {

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

    private VdrConnector _CurrentConnector = null;

    private VdrConnector GetOrCreateCurrentConnector() {
      if(_CurrentConnector == null) {
        _CurrentConnector = new VdrConnector(gTxtUrl.Text, gTxtToken.Text);
      }
      return _CurrentConnector;
    }

    private void LoadProfiles() {
      gCboProfile.Items.Clear();

      gCboProfile.Items.Add("default");

      var registryNode = Application.UserAppDataRegistry.CreateSubKey("ORSCF\\VdrTestClient");
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
      var registryNode = Application.UserAppDataRegistry.CreateSubKey("ORSCF\\VdrTestClient");
      gTxtUrl.Text = registryNode.GetValue(gCboProfile.Text + ".Url", "") as string;
      gTxtToken.Text = registryNode.GetValue(gCboProfile.Text + ".Token","") as string;
      registryNode.Close();
      registryNode.Dispose();
    }

    private void SaveCurrentProfile() {
      if (string.IsNullOrWhiteSpace(gCboProfile.Text)) {
        return;
      }

      var registryNode = Application.UserAppDataRegistry.CreateSubKey("ORSCF\\VdrTestClient");

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

      gCboClass.Items.Add(typeof(DataRecording));
      gCboClass.Items.Add(typeof(Visit));
      gCboClass.Items.Add(typeof(DrugApplyment));
      gCboClass.Items.Add(typeof(StudyEvent));
      gCboClass.Items.Add(typeof(StudyExecutionScope));
      gCboClass.Items.Add(typeof(Treatment));

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

      if (modelType == typeof(DataRecording)) {
        var record = JsonConvert.DeserializeObject<DataRecording>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().DataRecordings.AddNewDataRecording(record);
      }
      else if (modelType == typeof(Visit)) {
        var record = JsonConvert.DeserializeObject<Visit>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Visits.AddNewVisit(record);
      }
      else if (modelType == typeof(DrugApplyment)) {
        var record = JsonConvert.DeserializeObject<DrugApplyment>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().DrugApplyments.AddNewDrugApplyment(record);
      }
      else if (modelType == typeof(StudyEvent)) {
        var record = JsonConvert.DeserializeObject<StudyEvent>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyEvents.AddNewStudyEvent(record);
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        var record = JsonConvert.DeserializeObject<StudyExecutionScope>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyExecutionScopes.AddNewStudyExecutionScope(record);
      }
      else if (modelType == typeof(Treatment)) {
        var record = JsonConvert.DeserializeObject<Treatment>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Treatments.AddNewTreatment(record);
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

      if (modelType == typeof(DataRecording)) {
        var record = JsonConvert.DeserializeObject<DataRecording>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().DataRecordings.UpdateDataRecording(record);
      }
      else if (modelType == typeof(Visit)) {
        var record = JsonConvert.DeserializeObject<Visit>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Visits.UpdateVisit(record);
      }
      else if (modelType == typeof(DrugApplyment)) {
        var record = JsonConvert.DeserializeObject<DrugApplyment>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().DrugApplyments.UpdateDrugApplyment(record);
      }
      else if (modelType == typeof(StudyEvent)) {
        var record = JsonConvert.DeserializeObject<StudyEvent>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyEvents.UpdateStudyEvent(record);
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        var record = JsonConvert.DeserializeObject<StudyExecutionScope>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyExecutionScopes.UpdateStudyExecutionScope(record);
      }
      else if (modelType == typeof(Treatment)) {
        var record = JsonConvert.DeserializeObject<Treatment>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Treatments.UpdateTreatment(record);
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

      if (modelType == typeof(DataRecording)) {
        var record = JsonConvert.DeserializeObject<DataRecording>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().DataRecordings.DeleteDataRecordingByTaskGuid(record.TaskGuid);
      }
      else if (modelType == typeof(Visit)) {
        var record = JsonConvert.DeserializeObject<Visit>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Visits.DeleteVisitByVisitGuid(record.VisitGuid);
      }
      else if (modelType == typeof(DrugApplyment)) {
        var record = JsonConvert.DeserializeObject<DrugApplyment>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().DrugApplyments.DeleteDrugApplymentByTaskGuid(record.TaskGuid);
      }
      else if (modelType == typeof(StudyEvent)) {
        var record = JsonConvert.DeserializeObject<StudyEvent>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyEvents.DeleteStudyEventByEventGuid(record.EventGuid);
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        var record = JsonConvert.DeserializeObject<StudyExecutionScope>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().StudyExecutionScopes.DeleteStudyExecutionScopeByStudyExecutionIdentifier(record.StudyExecutionIdentifier);
      }
      else if (modelType == typeof(Treatment)) {
        var record = JsonConvert.DeserializeObject<Treatment>(gTxtJson.Text);
        success = this.GetOrCreateCurrentConnector().Treatments.DeleteTreatmentByTaskGuid(record.TaskGuid);
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

      if (modelType == typeof(DataRecording)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().DataRecordings.SearchDataRecordings(gTxtSearch.Text,gTxtSort.Text,int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(Visit)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().Visits.SearchVisits(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(DrugApplyment)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().DrugApplyments.SearchDrugApplyments(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(StudyEvent)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().StudyEvents.SearchStudyEvents(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(StudyExecutionScope)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().StudyExecutionScopes.SearchStudyExecutionScopes(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
      }
      else if (modelType == typeof(Treatment)) {
        gTable.DataSource = this.GetOrCreateCurrentConnector().Treatments.SearchTreatments(gTxtSearch.Text, gTxtSort.Text, int.Parse(gTxtPageNumber.Text), int.Parse(gTxtPageSize.Text)).ToList();
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
