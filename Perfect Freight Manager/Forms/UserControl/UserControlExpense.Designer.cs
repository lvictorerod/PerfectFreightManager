namespace Perfect_Freight_Manager.Forms
{
    partial class UserControlExpense
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlExpense));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReportExpenses = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnVendor = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtZip = new System.Windows.Forms.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblApu = new System.Windows.Forms.Label();
            this.lblTrailer = new System.Windows.Forms.Label();
            this.lblTruck = new System.Windows.Forms.Label();
            this.btnSearchApu = new System.Windows.Forms.Button();
            this.btnSearchTrailer = new System.Windows.Forms.Button();
            this.btnSearchTruck = new System.Windows.Forms.Button();
            this.lblAddResumes = new System.Windows.Forms.Label();
            this.btnAddNotes = new System.Windows.Forms.Button();
            this.txtApu = new System.Windows.Forms.TextBox();
            this.txtTrailer = new System.Windows.Forms.TextBox();
            this.txtTruck = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.txtSearchExpenses = new System.Windows.Forms.TextBox();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkPmTruck = new System.Windows.Forms.CheckBox();
            this.txtApuHours = new System.Windows.Forms.TextBox();
            this.txtTrailerMileage = new System.Windows.Forms.TextBox();
            this.txtTruckMileage = new System.Windows.Forms.TextBox();
            this.cbPayment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 40);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(500, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReportExpenses);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Controls.Add(this.lblApu);
            this.groupBox1.Controls.Add(this.lblTrailer);
            this.groupBox1.Controls.Add(this.lblTruck);
            this.groupBox1.Controls.Add(this.btnSearchApu);
            this.groupBox1.Controls.Add(this.btnSearchTrailer);
            this.groupBox1.Controls.Add(this.btnSearchTruck);
            this.groupBox1.Controls.Add(this.lblAddResumes);
            this.groupBox1.Controls.Add(this.btnAddNotes);
            this.groupBox1.Controls.Add(this.txtApu);
            this.groupBox1.Controls.Add(this.txtTrailer);
            this.groupBox1.Controls.Add(this.txtTruck);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.dgvExpenses);
            this.groupBox1.Controls.Add(this.txtSearchExpenses);
            this.groupBox1.Controls.Add(this.btnUpd);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkPmTruck);
            this.groupBox1.Controls.Add(this.txtApuHours);
            this.groupBox1.Controls.Add(this.txtTrailerMileage);
            this.groupBox1.Controls.Add(this.txtTruckMileage);
            this.groupBox1.Controls.Add(this.cbPayment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInvoice);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 800);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expenses by Invoices";
            // 
            // btnReportExpenses
            // 
            this.btnReportExpenses.AutoSize = true;
            this.btnReportExpenses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnReportExpenses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnReportExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportExpenses.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportExpenses.Location = new System.Drawing.Point(774, 387);
            this.btnReportExpenses.Name = "btnReportExpenses";
            this.btnReportExpenses.Size = new System.Drawing.Size(106, 26);
            this.btnReportExpenses.TabIndex = 17;
            this.btnReportExpenses.Text = "Report Expenses";
            this.btnReportExpenses.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblVendor);
            this.groupBox2.Controls.Add(this.btnVendor);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.txtZip);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtState);
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.txtContact);
            this.groupBox2.Controls.Add(this.txtVendor);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtNotes);
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1034, 135);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information of Vendor";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.BackColor = System.Drawing.Color.Gold;
            this.lblVendor.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendor.Location = new System.Drawing.Point(362, 51);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(70, 14);
            this.lblVendor.TabIndex = 271;
            this.lblVendor.Text = "Find Vendor";
            this.lblVendor.Visible = false;
            // 
            // btnVendor
            // 
            this.btnVendor.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnVendor.FlatAppearance.BorderSize = 2;
            this.btnVendor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnVendor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVendor.Image = ((System.Drawing.Image)(resources.GetObject("btnVendor.Image")));
            this.btnVendor.Location = new System.Drawing.Point(338, 25);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(28, 27);
            this.btnVendor.TabIndex = 270;
            this.btnVendor.Tag = "Find Shipper";
            this.btnVendor.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(444, 70);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(100, 22);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtZip
            // 
            this.txtZip.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZip.Location = new System.Drawing.Point(247, 101);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(70, 22);
            this.txtZip.TabIndex = 6;
            this.txtZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(19, 104);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 14);
            this.label22.TabIndex = 269;
            this.label22.Text = "City,St,Zip";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(389, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(49, 14);
            this.label21.TabIndex = 268;
            this.label21.Text = "Address";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(30, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 14);
            this.label20.TabIndex = 267;
            this.label20.Text = "Contact";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(397, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 14);
            this.label19.TabIndex = 266;
            this.label19.Text = "Phone";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(32, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 14);
            this.label18.TabIndex = 265;
            this.label18.Text = "Vendor";
            // 
            // txtState
            // 
            this.txtState.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Location = new System.Drawing.Point(202, 101);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(39, 22);
            this.txtState.TabIndex = 5;
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(82, 101);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(114, 22);
            this.txtCity.TabIndex = 4;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(444, 28);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.Size = new System.Drawing.Size(255, 36);
            this.txtAddress.TabIndex = 1;
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(82, 73);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(256, 22);
            this.txtContact.TabIndex = 2;
            // 
            // txtVendor
            // 
            this.txtVendor.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendor.Location = new System.Drawing.Point(82, 28);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(256, 22);
            this.txtVendor.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(710, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 14);
            this.label11.TabIndex = 264;
            this.label11.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(713, 28);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(277, 92);
            this.txtNotes.TabIndex = 7;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "M/d/yyyy H:mm";
            this.dtDate.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(98, 77);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(144, 22);
            this.dtDate.TabIndex = 1;
            // 
            // lblApu
            // 
            this.lblApu.AutoSize = true;
            this.lblApu.BackColor = System.Drawing.Color.Gold;
            this.lblApu.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApu.Location = new System.Drawing.Point(482, 153);
            this.lblApu.Name = "lblApu";
            this.lblApu.Size = new System.Drawing.Size(55, 14);
            this.lblApu.TabIndex = 252;
            this.lblApu.Text = "Find APU";
            this.lblApu.Visible = false;
            // 
            // lblTrailer
            // 
            this.lblTrailer.AutoSize = true;
            this.lblTrailer.BackColor = System.Drawing.Color.Gold;
            this.lblTrailer.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrailer.Location = new System.Drawing.Point(482, 113);
            this.lblTrailer.Name = "lblTrailer";
            this.lblTrailer.Size = new System.Drawing.Size(68, 14);
            this.lblTrailer.TabIndex = 251;
            this.lblTrailer.Text = "Find Trailer";
            this.lblTrailer.Visible = false;
            // 
            // lblTruck
            // 
            this.lblTruck.AutoSize = true;
            this.lblTruck.BackColor = System.Drawing.Color.Gold;
            this.lblTruck.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTruck.Location = new System.Drawing.Point(481, 70);
            this.lblTruck.Name = "lblTruck";
            this.lblTruck.Size = new System.Drawing.Size(64, 14);
            this.lblTruck.TabIndex = 250;
            this.lblTruck.Text = "FInd Truck";
            this.lblTruck.Visible = false;
            // 
            // btnSearchApu
            // 
            this.btnSearchApu.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSearchApu.FlatAppearance.BorderSize = 2;
            this.btnSearchApu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnSearchApu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnSearchApu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchApu.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchApu.Image")));
            this.btnSearchApu.Location = new System.Drawing.Point(453, 127);
            this.btnSearchApu.Name = "btnSearchApu";
            this.btnSearchApu.Size = new System.Drawing.Size(28, 27);
            this.btnSearchApu.TabIndex = 213;
            this.btnSearchApu.Tag = "Find Shipper";
            this.btnSearchApu.UseVisualStyleBackColor = true;
            // 
            // btnSearchTrailer
            // 
            this.btnSearchTrailer.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSearchTrailer.FlatAppearance.BorderSize = 2;
            this.btnSearchTrailer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnSearchTrailer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnSearchTrailer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTrailer.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchTrailer.Image")));
            this.btnSearchTrailer.Location = new System.Drawing.Point(453, 87);
            this.btnSearchTrailer.Name = "btnSearchTrailer";
            this.btnSearchTrailer.Size = new System.Drawing.Size(28, 27);
            this.btnSearchTrailer.TabIndex = 211;
            this.btnSearchTrailer.Tag = "Find Shipper";
            this.btnSearchTrailer.UseVisualStyleBackColor = true;
            // 
            // btnSearchTruck
            // 
            this.btnSearchTruck.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSearchTruck.FlatAppearance.BorderSize = 2;
            this.btnSearchTruck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnSearchTruck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnSearchTruck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchTruck.Image")));
            this.btnSearchTruck.Location = new System.Drawing.Point(453, 47);
            this.btnSearchTruck.Name = "btnSearchTruck";
            this.btnSearchTruck.Size = new System.Drawing.Size(28, 27);
            this.btnSearchTruck.TabIndex = 209;
            this.btnSearchTruck.Tag = "Find Shipper";
            this.btnSearchTruck.UseVisualStyleBackColor = true;
            // 
            // lblAddResumes
            // 
            this.lblAddResumes.AutoSize = true;
            this.lblAddResumes.BackColor = System.Drawing.Color.Gold;
            this.lblAddResumes.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddResumes.Location = new System.Drawing.Point(614, 357);
            this.lblAddResumes.Name = "lblAddResumes";
            this.lblAddResumes.Size = new System.Drawing.Size(108, 14);
            this.lblAddResumes.TabIndex = 249;
            this.lblAddResumes.Text = "Add/View Resumes";
            this.lblAddResumes.Visible = false;
            // 
            // btnAddNotes
            // 
            this.btnAddNotes.AutoSize = true;
            this.btnAddNotes.Enabled = false;
            this.btnAddNotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnAddNotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnAddNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNotes.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNotes.Location = new System.Drawing.Point(468, 327);
            this.btnAddNotes.Name = "btnAddNotes";
            this.btnAddNotes.Size = new System.Drawing.Size(154, 27);
            this.btnAddNotes.TabIndex = 11;
            this.btnAddNotes.Text = "Resumes Invoice";
            this.btnAddNotes.UseVisualStyleBackColor = true;
            // 
            // txtApu
            // 
            this.txtApu.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApu.Location = new System.Drawing.Point(382, 130);
            this.txtApu.Name = "txtApu";
            this.txtApu.Size = new System.Drawing.Size(71, 22);
            this.txtApu.TabIndex = 5;
            this.txtApu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTrailer
            // 
            this.txtTrailer.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrailer.Location = new System.Drawing.Point(382, 89);
            this.txtTrailer.Name = "txtTrailer";
            this.txtTrailer.Size = new System.Drawing.Size(71, 22);
            this.txtTrailer.TabIndex = 4;
            this.txtTrailer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTruck
            // 
            this.txtTruck.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTruck.Location = new System.Drawing.Point(382, 48);
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(71, 22);
            this.txtTruck.TabIndex = 3;
            this.txtTruck.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(28, 372);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(50, 17);
            this.label53.TabIndex = 248;
            this.label53.Text = "Search";
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.AllowUserToAddRows = false;
            this.dgvExpenses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExpenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenses.EnableHeadersVisualStyles = false;
            this.dgvExpenses.Location = new System.Drawing.Point(22, 418);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.ReadOnly = true;
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(1025, 285);
            this.dgvExpenses.TabIndex = 18;
            // 
            // txtSearchExpenses
            // 
            this.txtSearchExpenses.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchExpenses.Location = new System.Drawing.Point(23, 387);
            this.txtSearchExpenses.Name = "txtSearchExpenses";
            this.txtSearchExpenses.Size = new System.Drawing.Size(140, 25);
            this.txtSearchExpenses.TabIndex = 12;
            // 
            // btnUpd
            // 
            this.btnUpd.AutoSize = true;
            this.btnUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpd.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpd.Location = new System.Drawing.Point(559, 385);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(124, 26);
            this.btnUpd.TabIndex = 16;
            this.btnUpd.Text = "Update Expenses";
            this.btnUpd.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.AutoSize = true;
            this.btnDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(442, 386);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(104, 26);
            this.btnDel.TabIndex = 15;
            this.btnDel.Text = "Delete Expenses";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(338, 386);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 26);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add Expenses";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.AutoSize = true;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(169, 387);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 26);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear Screen";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(684, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 14);
            this.label10.TabIndex = 233;
            this.label10.Text = "APU Hours";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(662, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 14);
            this.label9.TabIndex = 231;
            this.label9.Text = "Trailer Mileage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(667, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 14);
            this.label8.TabIndex = 230;
            this.label8.Text = "Truck Mileage";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(348, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 14);
            this.label7.TabIndex = 227;
            this.label7.Text = "APU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(325, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 225;
            this.label6.Text = "Trailer #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(330, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 224;
            this.label5.Text = "Truck #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 221;
            this.label4.Text = "Payment";
            // 
            // chkPmTruck
            // 
            this.chkPmTruck.AutoSize = true;
            this.chkPmTruck.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPmTruck.Location = new System.Drawing.Point(920, 52);
            this.chkPmTruck.Name = "chkPmTruck";
            this.chkPmTruck.Size = new System.Drawing.Size(73, 18);
            this.chkPmTruck.TabIndex = 9;
            this.chkPmTruck.Text = "PmTruck";
            this.chkPmTruck.UseVisualStyleBackColor = true;
            // 
            // txtApuHours
            // 
            this.txtApuHours.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApuHours.Location = new System.Drawing.Point(753, 113);
            this.txtApuHours.Name = "txtApuHours";
            this.txtApuHours.Size = new System.Drawing.Size(111, 22);
            this.txtApuHours.TabIndex = 8;
            this.txtApuHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTrailerMileage
            // 
            this.txtTrailerMileage.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrailerMileage.Location = new System.Drawing.Point(753, 82);
            this.txtTrailerMileage.Name = "txtTrailerMileage";
            this.txtTrailerMileage.Size = new System.Drawing.Size(111, 22);
            this.txtTrailerMileage.TabIndex = 7;
            this.txtTrailerMileage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTruckMileage
            // 
            this.txtTruckMileage.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTruckMileage.Location = new System.Drawing.Point(753, 49);
            this.txtTruckMileage.Name = "txtTruckMileage";
            this.txtTruckMileage.Size = new System.Drawing.Size(111, 22);
            this.txtTruckMileage.TabIndex = 6;
            this.txtTruckMileage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbPayment
            // 
            this.cbPayment.BackColor = System.Drawing.SystemColors.Menu;
            this.cbPayment.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPayment.FormattingEnabled = true;
            this.cbPayment.Items.AddRange(new object[] {
            "Cash",
            "ComCheck"});
            this.cbPayment.Location = new System.Drawing.Point(97, 106);
            this.cbPayment.Name = "cbPayment";
            this.cbPayment.Size = new System.Drawing.Size(114, 22);
            this.cbPayment.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 208;
            this.label3.Text = "Invoice #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 206;
            this.label2.Text = "Date";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.Location = new System.Drawing.Point(97, 49);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(114, 22);
            this.txtInvoice.TabIndex = 0;
            this.txtInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UserControlExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "UserControlExpense";
            this.Size = new System.Drawing.Size(1200, 800);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReportExpenses;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.MaskedTextBox txtZip;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblApu;
        private System.Windows.Forms.Label lblTrailer;
        private System.Windows.Forms.Label lblTruck;
        private System.Windows.Forms.Button btnSearchApu;
        private System.Windows.Forms.Button btnSearchTrailer;
        private System.Windows.Forms.Button btnSearchTruck;
        private System.Windows.Forms.Label lblAddResumes;
        private System.Windows.Forms.Button btnAddNotes;
        private System.Windows.Forms.TextBox txtApu;
        private System.Windows.Forms.TextBox txtTrailer;
        private System.Windows.Forms.TextBox txtTruck;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.TextBox txtSearchExpenses;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkPmTruck;
        private System.Windows.Forms.TextBox txtApuHours;
        private System.Windows.Forms.TextBox txtTrailerMileage;
        private System.Windows.Forms.TextBox txtTruckMileage;
        private System.Windows.Forms.ComboBox cbPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoice;
    }
}
