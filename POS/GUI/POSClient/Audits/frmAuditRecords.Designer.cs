namespace POSClient
{
    partial class frmAuditRecords
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
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblEndDt = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.dtpStartDt = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dgvAuditRecords = new System.Windows.Forms.DataGridView();
            this.tlpShortCut = new System.Windows.Forms.TableLayoutPanel();
            this.btnSReset = new System.Windows.Forms.Button();
            this.btnSGetData = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditRecords)).BeginInit();
            this.tlpShortCut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 9;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.btnReset, 6, 1);
            this.tlpMain.Controls.Add(this.btnGetData, 5, 1);
            this.tlpMain.Controls.Add(this.lblEndDt, 3, 2);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dtpStartDt, 2, 2);
            this.tlpMain.Controls.Add(this.dtpEndDate, 4, 2);
            this.tlpMain.Controls.Add(this.lblStartDate, 1, 2);
            this.tlpMain.Controls.Add(this.dgvAuditRecords, 1, 5);
            this.tlpMain.Controls.Add(this.tlpShortCut, 1, 6);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(964, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnReset.Image = global::POSClient.Properties.Resources.refresh_24;
            this.btnReset.Location = new System.Drawing.Point(518, 43);
            this.btnReset.Name = "btnReset";
            this.tlpMain.SetRowSpan(this.btnReset, 3);
            this.btnReset.Size = new System.Drawing.Size(94, 34);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = " &Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.btnGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnGetData.Image = global::POSClient.Properties.Resources.getdata_24;
            this.btnGetData.Location = new System.Drawing.Point(418, 43);
            this.btnGetData.Name = "btnGetData";
            this.tlpMain.SetRowSpan(this.btnGetData, 3);
            this.btnGetData.Size = new System.Drawing.Size(94, 34);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = " &Get Data";
            this.btnGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblEndDt
            // 
            this.lblEndDt.AutoSize = true;
            this.lblEndDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndDt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEndDt.Location = new System.Drawing.Point(218, 47);
            this.lblEndDt.Name = "lblEndDt";
            this.lblEndDt.Size = new System.Drawing.Size(74, 30);
            this.lblEndDt.TabIndex = 3;
            this.lblEndDt.Text = "End Date";
            this.lblEndDt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 7);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(928, 34);
            this.btnHeader.TabIndex = 0;
            this.btnHeader.Text = "Audit Records";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // dtpStartDt
            // 
            this.dtpStartDt.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDt.CustomFormat = "dd-MM-yyyy";
            this.dtpStartDt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpStartDt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDt.Location = new System.Drawing.Point(98, 50);
            this.dtpStartDt.Name = "dtpStartDt";
            this.dtpStartDt.Size = new System.Drawing.Size(114, 25);
            this.dtpStartDt.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.CustomFormat = "dd-MM-yyyy";
            this.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(298, 50);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(114, 25);
            this.dtpEndDate.TabIndex = 4;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblStartDate.Location = new System.Drawing.Point(18, 47);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(74, 30);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "Start Date";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvAuditRecords
            // 
            this.dgvAuditRecords.AllowUserToAddRows = false;
            this.dgvAuditRecords.AllowUserToDeleteRows = false;
            this.dgvAuditRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvAuditRecords, 7);
            this.dgvAuditRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditRecords.Location = new System.Drawing.Point(18, 88);
            this.dgvAuditRecords.Name = "dgvAuditRecords";
            this.dgvAuditRecords.ReadOnly = true;
            this.dgvAuditRecords.Size = new System.Drawing.Size(928, 319);
            this.dgvAuditRecords.TabIndex = 7;
            // 
            // tlpShortCut
            // 
            this.tlpShortCut.ColumnCount = 4;
            this.tlpMain.SetColumnSpan(this.tlpShortCut, 6);
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpShortCut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortCut.Controls.Add(this.btnSReset, 2, 0);
            this.tlpShortCut.Controls.Add(this.btnSGetData, 0, 0);
            this.tlpShortCut.Controls.Add(this.lblShortcut, 0, 0);
            this.tlpShortCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortCut.Location = new System.Drawing.Point(18, 413);
            this.tlpShortCut.Name = "tlpShortCut";
            this.tlpShortCut.RowCount = 1;
            this.tlpShortCut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortCut.Size = new System.Drawing.Size(594, 34);
            this.tlpShortCut.TabIndex = 8;
            // 
            // btnSReset
            // 
            this.btnSReset.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSReset.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSReset.ForeColor = System.Drawing.Color.Navy;
            this.btnSReset.Location = new System.Drawing.Point(188, 3);
            this.btnSReset.Name = "btnSReset";
            this.btnSReset.Size = new System.Drawing.Size(114, 28);
            this.btnSReset.TabIndex = 51;
            this.btnSReset.Text = "Reset : Alt + R";
            this.btnSReset.UseVisualStyleBackColor = false;
            // 
            // btnSGetData
            // 
            this.btnSGetData.BackColor = System.Drawing.Color.MistyRose;
            this.btnSGetData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSGetData.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSGetData.ForeColor = System.Drawing.Color.Navy;
            this.btnSGetData.Location = new System.Drawing.Point(68, 3);
            this.btnSGetData.Name = "btnSGetData";
            this.btnSGetData.Size = new System.Drawing.Size(114, 28);
            this.btnSGetData.TabIndex = 50;
            this.btnSGetData.Text = "Get Data : Alt + G";
            this.btnSGetData.UseVisualStyleBackColor = false;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(59, 34);
            this.lblShortcut.TabIndex = 49;
            this.lblShortcut.Text = "Shortcut";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmAuditRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmAuditRecords";
            this.Text = "frmAuditRecords";
            this.Load += new System.EventHandler(this.frmAuditRecords_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAuditRecords_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditRecords)).EndInit();
            this.tlpShortCut.ResumeLayout(false);
            this.tlpShortCut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.DateTimePicker dtpStartDt;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDt;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvAuditRecords;
        private System.Windows.Forms.TableLayoutPanel tlpShortCut;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Button btnSReset;
        private System.Windows.Forms.Button btnSGetData;
    }
}