
namespace Perfect_Freight_Manager.Forms.AlertsIncidences
{
    partial class PickupDrop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupDrop));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.lbRecordPD = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnPDEnd = new System.Windows.Forms.Button();
            this.btnPDNext = new System.Windows.Forms.Button();
            this.btnPDPrevious = new System.Windows.Forms.Button();
            this.btnPDFirst = new System.Windows.Forms.Button();
            this.btnPckupUpd = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtAPDeliveryNumber = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.txtAPPickupNumber = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.lblPDDriver = new System.Windows.Forms.Label();
            this.lblPDType = new System.Windows.Forms.Label();
            this.txtpdPickupTime = new System.Windows.Forms.TextBox();
            this.txtPDDeliveryNumber = new System.Windows.Forms.TextBox();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.dtPDPickupAppoinment = new System.Windows.Forms.DateTimePicker();
            this.label125 = new System.Windows.Forms.Label();
            this.txtPDPickupNumber = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.txtPDSealShipper = new System.Windows.Forms.TextBox();
            this.txtPDSealReceiver = new System.Windows.Forms.TextBox();
            this.label124 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPDShipper = new System.Windows.Forms.Label();
            this.txtPDShipper = new System.Windows.Forms.TextBox();
            this.btnPDSearchShipper = new System.Windows.Forms.Button();
            this.label114 = new System.Windows.Forms.Label();
            this.txtPDDriver = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.lbRuta = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lbPDReceiver = new System.Windows.Forms.Label();
            this.txtPDReceiver = new System.Windows.Forms.TextBox();
            this.btnPDSearchReceiver = new System.Windows.Forms.Button();
            this.btnPDType = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.cbPDType = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.lbPDStartCS = new System.Windows.Forms.Label();
            this.lbPDEndCS = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtArrivaDate = new System.Windows.Forms.DateTimePicker();
            this.dtPDReceiverAppoinment = new System.Windows.Forms.DateTimePicker();
            this.lbSRPickup = new System.Windows.Forms.Label();
            this.txtPDEndCS = new System.Windows.Forms.TextBox();
            this.btnPDSearchEndCS = new System.Windows.Forms.Button();
            this.txtPDStarCS = new System.Windows.Forms.TextBox();
            this.btnPDSearchStartCS = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lbLoadIdPickup = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtPDTotalTime = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.dgvPickup = new System.Windows.Forms.DataGridView();
            this.btnPckupDel = new System.Windows.Forms.Button();
            this.btnClearPickup = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickup)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1361, 24);
            this.menuStrip1.TabIndex = 1;
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
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.LightGray;
            this.groupBox17.Controls.Add(this.btnClearPickup);
            this.groupBox17.Controls.Add(this.btnPckupDel);
            this.groupBox17.Controls.Add(this.lbRecordPD);
            this.groupBox17.Controls.Add(this.label25);
            this.groupBox17.Controls.Add(this.btnPDEnd);
            this.groupBox17.Controls.Add(this.btnPDNext);
            this.groupBox17.Controls.Add(this.btnPDPrevious);
            this.groupBox17.Controls.Add(this.btnPDFirst);
            this.groupBox17.Controls.Add(this.btnPckupUpd);
            this.groupBox17.Location = new System.Drawing.Point(108, 423);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(1118, 55);
            this.groupBox17.TabIndex = 186;
            this.groupBox17.TabStop = false;
            // 
            // lbRecordPD
            // 
            this.lbRecordPD.AutoSize = true;
            this.lbRecordPD.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordPD.ForeColor = System.Drawing.Color.Crimson;
            this.lbRecordPD.Location = new System.Drawing.Point(160, 21);
            this.lbRecordPD.Name = "lbRecordPD";
            this.lbRecordPD.Size = new System.Drawing.Size(70, 17);
            this.lbRecordPD.TabIndex = 219;
            this.lbRecordPD.Text = "label159";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Gold;
            this.label25.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(371, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 14);
            this.label25.TabIndex = 218;
            this.label25.Text = "Find City St.";
            this.label25.Visible = false;
            // 
            // btnPDEnd
            // 
            this.btnPDEnd.AutoSize = true;
            this.btnPDEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnPDEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPDEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDEnd.FlatAppearance.BorderSize = 0;
            this.btnPDEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnPDEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnPDEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDEnd.Image = global::Perfect_Freight_Manager.Properties.Resources.btnendt;
            this.btnPDEnd.Location = new System.Drawing.Point(502, 11);
            this.btnPDEnd.Name = "btnPDEnd";
            this.btnPDEnd.Size = new System.Drawing.Size(38, 38);
            this.btnPDEnd.TabIndex = 217;
            this.btnPDEnd.UseVisualStyleBackColor = false;
            this.btnPDEnd.Click += new System.EventHandler(this.btnPDEnd_Click);
            // 
            // btnPDNext
            // 
            this.btnPDNext.AutoSize = true;
            this.btnPDNext.BackColor = System.Drawing.Color.Transparent;
            this.btnPDNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPDNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDNext.FlatAppearance.BorderSize = 0;
            this.btnPDNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnPDNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnPDNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDNext.Image = global::Perfect_Freight_Manager.Properties.Resources.btnright;
            this.btnPDNext.Location = new System.Drawing.Point(459, 11);
            this.btnPDNext.Name = "btnPDNext";
            this.btnPDNext.Size = new System.Drawing.Size(38, 38);
            this.btnPDNext.TabIndex = 216;
            this.btnPDNext.UseVisualStyleBackColor = false;
            this.btnPDNext.Click += new System.EventHandler(this.btnPDNext_Click);
            // 
            // btnPDPrevious
            // 
            this.btnPDPrevious.AutoSize = true;
            this.btnPDPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPDPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPDPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDPrevious.FlatAppearance.BorderSize = 0;
            this.btnPDPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnPDPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnPDPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDPrevious.Image = global::Perfect_Freight_Manager.Properties.Resources.btnleft;
            this.btnPDPrevious.Location = new System.Drawing.Point(416, 11);
            this.btnPDPrevious.Name = "btnPDPrevious";
            this.btnPDPrevious.Size = new System.Drawing.Size(38, 38);
            this.btnPDPrevious.TabIndex = 215;
            this.btnPDPrevious.UseVisualStyleBackColor = false;
            this.btnPDPrevious.Click += new System.EventHandler(this.btnPDPrevious_Click);
            // 
            // btnPDFirst
            // 
            this.btnPDFirst.AutoSize = true;
            this.btnPDFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnPDFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPDFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPDFirst.FlatAppearance.BorderSize = 0;
            this.btnPDFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnPDFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnPDFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDFirst.Image = global::Perfect_Freight_Manager.Properties.Resources.btnfirst;
            this.btnPDFirst.Location = new System.Drawing.Point(373, 11);
            this.btnPDFirst.Name = "btnPDFirst";
            this.btnPDFirst.Size = new System.Drawing.Size(38, 38);
            this.btnPDFirst.TabIndex = 214;
            this.btnPDFirst.UseVisualStyleBackColor = false;
            this.btnPDFirst.Click += new System.EventHandler(this.btnPDFirst_Click);
            // 
            // btnPckupUpd
            // 
            this.btnPckupUpd.AutoSize = true;
            this.btnPckupUpd.BackColor = System.Drawing.Color.LightGray;
            this.btnPckupUpd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPckupUpd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPckupUpd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnPckupUpd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnPckupUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPckupUpd.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPckupUpd.Location = new System.Drawing.Point(575, 18);
            this.btnPckupUpd.Name = "btnPckupUpd";
            this.btnPckupUpd.Size = new System.Drawing.Size(160, 31);
            this.btnPckupUpd.TabIndex = 4;
            this.btnPckupUpd.Text = "Update Pickup && Drop";
            this.btnPckupUpd.UseVisualStyleBackColor = false;
            this.btnPckupUpd.Click += new System.EventHandler(this.btnPckupUpd_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.LightGray;
            this.groupBox7.Controls.Add(this.txtAPDeliveryNumber);
            this.groupBox7.Controls.Add(this.label118);
            this.groupBox7.Controls.Add(this.txtAPPickupNumber);
            this.groupBox7.Controls.Add(this.label51);
            this.groupBox7.Controls.Add(this.lblPDDriver);
            this.groupBox7.Controls.Add(this.lblPDType);
            this.groupBox7.Controls.Add(this.txtpdPickupTime);
            this.groupBox7.Controls.Add(this.txtPDDeliveryNumber);
            this.groupBox7.Controls.Add(this.label128);
            this.groupBox7.Controls.Add(this.label129);
            this.groupBox7.Controls.Add(this.dtPDPickupAppoinment);
            this.groupBox7.Controls.Add(this.label125);
            this.groupBox7.Controls.Add(this.txtPDPickupNumber);
            this.groupBox7.Controls.Add(this.label126);
            this.groupBox7.Controls.Add(this.label127);
            this.groupBox7.Controls.Add(this.txtPDSealShipper);
            this.groupBox7.Controls.Add(this.txtPDSealReceiver);
            this.groupBox7.Controls.Add(this.label124);
            this.groupBox7.Controls.Add(this.label123);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.lblPDShipper);
            this.groupBox7.Controls.Add(this.txtPDShipper);
            this.groupBox7.Controls.Add(this.btnPDSearchShipper);
            this.groupBox7.Controls.Add(this.label114);
            this.groupBox7.Controls.Add(this.txtPDDriver);
            this.groupBox7.Controls.Add(this.button7);
            this.groupBox7.Controls.Add(this.lbRuta);
            this.groupBox7.Controls.Add(this.label40);
            this.groupBox7.Controls.Add(this.lbPDReceiver);
            this.groupBox7.Controls.Add(this.txtPDReceiver);
            this.groupBox7.Controls.Add(this.btnPDSearchReceiver);
            this.groupBox7.Controls.Add(this.btnPDType);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.cbPDType);
            this.groupBox7.Controls.Add(this.label47);
            this.groupBox7.Controls.Add(this.lbPDStartCS);
            this.groupBox7.Controls.Add(this.lbPDEndCS);
            this.groupBox7.Controls.Add(this.dtStartDate);
            this.groupBox7.Controls.Add(this.dtArrivaDate);
            this.groupBox7.Controls.Add(this.dtPDReceiverAppoinment);
            this.groupBox7.Controls.Add(this.lbSRPickup);
            this.groupBox7.Controls.Add(this.txtPDEndCS);
            this.groupBox7.Controls.Add(this.btnPDSearchEndCS);
            this.groupBox7.Controls.Add(this.txtPDStarCS);
            this.groupBox7.Controls.Add(this.btnPDSearchStartCS);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.lbLoadIdPickup);
            this.groupBox7.Controls.Add(this.label104);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.txtNotes);
            this.groupBox7.Controls.Add(this.label41);
            this.groupBox7.Controls.Add(this.txtPDTotalTime);
            this.groupBox7.Controls.Add(this.label42);
            this.groupBox7.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(12, 41);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1337, 376);
            this.groupBox7.TabIndex = 185;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Shipper Receiver Pickup - Drop";
            // 
            // txtAPDeliveryNumber
            // 
            this.txtAPDeliveryNumber.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPDeliveryNumber.Location = new System.Drawing.Point(1064, 180);
            this.txtAPDeliveryNumber.Name = "txtAPDeliveryNumber";
            this.txtAPDeliveryNumber.Size = new System.Drawing.Size(91, 22);
            this.txtAPDeliveryNumber.TabIndex = 15;
            this.txtAPDeliveryNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.Location = new System.Drawing.Point(1061, 162);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(90, 16);
            this.label118.TabIndex = 227;
            this.label118.Text = "Appoinment #";
            // 
            // txtAPPickupNumber
            // 
            this.txtAPPickupNumber.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAPPickupNumber.Location = new System.Drawing.Point(1062, 80);
            this.txtAPPickupNumber.Name = "txtAPPickupNumber";
            this.txtAPPickupNumber.Size = new System.Drawing.Size(91, 22);
            this.txtAPPickupNumber.TabIndex = 7;
            this.txtAPPickupNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(1061, 61);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(90, 16);
            this.label51.TabIndex = 225;
            this.label51.Text = "Appoinment #";
            // 
            // lblPDDriver
            // 
            this.lblPDDriver.AutoSize = true;
            this.lblPDDriver.BackColor = System.Drawing.Color.Gold;
            this.lblPDDriver.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDDriver.Location = new System.Drawing.Point(738, 271);
            this.lblPDDriver.Name = "lblPDDriver";
            this.lblPDDriver.Size = new System.Drawing.Size(66, 14);
            this.lblPDDriver.TabIndex = 223;
            this.lblPDDriver.Text = "Find Driver";
            this.lblPDDriver.Visible = false;
            // 
            // lblPDType
            // 
            this.lblPDType.AutoSize = true;
            this.lblPDType.BackColor = System.Drawing.Color.Gold;
            this.lblPDType.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDType.Location = new System.Drawing.Point(127, 107);
            this.lblPDType.Name = "lblPDType";
            this.lblPDType.Size = new System.Drawing.Size(107, 14);
            this.lblPDType.TabIndex = 222;
            this.lblPDType.Text = "Add PickDrop Type";
            this.lblPDType.Visible = false;
            // 
            // txtpdPickupTime
            // 
            this.txtpdPickupTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtpdPickupTime.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpdPickupTime.Location = new System.Drawing.Point(826, 80);
            this.txtpdPickupTime.Name = "txtpdPickupTime";
            this.txtpdPickupTime.Size = new System.Drawing.Size(133, 22);
            this.txtpdPickupTime.TabIndex = 5;
            this.txtpdPickupTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPDDeliveryNumber
            // 
            this.txtPDDeliveryNumber.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDDeliveryNumber.Location = new System.Drawing.Point(967, 181);
            this.txtPDDeliveryNumber.Name = "txtPDDeliveryNumber";
            this.txtPDDeliveryNumber.Size = new System.Drawing.Size(91, 22);
            this.txtPDDeliveryNumber.TabIndex = 14;
            this.txtPDDeliveryNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.Location = new System.Drawing.Point(964, 163);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(68, 16);
            this.label128.TabIndex = 219;
            this.label128.Text = "Delivery #";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(823, 162);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(92, 16);
            this.label129.TabIndex = 218;
            this.label129.Text = "Delivery Time";
            // 
            // dtPDPickupAppoinment
            // 
            this.dtPDPickupAppoinment.CalendarFont = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPDPickupAppoinment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtPDPickupAppoinment.CustomFormat = "M/d/yyyy H:mm";
            this.dtPDPickupAppoinment.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPDPickupAppoinment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPDPickupAppoinment.Location = new System.Drawing.Point(1160, 80);
            this.dtPDPickupAppoinment.Name = "dtPDPickupAppoinment";
            this.dtPDPickupAppoinment.Size = new System.Drawing.Size(143, 23);
            this.dtPDPickupAppoinment.TabIndex = 8;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label125.Location = new System.Drawing.Point(1159, 61);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(110, 16);
            this.label125.TabIndex = 215;
            this.label125.Text = "Arrive Date-Time";
            // 
            // txtPDPickupNumber
            // 
            this.txtPDPickupNumber.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDPickupNumber.Location = new System.Drawing.Point(965, 80);
            this.txtPDPickupNumber.Name = "txtPDPickupNumber";
            this.txtPDPickupNumber.Size = new System.Drawing.Size(91, 22);
            this.txtPDPickupNumber.TabIndex = 6;
            this.txtPDPickupNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.Location = new System.Drawing.Point(964, 61);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(59, 16);
            this.label126.TabIndex = 213;
            this.label126.Text = "Pickup #";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.Location = new System.Drawing.Point(823, 62);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(86, 16);
            this.label127.TabIndex = 212;
            this.label127.Text = "PickUp Time";
            // 
            // txtPDSealShipper
            // 
            this.txtPDSealShipper.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDSealShipper.Location = new System.Drawing.Point(729, 81);
            this.txtPDSealShipper.Name = "txtPDSealShipper";
            this.txtPDSealShipper.Size = new System.Drawing.Size(91, 22);
            this.txtPDSealShipper.TabIndex = 4;
            this.txtPDSealShipper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPDSealReceiver
            // 
            this.txtPDSealReceiver.BackColor = System.Drawing.SystemColors.Window;
            this.txtPDSealReceiver.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDSealReceiver.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPDSealReceiver.Location = new System.Drawing.Point(729, 182);
            this.txtPDSealReceiver.Name = "txtPDSealReceiver";
            this.txtPDSealReceiver.Size = new System.Drawing.Size(91, 22);
            this.txtPDSealReceiver.TabIndex = 12;
            this.txtPDSealReceiver.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(726, 162);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(45, 17);
            this.label124.TabIndex = 210;
            this.label124.Text = "Seal #";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(726, 61);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(45, 17);
            this.label123.TabIndex = 208;
            this.label123.Text = "Seal #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 206;
            this.label5.Text = "Shipper";
            // 
            // lblPDShipper
            // 
            this.lblPDShipper.AutoSize = true;
            this.lblPDShipper.BackColor = System.Drawing.Color.Gold;
            this.lblPDShipper.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDShipper.Location = new System.Drawing.Point(315, 110);
            this.lblPDShipper.Name = "lblPDShipper";
            this.lblPDShipper.Size = new System.Drawing.Size(74, 14);
            this.lblPDShipper.TabIndex = 205;
            this.lblPDShipper.Text = "Find Shipper";
            this.lblPDShipper.Visible = false;
            // 
            // txtPDShipper
            // 
            this.txtPDShipper.BackColor = System.Drawing.SystemColors.Window;
            this.txtPDShipper.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDShipper.Location = new System.Drawing.Point(150, 82);
            this.txtPDShipper.Name = "txtPDShipper";
            this.txtPDShipper.Size = new System.Drawing.Size(227, 22);
            this.txtPDShipper.TabIndex = 1;
            // 
            // btnPDSearchShipper
            // 
            this.btnPDSearchShipper.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPDSearchShipper.FlatAppearance.BorderSize = 2;
            this.btnPDSearchShipper.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnPDSearchShipper.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPDSearchShipper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDSearchShipper.Image = ((System.Drawing.Image)(resources.GetObject("btnPDSearchShipper.Image")));
            this.btnPDSearchShipper.Location = new System.Drawing.Point(380, 81);
            this.btnPDSearchShipper.Name = "btnPDSearchShipper";
            this.btnPDSearchShipper.Size = new System.Drawing.Size(28, 27);
            this.btnPDSearchShipper.TabIndex = 204;
            this.btnPDSearchShipper.UseVisualStyleBackColor = true;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.Location = new System.Drawing.Point(425, 222);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(91, 18);
            this.label114.TabIndex = 202;
            this.label114.Text = "Driver Name";
            this.label114.Visible = false;
            // 
            // txtPDDriver
            // 
            this.txtPDDriver.BackColor = System.Drawing.SystemColors.Window;
            this.txtPDDriver.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDDriver.Location = new System.Drawing.Point(424, 243);
            this.txtPDDriver.Name = "txtPDDriver";
            this.txtPDDriver.Size = new System.Drawing.Size(300, 22);
            this.txtPDDriver.TabIndex = 18;
            this.txtPDDriver.Visible = false;
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(724, 241);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(28, 27);
            this.button7.TabIndex = 201;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // lbRuta
            // 
            this.lbRuta.AutoSize = true;
            this.lbRuta.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRuta.ForeColor = System.Drawing.Color.Blue;
            this.lbRuta.Location = new System.Drawing.Point(434, 320);
            this.lbRuta.Name = "lbRuta";
            this.lbRuta.Size = new System.Drawing.Size(75, 22);
            this.lbRuta.TabIndex = 199;
            this.lbRuta.Text = "label50";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(150, 161);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(63, 17);
            this.label40.TabIndex = 198;
            this.label40.Text = "Receiver";
            // 
            // lbPDReceiver
            // 
            this.lbPDReceiver.AutoSize = true;
            this.lbPDReceiver.BackColor = System.Drawing.Color.Gold;
            this.lbPDReceiver.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPDReceiver.Location = new System.Drawing.Point(318, 209);
            this.lbPDReceiver.Name = "lbPDReceiver";
            this.lbPDReceiver.Size = new System.Drawing.Size(77, 14);
            this.lbPDReceiver.TabIndex = 197;
            this.lbPDReceiver.Text = "Find Receiver";
            this.lbPDReceiver.Visible = false;
            // 
            // txtPDReceiver
            // 
            this.txtPDReceiver.BackColor = System.Drawing.SystemColors.Window;
            this.txtPDReceiver.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDReceiver.Location = new System.Drawing.Point(153, 181);
            this.txtPDReceiver.Name = "txtPDReceiver";
            this.txtPDReceiver.Size = new System.Drawing.Size(227, 22);
            this.txtPDReceiver.TabIndex = 9;
            // 
            // btnPDSearchReceiver
            // 
            this.btnPDSearchReceiver.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPDSearchReceiver.FlatAppearance.BorderSize = 2;
            this.btnPDSearchReceiver.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnPDSearchReceiver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPDSearchReceiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDSearchReceiver.Image = ((System.Drawing.Image)(resources.GetObject("btnPDSearchReceiver.Image")));
            this.btnPDSearchReceiver.Location = new System.Drawing.Point(382, 180);
            this.btnPDSearchReceiver.Name = "btnPDSearchReceiver";
            this.btnPDSearchReceiver.Size = new System.Drawing.Size(28, 27);
            this.btnPDSearchReceiver.TabIndex = 196;
            this.btnPDSearchReceiver.UseVisualStyleBackColor = true;
            // 
            // btnPDType
            // 
            this.btnPDType.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDType.Image = ((System.Drawing.Image)(resources.GetObject("btnPDType.Image")));
            this.btnPDType.Location = new System.Drawing.Point(123, 84);
            this.btnPDType.Name = "btnPDType";
            this.btnPDType.Size = new System.Drawing.Size(23, 23);
            this.btnPDType.TabIndex = 194;
            this.btnPDType.Text = "+";
            this.btnPDType.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 64);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 17);
            this.label21.TabIndex = 193;
            this.label21.Text = "Pick-Drop Type";
            // 
            // cbPDType
            // 
            this.cbPDType.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPDType.FormattingEnabled = true;
            this.cbPDType.Location = new System.Drawing.Point(10, 84);
            this.cbPDType.Name = "cbPDType";
            this.cbPDType.Size = new System.Drawing.Size(111, 22);
            this.cbPDType.TabIndex = 0;
            this.cbPDType.SelectedIndexChanged += new System.EventHandler(this.cbPDType_SelectedIndexChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(1159, 158);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(163, 18);
            this.label47.TabIndex = 191;
            this.label47.Tag = "";
            this.label47.Text = "Appointment Date-Time";
            // 
            // lbPDStartCS
            // 
            this.lbPDStartCS.AutoSize = true;
            this.lbPDStartCS.BackColor = System.Drawing.Color.Gold;
            this.lbPDStartCS.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPDStartCS.Location = new System.Drawing.Point(714, 111);
            this.lbPDStartCS.Name = "lbPDStartCS";
            this.lbPDStartCS.Size = new System.Drawing.Size(68, 14);
            this.lbPDStartCS.TabIndex = 190;
            this.lbPDStartCS.Text = "Find City St.";
            this.lbPDStartCS.Visible = false;
            // 
            // lbPDEndCS
            // 
            this.lbPDEndCS.AutoSize = true;
            this.lbPDEndCS.BackColor = System.Drawing.Color.Gold;
            this.lbPDEndCS.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPDEndCS.Location = new System.Drawing.Point(706, 209);
            this.lbPDEndCS.Name = "lbPDEndCS";
            this.lbPDEndCS.Size = new System.Drawing.Size(68, 14);
            this.lbPDEndCS.TabIndex = 189;
            this.lbPDEndCS.Text = "Find City St.";
            this.lbPDEndCS.Visible = false;
            // 
            // dtStartDate
            // 
            this.dtStartDate.CustomFormat = "M/d/yyyy";
            this.dtStartDate.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(422, 83);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(110, 22);
            this.dtStartDate.TabIndex = 2;
            // 
            // dtArrivaDate
            // 
            this.dtArrivaDate.CustomFormat = "M/d/yyyy";
            this.dtArrivaDate.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtArrivaDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtArrivaDate.Location = new System.Drawing.Point(424, 181);
            this.dtArrivaDate.Name = "dtArrivaDate";
            this.dtArrivaDate.Size = new System.Drawing.Size(108, 22);
            this.dtArrivaDate.TabIndex = 10;
            // 
            // dtPDReceiverAppoinment
            // 
            this.dtPDReceiverAppoinment.CustomFormat = "M/d/yyyy H:mm";
            this.dtPDReceiverAppoinment.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPDReceiverAppoinment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPDReceiverAppoinment.Location = new System.Drawing.Point(1162, 178);
            this.dtPDReceiverAppoinment.Name = "dtPDReceiverAppoinment";
            this.dtPDReceiverAppoinment.Size = new System.Drawing.Size(141, 22);
            this.dtPDReceiverAppoinment.TabIndex = 16;
            // 
            // lbSRPickup
            // 
            this.lbSRPickup.AutoSize = true;
            this.lbSRPickup.ForeColor = System.Drawing.Color.Crimson;
            this.lbSRPickup.Location = new System.Drawing.Point(382, 31);
            this.lbSRPickup.Name = "lbSRPickup";
            this.lbSRPickup.Size = new System.Drawing.Size(54, 17);
            this.lbSRPickup.TabIndex = 157;
            this.lbSRPickup.Text = "label40";
            // 
            // txtPDEndCS
            // 
            this.txtPDEndCS.BackColor = System.Drawing.SystemColors.Window;
            this.txtPDEndCS.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDEndCS.ForeColor = System.Drawing.Color.Crimson;
            this.txtPDEndCS.Location = new System.Drawing.Point(556, 180);
            this.txtPDEndCS.Name = "txtPDEndCS";
            this.txtPDEndCS.Size = new System.Drawing.Size(133, 23);
            this.txtPDEndCS.TabIndex = 11;
            this.txtPDEndCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPDSearchEndCS
            // 
            this.btnPDSearchEndCS.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPDSearchEndCS.FlatAppearance.BorderSize = 2;
            this.btnPDSearchEndCS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnPDSearchEndCS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPDSearchEndCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDSearchEndCS.Image = ((System.Drawing.Image)(resources.GetObject("btnPDSearchEndCS.Image")));
            this.btnPDSearchEndCS.Location = new System.Drawing.Point(688, 180);
            this.btnPDSearchEndCS.Name = "btnPDSearchEndCS";
            this.btnPDSearchEndCS.Size = new System.Drawing.Size(28, 27);
            this.btnPDSearchEndCS.TabIndex = 156;
            this.btnPDSearchEndCS.UseVisualStyleBackColor = true;
            // 
            // txtPDStarCS
            // 
            this.txtPDStarCS.BackColor = System.Drawing.SystemColors.Window;
            this.txtPDStarCS.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDStarCS.ForeColor = System.Drawing.Color.Crimson;
            this.txtPDStarCS.Location = new System.Drawing.Point(552, 82);
            this.txtPDStarCS.Name = "txtPDStarCS";
            this.txtPDStarCS.Size = new System.Drawing.Size(137, 23);
            this.txtPDStarCS.TabIndex = 3;
            this.txtPDStarCS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPDSearchStartCS
            // 
            this.btnPDSearchStartCS.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPDSearchStartCS.FlatAppearance.BorderSize = 2;
            this.btnPDSearchStartCS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnPDSearchStartCS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPDSearchStartCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDSearchStartCS.Image = ((System.Drawing.Image)(resources.GetObject("btnPDSearchStartCS.Image")));
            this.btnPDSearchStartCS.Location = new System.Drawing.Point(690, 81);
            this.btnPDSearchStartCS.Name = "btnPDSearchStartCS";
            this.btnPDSearchStartCS.Size = new System.Drawing.Size(28, 27);
            this.btnPDSearchStartCS.TabIndex = 154;
            this.btnPDSearchStartCS.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(423, 63);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 17);
            this.label23.TabIndex = 97;
            this.label23.Text = "Pickup Date";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(556, 161);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(81, 17);
            this.label26.TabIndex = 94;
            this.label26.Text = "End City, St.";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(549, 62);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 17);
            this.label27.TabIndex = 93;
            this.label27.Text = "Start City, St.";
            // 
            // lbLoadIdPickup
            // 
            this.lbLoadIdPickup.AutoSize = true;
            this.lbLoadIdPickup.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoadIdPickup.ForeColor = System.Drawing.Color.Crimson;
            this.lbLoadIdPickup.Location = new System.Drawing.Point(92, 26);
            this.lbLoadIdPickup.Name = "lbLoadIdPickup";
            this.lbLoadIdPickup.Size = new System.Drawing.Size(142, 22);
            this.lbLoadIdPickup.TabIndex = 52;
            this.lbLoadIdPickup.Text = "============";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(25, 31);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(61, 17);
            this.label104.TabIndex = 47;
            this.label104.Text = "Load ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(20, 243);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(388, 117);
            this.txtNotes.TabIndex = 17;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(421, 161);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(94, 17);
            this.label41.TabIndex = 41;
            this.label41.Text = "Delivery Date";
            // 
            // txtPDTotalTime
            // 
            this.txtPDTotalTime.BackColor = System.Drawing.SystemColors.Window;
            this.txtPDTotalTime.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDTotalTime.Location = new System.Drawing.Point(826, 181);
            this.txtPDTotalTime.Name = "txtPDTotalTime";
            this.txtPDTotalTime.Size = new System.Drawing.Size(133, 22);
            this.txtPDTotalTime.TabIndex = 13;
            this.txtPDTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(324, 30);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(52, 17);
            this.label42.TabIndex = 13;
            this.label42.Text = "Broker";
            // 
            // dgvPickup
            // 
            this.dgvPickup.AllowUserToAddRows = false;
            this.dgvPickup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPickup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPickup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPickup.EnableHeadersVisualStyles = false;
            this.dgvPickup.Location = new System.Drawing.Point(135, 484);
            this.dgvPickup.Name = "dgvPickup";
            this.dgvPickup.ReadOnly = true;
            this.dgvPickup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPickup.Size = new System.Drawing.Size(1057, 140);
            this.dgvPickup.TabIndex = 187;
            // 
            // btnPckupDel
            // 
            this.btnPckupDel.AutoSize = true;
            this.btnPckupDel.BackColor = System.Drawing.Color.LightGray;
            this.btnPckupDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPckupDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPckupDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnPckupDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnPckupDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPckupDel.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPckupDel.Location = new System.Drawing.Point(756, 18);
            this.btnPckupDel.Name = "btnPckupDel";
            this.btnPckupDel.Size = new System.Drawing.Size(155, 31);
            this.btnPckupDel.TabIndex = 220;
            this.btnPckupDel.Text = "Delete Pickup && Drop";
            this.btnPckupDel.UseVisualStyleBackColor = false;
            this.btnPckupDel.Click += new System.EventHandler(this.btnPckupDel_Click);
            // 
            // btnClearPickup
            // 
            this.btnClearPickup.AutoSize = true;
            this.btnClearPickup.BackColor = System.Drawing.Color.LightGray;
            this.btnClearPickup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearPickup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearPickup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.btnClearPickup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnClearPickup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPickup.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPickup.Location = new System.Drawing.Point(7, 15);
            this.btnClearPickup.Name = "btnClearPickup";
            this.btnClearPickup.Size = new System.Drawing.Size(147, 29);
            this.btnClearPickup.TabIndex = 221;
            this.btnClearPickup.Text = "Clear Pickup && Drop";
            this.btnClearPickup.UseVisualStyleBackColor = false;
            this.btnClearPickup.Click += new System.EventHandler(this.btnClearPickup_Click);
            // 
            // PickupDrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 630);
            this.Controls.Add(this.dgvPickup);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PickupDrop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pickup & Drop";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPickup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button btnPckupUpd;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtAPDeliveryNumber;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.TextBox txtAPPickupNumber;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lblPDDriver;
        private System.Windows.Forms.Label lblPDType;
        private System.Windows.Forms.TextBox txtpdPickupTime;
        private System.Windows.Forms.TextBox txtPDDeliveryNumber;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.DateTimePicker dtPDPickupAppoinment;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.TextBox txtPDPickupNumber;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.TextBox txtPDSealShipper;
        private System.Windows.Forms.TextBox txtPDSealReceiver;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPDShipper;
        private System.Windows.Forms.TextBox txtPDShipper;
        private System.Windows.Forms.Button btnPDSearchShipper;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.TextBox txtPDDriver;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lbRuta;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lbPDReceiver;
        private System.Windows.Forms.TextBox txtPDReceiver;
        private System.Windows.Forms.Button btnPDSearchReceiver;
        private System.Windows.Forms.Button btnPDType;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbPDType;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lbPDStartCS;
        private System.Windows.Forms.Label lbPDEndCS;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtArrivaDate;
        private System.Windows.Forms.DateTimePicker dtPDReceiverAppoinment;
        private System.Windows.Forms.Label lbSRPickup;
        private System.Windows.Forms.TextBox txtPDEndCS;
        private System.Windows.Forms.Button btnPDSearchEndCS;
        private System.Windows.Forms.TextBox txtPDStarCS;
        private System.Windows.Forms.Button btnPDSearchStartCS;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lbLoadIdPickup;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtPDTotalTime;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.DataGridView dgvPickup;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnPDEnd;
        private System.Windows.Forms.Button btnPDNext;
        private System.Windows.Forms.Button btnPDPrevious;
        private System.Windows.Forms.Button btnPDFirst;
        private System.Windows.Forms.Label lbRecordPD;
        private System.Windows.Forms.Button btnPckupDel;
        private System.Windows.Forms.Button btnClearPickup;
    }
}