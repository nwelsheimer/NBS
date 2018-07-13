namespace Open_Miracle
{
  partial class frmSites
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSites));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblGodownTypeValidator = new System.Windows.Forms.Label();
      this.btnClose = new System.Windows.Forms.Button();
      this.txtAddress = new System.Windows.Forms.TextBox();
      this.txtSiteName = new System.Windows.Forms.TextBox();
      this.lblNarration = new System.Windows.Forms.Label();
      this.btnDelete = new System.Windows.Forms.Button();
      this.lblGodownName = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.dgvSites = new System.Windows.Forms.DataGridView();
      this.chkManaged = new System.Windows.Forms.CheckBox();
      this.chkDflt = new System.Windows.Forms.CheckBox();
      this.dgvtxtslno = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvtxtSiteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvtxtSiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvSites)).BeginInit();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.Transparent;
      this.groupBox1.Controls.Add(this.chkDflt);
      this.groupBox1.Controls.Add(this.chkManaged);
      this.groupBox1.Controls.Add(this.lblGodownTypeValidator);
      this.groupBox1.Controls.Add(this.btnClose);
      this.groupBox1.Controls.Add(this.txtAddress);
      this.groupBox1.Controls.Add(this.txtSiteName);
      this.groupBox1.Controls.Add(this.lblNarration);
      this.groupBox1.Controls.Add(this.btnDelete);
      this.groupBox1.Controls.Add(this.lblGodownName);
      this.groupBox1.Controls.Add(this.btnSave);
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.ForeColor = System.Drawing.Color.Black;
      this.groupBox1.Location = new System.Drawing.Point(27, 20);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox1.Size = new System.Drawing.Size(1146, 225);
      this.groupBox1.TabIndex = 1146;
      this.groupBox1.TabStop = false;
      // 
      // lblGodownTypeValidator
      // 
      this.lblGodownTypeValidator.AutoSize = true;
      this.lblGodownTypeValidator.ForeColor = System.Drawing.Color.Red;
      this.lblGodownTypeValidator.Location = new System.Drawing.Point(498, 38);
      this.lblGodownTypeValidator.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.lblGodownTypeValidator.Name = "lblGodownTypeValidator";
      this.lblGodownTypeValidator.Size = new System.Drawing.Size(15, 20);
      this.lblGodownTypeValidator.TabIndex = 139;
      this.lblGodownTypeValidator.Text = "*";
      // 
      // btnClose
      // 
      this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
      this.btnClose.FlatAppearance.BorderSize = 0;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClose.ForeColor = System.Drawing.Color.Black;
      this.btnClose.Location = new System.Drawing.Point(982, 106);
      this.btnClose.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(128, 42);
      this.btnClose.TabIndex = 5;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // txtAddress
      // 
      this.txtAddress.Location = new System.Drawing.Point(195, 71);
      this.txtAddress.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.txtAddress.MaxLength = 5000;
      this.txtAddress.Multiline = true;
      this.txtAddress.Name = "txtAddress";
      this.txtAddress.Size = new System.Drawing.Size(298, 75);
      this.txtAddress.TabIndex = 1;
      this.txtAddress.Enter += new System.EventHandler(this.txtNarration_Enter);
      this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNarration_KeyDown);
      this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNarration_KeyPress);
      // 
      // txtSiteName
      // 
      this.txtSiteName.Location = new System.Drawing.Point(195, 32);
      this.txtSiteName.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.txtSiteName.Name = "txtSiteName";
      this.txtSiteName.Size = new System.Drawing.Size(298, 26);
      this.txtSiteName.TabIndex = 0;
      this.txtSiteName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGodownName_KeyDown);
      // 
      // lblNarration
      // 
      this.lblNarration.AutoSize = true;
      this.lblNarration.ForeColor = System.Drawing.Color.Black;
      this.lblNarration.Location = new System.Drawing.Point(22, 71);
      this.lblNarration.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.lblNarration.Name = "lblNarration";
      this.lblNarration.Size = new System.Drawing.Size(68, 20);
      this.lblNarration.TabIndex = 138;
      this.lblNarration.Text = "Address";
      // 
      // btnDelete
      // 
      this.btnDelete.BackColor = System.Drawing.Color.Salmon;
      this.btnDelete.FlatAppearance.BorderSize = 0;
      this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDelete.ForeColor = System.Drawing.Color.Black;
      this.btnDelete.Location = new System.Drawing.Point(846, 106);
      this.btnDelete.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(128, 42);
      this.btnDelete.TabIndex = 4;
      this.btnDelete.Text = "Delete";
      this.btnDelete.UseVisualStyleBackColor = false;
      this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
      // 
      // lblGodownName
      // 
      this.lblGodownName.AutoSize = true;
      this.lblGodownName.ForeColor = System.Drawing.Color.Black;
      this.lblGodownName.Location = new System.Drawing.Point(22, 38);
      this.lblGodownName.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.lblGodownName.Name = "lblGodownName";
      this.lblGodownName.Size = new System.Drawing.Size(83, 20);
      this.lblGodownName.TabIndex = 137;
      this.lblGodownName.Text = "Site Name";
      // 
      // btnSave
      // 
      this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
      this.btnSave.FlatAppearance.BorderSize = 0;
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.ForeColor = System.Drawing.Color.Black;
      this.btnSave.Location = new System.Drawing.Point(573, 106);
      this.btnSave.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(128, 42);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = false;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
      // 
      // btnClear
      // 
      this.btnClear.BackColor = System.Drawing.Color.LightSteelBlue;
      this.btnClear.FlatAppearance.BorderSize = 0;
      this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClear.ForeColor = System.Drawing.Color.Black;
      this.btnClear.Location = new System.Drawing.Point(710, 106);
      this.btnClear.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(128, 42);
      this.btnClear.TabIndex = 3;
      this.btnClear.Text = "Clear";
      this.btnClear.UseVisualStyleBackColor = false;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.BackColor = System.Drawing.Color.Transparent;
      this.groupBox2.Controls.Add(this.groupBox3);
      this.groupBox2.Controls.Add(this.dgvSites);
      this.groupBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox2.ForeColor = System.Drawing.Color.Maroon;
      this.groupBox2.Location = new System.Drawing.Point(27, 254);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox2.Size = new System.Drawing.Size(1146, 423);
      this.groupBox2.TabIndex = 1147;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "   Details";
      // 
      // groupBox3
      // 
      this.groupBox3.BackColor = System.Drawing.Color.Black;
      this.groupBox3.ForeColor = System.Drawing.Color.Black;
      this.groupBox3.Location = new System.Drawing.Point(28, 26);
      this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.groupBox3.Size = new System.Drawing.Size(105, 2);
      this.groupBox3.TabIndex = 9;
      this.groupBox3.TabStop = false;
      // 
      // dgvSites
      // 
      this.dgvSites.AllowUserToAddRows = false;
      this.dgvSites.AllowUserToDeleteRows = false;
      this.dgvSites.AllowUserToResizeColumns = false;
      this.dgvSites.AllowUserToResizeRows = false;
      this.dgvSites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvSites.BackgroundColor = System.Drawing.Color.White;
      this.dgvSites.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvSites.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.dgvSites.ColumnHeadersHeight = 25;
      this.dgvSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.dgvSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvtxtslno,
            this.dgvtxtSiteId,
            this.dgvtxtSiteName});
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon;
      dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
      dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvSites.DefaultCellStyle = dataGridViewCellStyle2;
      this.dgvSites.EnableHeadersVisualStyles = false;
      this.dgvSites.GridColor = System.Drawing.Color.DimGray;
      this.dgvSites.Location = new System.Drawing.Point(27, 38);
      this.dgvSites.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.dgvSites.MultiSelect = false;
      this.dgvSites.Name = "dgvSites";
      this.dgvSites.ReadOnly = true;
      this.dgvSites.RowHeadersVisible = false;
      this.dgvSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvSites.Size = new System.Drawing.Size(1092, 363);
      this.dgvSites.TabIndex = 8;
      this.dgvSites.TabStop = false;
      this.dgvSites.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGodown_CellDoubleClick);
      this.dgvSites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvGodown_KeyDown);
      this.dgvSites.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvGodown_KeyUp);
      // 
      // chkManaged
      // 
      this.chkManaged.AutoSize = true;
      this.chkManaged.Location = new System.Drawing.Point(195, 175);
      this.chkManaged.Name = "chkManaged";
      this.chkManaged.Size = new System.Drawing.Size(134, 24);
      this.chkManaged.TabIndex = 140;
      this.chkManaged.Text = "Managed Site";
      this.chkManaged.UseVisualStyleBackColor = true;
      // 
      // chkDflt
      // 
      this.chkDflt.AutoSize = true;
      this.chkDflt.Location = new System.Drawing.Point(380, 175);
      this.chkDflt.Name = "chkDflt";
      this.chkDflt.Size = new System.Drawing.Size(121, 24);
      this.chkDflt.TabIndex = 141;
      this.chkDflt.Text = "Default SIte";
      this.chkDflt.UseVisualStyleBackColor = true;
      // 
      // dgvtxtslno
      // 
      this.dgvtxtslno.DataPropertyName = "sl.no";
      this.dgvtxtslno.HeaderText = "Sl.No";
      this.dgvtxtslno.Name = "dgvtxtslno";
      this.dgvtxtslno.ReadOnly = true;
      this.dgvtxtslno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // dgvtxtSiteId
      // 
      this.dgvtxtSiteId.DataPropertyName = "siteId";
      this.dgvtxtSiteId.HeaderText = "Site ID";
      this.dgvtxtSiteId.Name = "dgvtxtSiteId";
      this.dgvtxtSiteId.ReadOnly = true;
      this.dgvtxtSiteId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.dgvtxtSiteId.Visible = false;
      // 
      // dgvtxtSiteName
      // 
      this.dgvtxtSiteName.DataPropertyName = "SiteName";
      this.dgvtxtSiteName.HeaderText = "Site Name";
      this.dgvtxtSiteName.Name = "dgvtxtSiteName";
      this.dgvtxtSiteName.ReadOnly = true;
      this.dgvtxtSiteName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      // 
      // frmSites
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Gainsboro;
      this.ClientSize = new System.Drawing.Size(1200, 697);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.ForeColor = System.Drawing.Color.Black;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.MaximizeBox = false;
      this.Name = "frmSites";
      this.Opacity = 0.85D;
      this.Padding = new System.Windows.Forms.Padding(22, 15, 22, 15);
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Sites";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGodown_FormClosing);
      this.Load += new System.EventHandler(this.frmGodown_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGodown_KeyDown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvSites)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label lblGodownTypeValidator;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.TextBox txtSiteName;
    private System.Windows.Forms.Label lblNarration;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Label lblGodownName;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.DataGridView dgvSites;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.CheckBox chkDflt;
    private System.Windows.Forms.CheckBox chkManaged;
    private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtslno;
    private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtSiteId;
    private System.Windows.Forms.DataGridViewTextBoxColumn dgvtxtSiteName;
  }
}