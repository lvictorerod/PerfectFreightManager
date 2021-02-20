namespace Perfect_Freight_Manager.Forms
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnTruck = new System.Windows.Forms.Button();
            this.Sidepanel = new System.Windows.Forms.Panel();
            this.pnUsuario = new System.Windows.Forms.Panel();
            this.pbUsuario = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnAdministration = new System.Windows.Forms.Button();
            this.btnCatalogs = new System.Windows.Forms.Button();
            this.btnTrip = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Colapsar = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.userControlExpense1 = new Perfect_Freight_Manager.Forms.UserControlExpense();
            this.userControlAdministration1 = new Perfect_Freight_Manager.Forms.UserControlAdministration();
            this.userControlUtilities1 = new Perfect_Freight_Manager.Forms.UserControlUtilities();
            this.userControlTruck1 = new Perfect_Freight_Manager.Forms.UserControlTruck();
            this.userControlRevenue1 = new Perfect_Freight_Manager.Forms.UserControlRevenue();
            this.userControlDashboard1 = new Perfect_Freight_Manager.Forms.UserControlDashboard();
            this.pnMenu.SuspendLayout();
            this.pnUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.pnMenu.BackColor = System.Drawing.Color.DimGray;
            this.pnMenu.Controls.Add(this.btnProfile);
            this.pnMenu.Controls.Add(this.btnTruck);
            this.pnMenu.Controls.Add(this.Sidepanel);
            this.pnMenu.Controls.Add(this.pnUsuario);
            this.pnMenu.Controls.Add(this.lblTime);
            this.pnMenu.Controls.Add(this.btnDashboard);
            this.pnMenu.Controls.Add(this.btnAdministration);
            this.pnMenu.Controls.Add(this.btnCatalogs);
            this.pnMenu.Controls.Add(this.btnTrip);
            this.pnMenu.Controls.Add(this.btnExpense);
            this.pnMenu.Controls.Add(this.btnLoad);
            this.pnMenu.Controls.Add(this.lblDate);
            this.pnMenu.Controls.Add(this.lblAppName);
            this.pnMenu.Location = new System.Drawing.Point(1, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(200, 850);
            this.pnMenu.TabIndex = 1;
            // 
            // btnProfile
            // 
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Image = global::Perfect_Freight_Manager.Properties.Resources.books_16px_white;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(10, 346);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(172, 32);
            this.btnProfile.TabIndex = 11;
            this.btnProfile.Text = "       Profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnTruck
            // 
            this.btnTruck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTruck.FlatAppearance.BorderSize = 0;
            this.btnTruck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruck.ForeColor = System.Drawing.Color.White;
            this.btnTruck.Image = global::Perfect_Freight_Manager.Properties.Resources.semi_truck_16px_white;
            this.btnTruck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTruck.Location = new System.Drawing.Point(10, 190);
            this.btnTruck.Name = "btnTruck";
            this.btnTruck.Size = new System.Drawing.Size(172, 32);
            this.btnTruck.TabIndex = 10;
            this.btnTruck.Text = "       Truck Fleet";
            this.btnTruck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTruck.UseVisualStyleBackColor = true;
            this.btnTruck.Click += new System.EventHandler(this.btnTruck_Click);
            // 
            // Sidepanel
            // 
            this.Sidepanel.BackColor = System.Drawing.Color.Crimson;
            this.Sidepanel.Location = new System.Drawing.Point(0, 112);
            this.Sidepanel.Name = "Sidepanel";
            this.Sidepanel.Size = new System.Drawing.Size(10, 32);
            this.Sidepanel.TabIndex = 2;
            // 
            // pnUsuario
            // 
            this.pnUsuario.Controls.Add(this.pbUsuario);
            this.pnUsuario.Controls.Add(this.button5);
            this.pnUsuario.Controls.Add(this.button4);
            this.pnUsuario.Controls.Add(this.button3);
            this.pnUsuario.Controls.Add(this.button2);
            this.pnUsuario.Controls.Add(this.btnUsuario);
            this.pnUsuario.Location = new System.Drawing.Point(0, 432);
            this.pnUsuario.MaximumSize = new System.Drawing.Size(210, 210);
            this.pnUsuario.MinimumSize = new System.Drawing.Size(210, 50);
            this.pnUsuario.Name = "pnUsuario";
            this.pnUsuario.Size = new System.Drawing.Size(210, 50);
            this.pnUsuario.TabIndex = 9;
            // 
            // pbUsuario
            // 
            this.pbUsuario.BackColor = System.Drawing.Color.DimGray;
            this.pbUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUsuario.Image = global::Perfect_Freight_Manager.Properties.Resources.male_user_16px_white;
            this.pbUsuario.Location = new System.Drawing.Point(15, 12);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.Size = new System.Drawing.Size(24, 24);
            this.pbUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUsuario.TabIndex = 11;
            this.pbUsuario.TabStop = false;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::Perfect_Freight_Manager.Properties.Resources.denied_16px_white;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(9, 126);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(173, 32);
            this.button5.TabIndex = 10;
            this.button5.Text = "       Delete Perfil";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::Perfect_Freight_Manager.Properties.Resources.communicate_16px_white;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(9, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 32);
            this.button4.TabIndex = 9;
            this.button4.Text = "       Close Sesion";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Perfect_Freight_Manager.Properties.Resources.add_user_16px_white;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(9, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 32);
            this.button3.TabIndex = 8;
            this.button3.Text = "       Add Perfil";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Perfect_Freight_Manager.Properties.Resources.registration_16px_white;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(9, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "      Edit Perfil";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnUsuario
            // 
            this.btnUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuario.FlatAppearance.BorderSize = 0;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.White;
            this.btnUsuario.Image = global::Perfect_Freight_Manager.Properties.Resources.forward_16px_white;
            this.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsuario.Location = new System.Drawing.Point(9, 9);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(173, 32);
            this.btnUsuario.TabIndex = 6;
            this.btnUsuario.Text = "             Add User";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(49, 74);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(41, 15);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "label1";
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.DimGray;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::Perfect_Freight_Manager.Properties.Resources.home_16px_white;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(10, 112);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(172, 32);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "       Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnAdministration
            // 
            this.btnAdministration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdministration.FlatAppearance.BorderSize = 0;
            this.btnAdministration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministration.ForeColor = System.Drawing.Color.White;
            this.btnAdministration.Image = global::Perfect_Freight_Manager.Properties.Resources.administrative_tools_16px_white;
            this.btnAdministration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministration.Location = new System.Drawing.Point(10, 385);
            this.btnAdministration.Name = "btnAdministration";
            this.btnAdministration.Size = new System.Drawing.Size(172, 32);
            this.btnAdministration.TabIndex = 5;
            this.btnAdministration.Text = "       Administration";
            this.btnAdministration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministration.UseVisualStyleBackColor = true;
            this.btnAdministration.Click += new System.EventHandler(this.btnAdministration_Click);
            // 
            // btnCatalogs
            // 
            this.btnCatalogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatalogs.FlatAppearance.BorderSize = 0;
            this.btnCatalogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogs.ForeColor = System.Drawing.Color.White;
            this.btnCatalogs.Image = global::Perfect_Freight_Manager.Properties.Resources.books_16px_white;
            this.btnCatalogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatalogs.Location = new System.Drawing.Point(10, 307);
            this.btnCatalogs.Name = "btnCatalogs";
            this.btnCatalogs.Size = new System.Drawing.Size(172, 32);
            this.btnCatalogs.TabIndex = 4;
            this.btnCatalogs.Text = "       Catalogs";
            this.btnCatalogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatalogs.UseVisualStyleBackColor = true;
            this.btnCatalogs.Click += new System.EventHandler(this.btnCatalogs_Click);
            // 
            // btnTrip
            // 
            this.btnTrip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrip.FlatAppearance.BorderSize = 0;
            this.btnTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrip.ForeColor = System.Drawing.Color.White;
            this.btnTrip.Image = global::Perfect_Freight_Manager.Properties.Resources.google_drive_16px_white;
            this.btnTrip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrip.Location = new System.Drawing.Point(10, 268);
            this.btnTrip.Name = "btnTrip";
            this.btnTrip.Size = new System.Drawing.Size(172, 32);
            this.btnTrip.TabIndex = 3;
            this.btnTrip.Text = "       Trip Planner";
            this.btnTrip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrip.UseVisualStyleBackColor = true;
            this.btnTrip.Click += new System.EventHandler(this.btnTrip_Click);
            // 
            // btnExpense
            // 
            this.btnExpense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpense.FlatAppearance.BorderSize = 0;
            this.btnExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpense.ForeColor = System.Drawing.Color.White;
            this.btnExpense.Image = global::Perfect_Freight_Manager.Properties.Resources.card_payment_16px_white;
            this.btnExpense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpense.Location = new System.Drawing.Point(10, 229);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(172, 32);
            this.btnExpense.TabIndex = 2;
            this.btnExpense.Text = "       Expense Invoices";
            this.btnExpense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.Click += new System.EventHandler(this.btnExpense_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Image = global::Perfect_Freight_Manager.Properties.Resources.process_16px;
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(10, 151);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(172, 32);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "       Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(4, 53);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 15);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "label1";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(5, 14);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(158, 25);
            this.lblAppName.TabIndex = 6;
            this.lblAppName.Text = "Perfect Freight";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Colapsar
            // 
            this.Colapsar.Enabled = true;
            this.Colapsar.Interval = 10;
            this.Colapsar.Tick += new System.EventHandler(this.Colapsar_Tick_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            // 
            // userControlExpense1
            // 
            this.userControlExpense1.Location = new System.Drawing.Point(200, 0);
            this.userControlExpense1.MaximumSize = new System.Drawing.Size(1200, 800);
            this.userControlExpense1.MinimumSize = new System.Drawing.Size(1000, 800);
            this.userControlExpense1.Name = "userControlExpense1";
            this.userControlExpense1.Size = new System.Drawing.Size(1200, 800);
            this.userControlExpense1.TabIndex = 7;
            // 
            // userControlAdministration1
            // 
            this.userControlAdministration1.Location = new System.Drawing.Point(200, 0);
            this.userControlAdministration1.MaximumSize = new System.Drawing.Size(1200, 800);
            this.userControlAdministration1.MinimumSize = new System.Drawing.Size(100, 800);
            this.userControlAdministration1.Name = "userControlAdministration1";
            this.userControlAdministration1.Size = new System.Drawing.Size(1200, 800);
            this.userControlAdministration1.TabIndex = 6;
            // 
            // userControlUtilities1
            // 
            this.userControlUtilities1.Location = new System.Drawing.Point(200, 0);
            this.userControlUtilities1.Name = "userControlUtilities1";
            this.userControlUtilities1.Size = new System.Drawing.Size(1187, 850);
            this.userControlUtilities1.TabIndex = 5;
            // 
            // userControlTruck1
            // 
            this.userControlTruck1.Location = new System.Drawing.Point(200, 0);
            this.userControlTruck1.MaximumSize = new System.Drawing.Size(1200, 800);
            this.userControlTruck1.MinimumSize = new System.Drawing.Size(1000, 800);
            this.userControlTruck1.Name = "userControlTruck1";
            this.userControlTruck1.Size = new System.Drawing.Size(1162, 800);
            this.userControlTruck1.TabIndex = 4;
            // 
            // userControlRevenue1
            // 
            this.userControlRevenue1.Location = new System.Drawing.Point(200, 0);
            this.userControlRevenue1.Name = "userControlRevenue1";
            this.userControlRevenue1.Size = new System.Drawing.Size(1200, 850);
            this.userControlRevenue1.TabIndex = 3;
            // 
            // userControlDashboard1
            // 
            this.userControlDashboard1.Location = new System.Drawing.Point(200, 0);
            this.userControlDashboard1.Name = "userControlDashboard1";
            this.userControlDashboard1.Size = new System.Drawing.Size(1200, 8850);
            this.userControlDashboard1.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 811);
            this.Controls.Add(this.userControlExpense1);
            this.Controls.Add(this.userControlAdministration1);
            this.Controls.Add(this.userControlUtilities1);
            this.Controls.Add(this.userControlTruck1);
            this.Controls.Add(this.userControlRevenue1);
            this.Controls.Add(this.userControlDashboard1);
            this.Controls.Add(this.pnMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1400, 850);
            this.MinimumSize = new System.Drawing.Size(1000, 850);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfect Freight Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            this.pnUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Panel pnUsuario;
        private System.Windows.Forms.PictureBox pbUsuario;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnAdministration;
        private System.Windows.Forms.Button btnCatalogs;
        private System.Windows.Forms.Button btnTrip;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer Colapsar;
        private System.Windows.Forms.Panel Sidepanel;
        private System.Windows.Forms.Timer timer1;
        private UserControlDashboard userControlDashboard1;
        private UserControlRevenue userControlRevenue1;
        private UserControlTruck userControlTruck1;
        private UserControlUtilities userControlUtilities1;
        private UserControlAdministration userControlAdministration1;
        private System.Windows.Forms.Button btnTruck;
        private System.Windows.Forms.Button btnProfile;
        private UserControlExpense userControlExpense1;
    }
}