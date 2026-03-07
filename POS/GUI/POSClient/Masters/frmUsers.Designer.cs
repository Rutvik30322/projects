
namespace POSClient
{
    partial class frmUsers
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
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnHeader = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.tlpShortcut = new System.Windows.Forms.TableLayoutPanel();
            this.btnSEdit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.btnSAdd = new System.Windows.Forms.Button();
            this.btnSResetList = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tlpShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 9;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpMain.Controls.Add(this.btnResetPassword, 6, 1);
            this.tlpMain.Controls.Add(this.btnAdd, 1, 1);
            this.tlpMain.Controls.Add(this.btnHeader, 1, 0);
            this.tlpMain.Controls.Add(this.dgvUser, 1, 3);
            this.tlpMain.Controls.Add(this.btnChangePassword, 7, 1);
            this.tlpMain.Controls.Add(this.tlpShortcut, 1, 4);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 6;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(875, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnResetPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnResetPassword.Image = global::POSClient.Properties.Resources.refresh_24;
            this.btnResetPassword.Location = new System.Drawing.Point(563, 43);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(144, 34);
            this.btnResetPassword.TabIndex = 3;
            this.btnResetPassword.Text = " &Password Reset List";
            this.btnResetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnAdd.Image = global::POSClient.Properties.Resources.add_24;
            this.btnAdd.Location = new System.Drawing.Point(18, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(74, 34);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = " &Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnHeader.Size = new System.Drawing.Size(839, 34);
            this.btnHeader.TabIndex = 1;
            this.btnHeader.Text = "Users";
            this.btnHeader.UseVisualStyleBackColor = false;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpMain.SetColumnSpan(this.dgvUser, 7);
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(18, 88);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.Size = new System.Drawing.Size(839, 309);
            this.dgvUser.TabIndex = 5;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
            this.dgvUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellContentClick);
            this.dgvUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellDoubleClick);
            this.dgvUser.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUser_CellFormatting);
            this.dgvUser.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellMouseEnter);
            this.dgvUser.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUser_CellPainting);
            this.dgvUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUser_KeyDown);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.btnChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChangePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.btnChangePassword.Image = global::POSClient.Properties.Resources.validation_24;
            this.btnChangePassword.Location = new System.Drawing.Point(713, 43);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(144, 34);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = " &Change Password";
            this.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // tlpShortcut
            // 
            this.tlpShortcut.ColumnCount = 6;
            this.tlpMain.SetColumnSpan(this.tlpShortcut, 7);
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpShortcut.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.Controls.Add(this.btnSEdit, 3, 0);
            this.tlpShortcut.Controls.Add(this.button1, 1, 0);
            this.tlpShortcut.Controls.Add(this.lblShortcut, 0, 0);
            this.tlpShortcut.Controls.Add(this.btnSAdd, 2, 0);
            this.tlpShortcut.Controls.Add(this.btnSResetList, 4, 0);
            this.tlpShortcut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShortcut.Location = new System.Drawing.Point(18, 403);
            this.tlpShortcut.Name = "tlpShortcut";
            this.tlpShortcut.RowCount = 3;
            this.tlpMain.SetRowSpan(this.tlpShortcut, 2);
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShortcut.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpShortcut.Size = new System.Drawing.Size(839, 44);
            this.tlpShortcut.TabIndex = 6;
            // 
            // btnSEdit
            // 
            this.btnSEdit.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEdit.ForeColor = System.Drawing.Color.Navy;
            this.btnSEdit.Location = new System.Drawing.Point(388, 3);
            this.btnSEdit.Name = "btnSEdit";
            this.tlpShortcut.SetRowSpan(this.btnSEdit, 2);
            this.btnSEdit.Size = new System.Drawing.Size(154, 29);
            this.btnSEdit.TabIndex = 51;
            this.btnSEdit.Text = "Edit : Ctrl + E";
            this.btnSEdit.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(68, 3);
            this.button1.Name = "button1";
            this.tlpShortcut.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(154, 29);
            this.button1.TabIndex = 48;
            this.button1.Text = "Change Password : Alt + C";
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
            this.lblShortcut.TabIndex = 47;
            this.lblShortcut.Text = "Shortcut";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSAdd
            // 
            this.btnSAdd.BackColor = System.Drawing.Color.PeachPuff;
            this.btnSAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAdd.ForeColor = System.Drawing.Color.Navy;
            this.btnSAdd.Location = new System.Drawing.Point(228, 3);
            this.btnSAdd.Name = "btnSAdd";
            this.tlpShortcut.SetRowSpan(this.btnSAdd, 2);
            this.btnSAdd.Size = new System.Drawing.Size(154, 29);
            this.btnSAdd.TabIndex = 49;
            this.btnSAdd.Text = "Add : Alt + A";
            this.btnSAdd.UseVisualStyleBackColor = false;
            // 
            // btnSResetList
            // 
            this.btnSResetList.BackColor = System.Drawing.Color.LightCyan;
            this.btnSResetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSResetList.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSResetList.ForeColor = System.Drawing.Color.Navy;
            this.btnSResetList.Location = new System.Drawing.Point(548, 3);
            this.btnSResetList.Name = "btnSResetList";
            this.tlpShortcut.SetRowSpan(this.btnSResetList, 2);
            this.btnSResetList.Size = new System.Drawing.Size(154, 29);
            this.btnSResetList.TabIndex = 50;
            this.btnSResetList.Text = "Reset List : Alt + R";
            this.btnSResetList.UseVisualStyleBackColor = false;
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmUsers";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsers_KeyDown);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.tlpShortcut.ResumeLayout(false);
            this.tlpShortcut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TableLayoutPanel tlpShortcut;
        private System.Windows.Forms.Label lblShortcut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSAdd;
        private System.Windows.Forms.Button btnSResetList;
        private System.Windows.Forms.Button btnSEdit;
    }
}