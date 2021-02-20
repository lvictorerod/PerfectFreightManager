namespace Perfect_Freight_Manager.Forms.ExpensesInvoices
{
    partial class frmResumens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumens));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtTrip = new System.Windows.Forms.TextBox();
            this.lblInvoiceResume = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvResumes = new System.Windows.Forms.DataGridView();
            this.label36 = new System.Windows.Forms.Label();
            this.txtNotesSearch = new System.Windows.Forms.TextBox();
            this.btnResumeUpd = new System.Windows.Forms.Button();
            this.btnResumeDel = new System.Windows.Forms.Button();
            this.btnResumeAdd = new System.Windows.Forms.Button();
            this.btnClearTrip = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumes)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.cbCategory);
            this.groupBox3.Controls.Add(this.txtTrip);
            this.groupBox3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(25, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(731, 92);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resumes Invoices";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(579, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 14);
            this.label15.TabIndex = 15;
            this.label15.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(576, 38);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(117, 22);
            this.txtPrice.TabIndex = 14;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(285, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 14);
            this.label14.TabIndex = 9;
            this.label14.Text = "Short Description";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(143, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 14);
            this.label13.TabIndex = 8;
            this.label13.Text = "Expense Category";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(32, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 14);
            this.label12.TabIndex = 7;
            this.label12.Text = "Trip ID";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(280, 38);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(281, 42);
            this.txtDescription.TabIndex = 4;
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.cbCategory.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Apu Service",
            "Fuel Card Fees",
            "Office",
            "Sales Tax",
            "Scale",
            "Supplies",
            "Tolls",
            "Trailer Service",
            "Truck PM Service",
            "Truck Wash"});
            this.cbCategory.Location = new System.Drawing.Point(138, 38);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(130, 22);
            this.cbCategory.TabIndex = 2;
            // 
            // txtTrip
            // 
            this.txtTrip.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrip.Location = new System.Drawing.Point(28, 38);
            this.txtTrip.Name = "txtTrip";
            this.txtTrip.Size = new System.Drawing.Size(100, 22);
            this.txtTrip.TabIndex = 1;
            // 
            // lblInvoiceResume
            // 
            this.lblInvoiceResume.AutoSize = true;
            this.lblInvoiceResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceResume.ForeColor = System.Drawing.Color.Crimson;
            this.lblInvoiceResume.Location = new System.Drawing.Point(96, 142);
            this.lblInvoiceResume.Name = "lblInvoiceResume";
            this.lblInvoiceResume.Size = new System.Drawing.Size(46, 18);
            this.lblInvoiceResume.TabIndex = 204;
            this.lblInvoiceResume.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 203;
            this.label4.Text = "Invoice #";
            // 
            // dgvResumes
            // 
            this.dgvResumes.AllowUserToAddRows = false;
            this.dgvResumes.AllowUserToDeleteRows = false;
            this.dgvResumes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResumes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResumes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResumes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResumes.EnableHeadersVisualStyles = false;
            this.dgvResumes.Location = new System.Drawing.Point(25, 223);
            this.dgvResumes.Name = "dgvResumes";
            this.dgvResumes.ReadOnly = true;
            this.dgvResumes.Size = new System.Drawing.Size(731, 199);
            this.dgvResumes.TabIndex = 202;
            this.dgvResumes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResumes_CellContentClick);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(27, 177);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 17);
            this.label36.TabIndex = 201;
            this.label36.Text = "Search";
            // 
            // txtNotesSearch
            // 
            this.txtNotesSearch.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotesSearch.Location = new System.Drawing.Point(24, 191);
            this.txtNotesSearch.Name = "txtNotesSearch";
            this.txtNotesSearch.Size = new System.Drawing.Size(140, 25);
            this.txtNotesSearch.TabIndex = 196;
            this.txtNotesSearch.TextChanged += new System.EventHandler(this.txtNotesSearch_TextChanged);
            // 
            // btnResumeUpd
            // 
            this.btnResumeUpd.AutoSize = true;
            this.btnResumeUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnResumeUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnResumeUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumeUpd.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumeUpd.Location = new System.Drawing.Point(588, 192);
            this.btnResumeUpd.Name = "btnResumeUpd";
            this.btnResumeUpd.Size = new System.Drawing.Size(101, 26);
            this.btnResumeUpd.TabIndex = 200;
            this.btnResumeUpd.Text = "Update Resume";
            this.btnResumeUpd.UseVisualStyleBackColor = true;
            this.btnResumeUpd.Click += new System.EventHandler(this.btnResumeUpd_Click);
            // 
            // btnResumeDel
            // 
            this.btnResumeDel.AutoSize = true;
            this.btnResumeDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnResumeDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnResumeDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumeDel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumeDel.Location = new System.Drawing.Point(475, 191);
            this.btnResumeDel.Name = "btnResumeDel";
            this.btnResumeDel.Size = new System.Drawing.Size(96, 26);
            this.btnResumeDel.TabIndex = 199;
            this.btnResumeDel.Text = "Delete Resume";
            this.btnResumeDel.UseVisualStyleBackColor = true;
            this.btnResumeDel.Click += new System.EventHandler(this.btnResumeDel_Click);
            // 
            // btnResumeAdd
            // 
            this.btnResumeAdd.AutoSize = true;
            this.btnResumeAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnResumeAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnResumeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumeAdd.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumeAdd.Location = new System.Drawing.Point(369, 191);
            this.btnResumeAdd.Name = "btnResumeAdd";
            this.btnResumeAdd.Size = new System.Drawing.Size(84, 26);
            this.btnResumeAdd.TabIndex = 198;
            this.btnResumeAdd.Text = "Add Resume";
            this.btnResumeAdd.UseVisualStyleBackColor = true;
            this.btnResumeAdd.Click += new System.EventHandler(this.btnResumeAdd_Click);
            // 
            // btnClearTrip
            // 
            this.btnClearTrip.AutoSize = true;
            this.btnClearTrip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnClearTrip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTrip.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearTrip.Location = new System.Drawing.Point(170, 192);
            this.btnClearTrip.Name = "btnClearTrip";
            this.btnClearTrip.Size = new System.Drawing.Size(101, 26);
            this.btnClearTrip.TabIndex = 197;
            this.btnClearTrip.Text = "Clear Screen";
            this.btnClearTrip.UseVisualStyleBackColor = true;
            this.btnClearTrip.Click += new System.EventHandler(this.btnClearTrip_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 205;
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
            // frmResumens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblInvoiceResume);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvResumes);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.txtNotesSearch);
            this.Controls.Add(this.btnResumeUpd);
            this.Controls.Add(this.btnResumeDel);
            this.Controls.Add(this.btnResumeAdd);
            this.Controls.Add(this.btnClearTrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmResumens";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resumes Invoice";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumes)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox txtPrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtTrip;
        private System.Windows.Forms.Label lblInvoiceResume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvResumes;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtNotesSearch;
        private System.Windows.Forms.Button btnResumeUpd;
        private System.Windows.Forms.Button btnResumeDel;
        private System.Windows.Forms.Button btnResumeAdd;
        private System.Windows.Forms.Button btnClearTrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}