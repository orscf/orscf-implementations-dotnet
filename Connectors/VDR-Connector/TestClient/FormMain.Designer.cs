
namespace TestClient {
  partial class FormMain {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.gBtnRemberUrl = new System.Windows.Forms.Button();
      this.gTable = new System.Windows.Forms.DataGridView();
      this.gCboProfile = new System.Windows.Forms.ComboBox();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.gCboClass = new System.Windows.Forms.ComboBox();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.gTxtPageSize = new System.Windows.Forms.TextBox();
      this.gTxtPageNumber = new System.Windows.Forms.TextBox();
      this.gTxtSort = new System.Windows.Forms.TextBox();
      this.gTxtSearch = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.gBtnLoad = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.gBtnSaveAsNew = new System.Windows.Forms.Button();
      this.gBtnDelete = new System.Windows.Forms.Button();
      this.gBtnTemplate = new System.Windows.Forms.Button();
      this.gBtnUpdate = new System.Windows.Forms.Button();
      this.gTxtJson = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.linkLabel2 = new System.Windows.Forms.LinkLabel();
      this.gTxtToken = new System.Windows.Forms.TextBox();
      this.gTxtUrl = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.gTable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // gBtnRemberUrl
      // 
      this.gBtnRemberUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gBtnRemberUrl.Location = new System.Drawing.Point(902, 22);
      this.gBtnRemberUrl.Name = "gBtnRemberUrl";
      this.gBtnRemberUrl.Size = new System.Drawing.Size(94, 23);
      this.gBtnRemberUrl.TabIndex = 0;
      this.gBtnRemberUrl.Text = "SAVE PROFILE";
      this.gBtnRemberUrl.UseVisualStyleBackColor = true;
      this.gBtnRemberUrl.Click += new System.EventHandler(this.gBtnRemberUrl_Click);
      // 
      // gTable
      // 
      this.gTable.AllowUserToDeleteRows = false;
      this.gTable.AllowUserToOrderColumns = true;
      this.gTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gTable.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
      this.gTable.Location = new System.Drawing.Point(0, 23);
      this.gTable.Margin = new System.Windows.Forms.Padding(8);
      this.gTable.MultiSelect = false;
      this.gTable.Name = "gTable";
      this.gTable.RowTemplate.Height = 25;
      this.gTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gTable.Size = new System.Drawing.Size(710, 434);
      this.gTable.TabIndex = 1;
      this.gTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gTable_CellContentClick);
      this.gTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gTable_CellEndEdit);
      this.gTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTable_ColumnHeaderMouseClick);
      this.gTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gTable_DataError);
      this.gTable.SelectionChanged += new System.EventHandler(this.gTable_SelectionChanged);
      // 
      // gCboProfile
      // 
      this.gCboProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gCboProfile.FormattingEnabled = true;
      this.gCboProfile.Location = new System.Drawing.Point(114, 22);
      this.gCboProfile.Name = "gCboProfile";
      this.gCboProfile.Size = new System.Drawing.Size(782, 23);
      this.gCboProfile.TabIndex = 2;
      this.gCboProfile.SelectedIndexChanged += new System.EventHandler(this.gCboProfile_SelectedIndexChanged);
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 53);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 15);
      this.label1.TabIndex = 4;
      this.label1.Text = "Service-URL:";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.Location = new System.Drawing.Point(0, 119);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.gTable);
      this.splitContainer1.Panel1.Controls.Add(this.gCboClass);
      this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
      this.splitContainer1.Panel2.Controls.Add(this.gTxtJson);
      this.splitContainer1.Size = new System.Drawing.Size(1008, 542);
      this.splitContainer1.SplitterDistance = 710;
      this.splitContainer1.TabIndex = 7;
      // 
      // gCboClass
      // 
      this.gCboClass.Dock = System.Windows.Forms.DockStyle.Top;
      this.gCboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.gCboClass.FormattingEnabled = true;
      this.gCboClass.Location = new System.Drawing.Point(0, 0);
      this.gCboClass.Name = "gCboClass";
      this.gCboClass.Size = new System.Drawing.Size(710, 23);
      this.gCboClass.TabIndex = 2;
      this.gCboClass.SelectedIndexChanged += new System.EventHandler(this.gCboClass_SelectedIndexChanged);
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.gTxtPageSize);
      this.groupBox4.Controls.Add(this.gTxtPageNumber);
      this.groupBox4.Controls.Add(this.gTxtSort);
      this.groupBox4.Controls.Add(this.gTxtSearch);
      this.groupBox4.Controls.Add(this.label3);
      this.groupBox4.Controls.Add(this.label2);
      this.groupBox4.Controls.Add(this.gBtnLoad);
      this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBox4.Location = new System.Drawing.Point(0, 457);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(710, 85);
      this.groupBox4.TabIndex = 6;
      this.groupBox4.TabStop = false;
      // 
      // gTxtPageSize
      // 
      this.gTxtPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gTxtPageSize.Location = new System.Drawing.Point(589, 22);
      this.gTxtPageSize.Name = "gTxtPageSize";
      this.gTxtPageSize.PlaceholderText = "Page-Size";
      this.gTxtPageSize.Size = new System.Drawing.Size(31, 23);
      this.gTxtPageSize.TabIndex = 6;
      this.gTxtPageSize.Text = "50";
      this.gTxtPageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // gTxtPageNumber
      // 
      this.gTxtPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gTxtPageNumber.Location = new System.Drawing.Point(589, 51);
      this.gTxtPageNumber.Name = "gTxtPageNumber";
      this.gTxtPageNumber.PlaceholderText = "Page-Number";
      this.gTxtPageNumber.Size = new System.Drawing.Size(31, 23);
      this.gTxtPageNumber.TabIndex = 5;
      this.gTxtPageNumber.Text = "1";
      this.gTxtPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // gTxtSort
      // 
      this.gTxtSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gTxtSort.Location = new System.Drawing.Point(6, 51);
      this.gTxtSort.Name = "gTxtSort";
      this.gTxtSort.PlaceholderText = "Sort-Expression";
      this.gTxtSort.Size = new System.Drawing.Size(541, 23);
      this.gTxtSort.TabIndex = 4;
      this.gTxtSort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryBoxes_KeyDown);
      // 
      // gTxtSearch
      // 
      this.gTxtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gTxtSearch.Location = new System.Drawing.Point(6, 20);
      this.gTxtSearch.Name = "gTxtSearch";
      this.gTxtSearch.PlaceholderText = "Seach-Expression";
      this.gTxtSearch.Size = new System.Drawing.Size(541, 23);
      this.gTxtSearch.TabIndex = 4;
      this.gTxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryBoxes_KeyDown);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(553, 54);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(33, 15);
      this.label3.TabIndex = 4;
      this.label3.Text = "Page";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(553, 30);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 15);
      this.label2.TabIndex = 4;
      this.label2.Text = "R.P.P.";
      // 
      // gBtnLoad
      // 
      this.gBtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gBtnLoad.Location = new System.Drawing.Point(626, 21);
      this.gBtnLoad.Name = "gBtnLoad";
      this.gBtnLoad.Size = new System.Drawing.Size(78, 53);
      this.gBtnLoad.TabIndex = 0;
      this.gBtnLoad.Text = "LOAD";
      this.gBtnLoad.UseVisualStyleBackColor = true;
      this.gBtnLoad.Click += new System.EventHandler(this.gBtnLoad_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.gBtnSaveAsNew);
      this.groupBox3.Controls.Add(this.gBtnDelete);
      this.groupBox3.Controls.Add(this.gBtnTemplate);
      this.groupBox3.Controls.Add(this.gBtnUpdate);
      this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupBox3.Location = new System.Drawing.Point(0, 457);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(294, 85);
      this.groupBox3.TabIndex = 6;
      this.groupBox3.TabStop = false;
      // 
      // gBtnSaveAsNew
      // 
      this.gBtnSaveAsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gBtnSaveAsNew.Location = new System.Drawing.Point(192, 51);
      this.gBtnSaveAsNew.Name = "gBtnSaveAsNew";
      this.gBtnSaveAsNew.Size = new System.Drawing.Size(96, 24);
      this.gBtnSaveAsNew.TabIndex = 0;
      this.gBtnSaveAsNew.Text = "SAVE AS NEW";
      this.gBtnSaveAsNew.UseVisualStyleBackColor = true;
      this.gBtnSaveAsNew.Click += new System.EventHandler(this.gBtnSaveAsNew_Click);
      // 
      // gBtnDelete
      // 
      this.gBtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gBtnDelete.Location = new System.Drawing.Point(6, 51);
      this.gBtnDelete.Name = "gBtnDelete";
      this.gBtnDelete.Size = new System.Drawing.Size(96, 24);
      this.gBtnDelete.TabIndex = 0;
      this.gBtnDelete.Text = "DELETE";
      this.gBtnDelete.UseVisualStyleBackColor = true;
      this.gBtnDelete.Click += new System.EventHandler(this.gBtnDelete_Click);
      // 
      // gBtnTemplate
      // 
      this.gBtnTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gBtnTemplate.Location = new System.Drawing.Point(6, 20);
      this.gBtnTemplate.Name = "gBtnTemplate";
      this.gBtnTemplate.Size = new System.Drawing.Size(96, 24);
      this.gBtnTemplate.TabIndex = 0;
      this.gBtnTemplate.Text = "TEMPLATE";
      this.gBtnTemplate.UseVisualStyleBackColor = true;
      this.gBtnTemplate.Click += new System.EventHandler(this.gBtnTemplate_Click);
      // 
      // gBtnUpdate
      // 
      this.gBtnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.gBtnUpdate.Location = new System.Drawing.Point(192, 20);
      this.gBtnUpdate.Name = "gBtnUpdate";
      this.gBtnUpdate.Size = new System.Drawing.Size(96, 24);
      this.gBtnUpdate.TabIndex = 0;
      this.gBtnUpdate.Text = "UPDATE";
      this.gBtnUpdate.UseVisualStyleBackColor = true;
      this.gBtnUpdate.Click += new System.EventHandler(this.gBtnUpdate_Click);
      // 
      // gTxtJson
      // 
      this.gTxtJson.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gTxtJson.Location = new System.Drawing.Point(0, 0);
      this.gTxtJson.Multiline = true;
      this.gTxtJson.Name = "gTxtJson";
      this.gTxtJson.PlaceholderText = "JSON";
      this.gTxtJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.gTxtJson.Size = new System.Drawing.Size(294, 542);
      this.gTxtJson.TabIndex = 3;
      this.gTxtJson.WordWrap = false;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.linkLabel2);
      this.groupBox2.Controls.Add(this.gCboProfile);
      this.groupBox2.Controls.Add(this.gTxtToken);
      this.groupBox2.Controls.Add(this.gTxtUrl);
      this.groupBox2.Controls.Add(this.gBtnRemberUrl);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.label5);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox2.Location = new System.Drawing.Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(1008, 119);
      this.groupBox2.TabIndex = 6;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Connection-Settings";
      this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
      // 
      // linkLabel2
      // 
      this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.Location = new System.Drawing.Point(902, 82);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new System.Drawing.Size(94, 15);
      this.linkLabel2.TabIndex = 5;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "https://orscf.org";
      this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      // 
      // gTxtToken
      // 
      this.gTxtToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gTxtToken.Location = new System.Drawing.Point(114, 79);
      this.gTxtToken.Name = "gTxtToken";
      this.gTxtToken.Size = new System.Drawing.Size(782, 23);
      this.gTxtToken.TabIndex = 4;
      this.gTxtToken.TextChanged += new System.EventHandler(this.gTxtToken_TextChanged);
      // 
      // gTxtUrl
      // 
      this.gTxtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gTxtUrl.Location = new System.Drawing.Point(114, 50);
      this.gTxtUrl.Name = "gTxtUrl";
      this.gTxtUrl.Size = new System.Drawing.Size(782, 23);
      this.gTxtUrl.TabIndex = 4;
      this.gTxtUrl.TextChanged += new System.EventHandler(this.gTxtUrl_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 82);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(105, 15);
      this.label4.TabIndex = 4;
      this.label4.Text = "API-Access-Token:";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 26);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(44, 15);
      this.label5.TabIndex = 4;
      this.label5.Text = "Profile:";
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1008, 661);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.groupBox2);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(550, 380);
      this.Name = "FormMain";
      this.Text = "ORSCF - \'VisitDataRepository\' (VDR) {V} - Testclient";
      this.Load += new System.EventHandler(this.FormMain_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gTable)).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button gBtnRemberUrl;
    private System.Windows.Forms.DataGridView gTable;
    private System.Windows.Forms.ComboBox gCboProfile;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TextBox gTxtPageSize;
    private System.Windows.Forms.TextBox gTxtPageNumber;
    private System.Windows.Forms.TextBox gTxtSort;
    private System.Windows.Forms.TextBox gTxtSearch;
    private System.Windows.Forms.Button gBtnLoad;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button gBtnSaveAsNew;
    private System.Windows.Forms.Button gBtnUpdate;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.LinkLabel linkLabel2;
    private System.Windows.Forms.DataGridView rid;
    private System.Windows.Forms.TextBox xt;
    private System.Windows.Forms.ComboBox gCboClass;
    private System.Windows.Forms.Button gBtnTemplate;
    private System.Windows.Forms.TextBox gTxtJson;
    private System.Windows.Forms.TextBox gTxtUrl;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox gTxtToken;
    private System.Windows.Forms.Button gBtnDelete;
  }
}

