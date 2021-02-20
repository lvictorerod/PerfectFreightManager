namespace Perfect_Freight_Manager.Forms.Revenue
{
    partial class frmDriverPay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDriverPay));
            this.dgvDriver = new System.Windows.Forms.DataGridView();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnDriverPayUpd = new System.Windows.Forms.Button();
            this.btnAppoint = new System.Windows.Forms.Button();
            this.lbPosition = new System.Windows.Forms.Label();
            this.lbRecord = new System.Windows.Forms.Label();
            this.btnClearTPay = new System.Windows.Forms.Button();
            this.btnPaySettlement = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbExtraordinary = new System.Windows.Forms.RadioButton();
            this.lbAdvertency = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtDeductions = new System.Windows.Forms.TextBox();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.dgvDeductions = new System.Windows.Forms.DataGridView();
            this.deduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPay = new System.Windows.Forms.DataGridView();
            this.method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ammount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label26 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtDriverSettlement = new System.Windows.Forms.DateTimePicker();
            this.lbDriverName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDriverPayMethod = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotalBonus = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVacations = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalPayDue = new System.Windows.Forms.TextBox();
            this.txtTotalDeduction = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalRevenue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTripEnd = new System.Windows.Forms.Button();
            this.btnTripNext = new System.Windows.Forms.Button();
            this.btnTripPrevios = new System.Windows.Forms.Button();
            this.btnTripFirst = new System.Windows.Forms.Button();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriver)).BeginInit();
            this.groupBox16.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPay)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDriver
            // 
            this.dgvDriver.AllowUserToAddRows = false;
            this.dgvDriver.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDriver.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDriver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDriver.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDriver.EnableHeadersVisualStyles = false;
            this.dgvDriver.Location = new System.Drawing.Point(138, 698);
            this.dgvDriver.Name = "dgvDriver";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDriver.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDriver.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDriver.Size = new System.Drawing.Size(1053, 112);
            this.dgvDriver.TabIndex = 185;
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.LightGray;
            this.groupBox16.Controls.Add(this.btnDriverPayUpd);
            this.groupBox16.Controls.Add(this.btnAppoint);
            this.groupBox16.Controls.Add(this.lbPosition);
            this.groupBox16.Controls.Add(this.lbRecord);
            this.groupBox16.Controls.Add(this.btnTripEnd);
            this.groupBox16.Controls.Add(this.btnTripNext);
            this.groupBox16.Controls.Add(this.btnTripPrevios);
            this.groupBox16.Controls.Add(this.btnClearTPay);
            this.groupBox16.Controls.Add(this.btnTripFirst);
            this.groupBox16.Controls.Add(this.btnPaySettlement);
            this.groupBox16.Location = new System.Drawing.Point(138, 640);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(1053, 55);
            this.groupBox16.TabIndex = 186;
            this.groupBox16.TabStop = false;
            // 
            // btnDriverPayUpd
            // 
            this.btnDriverPayUpd.AutoSize = true;
            this.btnDriverPayUpd.BackColor = System.Drawing.Color.LightGray;
            this.btnDriverPayUpd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDriverPayUpd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDriverPayUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnDriverPayUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnDriverPayUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDriverPayUpd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDriverPayUpd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDriverPayUpd.Location = new System.Drawing.Point(452, 12);
            this.btnDriverPayUpd.Name = "btnDriverPayUpd";
            this.btnDriverPayUpd.Size = new System.Drawing.Size(112, 31);
            this.btnDriverPayUpd.TabIndex = 215;
            this.btnDriverPayUpd.Text = "Bonus Update";
            this.btnDriverPayUpd.UseVisualStyleBackColor = false;
            this.btnDriverPayUpd.Click += new System.EventHandler(this.btnDriverPayUpd_Click);
            // 
            // btnAppoint
            // 
            this.btnAppoint.AutoSize = true;
            this.btnAppoint.BackColor = System.Drawing.Color.LightGray;
            this.btnAppoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAppoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAppoint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnAppoint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnAppoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppoint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAppoint.Location = new System.Drawing.Point(741, 13);
            this.btnAppoint.Name = "btnAppoint";
            this.btnAppoint.Size = new System.Drawing.Size(134, 31);
            this.btnAppoint.TabIndex = 214;
            this.btnAppoint.Text = "Report Settlement";
            this.btnAppoint.UseVisualStyleBackColor = false;
            this.btnAppoint.Click += new System.EventHandler(this.btnAppoint_Click);
            // 
            // lbPosition
            // 
            this.lbPosition.AutoSize = true;
            this.lbPosition.BackColor = System.Drawing.Color.Gold;
            this.lbPosition.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosition.Location = new System.Drawing.Point(328, 41);
            this.lbPosition.Name = "lbPosition";
            this.lbPosition.Size = new System.Drawing.Size(68, 14);
            this.lbPosition.TabIndex = 213;
            this.lbPosition.Text = "Find City St.";
            this.lbPosition.Visible = false;
            // 
            // lbRecord
            // 
            this.lbRecord.AutoSize = true;
            this.lbRecord.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecord.ForeColor = System.Drawing.Color.Crimson;
            this.lbRecord.Location = new System.Drawing.Point(130, 19);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(70, 17);
            this.lbRecord.TabIndex = 212;
            this.lbRecord.Text = "label159";
            // 
            // btnClearTPay
            // 
            this.btnClearTPay.AutoSize = true;
            this.btnClearTPay.BackColor = System.Drawing.Color.LightGray;
            this.btnClearTPay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClearTPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearTPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnClearTPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnClearTPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearTPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearTPay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearTPay.Location = new System.Drawing.Point(10, 13);
            this.btnClearTPay.Name = "btnClearTPay";
            this.btnClearTPay.Size = new System.Drawing.Size(115, 31);
            this.btnClearTPay.TabIndex = 3;
            this.btnClearTPay.Text = "Clear Screen";
            this.btnClearTPay.UseVisualStyleBackColor = false;
            this.btnClearTPay.Click += new System.EventHandler(this.btnClearPay_Click);
            // 
            // btnPaySettlement
            // 
            this.btnPaySettlement.AutoSize = true;
            this.btnPaySettlement.BackColor = System.Drawing.Color.LightGray;
            this.btnPaySettlement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPaySettlement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaySettlement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnPaySettlement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnPaySettlement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaySettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaySettlement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPaySettlement.Location = new System.Drawing.Point(599, 13);
            this.btnPaySettlement.Name = "btnPaySettlement";
            this.btnPaySettlement.Size = new System.Drawing.Size(112, 31);
            this.btnPaySettlement.TabIndex = 0;
            this.btnPaySettlement.Text = "Pay Settlement";
            this.btnPaySettlement.UseVisualStyleBackColor = false;
            this.btnPaySettlement.Click += new System.EventHandler(this.btnPaySettlement_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1404, 24);
            this.menuStrip1.TabIndex = 187;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbExtraordinary);
            this.groupBox1.Controls.Add(this.lbAdvertency);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtDateFrom);
            this.groupBox1.Controls.Add(this.txtBonus);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtDateTo);
            this.groupBox1.Controls.Add(this.txtDeductions);
            this.groupBox1.Controls.Add(this.txtPay);
            this.groupBox1.Controls.Add(this.dgvDeductions);
            this.groupBox1.Controls.Add(this.dgvPay);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtDriverSettlement);
            this.groupBox1.Controls.Add(this.lbDriverName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbDriverPayMethod);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(138, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1053, 606);
            this.groupBox1.TabIndex = 188;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Pay and Deductions";
            // 
            // rbExtraordinary
            // 
            this.rbExtraordinary.AutoSize = true;
            this.rbExtraordinary.Location = new System.Drawing.Point(32, 418);
            this.rbExtraordinary.Name = "rbExtraordinary";
            this.rbExtraordinary.Size = new System.Drawing.Size(232, 28);
            this.rbExtraordinary.TabIndex = 1;
            this.rbExtraordinary.Text = "Settlement Extraordinary";
            this.rbExtraordinary.UseVisualStyleBackColor = true;
            // 
            // lbAdvertency
            // 
            this.lbAdvertency.AutoSize = true;
            this.lbAdvertency.Location = new System.Drawing.Point(340, 257);
            this.lbAdvertency.Name = "lbAdvertency";
            this.lbAdvertency.Size = new System.Drawing.Size(379, 24);
            this.lbAdvertency.TabIndex = 81;
            this.lbAdvertency.Text = "You should select the range of date from - to";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(415, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 16);
            this.label14.TabIndex = 80;
            this.label14.Text = "Date to Pay";
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Checked = false;
            this.dtDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateFrom.Location = new System.Drawing.Point(510, 46);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.ShowCheckBox = true;
            this.dtDateFrom.Size = new System.Drawing.Size(237, 22);
            this.dtDateFrom.TabIndex = 0;
            // 
            // txtBonus
            // 
            this.txtBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBonus.Location = new System.Drawing.Point(385, 423);
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(100, 22);
            this.txtBonus.TabIndex = 5;
            this.txtBonus.Text = "0";
            this.txtBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBonus_KeyPress);
            this.txtBonus.Leave += new System.EventHandler(this.txtBonus_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(307, 426);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 77;
            this.label12.Text = "Bonus (+/-)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(753, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 16);
            this.label11.TabIndex = 76;
            this.label11.Text = "To:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(457, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 16);
            this.label10.TabIndex = 75;
            this.label10.Text = "From:";
            // 
            // dtDateTo
            // 
            this.dtDateTo.Checked = false;
            this.dtDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateTo.Location = new System.Drawing.Point(790, 46);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.ShowCheckBox = true;
            this.dtDateTo.Size = new System.Drawing.Size(237, 22);
            this.dtDateTo.TabIndex = 1;
            this.dtDateTo.Leave += new System.EventHandler(this.dtDateTo_Leave);
            // 
            // txtDeductions
            // 
            this.txtDeductions.BackColor = System.Drawing.Color.LightGray;
            this.txtDeductions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeductions.Location = new System.Drawing.Point(855, 360);
            this.txtDeductions.Name = "txtDeductions";
            this.txtDeductions.ReadOnly = true;
            this.txtDeductions.Size = new System.Drawing.Size(136, 22);
            this.txtDeductions.TabIndex = 4;
            this.txtDeductions.Text = "0.00";
            this.txtDeductions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPay
            // 
            this.txtPay.BackColor = System.Drawing.Color.LightGray;
            this.txtPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPay.Location = new System.Drawing.Point(349, 360);
            this.txtPay.Name = "txtPay";
            this.txtPay.ReadOnly = true;
            this.txtPay.Size = new System.Drawing.Size(136, 22);
            this.txtPay.TabIndex = 3;
            this.txtPay.Text = "0.00";
            this.txtPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvDeductions
            // 
            this.dgvDeductions.AllowUserToAddRows = false;
            this.dgvDeductions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeductions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeductions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deduction,
            this.cantidad});
            this.dgvDeductions.EnableHeadersVisualStyles = false;
            this.dgvDeductions.Location = new System.Drawing.Point(548, 155);
            this.dgvDeductions.Name = "dgvDeductions";
            this.dgvDeductions.ReadOnly = true;
            this.dgvDeductions.Size = new System.Drawing.Size(443, 188);
            this.dgvDeductions.TabIndex = 70;
            // 
            // deduction
            // 
            this.deduction.HeaderText = "Deduction Type";
            this.deduction.Name = "deduction";
            this.deduction.ReadOnly = true;
            this.deduction.Width = 300;
            // 
            // cantidad
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle5;
            this.cantidad.HeaderText = "Ammount";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // dgvPay
            // 
            this.dgvPay.AllowUserToAddRows = false;
            this.dgvPay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.method,
            this.ammount});
            this.dgvPay.EnableHeadersVisualStyles = false;
            this.dgvPay.Location = new System.Drawing.Point(42, 155);
            this.dgvPay.Name = "dgvPay";
            this.dgvPay.ReadOnly = true;
            this.dgvPay.Size = new System.Drawing.Size(443, 188);
            this.dgvPay.TabIndex = 69;
            // 
            // method
            // 
            this.method.HeaderText = "Pay Type";
            this.method.Name = "method";
            this.method.ReadOnly = true;
            this.method.Width = 300;
            // 
            // ammount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ammount.DefaultCellStyle = dataGridViewCellStyle7;
            this.ammount.HeaderText = "Ammount";
            this.ammount.Name = "ammount";
            this.ammount.ReadOnly = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(736, 363);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 16);
            this.label26.TabIndex = 67;
            this.label26.Text = "Total Deductions:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(507, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 16);
            this.label6.TabIndex = 65;
            this.label6.Text = "Select Date Driver Settlement";
            // 
            // dtDriverSettlement
            // 
            this.dtDriverSettlement.Checked = false;
            this.dtDriverSettlement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDriverSettlement.Location = new System.Drawing.Point(510, 83);
            this.dtDriverSettlement.Name = "dtDriverSettlement";
            this.dtDriverSettlement.ShowCheckBox = true;
            this.dtDriverSettlement.Size = new System.Drawing.Size(237, 22);
            this.dtDriverSettlement.TabIndex = 2;
            // 
            // lbDriverName
            // 
            this.lbDriverName.AutoSize = true;
            this.lbDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDriverName.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbDriverName.Location = new System.Drawing.Point(116, 44);
            this.lbDriverName.Name = "lbDriverName";
            this.lbDriverName.Size = new System.Drawing.Size(51, 16);
            this.lbDriverName.TabIndex = 63;
            this.lbDriverName.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(11, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "Driver Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(544, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 61;
            this.label2.Text = "Deductions";
            // 
            // lbDriverPayMethod
            // 
            this.lbDriverPayMethod.AutoSize = true;
            this.lbDriverPayMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDriverPayMethod.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbDriverPayMethod.Location = new System.Drawing.Point(139, 128);
            this.lbDriverPayMethod.Name = "lbDriverPayMethod";
            this.lbDriverPayMethod.Size = new System.Drawing.Size(51, 16);
            this.lbDriverPayMethod.TabIndex = 60;
            this.lbDriverPayMethod.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(39, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "Pay Method:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.txtTotalBonus);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtVacations);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTotalPayDue);
            this.groupBox2.Controls.Add(this.txtTotalDeduction);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtTotalRevenue);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(548, 394);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 203);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resume";
            // 
            // txtTotalBonus
            // 
            this.txtTotalBonus.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBonus.Location = new System.Drawing.Point(161, 87);
            this.txtTotalBonus.Name = "txtTotalBonus";
            this.txtTotalBonus.ReadOnly = true;
            this.txtTotalBonus.Size = new System.Drawing.Size(100, 22);
            this.txtTotalBonus.TabIndex = 2;
            this.txtTotalBonus.Text = "0.00";
            this.txtTotalBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(75, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 76;
            this.label13.Text = "Total Bonus";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVacations
            // 
            this.txtVacations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVacations.Location = new System.Drawing.Point(161, 167);
            this.txtVacations.Name = "txtVacations";
            this.txtVacations.ReadOnly = true;
            this.txtVacations.Size = new System.Drawing.Size(100, 22);
            this.txtVacations.TabIndex = 4;
            this.txtVacations.Text = "0.00";
            this.txtVacations.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(87, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 74;
            this.label9.Text = "Vacations";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalPayDue
            // 
            this.txtTotalPayDue.BackColor = System.Drawing.Color.LightGray;
            this.txtTotalPayDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPayDue.Location = new System.Drawing.Point(161, 127);
            this.txtTotalPayDue.Name = "txtTotalPayDue";
            this.txtTotalPayDue.ReadOnly = true;
            this.txtTotalPayDue.Size = new System.Drawing.Size(100, 22);
            this.txtTotalPayDue.TabIndex = 3;
            this.txtTotalPayDue.Text = "0.00";
            this.txtTotalPayDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalDeduction
            // 
            this.txtTotalDeduction.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalDeduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDeduction.Location = new System.Drawing.Point(161, 59);
            this.txtTotalDeduction.Name = "txtTotalDeduction";
            this.txtTotalDeduction.ReadOnly = true;
            this.txtTotalDeduction.Size = new System.Drawing.Size(100, 22);
            this.txtTotalDeduction.TabIndex = 1;
            this.txtTotalDeduction.Text = "0.00";
            this.txtTotalDeduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Total Driver Pay Due";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalRevenue
            // 
            this.txtTotalRevenue.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRevenue.Location = new System.Drawing.Point(161, 32);
            this.txtTotalRevenue.Name = "txtTotalRevenue";
            this.txtTotalRevenue.ReadOnly = true;
            this.txtTotalRevenue.Size = new System.Drawing.Size(100, 22);
            this.txtTotalRevenue.TabIndex = 0;
            this.txtTotalRevenue.Text = "0.00";
            this.txtTotalRevenue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(52, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Deduction";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Revenue";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(243, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Total Revenue:";
            // 
            // btnTripEnd
            // 
            this.btnTripEnd.AutoSize = true;
            this.btnTripEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnTripEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTripEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTripEnd.FlatAppearance.BorderSize = 0;
            this.btnTripEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnTripEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnTripEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripEnd.Image = global::Perfect_Freight_Manager.Properties.Resources.btnendt;
            this.btnTripEnd.Location = new System.Drawing.Point(393, 8);
            this.btnTripEnd.Name = "btnTripEnd";
            this.btnTripEnd.Size = new System.Drawing.Size(38, 38);
            this.btnTripEnd.TabIndex = 8;
            this.btnTripEnd.UseVisualStyleBackColor = false;
            this.btnTripEnd.Click += new System.EventHandler(this.btnTripEnd_Click);
            // 
            // btnTripNext
            // 
            this.btnTripNext.AutoSize = true;
            this.btnTripNext.BackColor = System.Drawing.Color.Transparent;
            this.btnTripNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTripNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTripNext.FlatAppearance.BorderSize = 0;
            this.btnTripNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnTripNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnTripNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripNext.Image = global::Perfect_Freight_Manager.Properties.Resources.btnright;
            this.btnTripNext.Location = new System.Drawing.Point(355, 8);
            this.btnTripNext.Name = "btnTripNext";
            this.btnTripNext.Size = new System.Drawing.Size(38, 38);
            this.btnTripNext.TabIndex = 7;
            this.btnTripNext.UseVisualStyleBackColor = false;
            this.btnTripNext.Click += new System.EventHandler(this.btnTripNext_Click);
            // 
            // btnTripPrevios
            // 
            this.btnTripPrevios.AutoSize = true;
            this.btnTripPrevios.BackColor = System.Drawing.Color.Transparent;
            this.btnTripPrevios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTripPrevios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTripPrevios.FlatAppearance.BorderSize = 0;
            this.btnTripPrevios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnTripPrevios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnTripPrevios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripPrevios.Image = global::Perfect_Freight_Manager.Properties.Resources.btnleft;
            this.btnTripPrevios.Location = new System.Drawing.Point(317, 8);
            this.btnTripPrevios.Name = "btnTripPrevios";
            this.btnTripPrevios.Size = new System.Drawing.Size(38, 38);
            this.btnTripPrevios.TabIndex = 6;
            this.btnTripPrevios.UseVisualStyleBackColor = false;
            this.btnTripPrevios.Click += new System.EventHandler(this.btnTripPrevios_Click);
            // 
            // btnTripFirst
            // 
            this.btnTripFirst.AutoSize = true;
            this.btnTripFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnTripFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTripFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTripFirst.FlatAppearance.BorderSize = 0;
            this.btnTripFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnTripFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnTripFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTripFirst.Image = global::Perfect_Freight_Manager.Properties.Resources.btnfirst;
            this.btnTripFirst.Location = new System.Drawing.Point(279, 8);
            this.btnTripFirst.Name = "btnTripFirst";
            this.btnTripFirst.Size = new System.Drawing.Size(38, 38);
            this.btnTripFirst.TabIndex = 5;
            this.btnTripFirst.UseVisualStyleBackColor = false;
            this.btnTripFirst.Click += new System.EventHandler(this.btnTripFirst_Click);
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filesToolStripMenuItem.Image")));
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.filesToolStripMenuItem.Text = "Return";
            this.filesToolStripMenuItem.Click += new System.EventHandler(this.filesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // frmDriverPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 811);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox16);
            this.Controls.Add(this.dgvDriver);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDriverPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Driver Pay";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriver)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDriver;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.Button btnTripEnd;
        private System.Windows.Forms.Button btnTripNext;
        private System.Windows.Forms.Button btnTripPrevios;
        private System.Windows.Forms.Button btnClearTPay;
        private System.Windows.Forms.Button btnTripFirst;
        private System.Windows.Forms.Button btnPaySettlement;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDriverPayMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbDriverName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtDriverSettlement;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DataGridView dgvPay;
        private System.Windows.Forms.DataGridView dgvDeductions;
        private System.Windows.Forms.DataGridViewTextBoxColumn method;
        private System.Windows.Forms.DataGridViewTextBoxColumn ammount;
        private System.Windows.Forms.TextBox txtTotalRevenue;
        private System.Windows.Forms.TextBox txtTotalPayDue;
        private System.Windows.Forms.TextBox txtTotalDeduction;
        private System.Windows.Forms.TextBox txtDeductions;
        private System.Windows.Forms.TextBox txtPay;
        private System.Windows.Forms.TextBox txtVacations;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn deduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalBonus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.Button btnAppoint;
        private System.Windows.Forms.Button btnDriverPayUpd;
        private System.Windows.Forms.Label lbAdvertency;
        private System.Windows.Forms.RadioButton rbExtraordinary;
    }
}