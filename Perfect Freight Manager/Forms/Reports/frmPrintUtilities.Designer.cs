namespace Perfect_Freight_Manager.Forms.Utilities
{
    partial class frmPrintUtilities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintUtilities));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printUtilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officeEmployProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faxSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axAcroPDF = new AxAcroPDFLib.AxAcroPDF();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.printUtilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
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
            // printUtilitiesToolStripMenuItem
            // 
            this.printUtilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyProfileToolStripMenuItem,
            this.driversProfileToolStripMenuItem,
            this.officeEmployProfileToolStripMenuItem,
            this.emailSettingsToolStripMenuItem,
            this.faxSettingsToolStripMenuItem});
            this.printUtilitiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printUtilitiesToolStripMenuItem.Image")));
            this.printUtilitiesToolStripMenuItem.Name = "printUtilitiesToolStripMenuItem";
            this.printUtilitiesToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.printUtilitiesToolStripMenuItem.Text = "Print Utilities";
            // 
            // companyProfileToolStripMenuItem
            // 
            this.companyProfileToolStripMenuItem.Name = "companyProfileToolStripMenuItem";
            this.companyProfileToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.companyProfileToolStripMenuItem.Text = "Company Profile";
            this.companyProfileToolStripMenuItem.Click += new System.EventHandler(this.companyProfileToolStripMenuItem_Click);
            // 
            // driversProfileToolStripMenuItem
            // 
            this.driversProfileToolStripMenuItem.Name = "driversProfileToolStripMenuItem";
            this.driversProfileToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.driversProfileToolStripMenuItem.Text = "Drivers Profile";
            this.driversProfileToolStripMenuItem.Click += new System.EventHandler(this.driversProfileToolStripMenuItem_Click);
            // 
            // officeEmployProfileToolStripMenuItem
            // 
            this.officeEmployProfileToolStripMenuItem.Name = "officeEmployProfileToolStripMenuItem";
            this.officeEmployProfileToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.officeEmployProfileToolStripMenuItem.Text = "Office Employ Profile";
            this.officeEmployProfileToolStripMenuItem.Click += new System.EventHandler(this.officeEmployProfileToolStripMenuItem_Click);
            // 
            // emailSettingsToolStripMenuItem
            // 
            this.emailSettingsToolStripMenuItem.Name = "emailSettingsToolStripMenuItem";
            this.emailSettingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.emailSettingsToolStripMenuItem.Text = "Email Settings";
            this.emailSettingsToolStripMenuItem.Click += new System.EventHandler(this.emailSettingsToolStripMenuItem_Click);
            // 
            // faxSettingsToolStripMenuItem
            // 
            this.faxSettingsToolStripMenuItem.Name = "faxSettingsToolStripMenuItem";
            this.faxSettingsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.faxSettingsToolStripMenuItem.Text = "Fax Settings";
            this.faxSettingsToolStripMenuItem.Click += new System.EventHandler(this.faxSettingsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.axAcroPDF);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1085, 787);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Catalogs Utilities";
            // 
            // axAcroPDF
            // 
            this.axAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(3, 25);
            this.axAcroPDF.Name = "axAcroPDF";
            this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
            this.axAcroPDF.Size = new System.Drawing.Size(1079, 759);
            this.axAcroPDF.TabIndex = 0;
            // 
            // frmPrintUtilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 811);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrintUtilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Utilities";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printUtilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem officeEmployProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faxSettingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
    }
}