
namespace POSClient
{
    partial class frmInventory
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
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.btnHeader = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpShortcut = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lblShortcut2 = new System.Windows.Forms.Label();
            this.pnlNonMoving = new System.Windows.Forms.Panel();
            this.tlpNM = new System.Windows.Forms.TableLayoutPanel();
            this.txtNonMovingDays = new System.Windows.Forms.TextBox();
            this.btnNMReset = new System.Windows.Forms.Button();
            this.lblNonMoving = new System.Windows.Forms.Label();
            this.btnNMGetData = new System.Windows.Forms.Button();
            this.lblDays = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tlpFilter = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchArticeNo = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblFromDt = new System.Windows.Forms.Label();
            this.lblMaterialSearch = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lblToDt = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtpFromDt = new System.Windows.Forms.DateTimePicker();
            this.dtpToDt = new System.Windows.Forms.DateTimePicker();
            this.cmbArticleNo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.tlpShortcut.SuspendLayout();
            this.pnlNonMoving.SuspendLayout();
            this.tlpNM.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.tlpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvInventory, 7);
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventory.Location = new System.Drawing.Point(18, 126);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.Size = new System.Drawing.Size(1321, 279);
            this.dgvInventory.TabIndex = 25;
            this.dgvInventory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellDoubleClick);
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 7);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(1321, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Inventory";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 9;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 713F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpMain.Controls.Add(this.tlpShortcut, 1, 5);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dgvInventory, 1, 4);
            this.tlpMain.Controls.Add(this.pnlNonMoving, 5, 1);
            this.tlpMain.Controls.Add(this.btnExportExcel, 6, 2);
            this.tlpMain.Controls.Add(this.label1, 5, 5);
            this.tlpMain.Controls.Add(this.pnlFilter, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.Size = new System.Drawing.Size(1370, 458);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpShortcut
            // 
            this.tlpShortcut.ColumnCount = 7;
            this.tlpMain.SetColumnSpan(this.tlpShortcut, 4);
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Controls.Add(this.button2, 2, 0);
            this.tlpShortcut.Controls.Add(this.button1, 1, 0);
            this.tlpShortcut.Controls.Add(this.button3, 3, 0);
            this.tlpShortcut.Controls.Add(this.button4, 4, 0);
            this.tlpShortcut.Controls.Add(this.button5, 5, 0);
            this.tlpShortcut.Controls.Add(this.lblShortcut2, 0, 0);
            this.tlpShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortcut.Location = new System.Drawing.Point(18, 411);
            this.tlpShortcut.Name = "tlpShortcut";
            this.tlpShortcut.RowCount = 1;
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Size = new System.Drawing.Size(858, 39);
            this.tlpShortcut.TabIndex = 0;
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
            this.button2.Text = "Reset : Alt + R";
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
            this.button1.Text = "Get Data : Alt+ G";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Cornsilk;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Navy;
            this.button3.Location = new System.Drawing.Point(343, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 33);
            this.button3.TabIndex = 0;
            this.button3.Text = "Non Moving Get Data : Alt + D";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightCyan;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Navy;
            this.button4.Location = new System.Drawing.Point(523, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 33);
            this.button4.TabIndex = 0;
            this.button4.Text = "Non Moving Reset : Alt + S";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(233)))), ((int)(((byte)(210)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Navy;
            this.button5.Location = new System.Drawing.Point(693, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(164, 33);
            this.button5.TabIndex = 0;
            this.button5.Text = "Export Excel : Alt + E";
            this.button5.UseVisualStyleBackColor = false;
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
            // pnlNonMoving
            // 
            this.pnlNonMoving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNonMoving.Controls.Add(this.tlpNM);
            this.pnlNonMoving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNonMoving.Location = new System.Drawing.Point(882, 43);
            this.pnlNonMoving.Name = "pnlNonMoving";
            this.tlpMain.SetRowSpan(this.pnlNonMoving, 2);
            this.pnlNonMoving.Size = new System.Drawing.Size(281, 72);
            this.pnlNonMoving.TabIndex = 17;
            // 
            // tlpNM
            // 
            this.tlpNM.ColumnCount = 4;
            this.tlpNM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpNM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.69534F));
            this.tlpNM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.76702F));
            this.tlpNM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpNM.Controls.Add(this.txtNonMovingDays, 0, 2);
            this.tlpNM.Controls.Add(this.btnNMReset, 3, 1);
            this.tlpNM.Controls.Add(this.lblNonMoving, 0, 0);
            this.tlpNM.Controls.Add(this.btnNMGetData, 2, 1);
            this.tlpNM.Controls.Add(this.lblDays, 1, 2);
            this.tlpNM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpNM.Location = new System.Drawing.Point(0, 0);
            this.tlpNM.Name = "tlpNM";
            this.tlpNM.RowCount = 4;
            this.tlpNM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpNM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpNM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpNM.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpNM.Size = new System.Drawing.Size(279, 70);
            this.tlpNM.TabIndex = 18;
            // 
            // txtNonMovingDays
            // 
            this.txtNonMovingDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNonMovingDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNonMovingDays.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNonMovingDays.Location = new System.Drawing.Point(3, 40);
            this.txtNonMovingDays.MaxLength = 5;
            this.txtNonMovingDays.Name = "txtNonMovingDays";
            this.txtNonMovingDays.Size = new System.Drawing.Size(50, 25);
            this.txtNonMovingDays.TabIndex = 20;
            this.txtNonMovingDays.Text = "30";
            this.txtNonMovingDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNonMovingDays_KeyPress);
            // 
            // btnNMReset
            // 
            this.btnNMReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnNMReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNMReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNMReset.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNMReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnNMReset.Image = global::POSClient.Properties.Resources.refresh_24;
            this.btnNMReset.Location = new System.Drawing.Point(197, 33);
            this.btnNMReset.Name = "btnNMReset";
            this.tlpNM.SetRowSpan(this.btnNMReset, 3);
            this.btnNMReset.Size = new System.Drawing.Size(79, 34);
            this.btnNMReset.TabIndex = 23;
            this.btnNMReset.Text = " Re&set";
            this.btnNMReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNMReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNMReset.UseVisualStyleBackColor = false;
            this.btnNMReset.Click += new System.EventHandler(this.btnNMReset_Click);
            // 
            // lblNonMoving
            // 
            this.lblNonMoving.AutoSize = true;
            this.tlpNM.SetColumnSpan(this.lblNonMoving, 2);
            this.lblNonMoving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNonMoving.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNonMoving.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNonMoving.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNonMoving.Location = new System.Drawing.Point(3, 0);
            this.lblNonMoving.Name = "lblNonMoving";
            this.tlpNM.SetRowSpan(this.lblNonMoving, 2);
            this.lblNonMoving.Size = new System.Drawing.Size(91, 37);
            this.lblNonMoving.TabIndex = 19;
            this.lblNonMoving.Text = "Non Moving";
            this.lblNonMoving.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnNMGetData
            // 
            this.btnNMGetData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnNMGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNMGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNMGetData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNMGetData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnNMGetData.Image = global::POSClient.Properties.Resources.getdata_24;
            this.btnNMGetData.Location = new System.Drawing.Point(100, 33);
            this.btnNMGetData.Name = "btnNMGetData";
            this.tlpNM.SetRowSpan(this.btnNMGetData, 3);
            this.btnNMGetData.Size = new System.Drawing.Size(91, 34);
            this.btnNMGetData.TabIndex = 22;
            this.btnNMGetData.Text = " Get &Data";
            this.btnNMGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNMGetData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNMGetData.UseVisualStyleBackColor = false;
            this.btnNMGetData.Click += new System.EventHandler(this.btnNMGetData_Click);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDays.Location = new System.Drawing.Point(59, 37);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(35, 30);
            this.lblDays.TabIndex = 21;
            this.lblDays.Text = "Days";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnExportExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnExportExcel.Image = global::POSClient.Properties.Resources.export_xls_24;
            this.btnExportExcel.Location = new System.Drawing.Point(1169, 78);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(110, 37);
            this.btnExportExcel.TabIndex = 24;
            this.btnExportExcel.Text = " &Export Excel";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tlpMain.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(37)))), ((int)(((byte)(62)))));
            this.label1.Location = new System.Drawing.Point(882, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Note : Double-click on the \"Available Stock\" cell to view the stock details.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.pnlFilter, 4);
            this.pnlFilter.Controls.Add(this.tlpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(18, 43);
            this.pnlFilter.Name = "pnlFilter";
            this.tlpMain.SetRowSpan(this.pnlFilter, 2);
            this.pnlFilter.Size = new System.Drawing.Size(858, 72);
            this.pnlFilter.TabIndex = 3;
            // 
            // tlpFilter
            // 
            this.tlpFilter.ColumnCount = 7;
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.85082F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.80186F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.03496F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.70396F));
            this.tlpFilter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.82051F));
            this.tlpFilter.Controls.Add(this.lblSearchArticeNo, 2, 0);
            this.tlpFilter.Controls.Add(this.cmbSupplier, 0, 2);
            this.tlpFilter.Controls.Add(this.cmbMaterial, 1, 2);
            this.tlpFilter.Controls.Add(this.lblSupplier, 0, 0);
            this.tlpFilter.Controls.Add(this.lblFromDt, 3, 0);
            this.tlpFilter.Controls.Add(this.lblMaterialSearch, 1, 0);
            this.tlpFilter.Controls.Add(this.btnFilter, 5, 1);
            this.tlpFilter.Controls.Add(this.lblToDt, 4, 0);
            this.tlpFilter.Controls.Add(this.btnReset, 6, 1);
            this.tlpFilter.Controls.Add(this.dtpFromDt, 3, 2);
            this.tlpFilter.Controls.Add(this.dtpToDt, 4, 2);
            this.tlpFilter.Controls.Add(this.cmbArticleNo, 2, 2);
            this.tlpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpFilter.Location = new System.Drawing.Point(0, 0);
            this.tlpFilter.Name = "tlpFilter";
            this.tlpFilter.RowCount = 4;
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFilter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpFilter.Size = new System.Drawing.Size(856, 70);
            this.tlpFilter.TabIndex = 4;
            // 
            // lblSearchArticeNo
            // 
            this.lblSearchArticeNo.AutoSize = true;
            this.lblSearchArticeNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearchArticeNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchArticeNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSearchArticeNo.Location = new System.Drawing.Point(247, 0);
            this.lblSearchArticeNo.Name = "lblSearchArticeNo";
            this.tlpFilter.SetRowSpan(this.lblSearchArticeNo, 2);
            this.lblSearchArticeNo.Size = new System.Drawing.Size(129, 37);
            this.lblSearchArticeNo.TabIndex = 9;
            this.lblSearchArticeNo.Text = "Search By Article No. ";
            this.lblSearchArticeNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSupplier.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(3, 40);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(116, 25);
            this.cmbSupplier.TabIndex = 6;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(125, 40);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(116, 25);
            this.cmbMaterial.TabIndex = 8;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSupplier.Location = new System.Drawing.Point(3, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.tlpFilter.SetRowSpan(this.lblSupplier, 2);
            this.lblSupplier.Size = new System.Drawing.Size(116, 37);
            this.lblSupplier.TabIndex = 5;
            this.lblSupplier.Text = "Search By Supplier";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblFromDt
            // 
            this.lblFromDt.AutoSize = true;
            this.lblFromDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromDt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFromDt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFromDt.Location = new System.Drawing.Point(382, 0);
            this.lblFromDt.Name = "lblFromDt";
            this.tlpFilter.SetRowSpan(this.lblFromDt, 2);
            this.lblFromDt.Size = new System.Drawing.Size(120, 37);
            this.lblFromDt.TabIndex = 11;
            this.lblFromDt.Text = "Purchase From Date";
            this.lblFromDt.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblMaterialSearch
            // 
            this.lblMaterialSearch.AutoSize = true;
            this.lblMaterialSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaterialSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMaterialSearch.Location = new System.Drawing.Point(125, 0);
            this.lblMaterialSearch.Name = "lblMaterialSearch";
            this.tlpFilter.SetRowSpan(this.lblMaterialSearch, 2);
            this.lblMaterialSearch.Size = new System.Drawing.Size(116, 37);
            this.lblMaterialSearch.TabIndex = 7;
            this.lblMaterialSearch.Text = "Search By Material";
            this.lblMaterialSearch.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnFilter.Image = global::POSClient.Properties.Resources.getdata_24;
            this.btnFilter.Location = new System.Drawing.Point(636, 33);
            this.btnFilter.Name = "btnFilter";
            this.tlpFilter.SetRowSpan(this.btnFilter, 3);
            this.btnFilter.Size = new System.Drawing.Size(102, 34);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = " &Get Data";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblToDt
            // 
            this.lblToDt.AutoSize = true;
            this.lblToDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToDt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblToDt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblToDt.Location = new System.Drawing.Point(508, 0);
            this.lblToDt.Name = "lblToDt";
            this.tlpFilter.SetRowSpan(this.lblToDt, 2);
            this.lblToDt.Size = new System.Drawing.Size(122, 37);
            this.lblToDt.TabIndex = 13;
            this.lblToDt.Text = "Purchase To Date";
            this.lblToDt.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnReset.Image = global::POSClient.Properties.Resources.refresh_24;
            this.btnReset.Location = new System.Drawing.Point(744, 33);
            this.btnReset.Name = "btnReset";
            this.tlpFilter.SetRowSpan(this.btnReset, 3);
            this.btnReset.Size = new System.Drawing.Size(109, 34);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = " &Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtpFromDt
            // 
            this.dtpFromDt.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFromDt.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDt.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFromDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDt.Location = new System.Drawing.Point(382, 40);
            this.dtpFromDt.Name = "dtpFromDt";
            this.dtpFromDt.Size = new System.Drawing.Size(120, 25);
            this.dtpFromDt.TabIndex = 12;
            // 
            // dtpToDt
            // 
            this.dtpToDt.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpToDt.CustomFormat = "dd-MM-yyyy";
            this.dtpToDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpToDt.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpToDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDt.Location = new System.Drawing.Point(508, 40);
            this.dtpToDt.Name = "dtpToDt";
            this.dtpToDt.Size = new System.Drawing.Size(122, 25);
            this.dtpToDt.TabIndex = 14;
            // 
            // cmbArticleNo
            // 
            this.cmbArticleNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbArticleNo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbArticleNo.FormattingEnabled = true;
            this.cmbArticleNo.ItemHeight = 17;
            this.cmbArticleNo.Location = new System.Drawing.Point(247, 40);
            this.cmbArticleNo.Name = "cmbArticleNo";
            this.cmbArticleNo.Size = new System.Drawing.Size(129, 25);
            this.cmbArticleNo.TabIndex = 10;
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 458);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmInventory";
            this.Text = "frmInventory";
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInventory_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpShortcut.ResumeLayout(false);
            this.tlpShortcut.PerformLayout();
            this.pnlNonMoving.ResumeLayout(false);
            this.tlpNM.ResumeLayout(false);
            this.tlpNM.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.tlpFilter.ResumeLayout(false);
            this.tlpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblFromDt;
        private System.Windows.Forms.Label lblToDt;
        private System.Windows.Forms.DateTimePicker dtpFromDt;
        private System.Windows.Forms.DateTimePicker dtpToDt;
        private System.Windows.Forms.Panel pnlNonMoving;
        private System.Windows.Forms.TableLayoutPanel tlpNM;
        private System.Windows.Forms.TextBox txtNonMovingDays;
        private System.Windows.Forms.Button btnNMReset;
        private System.Windows.Forms.Label lblNonMoving;
        private System.Windows.Forms.Button btnNMGetData;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label lblMaterialSearch;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TableLayoutPanel tlpFilter;
        private System.Windows.Forms.TableLayoutPanel tlpShortcut;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label lblShortcut2;
        private System.Windows.Forms.Label lblSearchArticeNo;
        private System.Windows.Forms.ComboBox cmbArticleNo;
    }
}