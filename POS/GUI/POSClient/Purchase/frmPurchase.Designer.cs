
namespace POSClient
{
    partial class frmPurchase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase));
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtGSTNo = new System.Windows.Forms.TextBox();
            this.lblGSTINNo = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.lblSGST = new System.Windows.Forms.Label();
            this.lblCGST = new System.Windows.Forms.Label();
            this.lblIGST = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtRoundOff = new System.Windows.Forms.TextBox();
            this.lblRoundOff = new System.Windows.Forms.Label();
            this.txtTD = new System.Windows.Forms.TextBox();
            this.lblTD = new System.Windows.Forms.Label();
            this.txtPurchaseNo = new System.Windows.Forms.TextBox();
            this.lblPurchaseNo = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.dgvPurchaseItems = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbMaterialCell = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ArticleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbUOMCell = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.HSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDiscTypeCell = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Disc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GSTRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.txtTotalItems = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblPaymentDueDate = new System.Windows.Forms.Label();
            this.dtpPaymentDueDate = new System.Windows.Forms.DateTimePicker();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tlpOptButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdatePayment = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblGSTAmount = new System.Windows.Forms.Label();
            this.txtGSTAmount = new System.Windows.Forms.TextBox();
            this.tlpShortCut = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblShortcut2 = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItems)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.tlpOptButton.SuspendLayout();
            this.tlpShortCut.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRemarks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRemarks.Location = new System.Drawing.Point(18, 100);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(114, 31);
            this.lblRemarks.TabIndex = 16;
            this.lblRemarks.Text = "Remarks";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGSTNo
            // 
            this.txtGSTNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGSTNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGSTNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGSTNo.Location = new System.Drawing.Point(573, 73);
            this.txtGSTNo.MaxLength = 20;
            this.txtGSTNo.Name = "txtGSTNo";
            this.txtGSTNo.Size = new System.Drawing.Size(156, 25);
            this.txtGSTNo.TabIndex = 11;
            // 
            // lblGSTINNo
            // 
            this.lblGSTINNo.AutoSize = true;
            this.lblGSTINNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGSTINNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGSTINNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGSTINNo.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblGSTINNo.Location = new System.Drawing.Point(498, 70);
            this.lblGSTINNo.Name = "lblGSTINNo";
            this.lblGSTINNo.Size = new System.Drawing.Size(69, 30);
            this.lblGSTINNo.TabIndex = 10;
            this.lblGSTINNo.Text = "GSTIN No.";
            this.lblGSTINNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 14);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(113)))), ((int)(((byte)(202)))));
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1454, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Purchase";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(348, 73);
            this.txtInvoiceNo.MaxLength = 100;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(144, 25);
            this.txtInvoiceNo.TabIndex = 9;
            this.txtInvoiceNo.Leave += new System.EventHandler(this.txtInvoiceNo_Leave);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.CustomFormat = "dd-MM-yyyy";
            this.dtpInvoiceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(138, 73);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(114, 25);
            this.dtpInvoiceDate.TabIndex = 7;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvoiceDate.Location = new System.Drawing.Point(18, 70);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(114, 30);
            this.lblInvoiceDate.TabIndex = 6;
            this.lblInvoiceDate.Text = "Invoice Date";
            this.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.BackColor = System.Drawing.SystemColors.Window;
            this.tlpMain.SetColumnSpan(this.cmbSupplier, 10);
            this.cmbSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.IntegralHeight = false;
            this.cmbSupplier.Location = new System.Drawing.Point(348, 43);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(989, 25);
            this.cmbSupplier.TabIndex = 5;
            this.cmbSupplier.SelectedIndexChanged += new System.EventHandler(this.cmbSupplier_SelectedIndexChanged);
            this.cmbSupplier.TextChanged += new System.EventHandler(this.cmbSupplier_TextChanged);
            this.cmbSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSupplier_KeyDown);
            this.cmbSupplier.Leave += new System.EventHandler(this.cmbSupplier_Leave);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSupplier.Location = new System.Drawing.Point(258, 40);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(84, 30);
            this.lblSupplier.TabIndex = 4;
            this.lblSupplier.Text = "Supplier *";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInvoiceNo.Location = new System.Drawing.Point(258, 70);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(84, 30);
            this.lblInvoiceNo.TabIndex = 8;
            this.lblInvoiceNo.Text = "Invoice No. *";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.txtRemarks, 12);
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRemarks.Location = new System.Drawing.Point(138, 103);
            this.txtRemarks.MaxLength = 200;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(1199, 25);
            this.txtRemarks.TabIndex = 17;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 16;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.txtSGST, 13, 10);
            this.tlpMain.Controls.Add(this.txtCGST, 13, 9);
            this.tlpMain.Controls.Add(this.txtIGST, 13, 8);
            this.tlpMain.Controls.Add(this.lblSGST, 12, 10);
            this.tlpMain.Controls.Add(this.lblCGST, 12, 9);
            this.tlpMain.Controls.Add(this.lblIGST, 12, 8);
            this.tlpMain.Controls.Add(this.txtState, 10, 2);
            this.tlpMain.Controls.Add(this.txtCity, 8, 2);
            this.tlpMain.Controls.Add(this.lblState, 9, 2);
            this.tlpMain.Controls.Add(this.lblCity, 7, 2);
            this.tlpMain.Controls.Add(this.txtRoundOff, 13, 11);
            this.tlpMain.Controls.Add(this.lblRoundOff, 12, 11);
            this.tlpMain.Controls.Add(this.txtTD, 13, 7);
            this.tlpMain.Controls.Add(this.lblTD, 12, 7);
            this.tlpMain.Controls.Add(this.txtPurchaseNo, 2, 1);
            this.tlpMain.Controls.Add(this.lblPurchaseNo, 1, 1);
            this.tlpMain.Controls.Add(this.txtNetAmount, 13, 12);
            this.tlpMain.Controls.Add(this.lblNetAmount, 12, 12);
            this.tlpMain.Controls.Add(this.txtTotalAmount, 13, 6);
            this.tlpMain.Controls.Add(this.txtRemarks, 2, 3);
            this.tlpMain.Controls.Add(this.lblInvoiceNo, 3, 2);
            this.tlpMain.Controls.Add(this.lblSupplier, 3, 1);
            this.tlpMain.Controls.Add(this.cmbSupplier, 4, 1);
            this.tlpMain.Controls.Add(this.lblInvoiceDate, 1, 2);
            this.tlpMain.Controls.Add(this.dtpInvoiceDate, 2, 2);
            this.tlpMain.Controls.Add(this.txtInvoiceNo, 4, 2);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.lblGSTINNo, 5, 2);
            this.tlpMain.Controls.Add(this.txtGSTNo, 6, 2);
            this.tlpMain.Controls.Add(this.lblRemarks, 1, 3);
            this.tlpMain.Controls.Add(this.dgvPurchaseItems, 1, 5);
            this.tlpMain.Controls.Add(this.lblTotalItems, 1, 6);
            this.tlpMain.Controls.Add(this.txtTotalItems, 2, 6);
            this.tlpMain.Controls.Add(this.lblTotalAmount, 12, 6);
            this.tlpMain.Controls.Add(this.lblPaymentDueDate, 1, 7);
            this.tlpMain.Controls.Add(this.dtpPaymentDueDate, 2, 7);
            this.tlpMain.Controls.Add(this.pnlButtons, 14, 1);
            this.tlpMain.Controls.Add(this.lblGSTAmount, 8, 6);
            this.tlpMain.Controls.Add(this.txtGSTAmount, 10, 6);
            this.tlpMain.Controls.Add(this.tlpShortCut, 1, 13);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 14;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.Size = new System.Drawing.Size(1490, 534);
            this.tlpMain.TabIndex = 0;
            // 
            // txtSGST
            // 
            this.txtSGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSGST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSGST.Enabled = false;
            this.txtSGST.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtSGST.Location = new System.Drawing.Point(1193, 402);
            this.txtSGST.MaxLength = 18;
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(144, 23);
            this.txtSGST.TabIndex = 28;
            this.txtSGST.Text = "0.00";
            // 
            // txtCGST
            // 
            this.txtCGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCGST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCGST.Enabled = false;
            this.txtCGST.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtCGST.Location = new System.Drawing.Point(1193, 372);
            this.txtCGST.MaxLength = 18;
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.Size = new System.Drawing.Size(144, 23);
            this.txtCGST.TabIndex = 26;
            this.txtCGST.Text = "0.00";
            // 
            // txtIGST
            // 
            this.txtIGST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIGST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIGST.Enabled = false;
            this.txtIGST.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIGST.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtIGST.Location = new System.Drawing.Point(1193, 342);
            this.txtIGST.MaxLength = 18;
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.Size = new System.Drawing.Size(144, 23);
            this.txtIGST.TabIndex = 24;
            this.txtIGST.Text = "0.00";
            // 
            // lblSGST
            // 
            this.lblSGST.AutoSize = true;
            this.lblSGST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSGST.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSGST.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSGST.Location = new System.Drawing.Point(1085, 399);
            this.lblSGST.Name = "lblSGST";
            this.lblSGST.Size = new System.Drawing.Size(102, 30);
            this.lblSGST.TabIndex = 27;
            this.lblSGST.Text = "SGST (₹)";
            this.lblSGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCGST
            // 
            this.lblCGST.AutoSize = true;
            this.lblCGST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCGST.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCGST.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCGST.Location = new System.Drawing.Point(1085, 369);
            this.lblCGST.Name = "lblCGST";
            this.lblCGST.Size = new System.Drawing.Size(102, 30);
            this.lblCGST.TabIndex = 25;
            this.lblCGST.Text = "CGST (₹)";
            this.lblCGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIGST
            // 
            this.lblIGST.AutoSize = true;
            this.lblIGST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIGST.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIGST.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIGST.Location = new System.Drawing.Point(1085, 339);
            this.lblIGST.Name = "lblIGST";
            this.lblIGST.Size = new System.Drawing.Size(102, 30);
            this.lblIGST.TabIndex = 23;
            this.lblIGST.Text = "IGST (₹)";
            this.lblIGST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtState
            // 
            this.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtState.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtState.Location = new System.Drawing.Point(960, 73);
            this.txtState.MaxLength = 50;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(124, 25);
            this.txtState.TabIndex = 15;
            // 
            // txtCity
            // 
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtCity.Location = new System.Drawing.Point(785, 73);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(119, 25);
            this.txtCity.TabIndex = 13;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblState.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblState.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblState.Location = new System.Drawing.Point(910, 70);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(44, 30);
            this.lblState.TabIndex = 14;
            this.lblState.Text = "State";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCity.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCity.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblCity.Location = new System.Drawing.Point(735, 70);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(44, 30);
            this.lblCity.TabIndex = 12;
            this.lblCity.Text = "City";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRoundOff
            // 
            this.txtRoundOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoundOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRoundOff.Enabled = false;
            this.txtRoundOff.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoundOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtRoundOff.Location = new System.Drawing.Point(1193, 432);
            this.txtRoundOff.MaxLength = 18;
            this.txtRoundOff.Name = "txtRoundOff";
            this.txtRoundOff.Size = new System.Drawing.Size(144, 23);
            this.txtRoundOff.TabIndex = 30;
            this.txtRoundOff.Text = "0.00";
            // 
            // lblRoundOff
            // 
            this.lblRoundOff.AutoSize = true;
            this.lblRoundOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRoundOff.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoundOff.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblRoundOff.Location = new System.Drawing.Point(1085, 429);
            this.lblRoundOff.Name = "lblRoundOff";
            this.lblRoundOff.Size = new System.Drawing.Size(102, 30);
            this.lblRoundOff.TabIndex = 29;
            this.lblRoundOff.Text = "Round Off (₹)";
            this.lblRoundOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTD
            // 
            this.txtTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtTD.Location = new System.Drawing.Point(1193, 312);
            this.txtTD.MaxLength = 18;
            this.txtTD.Name = "txtTD";
            this.txtTD.Size = new System.Drawing.Size(144, 23);
            this.txtTD.TabIndex = 22;
            this.txtTD.Text = "0.00";
            this.txtTD.TextChanged += new System.EventHandler(this.txtTD_TextChanged);
            this.txtTD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTD_KeyPress);
            // 
            // lblTD
            // 
            this.lblTD.AutoSize = true;
            this.lblTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTD.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTD.Location = new System.Drawing.Point(1085, 309);
            this.lblTD.Name = "lblTD";
            this.lblTD.Size = new System.Drawing.Size(102, 30);
            this.lblTD.TabIndex = 21;
            this.lblTD.Text = "( - ) T. D. (₹)";
            this.lblTD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPurchaseNo
            // 
            this.txtPurchaseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPurchaseNo.Enabled = false;
            this.txtPurchaseNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseNo.Location = new System.Drawing.Point(138, 43);
            this.txtPurchaseNo.Name = "txtPurchaseNo";
            this.txtPurchaseNo.Size = new System.Drawing.Size(114, 25);
            this.txtPurchaseNo.TabIndex = 3;
            // 
            // lblPurchaseNo
            // 
            this.lblPurchaseNo.AutoSize = true;
            this.lblPurchaseNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPurchaseNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchaseNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPurchaseNo.Location = new System.Drawing.Point(18, 40);
            this.lblPurchaseNo.Name = "lblPurchaseNo";
            this.lblPurchaseNo.Size = new System.Drawing.Size(114, 30);
            this.lblPurchaseNo.TabIndex = 2;
            this.lblPurchaseNo.Text = "Purchase No.";
            this.lblPurchaseNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNetAmount.Enabled = false;
            this.txtNetAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtNetAmount.Location = new System.Drawing.Point(1193, 462);
            this.txtNetAmount.MaxLength = 18;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(144, 23);
            this.txtNetAmount.TabIndex = 32;
            this.txtNetAmount.Text = "0.00";
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.AutoSize = true;
            this.lblNetAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNetAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNetAmount.Location = new System.Drawing.Point(1085, 459);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(102, 30);
            this.lblNetAmount.TabIndex = 31;
            this.lblNetAmount.Text = "Net Amount (₹)";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtTotalAmount.Location = new System.Drawing.Point(1193, 282);
            this.txtTotalAmount.MaxLength = 18;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(144, 23);
            this.txtTotalAmount.TabIndex = 20;
            this.txtTotalAmount.Text = "0.00";
            // 
            // dgvPurchaseItems
            // 
            this.dgvPurchaseItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchaseItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.cmbMaterialCell,
            this.ArticleNo,
            this.Classification,
            this.Size,
            this.Color,
            this.Qty,
            this.cmbUOMCell,
            this.HSN,
            this.MRP,
            this.Rate,
            this.cmbDiscTypeCell,
            this.Disc,
            this.NetRate,
            this.NetAmount,
            this.GSTRate});
            this.tlpMain.SetColumnSpan(this.dgvPurchaseItems, 13);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchaseItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseItems.EnableHeadersVisualStyles = false;
            this.dgvPurchaseItems.Location = new System.Drawing.Point(18, 139);
            this.dgvPurchaseItems.Name = "dgvPurchaseItems";
            this.dgvPurchaseItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPurchaseItems.RowHeadersVisible = false;
            this.dgvPurchaseItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPurchaseItems.Size = new System.Drawing.Size(1319, 137);
            this.dgvPurchaseItems.TabIndex = 18;
            this.dgvPurchaseItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseItems_CellContentClick);
            this.dgvPurchaseItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseItems_CellEndEdit);
            this.dgvPurchaseItems.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseItems_CellValidated);
            this.dgvPurchaseItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPurchaseItems_CellValidating);
            this.dgvPurchaseItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseItems_CellValueChanged);
            this.dgvPurchaseItems.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvPurchaseItems_DefaultValuesNeeded);
            this.dgvPurchaseItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPurchaseItems_EditingControlShowing);
            this.dgvPurchaseItems.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPurchaseItems_RowPostPaint);
            this.dgvPurchaseItems.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvPurchaseItems_RowsAdded);
            this.dgvPurchaseItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPurchaseItems_RowsRemoved);
            this.dgvPurchaseItems.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseItems_RowValidated);
            this.dgvPurchaseItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPurchaseItems_KeyDown);
            // 
            // SrNo
            // 
            this.SrNo.HeaderText = "Sr. No.";
            this.SrNo.Name = "SrNo";
            this.SrNo.ReadOnly = true;
            this.SrNo.Width = 55;
            // 
            // cmbMaterialCell
            // 
            this.cmbMaterialCell.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cmbMaterialCell.HeaderText = "Material";
            this.cmbMaterialCell.Name = "cmbMaterialCell";
            this.cmbMaterialCell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbMaterialCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmbMaterialCell.Width = 153;
            // 
            // ArticleNo
            // 
            this.ArticleNo.HeaderText = "Article No";
            this.ArticleNo.MaxInputLength = 15;
            this.ArticleNo.Name = "ArticleNo";
            // 
            // Classification
            // 
            this.Classification.HeaderText = "Classification";
            this.Classification.MaxInputLength = 100;
            this.Classification.Name = "Classification";
            this.Classification.Width = 140;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.MaxInputLength = 6;
            this.Size.Name = "Size";
            this.Size.Width = 60;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.MaxInputLength = 50;
            this.Color.Name = "Color";
            this.Color.Width = 90;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty.";
            this.Qty.Name = "Qty";
            this.Qty.Width = 50;
            // 
            // cmbUOMCell
            // 
            this.cmbUOMCell.HeaderText = "UOM";
            this.cmbUOMCell.Name = "cmbUOMCell";
            this.cmbUOMCell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbUOMCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // HSN
            // 
            this.HSN.HeaderText = "HSN";
            this.HSN.MaxInputLength = 10;
            this.HSN.Name = "HSN";
            this.HSN.Width = 70;
            // 
            // MRP
            // 
            this.MRP.HeaderText = "MRP (₹)";
            this.MRP.Name = "MRP";
            this.MRP.Width = 85;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate (₹)";
            this.Rate.Name = "Rate";
            this.Rate.Width = 85;
            // 
            // cmbDiscTypeCell
            // 
            this.cmbDiscTypeCell.HeaderText = "Disc. Type";
            this.cmbDiscTypeCell.Name = "cmbDiscTypeCell";
            // 
            // Disc
            // 
            this.Disc.HeaderText = "Disc.";
            this.Disc.Name = "Disc";
            this.Disc.Width = 60;
            // 
            // NetRate
            // 
            this.NetRate.HeaderText = "Net Rate (₹)";
            this.NetRate.Name = "NetRate";
            this.NetRate.Width = 90;
            // 
            // NetAmount
            // 
            this.NetAmount.HeaderText = "Net Amount (₹)";
            this.NetAmount.Name = "NetAmount";
            this.NetAmount.ReadOnly = true;
            // 
            // GSTRate
            // 
            this.GSTRate.HeaderText = "GST Rate (%)";
            this.GSTRate.Name = "GSTRate";
            this.GSTRate.Width = 90;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalItems.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotalItems.Location = new System.Drawing.Point(18, 279);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(114, 30);
            this.lblTotalItems.TabIndex = 35;
            this.lblTotalItems.Text = "Total Items : ";
            this.lblTotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalItems.Enabled = false;
            this.txtTotalItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtTotalItems.Location = new System.Drawing.Point(138, 282);
            this.txtTotalItems.MaxLength = 5;
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Size = new System.Drawing.Size(114, 23);
            this.txtTotalItems.TabIndex = 36;
            this.txtTotalItems.Text = "0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTotalAmount.Location = new System.Drawing.Point(1085, 279);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(102, 30);
            this.lblTotalAmount.TabIndex = 19;
            this.lblTotalAmount.Text = "Total Amount (₹)";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaymentDueDate
            // 
            this.lblPaymentDueDate.AutoSize = true;
            this.lblPaymentDueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPaymentDueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaymentDueDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPaymentDueDate.Location = new System.Drawing.Point(18, 309);
            this.lblPaymentDueDate.Name = "lblPaymentDueDate";
            this.lblPaymentDueDate.Size = new System.Drawing.Size(114, 30);
            this.lblPaymentDueDate.TabIndex = 37;
            this.lblPaymentDueDate.Text = "Payment Due Date";
            this.lblPaymentDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPaymentDueDate
            // 
            this.dtpPaymentDueDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDueDate.CustomFormat = "dd-MM-yyyy";
            this.dtpPaymentDueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPaymentDueDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDueDate.Location = new System.Drawing.Point(138, 312);
            this.dtpPaymentDueDate.Name = "dtpPaymentDueDate";
            this.dtpPaymentDueDate.Size = new System.Drawing.Size(114, 25);
            this.dtpPaymentDueDate.TabIndex = 38;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtons.Controls.Add(this.tlpOptButton);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(1343, 43);
            this.pnlButtons.Name = "pnlButtons";
            this.tlpMain.SetRowSpan(this.pnlButtons, 13);
            this.pnlButtons.Size = new System.Drawing.Size(129, 488);
            this.pnlButtons.TabIndex = 39;
            // 
            // tlpOptButton
            // 
            this.tlpOptButton.ColumnCount = 1;
            this.tlpOptButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptButton.Controls.Add(this.btnUpdatePayment, 0, 3);
            this.tlpOptButton.Controls.Add(this.btnSupplier, 0, 4);
            this.tlpOptButton.Controls.Add(this.btnCancel, 0, 1);
            this.tlpOptButton.Controls.Add(this.btnView, 0, 2);
            this.tlpOptButton.Controls.Add(this.btnSave, 0, 0);
            this.tlpOptButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOptButton.Location = new System.Drawing.Point(0, 0);
            this.tlpOptButton.Name = "tlpOptButton";
            this.tlpOptButton.RowCount = 6;
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpOptButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOptButton.Size = new System.Drawing.Size(127, 486);
            this.tlpOptButton.TabIndex = 40;
            // 
            // btnUpdatePayment
            // 
            this.btnUpdatePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnUpdatePayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdatePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdatePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePayment.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePayment.Image = global::POSClient.Properties.Resources.voucher_24;
            this.btnUpdatePayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePayment.Location = new System.Drawing.Point(3, 123);
            this.btnUpdatePayment.Name = "btnUpdatePayment";
            this.btnUpdatePayment.Size = new System.Drawing.Size(121, 34);
            this.btnUpdatePayment.TabIndex = 44;
            this.btnUpdatePayment.Text = "&Payment Status";
            this.btnUpdatePayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdatePayment.UseVisualStyleBackColor = false;
            this.btnUpdatePayment.Click += new System.EventHandler(this.btnUpdatePayment_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSupplier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Image = global::POSClient.Properties.Resources.supplier_24;
            this.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplier.Location = new System.Drawing.Point(3, 163);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(121, 34);
            this.btnSupplier.TabIndex = 45;
            this.btnSupplier.Text = "&Supplier";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Image = global::POSClient.Properties.Resources.cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(3, 43);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 34);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Image = global::POSClient.Properties.Resources.view_24;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(3, 83);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(121, 34);
            this.btnView.TabIndex = 43;
            this.btnView.Text = "&View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::POSClient.Properties.Resources.save_24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 34);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblGSTAmount
            // 
            this.lblGSTAmount.AutoSize = true;
            this.lblGSTAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGSTAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGSTAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGSTAmount.Location = new System.Drawing.Point(785, 279);
            this.lblGSTAmount.Name = "lblGSTAmount";
            this.lblGSTAmount.Size = new System.Drawing.Size(119, 30);
            this.lblGSTAmount.TabIndex = 33;
            this.lblGSTAmount.Text = "GST Amount (₹)";
            this.lblGSTAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGSTAmount.Visible = false;
            // 
            // txtGSTAmount
            // 
            this.txtGSTAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGSTAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGSTAmount.Enabled = false;
            this.txtGSTAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGSTAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.txtGSTAmount.Location = new System.Drawing.Point(960, 282);
            this.txtGSTAmount.MaxLength = 18;
            this.txtGSTAmount.Name = "txtGSTAmount";
            this.txtGSTAmount.Size = new System.Drawing.Size(124, 23);
            this.txtGSTAmount.TabIndex = 34;
            this.txtGSTAmount.Text = "0.00";
            this.txtGSTAmount.Visible = false;
            // 
            // tlpShortCut
            // 
            this.tlpShortCut.ColumnCount = 7;
            this.tlpMain.SetColumnSpan(this.tlpShortCut, 8);
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortCut.Controls.Add(this.button5, 5, 0);
            this.tlpShortCut.Controls.Add(this.button4, 4, 0);
            this.tlpShortCut.Controls.Add(this.button3, 3, 0);
            this.tlpShortCut.Controls.Add(this.button2, 2, 0);
            this.tlpShortCut.Controls.Add(this.button1, 1, 0);
            this.tlpShortCut.Controls.Add(this.lblShortcut2, 0, 0);
            this.tlpShortCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortCut.Location = new System.Drawing.Point(18, 492);
            this.tlpShortCut.Name = "tlpShortCut";
            this.tlpShortCut.RowCount = 1;
            this.tlpShortCut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortCut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpShortCut.Size = new System.Drawing.Size(886, 39);
            this.tlpShortCut.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(233)))), ((int)(((byte)(210)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Navy;
            this.button5.Location = new System.Drawing.Point(623, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 33);
            this.button5.TabIndex = 0;
            this.button5.Text = "Payment Status : Alt + P";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightCyan;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Navy;
            this.button4.Location = new System.Drawing.Point(483, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 33);
            this.button4.TabIndex = 0;
            this.button4.Text = "Supplier : Alt + S";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Cornsilk;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(343, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 33);
            this.button3.TabIndex = 0;
            this.button3.Text = "View : Alt + V";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PeachPuff;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(203, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 33);
            this.button2.TabIndex = 0;
            this.button2.Text = "Cancel : Alt + C";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(63, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save : Ctrl + S";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblShortcut2
            // 
            this.lblShortcut2.AutoSize = true;
            this.lblShortcut2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut2.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut2.Name = "lblShortcut2";
            this.lblShortcut2.Size = new System.Drawing.Size(54, 39);
            this.lblShortcut2.TabIndex = 0;
            this.lblShortcut2.Text = "Shortcut";
            this.lblShortcut2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1490, 534);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPurchase";
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPurchase_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseItems)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.tlpOptButton.ResumeLayout(false);
            this.tlpShortCut.ResumeLayout(false);
            this.tlpShortCut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtGSTNo;
        private System.Windows.Forms.Label lblGSTINNo;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.DataGridView dgvPurchaseItems;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.TextBox txtTotalItems;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtGSTAmount;
        private System.Windows.Forms.Label lblGSTAmount;
        private System.Windows.Forms.Label lblNetAmount;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label lblPaymentDueDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDueDate;
        private System.Windows.Forms.Label lblPurchaseNo;
        private System.Windows.Forms.TextBox txtPurchaseNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtTD;
        private System.Windows.Forms.Label lblTD;
        private System.Windows.Forms.TextBox txtRoundOff;
        private System.Windows.Forms.Label lblRoundOff;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.TableLayoutPanel tlpOptButton;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblSGST;
        private System.Windows.Forms.Label lblCGST;
        private System.Windows.Forms.Label lblIGST;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.TextBox txtCGST;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.Button btnUpdatePayment;
        private System.Windows.Forms.TableLayoutPanel tlpShortCut;
        private System.Windows.Forms.Label lblShortcut2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbMaterialCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbUOMCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbDiscTypeCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GSTRate;
    }
}