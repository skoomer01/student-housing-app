namespace Student_housing
{
    partial class ADMIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMIN));
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpAdminUsers = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tpAdminComplaints = new System.Windows.Forms.TabPage();
            this.tpAdminTechnical = new System.Windows.Forms.TabPage();
            this.tpAdminRules = new System.Windows.Forms.TabPage();
            this.lblGuidelines = new System.Windows.Forms.Label();
            this.lblRules = new System.Windows.Forms.Label();
            this.rtbGuidelines = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtbRules = new System.Windows.Forms.RichTextBox();
            this.pbProfile = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbLogOut = new System.Windows.Forms.PictureBox();
            this.pbNotification = new System.Windows.Forms.PictureBox();
            this.btnRulesAdminTab = new System.Windows.Forms.Button();
            this.btnTechnicalAdminTab = new System.Windows.Forms.Button();
            this.btnComplaintsAdminTab = new System.Windows.Forms.Button();
            this.btnUsersAdminTab = new System.Windows.Forms.Button();
            this.buttonPannelAdmin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtxCreateWarning = new System.Windows.Forms.RichTextBox();
            this.lblPlanParty = new System.Windows.Forms.Label();
            this.lbxAllComplaints = new System.Windows.Forms.ListBox();
            this.lblPartyPlanDay = new System.Windows.Forms.Label();
            this.btnRemoveComplaint = new System.Windows.Forms.Button();
            this.cbxComplaintUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendWarning = new System.Windows.Forms.Button();
            this.tcAdmin.SuspendLayout();
            this.tpAdminUsers.SuspendLayout();
            this.tpAdminComplaints.SuspendLayout();
            this.tpAdminRules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpAdminUsers);
            this.tcAdmin.Controls.Add(this.tpAdminComplaints);
            this.tcAdmin.Controls.Add(this.tpAdminTechnical);
            this.tcAdmin.Controls.Add(this.tpAdminRules);
            this.tcAdmin.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAdmin.Location = new System.Drawing.Point(150, 143);
            this.tcAdmin.Multiline = true;
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1250, 556);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpAdminUsers
            // 
            this.tpAdminUsers.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminUsers.Controls.Add(this.textBox2);
            this.tpAdminUsers.Controls.Add(this.textBox1);
            this.tpAdminUsers.Controls.Add(this.button1);
            this.tpAdminUsers.Location = new System.Drawing.Point(4, 24);
            this.tpAdminUsers.Name = "tpAdminUsers";
            this.tpAdminUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdminUsers.Size = new System.Drawing.Size(1242, 528);
            this.tpAdminUsers.TabIndex = 0;
            this.tpAdminUsers.Text = "Users";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(170, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tpAdminComplaints
            // 
            this.tpAdminComplaints.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminComplaints.Controls.Add(this.btnSendWarning);
            this.tpAdminComplaints.Controls.Add(this.label2);
            this.tpAdminComplaints.Controls.Add(this.label1);
            this.tpAdminComplaints.Controls.Add(this.cbxComplaintUser);
            this.tpAdminComplaints.Controls.Add(this.btnRemoveComplaint);
            this.tpAdminComplaints.Controls.Add(this.lblPartyPlanDay);
            this.tpAdminComplaints.Controls.Add(this.lbxAllComplaints);
            this.tpAdminComplaints.Controls.Add(this.lblPlanParty);
            this.tpAdminComplaints.Controls.Add(this.rtxCreateWarning);
            this.tpAdminComplaints.Location = new System.Drawing.Point(4, 24);
            this.tpAdminComplaints.Name = "tpAdminComplaints";
            this.tpAdminComplaints.Padding = new System.Windows.Forms.Padding(3);
            this.tpAdminComplaints.Size = new System.Drawing.Size(1242, 528);
            this.tpAdminComplaints.TabIndex = 1;
            this.tpAdminComplaints.Text = "Complaints";
            // 
            // tpAdminTechnical
            // 
            this.tpAdminTechnical.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminTechnical.Location = new System.Drawing.Point(4, 24);
            this.tpAdminTechnical.Name = "tpAdminTechnical";
            this.tpAdminTechnical.Size = new System.Drawing.Size(1242, 528);
            this.tpAdminTechnical.TabIndex = 2;
            this.tpAdminTechnical.Text = "Technical Visits";
            // 
            // tpAdminRules
            // 
            this.tpAdminRules.BackColor = System.Drawing.Color.Ivory;
            this.tpAdminRules.Controls.Add(this.lblGuidelines);
            this.tpAdminRules.Controls.Add(this.lblRules);
            this.tpAdminRules.Controls.Add(this.rtbGuidelines);
            this.tpAdminRules.Controls.Add(this.btnSave);
            this.tpAdminRules.Controls.Add(this.rtbRules);
            this.tpAdminRules.Location = new System.Drawing.Point(4, 24);
            this.tpAdminRules.Name = "tpAdminRules";
            this.tpAdminRules.Size = new System.Drawing.Size(1242, 528);
            this.tpAdminRules.TabIndex = 3;
            this.tpAdminRules.Text = "Rules & Guidelines";
            // 
            // lblGuidelines
            // 
            this.lblGuidelines.AutoSize = true;
            this.lblGuidelines.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuidelines.Location = new System.Drawing.Point(901, 2);
            this.lblGuidelines.Name = "lblGuidelines";
            this.lblGuidelines.Size = new System.Drawing.Size(88, 21);
            this.lblGuidelines.TabIndex = 7;
            this.lblGuidelines.Text = "Guidelines";
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.Location = new System.Drawing.Point(254, 3);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(52, 21);
            this.lblRules.TabIndex = 6;
            this.lblRules.Text = "Rules";
            // 
            // rtbGuidelines
            // 
            this.rtbGuidelines.Location = new System.Drawing.Point(708, 36);
            this.rtbGuidelines.Name = "rtbGuidelines";
            this.rtbGuidelines.Size = new System.Drawing.Size(521, 387);
            this.rtbGuidelines.TabIndex = 4;
            this.rtbGuidelines.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(398, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(467, 53);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE TO FILE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rtbRules
            // 
            this.rtbRules.Location = new System.Drawing.Point(30, 38);
            this.rtbRules.Name = "rtbRules";
            this.rtbRules.Size = new System.Drawing.Size(521, 387);
            this.rtbRules.TabIndex = 2;
            this.rtbRules.Text = "";
            // 
            // pbProfile
            // 
            this.pbProfile.Image = ((System.Drawing.Image)(resources.GetObject("pbProfile.Image")));
            this.pbProfile.Location = new System.Drawing.Point(12, 16);
            this.pbProfile.Name = "pbProfile";
            this.pbProfile.Size = new System.Drawing.Size(132, 121);
            this.pbProfile.TabIndex = 1;
            this.pbProfile.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.lblTitle.Location = new System.Drawing.Point(150, 54);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(499, 60);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Welcome back, <name>";
            // 
            // pbLogOut
            // 
            this.pbLogOut.Image = ((System.Drawing.Image)(resources.GetObject("pbLogOut.Image")));
            this.pbLogOut.Location = new System.Drawing.Point(1787, 46);
            this.pbLogOut.Name = "pbLogOut";
            this.pbLogOut.Size = new System.Drawing.Size(95, 91);
            this.pbLogOut.TabIndex = 5;
            this.pbLogOut.TabStop = false;
            this.pbLogOut.Click += new System.EventHandler(this.pbLogOut_Click);
            // 
            // pbNotification
            // 
            this.pbNotification.Image = ((System.Drawing.Image)(resources.GetObject("pbNotification.Image")));
            this.pbNotification.Location = new System.Drawing.Point(1576, 46);
            this.pbNotification.Name = "pbNotification";
            this.pbNotification.Size = new System.Drawing.Size(102, 91);
            this.pbNotification.TabIndex = 7;
            this.pbNotification.TabStop = false;
            // 
            // btnRulesAdminTab
            // 
            this.btnRulesAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnRulesAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRulesAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRulesAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnRulesAdminTab.Location = new System.Drawing.Point(-4, 372);
            this.btnRulesAdminTab.Name = "btnRulesAdminTab";
            this.btnRulesAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnRulesAdminTab.TabIndex = 14;
            this.btnRulesAdminTab.Text = "Rules/Guidelines";
            this.btnRulesAdminTab.UseVisualStyleBackColor = false;
            this.btnRulesAdminTab.Click += new System.EventHandler(this.btnRuesAdminTab_Click);
            // 
            // btnTechnicalAdminTab
            // 
            this.btnTechnicalAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnTechnicalAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTechnicalAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechnicalAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnTechnicalAdminTab.Location = new System.Drawing.Point(-4, 297);
            this.btnTechnicalAdminTab.Name = "btnTechnicalAdminTab";
            this.btnTechnicalAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnTechnicalAdminTab.TabIndex = 13;
            this.btnTechnicalAdminTab.Text = "Technical Visits";
            this.btnTechnicalAdminTab.UseVisualStyleBackColor = false;
            this.btnTechnicalAdminTab.Click += new System.EventHandler(this.btnTechnicalAdminTab_Click);
            // 
            // btnComplaintsAdminTab
            // 
            this.btnComplaintsAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnComplaintsAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComplaintsAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplaintsAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnComplaintsAdminTab.Location = new System.Drawing.Point(-4, 222);
            this.btnComplaintsAdminTab.Name = "btnComplaintsAdminTab";
            this.btnComplaintsAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnComplaintsAdminTab.TabIndex = 12;
            this.btnComplaintsAdminTab.Text = "Complaints";
            this.btnComplaintsAdminTab.UseVisualStyleBackColor = false;
            this.btnComplaintsAdminTab.Click += new System.EventHandler(this.btnComplaintsAdminTab_Click);
            // 
            // btnUsersAdminTab
            // 
            this.btnUsersAdminTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnUsersAdminTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUsersAdminTab.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsersAdminTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnUsersAdminTab.Location = new System.Drawing.Point(-4, 147);
            this.btnUsersAdminTab.Name = "btnUsersAdminTab";
            this.btnUsersAdminTab.Size = new System.Drawing.Size(148, 69);
            this.btnUsersAdminTab.TabIndex = 11;
            this.btnUsersAdminTab.Text = "Users";
            this.btnUsersAdminTab.UseVisualStyleBackColor = false;
            this.btnUsersAdminTab.Click += new System.EventHandler(this.btnUsersAdminTab_Click);
            // 
            // buttonPannelAdmin
            // 
            this.buttonPannelAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.buttonPannelAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonPannelAdmin.Location = new System.Drawing.Point(131, 147);
            this.buttonPannelAdmin.Name = "buttonPannelAdmin";
            this.buttonPannelAdmin.Size = new System.Drawing.Size(13, 69);
            this.buttonPannelAdmin.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1333, 54);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // rtxCreateWarning
            // 
            this.rtxCreateWarning.Location = new System.Drawing.Point(798, 155);
            this.rtxCreateWarning.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rtxCreateWarning.Name = "rtxCreateWarning";
            this.rtxCreateWarning.Size = new System.Drawing.Size(404, 286);
            this.rtxCreateWarning.TabIndex = 34;
            this.rtxCreateWarning.Text = "";
            // 
            // lblPlanParty
            // 
            this.lblPlanParty.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanParty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(21)))), ((int)(((byte)(101)))));
            this.lblPlanParty.Location = new System.Drawing.Point(4, 9);
            this.lblPlanParty.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPlanParty.Name = "lblPlanParty";
            this.lblPlanParty.Size = new System.Drawing.Size(397, 40);
            this.lblPlanParty.TabIndex = 35;
            this.lblPlanParty.Text = "Create and review complaints";
            // 
            // lbxAllComplaints
            // 
            this.lbxAllComplaints.ColumnWidth = 748;
            this.lbxAllComplaints.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAllComplaints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lbxAllComplaints.FormattingEnabled = true;
            this.lbxAllComplaints.HorizontalScrollbar = true;
            this.lbxAllComplaints.ItemHeight = 21;
            this.lbxAllComplaints.Location = new System.Drawing.Point(34, 80);
            this.lbxAllComplaints.Margin = new System.Windows.Forms.Padding(1);
            this.lbxAllComplaints.Name = "lbxAllComplaints";
            this.lbxAllComplaints.ScrollAlwaysVisible = true;
            this.lbxAllComplaints.Size = new System.Drawing.Size(461, 361);
            this.lbxAllComplaints.TabIndex = 36;
            // 
            // lblPartyPlanDay
            // 
            this.lblPartyPlanDay.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyPlanDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.lblPartyPlanDay.Location = new System.Drawing.Point(30, 53);
            this.lblPartyPlanDay.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblPartyPlanDay.Name = "lblPartyPlanDay";
            this.lblPartyPlanDay.Size = new System.Drawing.Size(209, 26);
            this.lblPartyPlanDay.TabIndex = 37;
            this.lblPartyPlanDay.Text = "All the complaints sent:";
            // 
            // btnRemoveComplaint
            // 
            this.btnRemoveComplaint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnRemoveComplaint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveComplaint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveComplaint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveComplaint.Location = new System.Drawing.Point(166, 455);
            this.btnRemoveComplaint.Margin = new System.Windows.Forms.Padding(1);
            this.btnRemoveComplaint.Name = "btnRemoveComplaint";
            this.btnRemoveComplaint.Size = new System.Drawing.Size(175, 53);
            this.btnRemoveComplaint.TabIndex = 38;
            this.btnRemoveComplaint.Text = "Remove complaint";
            this.btnRemoveComplaint.UseVisualStyleBackColor = false;
            this.btnRemoveComplaint.Click += new System.EventHandler(this.btnRemoveComplaint_Click);
            // 
            // cbxComplaintUser
            // 
            this.cbxComplaintUser.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxComplaintUser.FormattingEnabled = true;
            this.cbxComplaintUser.ItemHeight = 27;
            this.cbxComplaintUser.Location = new System.Drawing.Point(798, 84);
            this.cbxComplaintUser.Name = "cbxComplaintUser";
            this.cbxComplaintUser.Size = new System.Drawing.Size(224, 35);
            this.cbxComplaintUser.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.label1.Location = new System.Drawing.Point(794, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 40;
            this.label1.Text = "Select a user:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(44)))));
            this.label2.Location = new System.Drawing.Point(794, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 41;
            this.label2.Text = "Write a complaint:";
            // 
            // btnSendWarning
            // 
            this.btnSendWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(171)))), ((int)(((byte)(188)))));
            this.btnSendWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendWarning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendWarning.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSendWarning.Location = new System.Drawing.Point(925, 455);
            this.btnSendWarning.Margin = new System.Windows.Forms.Padding(1);
            this.btnSendWarning.Name = "btnSendWarning";
            this.btnSendWarning.Size = new System.Drawing.Size(175, 53);
            this.btnSendWarning.TabIndex = 42;
            this.btnSendWarning.Text = "Sent a warning to the user";
            this.btnSendWarning.UseVisualStyleBackColor = false;
            this.btnSendWarning.Click += new System.EventHandler(this.btnSendWarning_Click);
            // 
            // ADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1412, 711);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonPannelAdmin);
            this.Controls.Add(this.btnRulesAdminTab);
            this.Controls.Add(this.btnTechnicalAdminTab);
            this.Controls.Add(this.btnComplaintsAdminTab);
            this.Controls.Add(this.btnUsersAdminTab);
            this.Controls.Add(this.pbNotification);
            this.Controls.Add(this.pbLogOut);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbProfile);
            this.Controls.Add(this.tcAdmin);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ADMIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ADMIN";
            this.Load += new System.EventHandler(this.ADMIN_Load);
            this.tcAdmin.ResumeLayout(false);
            this.tpAdminUsers.ResumeLayout(false);
            this.tpAdminUsers.PerformLayout();
            this.tpAdminComplaints.ResumeLayout(false);
            this.tpAdminRules.ResumeLayout(false);
            this.tpAdminRules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tpAdminUsers;
        private System.Windows.Forms.TabPage tpAdminComplaints;
        private System.Windows.Forms.PictureBox pbProfile;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbLogOut;
        private System.Windows.Forms.PictureBox pbNotification;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRulesAdminTab;
        private System.Windows.Forms.Button btnTechnicalAdminTab;
        private System.Windows.Forms.Button btnComplaintsAdminTab;
        private System.Windows.Forms.Button btnUsersAdminTab;
        private System.Windows.Forms.Panel buttonPannelAdmin;
        private System.Windows.Forms.TabPage tpAdminTechnical;
        private System.Windows.Forms.TabPage tpAdminRules;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGuidelines;
        private System.Windows.Forms.Label lblRules;
        private System.Windows.Forms.RichTextBox rtbGuidelines;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbRules;
        private System.Windows.Forms.RichTextBox rtxCreateWarning;
        private System.Windows.Forms.Label lblPlanParty;
        private System.Windows.Forms.ListBox lbxAllComplaints;
        private System.Windows.Forms.Label lblPartyPlanDay;
        private System.Windows.Forms.Button btnRemoveComplaint;
        private System.Windows.Forms.Button btnSendWarning;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxComplaintUser;
    }
}