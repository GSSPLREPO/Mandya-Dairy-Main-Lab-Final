
namespace WeightBridgeMandya.clientui
{
    partial class OldData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OldData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.dtFromDate = new MetroFramework.Controls.MetroDateTime();
            this.dtToDate = new MetroFramework.Controls.MetroDateTime();
            this.btnGo = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.gvMainLab = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.MainLabAnalysisID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TankNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acidity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alcohol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Neutrilizer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Urea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Starch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FPD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvMainLab)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn2.DataPropertyName = "Delete";
            this.dataGridViewImageColumn2.FillWeight = 60F;
            this.dataGridViewImageColumn2.HeaderText = "Delete";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Edit";
            this.dataGridViewImageColumn1.FillWeight = 50F;
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 31;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(207, 23);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 161;
            this.metroLabel1.Text = "Tank No :";
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.CustomButton.Image = null;
            this.txtSearch.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtSearch.CustomButton.Name = "";
            this.txtSearch.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearch.CustomButton.TabIndex = 1;
            this.txtSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearch.CustomButton.UseSelectable = true;
            this.txtSearch.CustomButton.Visible = false;
            this.txtSearch.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(290, 18);
            this.txtSearch.MaxLength = 10;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(155, 29);
            this.txtSearch.TabIndex = 160;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1064, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 34);
            this.btnClose.TabIndex = 159;
            this.btnClose.Text = "Close";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(550, 18);
            this.dtFromDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(132, 29);
            this.dtFromDate.TabIndex = 163;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(727, 18);
            this.dtToDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(132, 29);
            this.dtToDate.TabIndex = 164;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(872, 15);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(57, 34);
            this.btnGo.TabIndex = 165;
            this.btnGo.Text = "Go";
            this.btnGo.UseSelectable = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(692, 23);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(29, 19);
            this.metroLabel2.TabIndex = 166;
            this.metroLabel2.Text = "To :";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(465, 23);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(79, 19);
            this.metroLabel3.TabIndex = 167;
            this.metroLabel3.Text = "Date From :";
            // 
            // gvMainLab
            // 
            this.gvMainLab.AllowUserToAddRows = false;
            this.gvMainLab.AllowUserToDeleteRows = false;
            this.gvMainLab.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMainLab.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvMainLab.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvMainLab.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gvMainLab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvMainLab.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(145)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(145)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMainLab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvMainLab.ColumnHeadersHeight = 42;
            this.gvMainLab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete,
            this.MainLabAnalysisID,
            this.DateTime,
            this.TankNo,
            this.BatchNo,
            this.Product,
            this.OT,
            this.Temp,
            this.Fat,
            this.SNF,
            this.Acidity,
            this.COB,
            this.Alcohol,
            this.Neutrilizer,
            this.Urea,
            this.Salt,
            this.Starch,
            this.FPD,
            this.Status});
            this.gvMainLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvMainLab.EnableHeadersVisualStyles = false;
            this.gvMainLab.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.gvMainLab.Location = new System.Drawing.Point(20, 60);
            this.gvMainLab.Name = "gvMainLab";
            this.gvMainLab.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvMainLab.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvMainLab.RowHeadersVisible = false;
            this.gvMainLab.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gvMainLab.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvMainLab.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gvMainLab.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.gvMainLab.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gvMainLab.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gvMainLab.ShowCellErrors = false;
            this.gvMainLab.Size = new System.Drawing.Size(1242, 463);
            this.gvMainLab.TabIndex = 168;
            this.gvMainLab.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMainLab_CellContentClick);
            // 
            // Edit
            // 
            this.Edit.DataPropertyName = "Edit";
            this.Edit.FillWeight = 46.66422F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Delete.DataPropertyName = "Delete";
            this.Delete.FillWeight = 70F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // MainLabAnalysisID
            // 
            this.MainLabAnalysisID.DataPropertyName = "ID";
            this.MainLabAnalysisID.HeaderText = "MainLabAnalysisID";
            this.MainLabAnalysisID.Name = "MainLabAnalysisID";
            this.MainLabAnalysisID.ReadOnly = true;
            this.MainLabAnalysisID.Visible = false;
            // 
            // DateTime
            // 
            this.DateTime.DataPropertyName = "DateTime";
            this.DateTime.FillWeight = 200F;
            this.DateTime.HeaderText = "DateTime";
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            // 
            // TankNo
            // 
            this.TankNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TankNo.DataPropertyName = "TankNo";
            this.TankNo.FillWeight = 120F;
            this.TankNo.HeaderText = "Tank No";
            this.TankNo.Name = "TankNo";
            this.TankNo.ReadOnly = true;
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.FillWeight = 110F;
            this.BatchNo.HeaderText = "Batch No";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product";
            this.Product.FillWeight = 250F;
            this.Product.HeaderText = "Product Name";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // OT
            // 
            this.OT.DataPropertyName = "OT";
            this.OT.FillWeight = 80F;
            this.OT.HeaderText = "OT";
            this.OT.Name = "OT";
            this.OT.ReadOnly = true;
            // 
            // Temp
            // 
            this.Temp.DataPropertyName = "Temp";
            this.Temp.FillWeight = 80F;
            this.Temp.HeaderText = "Temp \'C";
            this.Temp.Name = "Temp";
            this.Temp.ReadOnly = true;
            // 
            // Fat
            // 
            this.Fat.DataPropertyName = "Fat";
            this.Fat.FillWeight = 70F;
            this.Fat.HeaderText = "Fat %";
            this.Fat.Name = "Fat";
            this.Fat.ReadOnly = true;
            // 
            // SNF
            // 
            this.SNF.DataPropertyName = "SNF";
            this.SNF.FillWeight = 70F;
            this.SNF.HeaderText = "SNF %";
            this.SNF.Name = "SNF";
            this.SNF.ReadOnly = true;
            // 
            // Acidity
            // 
            this.Acidity.DataPropertyName = "Acidity";
            this.Acidity.HeaderText = "Acidity (%LA)";
            this.Acidity.Name = "Acidity";
            this.Acidity.ReadOnly = true;
            // 
            // COB
            // 
            this.COB.DataPropertyName = "COB";
            this.COB.FillWeight = 70F;
            this.COB.HeaderText = "COB";
            this.COB.Name = "COB";
            this.COB.ReadOnly = true;
            // 
            // Alcohol
            // 
            this.Alcohol.DataPropertyName = "Alcohol";
            this.Alcohol.FillWeight = 90F;
            this.Alcohol.HeaderText = "Alcohol Test";
            this.Alcohol.Name = "Alcohol";
            this.Alcohol.ReadOnly = true;
            // 
            // Neutrilizer
            // 
            this.Neutrilizer.DataPropertyName = "Neutrilizer";
            this.Neutrilizer.FillWeight = 110F;
            this.Neutrilizer.HeaderText = "Neutrilizer";
            this.Neutrilizer.Name = "Neutrilizer";
            this.Neutrilizer.ReadOnly = true;
            // 
            // Urea
            // 
            this.Urea.DataPropertyName = "Urea";
            this.Urea.FillWeight = 80F;
            this.Urea.HeaderText = "Urea";
            this.Urea.Name = "Urea";
            this.Urea.ReadOnly = true;
            // 
            // Salt
            // 
            this.Salt.DataPropertyName = "Salt";
            this.Salt.FillWeight = 80F;
            this.Salt.HeaderText = "Salt";
            this.Salt.Name = "Salt";
            this.Salt.ReadOnly = true;
            // 
            // Starch
            // 
            this.Starch.DataPropertyName = "Starch";
            this.Starch.FillWeight = 90F;
            this.Starch.HeaderText = "Starch";
            this.Starch.Name = "Starch";
            this.Starch.ReadOnly = true;
            // 
            // FPD
            // 
            this.FPD.DataPropertyName = "Fpd";
            this.FPD.FillWeight = 80F;
            this.FPD.HeaderText = "FPD";
            this.FPD.Name = "FPD";
            this.FPD.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.FillWeight = 150F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // OldData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 543);
            this.Controls.Add(this.gvMainLab);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OldData";
            this.Text = "Old Data";
            this.Load += new System.EventHandler(this.OldData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMainLab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtSearch;
        private MetroFramework.Controls.MetroButton btnClose;
        private MetroFramework.Controls.MetroDateTime dtFromDate;
        private MetroFramework.Controls.MetroDateTime dtToDate;
        private MetroFramework.Controls.MetroButton btnGo;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DataGridView gvMainLab;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainLabAnalysisID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TankNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn OT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acidity;
        private System.Windows.Forms.DataGridViewTextBoxColumn COB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alcohol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Neutrilizer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Urea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Starch;
        private System.Windows.Forms.DataGridViewTextBoxColumn FPD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}