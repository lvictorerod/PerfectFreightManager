namespace Perfect_Freight_Manager.Forms.Revenue
{
    partial class frmPrintPdf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintPdf));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oustandingInvoice60DaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dueInvoiceNotLate6090DaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastDueInvoice90DaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paidInvoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.printDocumentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1085, 24);
            this.menuStrip1.TabIndex = 107;
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
            // printDocumentToolStripMenuItem
            // 
            this.printDocumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oustandingInvoice60DaysToolStripMenuItem,
            this.dueInvoiceNotLate6090DaysToolStripMenuItem,
            this.pastDueInvoice90DaysToolStripMenuItem,
            this.paidInvoicesToolStripMenuItem});
            this.printDocumentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printDocumentToolStripMenuItem.Image")));
            this.printDocumentToolStripMenuItem.Name = "printDocumentToolStripMenuItem";
            this.printDocumentToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.printDocumentToolStripMenuItem.Text = "Print Document";
            // 
            // oustandingInvoice60DaysToolStripMenuItem
            // 
            this.oustandingInvoice60DaysToolStripMenuItem.Name = "oustandingInvoice60DaysToolStripMenuItem";
            this.oustandingInvoice60DaysToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.oustandingInvoice60DaysToolStripMenuItem.Text = "Oustanding Invoice ( <= 60 days )";
            this.oustandingInvoice60DaysToolStripMenuItem.Click += new System.EventHandler(this.oustandingInvoice60DaysToolStripMenuItem_Click);
            // 
            // dueInvoiceNotLate6090DaysToolStripMenuItem
            // 
            this.dueInvoiceNotLate6090DaysToolStripMenuItem.Name = "dueInvoiceNotLate6090DaysToolStripMenuItem";
            this.dueInvoiceNotLate6090DaysToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.dueInvoiceNotLate6090DaysToolStripMenuItem.Text = "Due Invoice Not Late ( >60 & <= 90 days )";
            this.dueInvoiceNotLate6090DaysToolStripMenuItem.Click += new System.EventHandler(this.dueInvoiceNotLate6090DaysToolStripMenuItem_Click);
            // 
            // pastDueInvoice90DaysToolStripMenuItem
            // 
            this.pastDueInvoice90DaysToolStripMenuItem.Name = "pastDueInvoice90DaysToolStripMenuItem";
            this.pastDueInvoice90DaysToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.pastDueInvoice90DaysToolStripMenuItem.Text = "Past Due Invoice ( > 90 days )";
            this.pastDueInvoice90DaysToolStripMenuItem.Click += new System.EventHandler(this.pastDueInvoice90DaysToolStripMenuItem_Click);
            // 
            // paidInvoicesToolStripMenuItem
            // 
            this.paidInvoicesToolStripMenuItem.Name = "paidInvoicesToolStripMenuItem";
            this.paidInvoicesToolStripMenuItem.Size = new System.Drawing.Size(285, 22);
            this.paidInvoicesToolStripMenuItem.Text = "Paid Invoices";
            this.paidInvoicesToolStripMenuItem.Click += new System.EventHandler(this.paidInvoicesToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.axAcroPDF);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1085, 787);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Document Invoice Status";
            // 
            // axAcroPDF
            // 
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(-5, 23);
            this.axAcroPDF.Name = "axAcroPDF";
            this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
            this.axAcroPDF.Size = new System.Drawing.Size(1095, 764);
            this.axAcroPDF.TabIndex = 109;
            // 
            // frmPrintPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 811);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrintPdf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print PDF";
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
        private System.Windows.Forms.GroupBox groupBox1;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
        private System.Windows.Forms.ToolStripMenuItem printDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oustandingInvoice60DaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dueInvoiceNotLate6090DaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastDueInvoice90DaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paidInvoicesToolStripMenuItem;
    }
}