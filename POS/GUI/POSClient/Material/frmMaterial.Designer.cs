
using System.Drawing;
using System.Windows.Forms;

namespace POSClient
{
    partial class frmMaterial
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
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Text = "frmMaterial";
        //}

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;

        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtMinLevel = new System.Windows.Forms.TextBox();
            this.lblMinLevel = new System.Windows.Forms.Label();
            this.btnHeader = new System.Windows.Forms.Button();
            this.lblGroupCode = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGrpCode = new System.Windows.Forms.TextBox();
            this.txtGrpName = new System.Windows.Forms.TextBox();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.tlpCrudButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSEdit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            this.tlpCrudButton.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 8;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.txtMinLevel, 4, 2);
            this.tlpMain.Controls.Add(this.lblMinLevel, 4, 1);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.lblGroupCode, 1, 1);
            this.tlpMain.Controls.Add(this.lblGroupName, 2, 1);
            this.tlpMain.Controls.Add(this.txtGrpCode, 1, 2);
            this.tlpMain.Controls.Add(this.txtGrpName, 2, 2);
            this.tlpMain.Controls.Add(this.dgvMaterial, 1, 4);
            this.tlpMain.Controls.Add(this.tlpCrudButton, 5, 1);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 1, 5);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(999, 526);
            this.tlpMain.TabIndex = 0;
            // 
            // txtMinLevel
            // 
            this.txtMinLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMinLevel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMinLevel.Location = new System.Drawing.Point(588, 73);
            this.txtMinLevel.MaxLength = 10;
            this.txtMinLevel.Name = "txtMinLevel";
            this.txtMinLevel.Size = new System.Drawing.Size(94, 25);
            this.txtMinLevel.TabIndex = 6;
            this.txtMinLevel.Text = "0.00";
            // 
            // lblMinLevel
            // 
            this.lblMinLevel.AutoSize = true;
            this.lblMinLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMinLevel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMinLevel.Location = new System.Drawing.Point(588, 40);
            this.lblMinLevel.Name = "lblMinLevel";
            this.lblMinLevel.Size = new System.Drawing.Size(94, 30);
            this.lblMinLevel.TabIndex = 5;
            this.lblMinLevel.Text = "Min Level *";
            this.lblMinLevel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.tlpMain.SetColumnSpan(this.btnHeader, 6);
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnHeader.Location = new System.Drawing.Point(18, 3);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(963, 34);
            this.btnHeader.TabIndex = 0;
            this.btnHeader.Text = "Material";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // lblGroupCode
            // 
            this.lblGroupCode.AutoSize = true;
            this.lblGroupCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupCode.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGroupCode.Location = new System.Drawing.Point(18, 40);
            this.lblGroupCode.Name = "lblGroupCode";
            this.lblGroupCode.Size = new System.Drawing.Size(184, 30);
            this.lblGroupCode.TabIndex = 1;
            this.lblGroupCode.Text = "Group Code *";
            this.lblGroupCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGroupName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGroupName.Location = new System.Drawing.Point(208, 40);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(184, 30);
            this.lblGroupName.TabIndex = 3;
            this.lblGroupName.Text = "Group Name *";
            this.lblGroupName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtGrpCode
            // 
            this.txtGrpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrpCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGrpCode.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGrpCode.Location = new System.Drawing.Point(18, 73);
            this.txtGrpCode.MaxLength = 10;
            this.txtGrpCode.Name = "txtGrpCode";
            this.txtGrpCode.Size = new System.Drawing.Size(184, 25);
            this.txtGrpCode.TabIndex = 2;
            this.txtGrpCode.Leave += new System.EventHandler(this.txtGrpCode_Leave);
            // 
            // txtGrpName
            // 
            this.txtGrpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlpMain.SetColumnSpan(this.txtGrpName, 2);
            this.txtGrpName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGrpName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtGrpName.Location = new System.Drawing.Point(208, 73);
            this.txtGrpName.MaxLength = 100;
            this.txtGrpName.Name = "txtGrpName";
            this.txtGrpName.Size = new System.Drawing.Size(374, 25);
            this.txtGrpName.TabIndex = 4;
            this.txtGrpName.Leave += new System.EventHandler(this.txtGrpName_Leave);
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvMaterial, 6);
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(18, 108);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.ReadOnly = true;
            this.dgvMaterial.Size = new System.Drawing.Size(963, 365);
            this.dgvMaterial.TabIndex = 10;
            this.dgvMaterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterial_CellClick);
            this.dgvMaterial.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ccdc_Status);
            this.dgvMaterial.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ccdc_Status);
            this.dgvMaterial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMaterial_CellFormatting);
            this.dgvMaterial.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterial_CellMouseEnter);
            this.dgvMaterial.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMaterial_CellPainting);
            this.dgvMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvMaterial_KeyDown);
            // 
            // tlpCrudButton
            // 
            this.tlpCrudButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tlpCrudButton.ColumnCount = 2;
            this.tlpCrudButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCrudButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCrudButton.Controls.Add(this.btnSave, 0, 1);
            this.tlpCrudButton.Controls.Add(this.btnCancel, 1, 1);
            this.tlpCrudButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpCrudButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tlpCrudButton.Location = new System.Drawing.Point(688, 43);
            this.tlpCrudButton.Name = "tlpCrudButton";
            this.tlpCrudButton.RowCount = 4;
            this.tlpMain.SetRowSpan(this.tlpCrudButton, 3);
            this.tlpCrudButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCrudButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tlpCrudButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpCrudButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpCrudButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCrudButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCrudButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCrudButton.Size = new System.Drawing.Size(193, 59);
            this.tlpCrudButton.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnSave.Image = global::POSClient.Properties.Resources.save_24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(3, 22);
            this.btnSave.Name = "btnSave";
            this.tlpCrudButton.SetRowSpan(this.btnSave, 3);
            this.btnSave.Size = new System.Drawing.Size(90, 34);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = " Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnCancel.Image = global::POSClient.Properties.Resources.cancel_24;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(99, 22);
            this.btnCancel.Name = "btnCancel";
            this.tlpCrudButton.SetRowSpan(this.btnCancel, 3);
            this.btnCancel.Size = new System.Drawing.Size(91, 34);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = " &Clear";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tlpMain.SetColumnSpan(this.tableLayoutPanel1, 3);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnSEdit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblShortcut, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 479);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tlpMain.SetRowSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(564, 44);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btnSEdit
            // 
            this.btnSEdit.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEdit.ForeColor = System.Drawing.Color.Navy;
            this.btnSEdit.Location = new System.Drawing.Point(188, 3);
            this.btnSEdit.Name = "btnSEdit";
            this.tableLayoutPanel1.SetRowSpan(this.btnSEdit, 2);
            this.btnSEdit.Size = new System.Drawing.Size(114, 29);
            this.btnSEdit.TabIndex = 14;
            this.btnSEdit.Text = "Edit : Ctrl + E";
            this.btnSEdit.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Cornsilk;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Navy;
            this.button2.Location = new System.Drawing.Point(308, 3);
            this.button2.Name = "button2";
            this.tableLayoutPanel1.SetRowSpan(this.button2, 2);
            this.button2.Size = new System.Drawing.Size(114, 29);
            this.button2.TabIndex = 15;
            this.button2.Text = "Clear : Alt + C";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(68, 3);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(114, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save : Ctrl + S";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcut.Location = new System.Drawing.Point(3, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(59, 30);
            this.lblShortcut.TabIndex = 12;
            this.lblShortcut.Text = "Shortcut";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 526);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmMaterial";
            this.Text = "Material";
            this.Load += new System.EventHandler(this.frmMaterial_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMaterial_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            this.tlpCrudButton.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblGroupCode;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGrpCode;
        private System.Windows.Forms.TextBox txtGrpName;
        private System.Windows.Forms.DataGridView dgvMaterial;
        private System.Windows.Forms.TableLayoutPanel tlpCrudButton;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblShortcut;
        private Button button1;
        private Button button2;
        private Button btnSEdit;
        private Label lblMinLevel;
        private TextBox txtMinLevel;
    }
}