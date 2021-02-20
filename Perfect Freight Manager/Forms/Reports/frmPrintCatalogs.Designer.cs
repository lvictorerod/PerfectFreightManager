namespace Perfect_Freight_Manager.Forms.Revenue
{
    partial class frmPrintCatalogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintCatalogs));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.brokersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.agentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agencyInsuranceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phoneBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trucksTrailersProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trailersProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.helpToolStripMenuItem1});
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
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brokersToolStripMenuItem1,
            this.agentsToolStripMenuItem1,
            this.customerToolStripMenuItem,
            this.agencyInsuranceToolStripMenuItem,
            this.phoneBookToolStripMenuItem,
            this.vendorToolStripMenuItem,
            this.trucksTrailersProfileToolStripMenuItem,
            this.trailersProfileToolStripMenuItem});
            this.helpToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem1.Image")));
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(109, 20);
            this.helpToolStripMenuItem1.Text = "Print Catalogs";
            // 
            // brokersToolStripMenuItem1
            // 
            this.brokersToolStripMenuItem1.Name = "brokersToolStripMenuItem1";
            this.brokersToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.brokersToolStripMenuItem1.Text = "Brokers";
            this.brokersToolStripMenuItem1.Click += new System.EventHandler(this.brokersToolStripMenuItem1_Click);
            // 
            // agentsToolStripMenuItem1
            // 
            this.agentsToolStripMenuItem1.Name = "agentsToolStripMenuItem1";
            this.agentsToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.agentsToolStripMenuItem1.Text = "Agents";
            this.agentsToolStripMenuItem1.Click += new System.EventHandler(this.agentsToolStripMenuItem1_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // agencyInsuranceToolStripMenuItem
            // 
            this.agencyInsuranceToolStripMenuItem.Name = "agencyInsuranceToolStripMenuItem";
            this.agencyInsuranceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.agencyInsuranceToolStripMenuItem.Text = "Insurance Agency ";
            this.agencyInsuranceToolStripMenuItem.Click += new System.EventHandler(this.agencyInsuranceToolStripMenuItem_Click);
            // 
            // phoneBookToolStripMenuItem
            // 
            this.phoneBookToolStripMenuItem.Name = "phoneBookToolStripMenuItem";
            this.phoneBookToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.phoneBookToolStripMenuItem.Text = "Phone Book";
            this.phoneBookToolStripMenuItem.Click += new System.EventHandler(this.phoneBookToolStripMenuItem_Click);
            // 
            // vendorToolStripMenuItem
            // 
            this.vendorToolStripMenuItem.Name = "vendorToolStripMenuItem";
            this.vendorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.vendorToolStripMenuItem.Text = "Vendor";
            this.vendorToolStripMenuItem.Click += new System.EventHandler(this.vendorToolStripMenuItem_Click);
            // 
            // trucksTrailersProfileToolStripMenuItem
            // 
            this.trucksTrailersProfileToolStripMenuItem.Name = "trucksTrailersProfileToolStripMenuItem";
            this.trucksTrailersProfileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.trucksTrailersProfileToolStripMenuItem.Text = "Trucks Profile";
            this.trucksTrailersProfileToolStripMenuItem.Click += new System.EventHandler(this.trucksTrailersProfileToolStripMenuItem_Click);
            // 
            // trailersProfileToolStripMenuItem
            // 
            this.trailersProfileToolStripMenuItem.Name = "trailersProfileToolStripMenuItem";
            this.trailersProfileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.trailersProfileToolStripMenuItem.Text = "Trailers Profile";
            this.trailersProfileToolStripMenuItem.Click += new System.EventHandler(this.trailersProfileToolStripMenuItem_Click);
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
            this.groupBox1.Text = "Reports Catalogs";
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
            // frmPrintCatalogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 811);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrintCatalogs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrintCatalogs";
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
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agencyInsuranceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phoneBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trucksTrailersProfileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem trailersProfileToolStripMenuItem;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
        private System.Windows.Forms.ToolStripMenuItem brokersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem agentsToolStripMenuItem1;
    }
}