
namespace POSClient
{
    partial class frmReport
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblReportName = new System.Windows.Forms.Label();
            this.lblReportCategory = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.cmbReportName = new System.Windows.Forms.ComboBox();
            this.cmbReportCategory = new System.Windows.Forms.ComboBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblArticleNo = new System.Windows.Forms.Label();
            this.cmbArticleNo = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblSalesThreshold = new System.Windows.Forms.Label();
            this.txtSalesThreshold = new System.Windows.Forms.TextBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.rptReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblNotes = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 12;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.btnPreview, 10, 2);
            this.tlpMain.Controls.Add(this.lblReportName, 2, 1);
            this.tlpMain.Controls.Add(this.lblReportCategory, 1, 1);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dtpToDate, 4, 3);
            this.tlpMain.Controls.Add(this.lblToDate, 4, 1);
            this.tlpMain.Controls.Add(this.lblFromDate, 3, 1);
            this.tlpMain.Controls.Add(this.cmbReportName, 2, 3);
            this.tlpMain.Controls.Add(this.cmbReportCategory, 1, 3);
            this.tlpMain.Controls.Add(this.dtpFromDate, 3, 3);
            this.tlpMain.Controls.Add(this.lblMaterial, 5, 1);
            this.tlpMain.Controls.Add(this.cmbMaterial, 5, 3);
            this.tlpMain.Controls.Add(this.lblArticleNo, 6, 1);
            this.tlpMain.Controls.Add(this.cmbArticleNo, 6, 3);
            this.tlpMain.Controls.Add(this.lblSupplier, 7, 1);
            this.tlpMain.Controls.Add(this.cmbSupplier, 7, 3);
            this.tlpMain.Controls.Add(this.lblSalesThreshold, 8, 1);
            this.tlpMain.Controls.Add(this.txtSalesThreshold, 8, 3);
            this.tlpMain.Controls.Add(this.lblDays, 9, 1);
            this.tlpMain.Controls.Add(this.txtDays, 9, 3);
            this.tlpMain.Controls.Add(this.rptReportViewer, 1, 7);
            this.tlpMain.Controls.Add(this.lblNotes, 1, 5);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 12;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1530, 443);
            this.tlpMain.TabIndex = 1;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnPreview.Image = global::POSClient.Properties.Resources.preview_24;
            this.btnPreview.Location = new System.Drawing.Point(1414, 73);
            this.btnPreview.Name = "btnPreview";
            this.tlpMain.SetRowSpan(this.btnPreview, 3);
            this.btnPreview.Size = new System.Drawing.Size(98, 34);
            this.btnPreview.TabIndex = 24;
            this.btnPreview.Text = " &Preview";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReportName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblReportName.Location = new System.Drawing.Point(208, 40);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(144, 30);
            this.lblReportName.TabIndex = 27;
            this.lblReportName.Text = "Name";
            this.lblReportName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblReportCategory
            // 
            this.lblReportCategory.AutoSize = true;
            this.lblReportCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReportCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportCategory.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblReportCategory.Location = new System.Drawing.Point(18, 40);
            this.lblReportCategory.Name = "lblReportCategory";
            this.lblReportCategory.Size = new System.Drawing.Size(184, 30);
            this.lblReportCategory.TabIndex = 26;
            this.lblReportCategory.Text = "Category";
            this.lblReportCategory.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 10);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1494, 34);
            this.btnHeader.TabIndex = 25;
            this.btnHeader.Text = "Reports";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dtpToDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(508, 80);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(144, 23);
            this.dtpToDate.TabIndex = 13;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblToDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblToDate.Location = new System.Drawing.Point(508, 40);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(144, 30);
            this.lblToDate.TabIndex = 10;
            this.lblToDate.Text = "To Date";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromDate.Location = new System.Drawing.Point(358, 40);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(144, 30);
            this.lblFromDate.TabIndex = 9;
            this.lblFromDate.Text = "From Date";
            this.lblFromDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbReportName
            // 
            this.cmbReportName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbReportName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportName.FormattingEnabled = true;
            this.cmbReportName.Location = new System.Drawing.Point(208, 80);
            this.cmbReportName.Name = "cmbReportName";
            this.cmbReportName.Size = new System.Drawing.Size(144, 25);
            this.cmbReportName.TabIndex = 8;
            this.cmbReportName.SelectedIndexChanged += new System.EventHandler(this.cmbReportName_SelectedIndexChanged);
            // 
            // cmbReportCategory
            // 
            this.cmbReportCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbReportCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportCategory.FormattingEnabled = true;
            this.cmbReportCategory.Location = new System.Drawing.Point(18, 80);
            this.cmbReportCategory.Name = "cmbReportCategory";
            this.cmbReportCategory.Size = new System.Drawing.Size(184, 25);
            this.cmbReportCategory.TabIndex = 6;
            this.cmbReportCategory.SelectedIndexChanged += new System.EventHandler(this.cmbReportCategory_SelectedIndexChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dtpFromDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(358, 80);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(144, 23);
            this.dtpFromDate.TabIndex = 12;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMaterial.Location = new System.Drawing.Point(658, 40);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(144, 30);
            this.lblMaterial.TabIndex = 14;
            this.lblMaterial.Text = "Material";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(658, 80);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(144, 25);
            this.cmbMaterial.TabIndex = 17;
            // 
            // lblArticleNo
            // 
            this.lblArticleNo.AutoSize = true;
            this.lblArticleNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArticleNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblArticleNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblArticleNo.Location = new System.Drawing.Point(808, 40);
            this.lblArticleNo.Name = "lblArticleNo";
            this.lblArticleNo.Size = new System.Drawing.Size(150, 30);
            this.lblArticleNo.TabIndex = 15;
            this.lblArticleNo.Text = "Article No.";
            this.lblArticleNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbArticleNo
            // 
            this.cmbArticleNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbArticleNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbArticleNo.FormattingEnabled = true;
            this.cmbArticleNo.Location = new System.Drawing.Point(808, 80);
            this.cmbArticleNo.Name = "cmbArticleNo";
            this.cmbArticleNo.Size = new System.Drawing.Size(150, 25);
            this.cmbArticleNo.TabIndex = 18;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSupplier.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSupplier.Location = new System.Drawing.Point(964, 40);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(144, 30);
            this.lblSupplier.TabIndex = 16;
            this.lblSupplier.Text = "Supplier";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(964, 80);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(144, 25);
            this.cmbSupplier.TabIndex = 19;
            // 
            // lblSalesThreshold
            // 
            this.lblSalesThreshold.AutoSize = true;
            this.lblSalesThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSalesThreshold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSalesThreshold.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSalesThreshold.Location = new System.Drawing.Point(1114, 40);
            this.lblSalesThreshold.Name = "lblSalesThreshold";
            this.lblSalesThreshold.Size = new System.Drawing.Size(144, 30);
            this.lblSalesThreshold.TabIndex = 20;
            this.lblSalesThreshold.Text = "Threshold";
            this.lblSalesThreshold.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtSalesThreshold
            // 
            this.txtSalesThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSalesThreshold.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSalesThreshold.Location = new System.Drawing.Point(1114, 80);
            this.txtSalesThreshold.MaxLength = 10;
            this.txtSalesThreshold.Name = "txtSalesThreshold";
            this.txtSalesThreshold.Size = new System.Drawing.Size(144, 25);
            this.txtSalesThreshold.TabIndex = 22;
            this.txtSalesThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesThreshold_KeyPress);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDays.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDays.Location = new System.Drawing.Point(1264, 40);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(144, 30);
            this.lblDays.TabIndex = 21;
            this.lblDays.Text = "Evaluation Period";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDays
            // 
            this.txtDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDays.Location = new System.Drawing.Point(1264, 80);
            this.txtDays.MaxLength = 10;
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(144, 25);
            this.txtDays.TabIndex = 23;
            this.txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDays_KeyPress);
            // 
            // rptReportViewer
            // 
            this.tlpMain.SetColumnSpan(this.rptReportViewer, 10);
            this.rptReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptReportViewer.Location = new System.Drawing.Point(18, 152);
            this.rptReportViewer.Name = "rptReportViewer";
            this.tlpMain.SetRowSpan(this.rptReportViewer, 5);
            this.rptReportViewer.ServerReport.BearerToken = null;
            this.rptReportViewer.Size = new System.Drawing.Size(1494, 288);
            this.rptReportViewer.TabIndex = 29;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.lblNotes, 6);
            this.lblNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.ForeColor = System.Drawing.Color.DarkRed;
            this.lblNotes.Location = new System.Drawing.Point(18, 110);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(940, 30);
            this.lblNotes.TabIndex = 30;
            this.lblNotes.Text = "Note: Evaluation Period: Based on the last X days of sales activity. Threshold: I" +
    "tems that sold Y units or fewer in this time are flagged as slow-moving.";
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1530, 443);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmReport";
            this.Text = "frmReport";
            this.Load += new System.EventHandler(this.frmReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReport_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ComboBox cmbReportCategory;
        private System.Windows.Forms.ComboBox cmbReportName;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblArticleNo;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.ComboBox cmbArticleNo;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblSalesThreshold;
        private System.Windows.Forms.TextBox txtSalesThreshold;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.Label lblReportCategory;
        private System.Windows.Forms.Button btnHeader;
        private Microsoft.Reporting.WinForms.ReportViewer rptReportViewer;
        private System.Windows.Forms.Label lblNotes;
    }
}