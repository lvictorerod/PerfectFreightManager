namespace Perfect_Freight_Manager.Forms.Revenue
{
    partial class frmNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotes));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPayAmount = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dgvDescNotes = new System.Windows.Forms.DataGridView();
            this.label36 = new System.Windows.Forms.Label();
            this.txtNotesSearch = new System.Windows.Forms.TextBox();
            this.btnNotesUpd = new System.Windows.Forms.Button();
            this.btnNotesDel = new System.Windows.Forms.Button();
            this.btnNotesAdd = new System.Windows.Forms.Button();
            this.btnClearTrip = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCodigodNotes = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescNotes)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtPayAmount);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbCategory);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Location = new System.Drawing.Point(41, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(724, 110);
            this.groupBox3.TabIndex = 184;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Description/Notes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 101;
            this.label1.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(568, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 100;
            this.label2.Text = "Pay Amount";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayAmount.Location = new System.Drawing.Point(563, 37);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(105, 22);
            this.txtPayAmount.TabIndex = 2;
            this.txtPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(403, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pay Category";
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.SystemColors.Window;
            this.cbCategory.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Detention",
            "Drop-Pickup",
            "Fuel Surg",
            "Layover",
            "Line Haul",
            "Load-Unload"});
            this.cbCategory.Location = new System.Drawing.Point(403, 38);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(154, 22);
            this.cbCategory.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(35, 38);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(362, 31);
            this.txtDescription.TabIndex = 0;
            // 
            // dgvDescNotes
            // 
            this.dgvDescNotes.AllowUserToAddRows = false;
            this.dgvDescNotes.AllowUserToDeleteRows = false;
            this.dgvDescNotes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDescNotes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDescNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDescNotes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDescNotes.EnableHeadersVisualStyles = false;
            this.dgvDescNotes.Location = new System.Drawing.Point(41, 239);
            this.dgvDescNotes.Name = "dgvDescNotes";
            this.dgvDescNotes.ReadOnly = true;
            this.dgvDescNotes.Size = new System.Drawing.Size(724, 199);
            this.dgvDescNotes.TabIndex = 192;
            this.dgvDescNotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDescNotes_CellContentClick);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(43, 193);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 17);
            this.label36.TabIndex = 191;
            this.label36.Text = "Search";
            // 
            // txtNotesSearch
            // 
            this.txtNotesSearch.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotesSearch.Location = new System.Drawing.Point(40, 207);
            this.txtNotesSearch.Name = "txtNotesSearch";
            this.txtNotesSearch.Size = new System.Drawing.Size(140, 25);
            this.txtNotesSearch.TabIndex = 185;
            this.txtNotesSearch.TextChanged += new System.EventHandler(this.txtNotesSearch_TextChanged_1);
            // 
            // btnNotesUpd
            // 
            this.btnNotesUpd.AutoSize = true;
            this.btnNotesUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnNotesUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNotesUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotesUpd.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotesUpd.Location = new System.Drawing.Point(603, 208);
            this.btnNotesUpd.Name = "btnNotesUpd";
            this.btnNotesUpd.Size = new System.Drawing.Size(89, 26);
            this.btnNotesUpd.TabIndex = 189;
            this.btnNotesUpd.Text = "Update Notes";
            this.btnNotesUpd.UseVisualStyleBackColor = true;
            this.btnNotesUpd.Click += new System.EventHandler(this.btnNotesUpd_Click);
            // 
            // btnNotesDel
            // 
            this.btnNotesDel.AutoSize = true;
            this.btnNotesDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnNotesDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNotesDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotesDel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotesDel.Location = new System.Drawing.Point(468, 208);
            this.btnNotesDel.Name = "btnNotesDel";
            this.btnNotesDel.Size = new System.Drawing.Size(84, 26);
            this.btnNotesDel.TabIndex = 188;
            this.btnNotesDel.Text = "Delete Notes";
            this.btnNotesDel.UseVisualStyleBackColor = true;
            this.btnNotesDel.Click += new System.EventHandler(this.btnNotesDel_Click);
            // 
            // btnNotesAdd
            // 
            this.btnNotesAdd.AutoSize = true;
            this.btnNotesAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnNotesAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNotesAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotesAdd.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotesAdd.Location = new System.Drawing.Point(340, 208);
            this.btnNotesAdd.Name = "btnNotesAdd";
            this.btnNotesAdd.Size = new System.Drawing.Size(75, 26);
            this.btnNotesAdd.TabIndex = 187;
            this.btnNotesAdd.Text = "Add Notes";
            this.btnNotesAdd.UseVisualStyleBackColor = true;
            this.btnNotesAdd.Click += new System.EventHandler(this.btnNotesAdd_Click);
            // 
            // btnClearTrip
            // 
            this.btnClearTrip.AutoSize = true;
            this.btnClearTrip.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnClearTrip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClearTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTrip.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearTrip.Location = new System.Drawing.Point(186, 208);
            this.btnClearTrip.Name = "btnClearTrip";
            this.btnClearTrip.Size = new System.Drawing.Size(101, 26);
            this.btnClearTrip.TabIndex = 186;
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
            this.menuStrip1.TabIndex = 193;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 194;
            this.label4.Text = "LoadId";
            // 
            // lblCodigodNotes
            // 
            this.lblCodigodNotes.AutoSize = true;
            this.lblCodigodNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigodNotes.ForeColor = System.Drawing.Color.Crimson;
            this.lblCodigodNotes.Location = new System.Drawing.Point(98, 158);
            this.lblCodigodNotes.Name = "lblCodigodNotes";
            this.lblCodigodNotes.Size = new System.Drawing.Size(46, 18);
            this.lblCodigodNotes.TabIndex = 195;
            this.lblCodigodNotes.Text = "label5";
            // 
            // frmNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCodigodNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDescNotes);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.txtNotesSearch);
            this.Controls.Add(this.btnNotesUpd);
            this.Controls.Add(this.btnNotesDel);
            this.Controls.Add(this.btnNotesAdd);
            this.Controls.Add(this.btnClearTrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descriptions/Notes";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescNotes)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtPayAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DataGridView dgvDescNotes;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtNotesSearch;
        private System.Windows.Forms.Button btnNotesUpd;
        private System.Windows.Forms.Button btnNotesDel;
        private System.Windows.Forms.Button btnNotesAdd;
        private System.Windows.Forms.Button btnClearTrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCodigodNotes;
    }
}