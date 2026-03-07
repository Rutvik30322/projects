namespace POSClient
{
    partial class frmSalesView
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
            this.btnReset = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.dgvViewSales = new System.Windows.Forms.DataGridView();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.lblFromDt = new System.Windows.Forms.Label();
            this.lblToDt = new System.Windows.Forms.Label();
            this.dtpFromDt = new System.Windows.Forms.DateTimePicker();
            this.dtpToDt = new System.Windows.Forms.DateTimePicker();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.tlpSalesSummary = new System.Windows.Forms.TableLayoutPanel();
            this.btnTotalInvoice = new System.Windows.Forms.Button();
            this.btnTotalSaleQty = new System.Windows.Forms.Button();
            this.btnTotalSaleAmount = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.tlpShortcut = new System.Windows.Forms.TableLayoutPanel();
            this.btnSExportExcel = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSAdd = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewSales)).BeginInit();
            this.tlpSalesSummary.SuspendLayout();
            this.tlpShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 15;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.btnReset, 11, 1);
            this.tlpMain.Controls.Add(this.txtCustomerName, 8, 2);
            this.tlpMain.Controls.Add(this.dgvViewSales, 1, 4);
            this.tlpMain.Controls.Add(this.btnGetData, 11, 1);
            this.tlpMain.Controls.Add(this.cmbMaterial, 6, 2);
            this.tlpMain.Controls.Add(this.lblMaterial, 5, 2);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.lblFromDt, 1, 2);
            this.tlpMain.Controls.Add(this.lblToDt, 3, 2);
            this.tlpMain.Controls.Add(this.dtpFromDt, 2, 2);
            this.tlpMain.Controls.Add(this.dtpToDt, 4, 2);
            this.tlpMain.Controls.Add(this.lblMobileNo, 9, 2);
            this.tlpMain.Controls.Add(this.txtMobileNo, 10, 2);
            this.tlpMain.Controls.Add(this.lblCustomerName, 7, 2);
            this.tlpMain.Controls.Add(this.tlpSalesSummary, 8, 5);
            this.tlpMain.Controls.Add(this.btnExport, 13, 1);
            this.tlpMain.Controls.Add(this.tlpShortcut, 1, 5);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.Size = new System.Drawing.Size(1445, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnReset.Image = global::POSClient.Properties.Resources.refresh_24;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(1197, 43);
            this.btnReset.Name = "btnReset";
            this.tlpMain.SetRowSpan(this.btnReset, 3);
            this.btnReset.Size = new System.Drawing.Size(114, 34);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = " &Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCustomerName.Location = new System.Drawing.Point(627, 50);
            this.txtCustomerName.MaxLength = 500;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(244, 25);
            this.txtCustomerName.TabIndex = 9;
            // 
            // dgvViewSales
            // 
            this.dgvViewSales.AllowUserToAddRows = false;
            this.dgvViewSales.AllowUserToDeleteRows = false;
            this.dgvViewSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvViewSales, 13);
            this.dgvViewSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvViewSales.Location = new System.Drawing.Point(18, 83);
            this.dgvViewSales.Name = "dgvViewSales";
            this.dgvViewSales.ReadOnly = true;
            this.dgvViewSales.Size = new System.Drawing.Size(1409, 314);
            this.dgvViewSales.TabIndex = 15;
            this.dgvViewSales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewSales_CellClick);
            this.dgvViewSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewSales_CellContentClick);
            this.dgvViewSales.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewSales_CellMouseEnter);
            this.dgvViewSales.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvViewSales_CellPainting);
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnGetData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnGetData.Image = global::POSClient.Properties.Resources.getdata_24;
            this.btnGetData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetData.Location = new System.Drawing.Point(1077, 43);
            this.btnGetData.Name = "btnGetData";
            this.tlpMain.SetRowSpan(this.btnGetData, 3);
            this.btnGetData.Size = new System.Drawing.Size(114, 34);
            this.btnGetData.TabIndex = 12;
            this.btnGetData.Text = " &Get Data";
            this.btnGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(427, 50);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(134, 25);
            this.cmbMaterial.TabIndex = 7;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaterial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMaterial.Location = new System.Drawing.Point(347, 47);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(74, 30);
            this.lblMaterial.TabIndex = 6;
            this.lblMaterial.Text = "Material";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tlpMain.SetColumnSpan(this.btnHeader, 13);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1409, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Sales View";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // lblFromDt
            // 
            this.lblFromDt.AutoSize = true;
            this.lblFromDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromDt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFromDt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromDt.Location = new System.Drawing.Point(18, 47);
            this.lblFromDt.Name = "lblFromDt";
            this.lblFromDt.Size = new System.Drawing.Size(74, 30);
            this.lblFromDt.TabIndex = 2;
            this.lblFromDt.Text = "From Date";
            this.lblFromDt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblToDt
            // 
            this.lblToDt.AutoSize = true;
            this.lblToDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToDt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblToDt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblToDt.Location = new System.Drawing.Point(190, 47);
            this.lblToDt.Name = "lblToDt";
            this.lblToDt.Size = new System.Drawing.Size(59, 30);
            this.lblToDt.TabIndex = 4;
            this.lblToDt.Text = "To Date";
            this.lblToDt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFromDt
            // 
            this.dtpFromDt.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFromDt.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFromDt.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFromDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDt.Location = new System.Drawing.Point(98, 50);
            this.dtpFromDt.Name = "dtpFromDt";
            this.dtpFromDt.Size = new System.Drawing.Size(86, 25);
            this.dtpFromDt.TabIndex = 3;
            // 
            // dtpToDt
            // 
            this.dtpToDt.CustomFormat = "dd-MM-yyyy";
            this.dtpToDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpToDt.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpToDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDt.Location = new System.Drawing.Point(255, 50);
            this.dtpToDt.Name = "dtpToDt";
            this.dtpToDt.Size = new System.Drawing.Size(86, 25);
            this.dtpToDt.TabIndex = 5;
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMobileNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobileNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMobileNo.Location = new System.Drawing.Point(877, 47);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(74, 30);
            this.lblMobileNo.TabIndex = 10;
            this.lblMobileNo.Text = "Mobile No.";
            this.lblMobileNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobileNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMobileNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMobileNo.Location = new System.Drawing.Point(957, 50);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(114, 25);
            this.txtMobileNo.TabIndex = 11;
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobileNo_KeyPress);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCustomerName.Location = new System.Drawing.Point(567, 47);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(54, 30);
            this.lblCustomerName.TabIndex = 8;
            this.lblCustomerName.Text = "Name";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpSalesSummary
            // 
            this.tlpSalesSummary.ColumnCount = 3;
            this.tlpMain.SetColumnSpan(this.tlpSalesSummary, 6);
            this.tlpSalesSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSalesSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpSalesSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpSalesSummary.Controls.Add(this.btnTotalInvoice, 0, 0);
            this.tlpSalesSummary.Controls.Add(this.btnTotalSaleQty, 1, 0);
            this.tlpSalesSummary.Controls.Add(this.btnTotalSaleAmount, 2, 0);
            this.tlpSalesSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSalesSummary.Location = new System.Drawing.Point(627, 403);
            this.tlpSalesSummary.Name = "tlpSalesSummary";
            this.tlpSalesSummary.RowCount = 1;
            this.tlpSalesSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSalesSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSalesSummary.Size = new System.Drawing.Size(800, 39);
            this.tlpSalesSummary.TabIndex = 45;
            // 
            // btnTotalInvoice
            // 
            this.btnTotalInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(180)))), ((int)(((byte)(199)))));
            this.btnTotalInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalInvoice.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTotalInvoice.ForeColor = System.Drawing.Color.Black;
            this.btnTotalInvoice.Location = new System.Drawing.Point(3, 3);
            this.btnTotalInvoice.Name = "btnTotalInvoice";
            this.btnTotalInvoice.Size = new System.Drawing.Size(260, 33);
            this.btnTotalInvoice.TabIndex = 18;
            this.btnTotalInvoice.UseVisualStyleBackColor = false;
            this.btnTotalInvoice.Visible = false;
            // 
            // btnTotalSaleQty
            // 
            this.btnTotalSaleQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(217)))), ((int)(((byte)(221)))));
            this.btnTotalSaleQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalSaleQty.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTotalSaleQty.ForeColor = System.Drawing.Color.Black;
            this.btnTotalSaleQty.Location = new System.Drawing.Point(269, 3);
            this.btnTotalSaleQty.Name = "btnTotalSaleQty";
            this.btnTotalSaleQty.Size = new System.Drawing.Size(260, 33);
            this.btnTotalSaleQty.TabIndex = 19;
            this.btnTotalSaleQty.UseVisualStyleBackColor = false;
            this.btnTotalSaleQty.Visible = false;
            // 
            // btnTotalSaleAmount
            // 
            this.btnTotalSaleAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(229)))), ((int)(((byte)(213)))));
            this.btnTotalSaleAmount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTotalSaleAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotalSaleAmount.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTotalSaleAmount.ForeColor = System.Drawing.Color.Black;
            this.btnTotalSaleAmount.Location = new System.Drawing.Point(535, 3);
            this.btnTotalSaleAmount.Name = "btnTotalSaleAmount";
            this.btnTotalSaleAmount.Size = new System.Drawing.Size(262, 33);
            this.btnTotalSaleAmount.TabIndex = 20;
            this.btnTotalSaleAmount.UseVisualStyleBackColor = false;
            this.btnTotalSaleAmount.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnExport.Image = global::POSClient.Properties.Resources.export_xls_24;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(1317, 43);
            this.btnExport.Name = "btnExport";
            this.tlpMain.SetRowSpan(this.btnExport, 3);
            this.btnExport.Size = new System.Drawing.Size(110, 34);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = " &Export Excel";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tlpShortcut
            // 
            this.tlpShortcut.ColumnCount = 5;
            this.tlpMain.SetColumnSpan(this.tlpShortcut, 6);
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Controls.Add(this.btnSExportExcel, 3, 0);
            this.tlpShortcut.Controls.Add(this.lblShortcut, 0, 0);
            this.tlpShortcut.Controls.Add(this.btnSAdd, 2, 0);
            this.tlpShortcut.Controls.Add(this.button1, 1, 0);
            this.tlpShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortcut.Location = new System.Drawing.Point(18, 403);
            this.tlpShortcut.Name = "tlpShortcut";
            this.tlpShortcut.RowCount = 1;
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Size = new System.Drawing.Size(543, 39);
            this.tlpShortcut.TabIndex = 0;
            // 
            // btnSExportExcel
            // 
            this.btnSExportExcel.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSExportExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSExportExcel.ForeColor = System.Drawing.Color.Navy;
            this.btnSExportExcel.Location = new System.Drawing.Point(328, 3);
            this.btnSExportExcel.Name = "btnSExportExcel";
            this.btnSExportExcel.Size = new System.Drawing.Size(124, 33);
            this.btnSExportExcel.TabIndex = 0;
            this.btnSExportExcel.Text = "Export Excel : Alt + E";
            this.btnSExportExcel.UseVisualStyleBackColor = false;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(59, 39);
            this.lblShortcut.TabIndex = 0;
            this.lblShortcut.Text = "Shortcut";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(68, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Data : Alt + G";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnSAdd
            // 
            this.btnSAdd.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnSAdd.Location = new System.Drawing.Point(198, 3);
            this.btnSAdd.Name = "btnSAdd";
            this.btnSAdd.Size = new System.Drawing.Size(124, 33);
            this.btnSAdd.TabIndex = 0;
            this.btnSAdd.Text = "Reset : Alt + R";
            this.btnSAdd.UseVisualStyleBackColor = false;
            // 
            // frmSalesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmSalesView";
            this.Text = "View Sales";
            this.Load += new System.EventHandler(this.frmSalesView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSalesView_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewSales)).EndInit();
            this.tlpSalesSummary.ResumeLayout(false);
            this.tlpShortcut.ResumeLayout(false);
            this.tlpShortcut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.Label lblToDt;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.DateTimePicker dtpFromDt;
        private System.Windows.Forms.DateTimePicker dtpToDt;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.DataGridView dgvViewSales;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblFromDt;
        private System.Windows.Forms.Button btnTotalInvoice;
        private System.Windows.Forms.Button btnTotalSaleQty;
        private System.Windows.Forms.Button btnTotalSaleAmount;
        private System.Windows.Forms.TableLayoutPanel tlpSalesSummary;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TableLayoutPanel tlpShortcut;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSAdd;
        private System.Windows.Forms.Button btnSExportExcel;
    }
}