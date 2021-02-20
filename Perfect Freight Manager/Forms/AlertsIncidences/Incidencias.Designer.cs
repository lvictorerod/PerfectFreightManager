namespace Perfect_Freight_Manager.Forms.AlertsIncidences
{
    partial class Incidencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Incidencias));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label47 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.dtCDLExpireDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.btnSelDriverCDL = new System.Windows.Forms.Button();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtCDLEndor = new System.Windows.Forms.TextBox();
            this.txtCDLClass = new System.Windows.Forms.TextBox();
            this.txtCDLState = new System.Windows.Forms.TextBox();
            this.txtCDLNumber = new System.Windows.Forms.TextBox();
            this.pbCDLPhoto = new System.Windows.Forms.PictureBox();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.dtMedExpireDate = new System.Windows.Forms.DateTimePicker();
            this.btnSelDriverMedCard = new System.Windows.Forms.Button();
            this.pbDriverMedCardPhoto = new System.Windows.Forms.PictureBox();
            this.label54 = new System.Windows.Forms.Label();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.btDriverSSCard = new System.Windows.Forms.Button();
            this.pbDriverSSPhoto = new System.Windows.Forms.PictureBox();
            this.txtSSNumber = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.dgvDriver = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.driverName = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDriverUpd = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCDLPhoto)).BeginInit();
            this.tabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDriverMedCardPhoto)).BeginInit();
            this.tabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDriverSSPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriver)).BeginInit();
            this.groupBox16.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(546, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.fileToolStripMenuItem.Text = "Return";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(13, 114);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(32, 13);
            this.label47.TabIndex = 21;
            this.label47.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Location = new System.Drawing.Point(55, 114);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(251, 20);
            this.txtEmail.TabIndex = 20;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage13);
            this.tabControl4.Controls.Add(this.tabPage14);
            this.tabControl4.Controls.Add(this.tabPage15);
            this.tabControl4.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl4.Location = new System.Drawing.Point(16, 170);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(518, 198);
            this.tabControl4.TabIndex = 24;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.dtCDLExpireDate);
            this.tabPage13.Controls.Add(this.label25);
            this.tabPage13.Controls.Add(this.btnSelDriverCDL);
            this.tabPage13.Controls.Add(this.label52);
            this.tabPage13.Controls.Add(this.label51);
            this.tabPage13.Controls.Add(this.label50);
            this.tabPage13.Controls.Add(this.label49);
            this.tabPage13.Controls.Add(this.txtCDLEndor);
            this.tabPage13.Controls.Add(this.txtCDLClass);
            this.tabPage13.Controls.Add(this.txtCDLState);
            this.tabPage13.Controls.Add(this.txtCDLNumber);
            this.tabPage13.Controls.Add(this.pbCDLPhoto);
            this.tabPage13.Location = new System.Drawing.Point(4, 23);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(510, 171);
            this.tabPage13.TabIndex = 1;
            this.tabPage13.Text = "CDL";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // dtCDLExpireDate
            // 
            this.dtCDLExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCDLExpireDate.Location = new System.Drawing.Point(384, 17);
            this.dtCDLExpireDate.Name = "dtCDLExpireDate";
            this.dtCDLExpireDate.Size = new System.Drawing.Size(117, 22);
            this.dtCDLExpireDate.TabIndex = 81;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(402, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 14);
            this.label25.TabIndex = 79;
            this.label25.Text = "Expire Date";
            // 
            // btnSelDriverCDL
            // 
            this.btnSelDriverCDL.AutoSize = true;
            this.btnSelDriverCDL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelDriverCDL.Location = new System.Drawing.Point(36, 76);
            this.btnSelDriverCDL.Name = "btnSelDriverCDL";
            this.btnSelDriverCDL.Size = new System.Drawing.Size(80, 27);
            this.btnSelDriverCDL.TabIndex = 75;
            this.btnSelDriverCDL.Text = "Select Photo";
            this.btnSelDriverCDL.UseVisualStyleBackColor = true;
            this.btnSelDriverCDL.Click += new System.EventHandler(this.btnSelDriverCDL_Click);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(274, 6);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(86, 14);
            this.label52.TabIndex = 9;
            this.label52.Text = "Endor Sements";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(204, 6);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(33, 14);
            this.label51.TabIndex = 8;
            this.label51.Text = "Class";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(150, 5);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(20, 14);
            this.label50.TabIndex = 7;
            this.label50.Text = "ST";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(21, 4);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(38, 14);
            this.label49.TabIndex = 6;
            this.label49.Text = "CDL #";
            // 
            // txtCDLEndor
            // 
            this.txtCDLEndor.Location = new System.Drawing.Point(270, 17);
            this.txtCDLEndor.Name = "txtCDLEndor";
            this.txtCDLEndor.Size = new System.Drawing.Size(109, 22);
            this.txtCDLEndor.TabIndex = 4;
            // 
            // txtCDLClass
            // 
            this.txtCDLClass.Location = new System.Drawing.Point(201, 17);
            this.txtCDLClass.Name = "txtCDLClass";
            this.txtCDLClass.Size = new System.Drawing.Size(63, 22);
            this.txtCDLClass.TabIndex = 3;
            // 
            // txtCDLState
            // 
            this.txtCDLState.Location = new System.Drawing.Point(149, 17);
            this.txtCDLState.Name = "txtCDLState";
            this.txtCDLState.Size = new System.Drawing.Size(46, 22);
            this.txtCDLState.TabIndex = 2;
            // 
            // txtCDLNumber
            // 
            this.txtCDLNumber.Location = new System.Drawing.Point(16, 17);
            this.txtCDLNumber.Name = "txtCDLNumber";
            this.txtCDLNumber.Size = new System.Drawing.Size(127, 22);
            this.txtCDLNumber.TabIndex = 1;
            // 
            // pbCDLPhoto
            // 
            this.pbCDLPhoto.BackColor = System.Drawing.Color.Black;
            this.pbCDLPhoto.Location = new System.Drawing.Point(122, 49);
            this.pbCDLPhoto.Name = "pbCDLPhoto";
            this.pbCDLPhoto.Size = new System.Drawing.Size(215, 116);
            this.pbCDLPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCDLPhoto.TabIndex = 0;
            this.pbCDLPhoto.TabStop = false;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.dtMedExpireDate);
            this.tabPage14.Controls.Add(this.btnSelDriverMedCard);
            this.tabPage14.Controls.Add(this.pbDriverMedCardPhoto);
            this.tabPage14.Controls.Add(this.label54);
            this.tabPage14.Location = new System.Drawing.Point(4, 23);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(510, 171);
            this.tabPage14.TabIndex = 2;
            this.tabPage14.Text = "Med Card";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // dtMedExpireDate
            // 
            this.dtMedExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMedExpireDate.Location = new System.Drawing.Point(112, 6);
            this.dtMedExpireDate.Name = "dtMedExpireDate";
            this.dtMedExpireDate.Size = new System.Drawing.Size(102, 22);
            this.dtMedExpireDate.TabIndex = 77;
            // 
            // btnSelDriverMedCard
            // 
            this.btnSelDriverMedCard.AutoSize = true;
            this.btnSelDriverMedCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelDriverMedCard.Location = new System.Drawing.Point(26, 71);
            this.btnSelDriverMedCard.Name = "btnSelDriverMedCard";
            this.btnSelDriverMedCard.Size = new System.Drawing.Size(80, 27);
            this.btnSelDriverMedCard.TabIndex = 75;
            this.btnSelDriverMedCard.Text = "Select Photo";
            this.btnSelDriverMedCard.UseVisualStyleBackColor = true;
            this.btnSelDriverMedCard.Click += new System.EventHandler(this.btnSelDriverMedCard_Click);
            // 
            // pbDriverMedCardPhoto
            // 
            this.pbDriverMedCardPhoto.BackColor = System.Drawing.Color.Black;
            this.pbDriverMedCardPhoto.Location = new System.Drawing.Point(112, 35);
            this.pbDriverMedCardPhoto.Name = "pbDriverMedCardPhoto";
            this.pbDriverMedCardPhoto.Size = new System.Drawing.Size(249, 116);
            this.pbDriverMedCardPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDriverMedCardPhoto.TabIndex = 2;
            this.pbDriverMedCardPhoto.TabStop = false;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(12, 10);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(94, 14);
            this.label54.TabIndex = 0;
            this.label54.Text = "Med Expire Date";
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.btDriverSSCard);
            this.tabPage15.Controls.Add(this.pbDriverSSPhoto);
            this.tabPage15.Controls.Add(this.txtSSNumber);
            this.tabPage15.Controls.Add(this.label55);
            this.tabPage15.Location = new System.Drawing.Point(4, 23);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Size = new System.Drawing.Size(510, 171);
            this.tabPage15.TabIndex = 3;
            this.tabPage15.Text = "SS Card";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // btDriverSSCard
            // 
            this.btDriverSSCard.AutoSize = true;
            this.btDriverSSCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDriverSSCard.Location = new System.Drawing.Point(33, 77);
            this.btDriverSSCard.Name = "btDriverSSCard";
            this.btDriverSSCard.Size = new System.Drawing.Size(80, 27);
            this.btDriverSSCard.TabIndex = 76;
            this.btDriverSSCard.Text = "Select Photo";
            this.btDriverSSCard.UseVisualStyleBackColor = true;
            // 
            // pbDriverSSPhoto
            // 
            this.pbDriverSSPhoto.BackColor = System.Drawing.Color.Black;
            this.pbDriverSSPhoto.Location = new System.Drawing.Point(119, 36);
            this.pbDriverSSPhoto.Name = "pbDriverSSPhoto";
            this.pbDriverSSPhoto.Size = new System.Drawing.Size(223, 132);
            this.pbDriverSSPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDriverSSPhoto.TabIndex = 2;
            this.pbDriverSSPhoto.TabStop = false;
            // 
            // txtSSNumber
            // 
            this.txtSSNumber.Location = new System.Drawing.Point(79, 6);
            this.txtSSNumber.Name = "txtSSNumber";
            this.txtSSNumber.Size = new System.Drawing.Size(119, 22);
            this.txtSSNumber.TabIndex = 1;
            this.txtSSNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(8, 9);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(65, 14);
            this.label55.TabIndex = 0;
            this.label55.Text = "SS Number";
            // 
            // dgvDriver
            // 
            this.dgvDriver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriver.Location = new System.Drawing.Point(312, 72);
            this.dgvDriver.Name = "dgvDriver";
            this.dgvDriver.Size = new System.Drawing.Size(222, 92);
            this.dgvDriver.TabIndex = 25;
            this.dgvDriver.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Actualizacion de eMail , CDL, MedCard y SS Card del Driver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Driver Name:";
            // 
            // driverName
            // 
            this.driverName.AutoSize = true;
            this.driverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverName.Location = new System.Drawing.Point(139, 72);
            this.driverName.Name = "driverName";
            this.driverName.Size = new System.Drawing.Size(57, 20);
            this.driverName.TabIndex = 28;
            this.driverName.Text = "label3";
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.LightGray;
            this.groupBox16.Controls.Add(this.button1);
            this.groupBox16.Controls.Add(this.btnDriverUpd);
            this.groupBox16.Location = new System.Drawing.Point(20, 370);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(510, 52);
            this.groupBox16.TabIndex = 213;
            this.groupBox16.TabStop = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(853, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 29);
            this.button1.TabIndex = 206;
            this.button1.Text = "Print Utilities";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDriverUpd
            // 
            this.btnDriverUpd.AutoSize = true;
            this.btnDriverUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnDriverUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnDriverUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriverUpd.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDriverUpd.Location = new System.Drawing.Point(188, 10);
            this.btnDriverUpd.Name = "btnDriverUpd";
            this.btnDriverUpd.Size = new System.Drawing.Size(109, 29);
            this.btnDriverUpd.TabIndex = 65;
            this.btnDriverUpd.Text = "Update Driver";
            this.btnDriverUpd.UseVisualStyleBackColor = true;
            this.btnDriverUpd.Click += new System.EventHandler(this.btnDriverUpd_Click);
            // 
            // Incidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 425);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.driverName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDriver);
            this.Controls.Add(this.tabControl4);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Incidencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Missing & Incidents Alerts";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCDLPhoto)).EndInit();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDriverMedCardPhoto)).EndInit();
            this.tabPage15.ResumeLayout(false);
            this.tabPage15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDriverSSPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriver)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.DateTimePicker dtCDLExpireDate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnSelDriverCDL;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox txtCDLEndor;
        private System.Windows.Forms.TextBox txtCDLClass;
        private System.Windows.Forms.TextBox txtCDLState;
        private System.Windows.Forms.TextBox txtCDLNumber;
        private System.Windows.Forms.PictureBox pbCDLPhoto;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.DateTimePicker dtMedExpireDate;
        private System.Windows.Forms.Button btnSelDriverMedCard;
        private System.Windows.Forms.PictureBox pbDriverMedCardPhoto;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.Button btDriverSSCard;
        private System.Windows.Forms.PictureBox pbDriverSSPhoto;
        private System.Windows.Forms.TextBox txtSSNumber;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.DataGridView dgvDriver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label driverName;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDriverUpd;
    }
}