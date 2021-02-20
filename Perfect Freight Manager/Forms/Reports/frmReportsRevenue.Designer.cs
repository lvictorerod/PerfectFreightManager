namespace Perfect_Freight_Manager.Forms.Revenue
{
    partial class frmReportsRevenue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportsRevenue));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsRevenueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripPikupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripFuelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tripRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.reportsRevenueToolStripMenuItem});
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
            // reportsRevenueToolStripMenuItem
            // 
            this.reportsRevenueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tripPikupToolStripMenuItem,
            this.tripFuelToolStripMenuItem,
            this.tripExpensesToolStripMenuItem,
            this.tripRouteToolStripMenuItem});
            this.reportsRevenueToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportsRevenueToolStripMenuItem.Image")));
            this.reportsRevenueToolStripMenuItem.Name = "reportsRevenueToolStripMenuItem";
            this.reportsRevenueToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.reportsRevenueToolStripMenuItem.Text = "Reports Revenue";
            // 
            // tripPikupToolStripMenuItem
            // 
            this.tripPikupToolStripMenuItem.AutoToolTip = true;
            this.tripPikupToolStripMenuItem.Name = "tripPikupToolStripMenuItem";
            this.tripPikupToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.tripPikupToolStripMenuItem.Text = "Trip->Pickup & Drop";
            this.tripPikupToolStripMenuItem.ToolTipText = "Report Pickup & Drop";
            this.tripPikupToolStripMenuItem.Click += new System.EventHandler(this.tripPickupToolStripMenuItem_Click);
            // 
            // tripFuelToolStripMenuItem
            // 
            this.tripFuelToolStripMenuItem.AutoToolTip = true;
            this.tripFuelToolStripMenuItem.Name = "tripFuelToolStripMenuItem";
            this.tripFuelToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.tripFuelToolStripMenuItem.Text = "Trip->Fuel";
            this.tripFuelToolStripMenuItem.ToolTipText = "Report Fuel";
            this.tripFuelToolStripMenuItem.Click += new System.EventHandler(this.tripFuelToolStripMenuItem_Click);
            // 
            // tripExpensesToolStripMenuItem
            // 
            this.tripExpensesToolStripMenuItem.AutoToolTip = true;
            this.tripExpensesToolStripMenuItem.Name = "tripExpensesToolStripMenuItem";
            this.tripExpensesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.tripExpensesToolStripMenuItem.Text = "Trip->Expenses";
            this.tripExpensesToolStripMenuItem.ToolTipText = "Report Expenses";
            this.tripExpensesToolStripMenuItem.Click += new System.EventHandler(this.tripExpensesToolStripMenuItem_Click);
            // 
            // tripRouteToolStripMenuItem
            // 
            this.tripRouteToolStripMenuItem.AutoToolTip = true;
            this.tripRouteToolStripMenuItem.Name = "tripRouteToolStripMenuItem";
            this.tripRouteToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.tripRouteToolStripMenuItem.Text = "Trip->Route";
            this.tripRouteToolStripMenuItem.ToolTipText = "Report Route";
            this.tripRouteToolStripMenuItem.Click += new System.EventHandler(this.tripRouteToolStripMenuItem_Click);
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
            this.groupBox1.Text = "Reports Revenue";
            // 
            // axAcroPDF
            // 
            this.axAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(3, 25);
            this.axAcroPDF.Name = "axAcroPDF";
            this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
            this.axAcroPDF.Size = new System.Drawing.Size(1079, 759);
            this.axAcroPDF.TabIndex = 2;
            // 
            // frmReportsRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 811);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmReportsRevenue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsRevenueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tripPikupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tripFuelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tripExpensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tripRouteToolStripMenuItem;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
    }
}