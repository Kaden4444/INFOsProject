namespace INFOsProject.Presentation
{
    partial class MainUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.projectDatabaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addRadioGroup = new System.Windows.Forms.RadioButton();
            this.deleteRadioGroup = new System.Windows.Forms.RadioButton();
            this.editRadioGroup = new System.Windows.Forms.RadioButton();
            this.viewRadioGroup = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ClientPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.ReservationTextbox = new System.Windows.Forms.TextBox();
            this.PostalCodeTextbox = new System.Windows.Forms.TextBox();
            this.TownTextbox = new System.Windows.Forms.TextBox();
            this.AreaTextbox = new System.Windows.Forms.TextBox();
            this.AddressTextbox = new System.Windows.Forms.TextBox();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.ClientTextbox = new System.Windows.Forms.TextBox();
            this.ClientSubmit = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RoomPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.PriceTextbox = new System.Windows.Forms.TextBox();
            this.RoomIDTextbox = new System.Windows.Forms.TextBox();
            this.RoomSubmit = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ReservationPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.TotalTextbox = new System.Windows.Forms.TextBox();
            this.RoomTextbox = new System.Windows.Forms.TextBox();
            this.GuestTextbox = new System.Windows.Forms.TextBox();
            this.ReservationIDTextbox = new System.Windows.Forms.TextBox();
            this.ReservationSubmit = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ListView = new System.Windows.Forms.ListView();
            this.MainListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.projectDatabaseDataSetBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ClientPanel.SuspendLayout();
            this.RoomPanel.SuspendLayout();
            this.ReservationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(-1, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 398);
            this.panel1.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(18, 151);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(93, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(-5, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "< Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addRadioGroup);
            this.groupBox1.Controls.Add(this.deleteRadioGroup);
            this.groupBox1.Controls.Add(this.editRadioGroup);
            this.groupBox1.Controls.Add(this.viewRadioGroup);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // addRadioGroup
            // 
            this.addRadioGroup.AutoSize = true;
            this.addRadioGroup.Location = new System.Drawing.Point(15, 40);
            this.addRadioGroup.Name = "addRadioGroup";
            this.addRadioGroup.Size = new System.Drawing.Size(50, 20);
            this.addRadioGroup.TabIndex = 3;
            this.addRadioGroup.Text = "Add";
            this.addRadioGroup.UseVisualStyleBackColor = true;
            this.addRadioGroup.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // deleteRadioGroup
            // 
            this.deleteRadioGroup.AutoSize = true;
            this.deleteRadioGroup.Location = new System.Drawing.Point(15, 82);
            this.deleteRadioGroup.Name = "deleteRadioGroup";
            this.deleteRadioGroup.Size = new System.Drawing.Size(65, 20);
            this.deleteRadioGroup.TabIndex = 2;
            this.deleteRadioGroup.Text = "Delete";
            this.deleteRadioGroup.UseVisualStyleBackColor = true;
            // 
            // editRadioGroup
            // 
            this.editRadioGroup.AutoSize = true;
            this.editRadioGroup.Location = new System.Drawing.Point(15, 62);
            this.editRadioGroup.Name = "editRadioGroup";
            this.editRadioGroup.Size = new System.Drawing.Size(48, 20);
            this.editRadioGroup.TabIndex = 1;
            this.editRadioGroup.Text = "Edit";
            this.editRadioGroup.UseVisualStyleBackColor = true;
            // 
            // viewRadioGroup
            // 
            this.viewRadioGroup.AutoSize = true;
            this.viewRadioGroup.Location = new System.Drawing.Point(15, 19);
            this.viewRadioGroup.Name = "viewRadioGroup";
            this.viewRadioGroup.Size = new System.Drawing.Size(54, 20);
            this.viewRadioGroup.TabIndex = 0;
            this.viewRadioGroup.Text = "View";
            this.viewRadioGroup.UseVisualStyleBackColor = true;
            this.viewRadioGroup.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "PumPum";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(194, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(577, 398);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ClientPanel
            // 
            this.ClientPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientPanel.Controls.Add(this.label9);
            this.ClientPanel.Controls.Add(this.ReservationTextbox);
            this.ClientPanel.Controls.Add(this.PostalCodeTextbox);
            this.ClientPanel.Controls.Add(this.TownTextbox);
            this.ClientPanel.Controls.Add(this.AreaTextbox);
            this.ClientPanel.Controls.Add(this.AddressTextbox);
            this.ClientPanel.Controls.Add(this.NameTextbox);
            this.ClientPanel.Controls.Add(this.ClientTextbox);
            this.ClientPanel.Controls.Add(this.ClientSubmit);
            this.ClientPanel.Controls.Add(this.button3);
            this.ClientPanel.Controls.Add(this.label8);
            this.ClientPanel.Controls.Add(this.label7);
            this.ClientPanel.Controls.Add(this.label6);
            this.ClientPanel.Controls.Add(this.label5);
            this.ClientPanel.Controls.Add(this.label4);
            this.ClientPanel.Controls.Add(this.label3);
            this.ClientPanel.Controls.Add(this.label2);
            this.ClientPanel.Location = new System.Drawing.Point(240, 53);
            this.ClientPanel.Name = "ClientPanel";
            this.ClientPanel.Size = new System.Drawing.Size(491, 374);
            this.ClientPanel.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Nirmala UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(106, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 50);
            this.label9.TabIndex = 16;
            this.label9.Text = "Client Details:";
            // 
            // ReservationTextbox
            // 
            this.ReservationTextbox.Location = new System.Drawing.Point(213, 219);
            this.ReservationTextbox.Name = "ReservationTextbox";
            this.ReservationTextbox.Size = new System.Drawing.Size(84, 20);
            this.ReservationTextbox.TabIndex = 15;
            // 
            // PostalCodeTextbox
            // 
            this.PostalCodeTextbox.Location = new System.Drawing.Point(340, 163);
            this.PostalCodeTextbox.Name = "PostalCodeTextbox";
            this.PostalCodeTextbox.Size = new System.Drawing.Size(54, 20);
            this.PostalCodeTextbox.TabIndex = 14;
            // 
            // TownTextbox
            // 
            this.TownTextbox.Location = new System.Drawing.Point(88, 163);
            this.TownTextbox.Name = "TownTextbox";
            this.TownTextbox.Size = new System.Drawing.Size(100, 20);
            this.TownTextbox.TabIndex = 13;
            // 
            // AreaTextbox
            // 
            this.AreaTextbox.Location = new System.Drawing.Point(295, 125);
            this.AreaTextbox.Name = "AreaTextbox";
            this.AreaTextbox.Size = new System.Drawing.Size(99, 20);
            this.AreaTextbox.TabIndex = 12;
            // 
            // AddressTextbox
            // 
            this.AddressTextbox.Location = new System.Drawing.Point(106, 123);
            this.AddressTextbox.Name = "AddressTextbox";
            this.AddressTextbox.Size = new System.Drawing.Size(86, 20);
            this.AddressTextbox.TabIndex = 11;
            // 
            // NameTextbox
            // 
            this.NameTextbox.Location = new System.Drawing.Point(303, 77);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(91, 20);
            this.NameTextbox.TabIndex = 10;
            // 
            // ClientTextbox
            // 
            this.ClientTextbox.Location = new System.Drawing.Point(101, 76);
            this.ClientTextbox.Name = "ClientTextbox";
            this.ClientTextbox.Size = new System.Drawing.Size(91, 20);
            this.ClientTextbox.TabIndex = 9;
            this.ClientTextbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ClientSubmit
            // 
            this.ClientSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSubmit.Location = new System.Drawing.Point(268, 297);
            this.ClientSubmit.Name = "ClientSubmit";
            this.ClientSubmit.Size = new System.Drawing.Size(100, 29);
            this.ClientSubmit.TabIndex = 8;
            this.ClientSubmit.Text = "Submit";
            this.ClientSubmit.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(115, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(128, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Reservation";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(253, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Postal Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Town";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(253, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(253, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "ClientID";
            // 
            // RoomPanel
            // 
            this.RoomPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.RoomPanel.Controls.Add(this.label10);
            this.RoomPanel.Controls.Add(this.PriceTextbox);
            this.RoomPanel.Controls.Add(this.RoomIDTextbox);
            this.RoomPanel.Controls.Add(this.RoomSubmit);
            this.RoomPanel.Controls.Add(this.button5);
            this.RoomPanel.Controls.Add(this.label16);
            this.RoomPanel.Controls.Add(this.label17);
            this.RoomPanel.Location = new System.Drawing.Point(857, 412);
            this.RoomPanel.Name = "RoomPanel";
            this.RoomPanel.Size = new System.Drawing.Size(443, 196);
            this.RoomPanel.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Nirmala UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(106, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(264, 50);
            this.label10.TabIndex = 16;
            this.label10.Text = "Room Details:";
            // 
            // PriceTextbox
            // 
            this.PriceTextbox.Location = new System.Drawing.Point(294, 77);
            this.PriceTextbox.Name = "PriceTextbox";
            this.PriceTextbox.Size = new System.Drawing.Size(62, 20);
            this.PriceTextbox.TabIndex = 10;
            // 
            // RoomIDTextbox
            // 
            this.RoomIDTextbox.Location = new System.Drawing.Point(105, 76);
            this.RoomIDTextbox.Name = "RoomIDTextbox";
            this.RoomIDTextbox.Size = new System.Drawing.Size(87, 20);
            this.RoomIDTextbox.TabIndex = 9;
            // 
            // RoomSubmit
            // 
            this.RoomSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomSubmit.Location = new System.Drawing.Point(256, 126);
            this.RoomSubmit.Name = "RoomSubmit";
            this.RoomSubmit.Size = new System.Drawing.Size(100, 29);
            this.RoomSubmit.TabIndex = 8;
            this.RoomSubmit.Text = "Submit";
            this.RoomSubmit.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(105, 126);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 29);
            this.button5.TabIndex = 7;
            this.button5.Text = "Cancel";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(253, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 16);
            this.label16.TabIndex = 1;
            this.label16.Text = "Price";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(42, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "RoomID";
            // 
            // ReservationPanel
            // 
            this.ReservationPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ReservationPanel.Controls.Add(this.label11);
            this.ReservationPanel.Controls.Add(this.TotalTextbox);
            this.ReservationPanel.Controls.Add(this.RoomTextbox);
            this.ReservationPanel.Controls.Add(this.GuestTextbox);
            this.ReservationPanel.Controls.Add(this.ReservationIDTextbox);
            this.ReservationPanel.Controls.Add(this.ReservationSubmit);
            this.ReservationPanel.Controls.Add(this.button7);
            this.ReservationPanel.Controls.Add(this.label15);
            this.ReservationPanel.Controls.Add(this.label18);
            this.ReservationPanel.Controls.Add(this.label19);
            this.ReservationPanel.Controls.Add(this.label20);
            this.ReservationPanel.Location = new System.Drawing.Point(818, 117);
            this.ReservationPanel.Name = "ReservationPanel";
            this.ReservationPanel.Size = new System.Drawing.Size(491, 245);
            this.ReservationPanel.TabIndex = 6;
            this.ReservationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ReservationPanel_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Nirmala UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(365, 50);
            this.label11.TabIndex = 16;
            this.label11.Text = "Reservation Details:";
            // 
            // TotalTextbox
            // 
            this.TotalTextbox.Location = new System.Drawing.Point(294, 126);
            this.TotalTextbox.Name = "TotalTextbox";
            this.TotalTextbox.Size = new System.Drawing.Size(100, 20);
            this.TotalTextbox.TabIndex = 12;
            // 
            // RoomTextbox
            // 
            this.RoomTextbox.Location = new System.Drawing.Point(92, 123);
            this.RoomTextbox.Name = "RoomTextbox";
            this.RoomTextbox.Size = new System.Drawing.Size(100, 20);
            this.RoomTextbox.TabIndex = 11;
            this.RoomTextbox.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // GuestTextbox
            // 
            this.GuestTextbox.Location = new System.Drawing.Point(294, 77);
            this.GuestTextbox.Name = "GuestTextbox";
            this.GuestTextbox.Size = new System.Drawing.Size(100, 20);
            this.GuestTextbox.TabIndex = 10;
            // 
            // ReservationIDTextbox
            // 
            this.ReservationIDTextbox.Location = new System.Drawing.Point(141, 76);
            this.ReservationIDTextbox.Name = "ReservationIDTextbox";
            this.ReservationIDTextbox.Size = new System.Drawing.Size(51, 20);
            this.ReservationIDTextbox.TabIndex = 9;
            this.ReservationIDTextbox.TextChanged += new System.EventHandler(this.textBox16_TextChanged);
            // 
            // ReservationSubmit
            // 
            this.ReservationSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReservationSubmit.Location = new System.Drawing.Point(257, 187);
            this.ReservationSubmit.Name = "ReservationSubmit";
            this.ReservationSubmit.Size = new System.Drawing.Size(100, 29);
            this.ReservationSubmit.TabIndex = 8;
            this.ReservationSubmit.Text = "Submit";
            this.ReservationSubmit.UseVisualStyleBackColor = true;
            this.ReservationSubmit.Click += new System.EventHandler(this.ReservationSubmit_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(110, 187);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 29);
            this.button7.TabIndex = 7;
            this.button7.Text = "Cancel";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(253, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "Total";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(42, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Room";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(253, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 16);
            this.label19.TabIndex = 1;
            this.label19.Text = "Guest";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(42, 80);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "ReservationID";
            // 
            // ListView
            // 
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(194, 40);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(577, 396);
            this.ListView.TabIndex = 7;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // MainListView
            // 
            this.MainListView.HideSelection = false;
            this.MainListView.Location = new System.Drawing.Point(216, 53);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(534, 172);
            this.MainListView.TabIndex = 8;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.SelectedIndexChanged += new System.EventHandler(this.MainListView_SelectedIndexChanged);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.ClientPanel);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.ReservationPanel);
            this.Controls.Add(this.RoomPanel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainUI";
            this.Text = "ClientsUI";
            this.Load += new System.EventHandler(this.MainUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectDatabaseDataSetBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ClientPanel.ResumeLayout(false);
            this.ClientPanel.PerformLayout();
            this.RoomPanel.ResumeLayout(false);
            this.RoomPanel.PerformLayout();
            this.ReservationPanel.ResumeLayout(false);
            this.ReservationPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource projectDatabaseDataSetBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RadioButton deleteRadioGroup;
        private System.Windows.Forms.RadioButton editRadioGroup;
        private System.Windows.Forms.RadioButton viewRadioGroup;
        private System.Windows.Forms.RadioButton addRadioGroup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel ClientPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ClientSubmit;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ReservationTextbox;
        private System.Windows.Forms.TextBox PostalCodeTextbox;
        private System.Windows.Forms.TextBox TownTextbox;
        private System.Windows.Forms.TextBox AreaTextbox;
        private System.Windows.Forms.TextBox AddressTextbox;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.TextBox ClientTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel RoomPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PriceTextbox;
        private System.Windows.Forms.TextBox RoomIDTextbox;
        private System.Windows.Forms.Button RoomSubmit;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel ReservationPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TotalTextbox;
        private System.Windows.Forms.TextBox RoomTextbox;
        private System.Windows.Forms.TextBox GuestTextbox;
        private System.Windows.Forms.TextBox ReservationIDTextbox;
        private System.Windows.Forms.Button ReservationSubmit;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ListView MainListView;
    }
}