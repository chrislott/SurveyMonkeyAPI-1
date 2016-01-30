namespace SurveyTest
{
    partial class SurveyTest
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
            this.btnGetSurveyList = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetResponseSummary = new System.Windows.Forms.Button();
            this.btnJsonRequest = new System.Windows.Forms.Button();
            this.btnJsonResponse = new System.Windows.Forms.Button();
            this.btnCreateEmailMessage = new System.Windows.Forms.Button();
            this.btnCreateSurvey = new System.Windows.Forms.Button();
            this.btnCreateRecipients = new System.Windows.Forms.Button();
            this.btnSendFlow = new System.Windows.Forms.Button();
            this.btnGetUserDetails = new System.Windows.Forms.Button();
            this.btnGetResponseCounts = new System.Windows.Forms.Button();
            this.btnGetResponses = new System.Windows.Forms.Button();
            this.btnGetRespondentList = new System.Windows.Forms.Button();
            this.btnCreateCollector = new System.Windows.Forms.Button();
            this.btnGetSurveyDetails = new System.Windows.Forms.Button();
            this.btnCreateFlow = new System.Windows.Forms.Button();
            this.btnGetCollectorList = new System.Windows.Forms.Button();
            this.btnGetTemplateList = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvSurveyList = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCollectorURL = new System.Windows.Forms.TextBox();
            this.txtCollectorThanks = new System.Windows.Forms.TextBox();
            this.txtCollectorName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rbModify = new System.Windows.Forms.RadioButton();
            this.rbCreate = new System.Windows.Forms.RadioButton();
            this.rbTitle = new System.Windows.Forms.RadioButton();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.txtTemplateID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCollectorID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtResID3 = new System.Windows.Forms.TextBox();
            this.txtResID4 = new System.Windows.Forms.TextBox();
            this.txtResID2 = new System.Windows.Forms.TextBox();
            this.txtResID1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFields = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSurveyName = new System.Windows.Forms.TextBox();
            this.chkOrderAsc = new System.Windows.Forms.CheckBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSurveyID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSurveyAnswers = new System.Windows.Forms.CheckBox();
            this.chkFull = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveyList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetSurveyList
            // 
            this.btnGetSurveyList.Location = new System.Drawing.Point(3, 90);
            this.btnGetSurveyList.Name = "btnGetSurveyList";
            this.btnGetSurveyList.Size = new System.Drawing.Size(130, 23);
            this.btnGetSurveyList.TabIndex = 0;
            this.btnGetSurveyList.Text = "Get Survey List";
            this.btnGetSurveyList.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetResponseSummary);
            this.panel1.Controls.Add(this.btnJsonRequest);
            this.panel1.Controls.Add(this.btnJsonResponse);
            this.panel1.Controls.Add(this.btnCreateEmailMessage);
            this.panel1.Controls.Add(this.btnCreateSurvey);
            this.panel1.Controls.Add(this.btnCreateRecipients);
            this.panel1.Controls.Add(this.btnSendFlow);
            this.panel1.Controls.Add(this.btnGetUserDetails);
            this.panel1.Controls.Add(this.btnGetResponseCounts);
            this.panel1.Controls.Add(this.btnGetResponses);
            this.panel1.Controls.Add(this.btnGetRespondentList);
            this.panel1.Controls.Add(this.btnCreateCollector);
            this.panel1.Controls.Add(this.btnGetSurveyDetails);
            this.panel1.Controls.Add(this.btnCreateFlow);
            this.panel1.Controls.Add(this.btnGetCollectorList);
            this.panel1.Controls.Add(this.btnGetTemplateList);
            this.panel1.Controls.Add(this.btnGetSurveyList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 664);
            this.panel1.TabIndex = 1;
            // 
            // btnGetResponseSummary
            // 
            this.btnGetResponseSummary.Location = new System.Drawing.Point(3, 411);
            this.btnGetResponseSummary.Name = "btnGetResponseSummary";
            this.btnGetResponseSummary.Size = new System.Drawing.Size(130, 23);
            this.btnGetResponseSummary.TabIndex = 16;
            this.btnGetResponseSummary.Text = "Get Response Summary";
            this.btnGetResponseSummary.UseVisualStyleBackColor = true;
            // 
            // btnJsonRequest
            // 
            this.btnJsonRequest.Location = new System.Drawing.Point(3, 482);
            this.btnJsonRequest.Name = "btnJsonRequest";
            this.btnJsonRequest.Size = new System.Drawing.Size(130, 23);
            this.btnJsonRequest.TabIndex = 15;
            this.btnJsonRequest.Text = "View JSON Request";
            this.btnJsonRequest.UseVisualStyleBackColor = true;
            // 
            // btnJsonResponse
            // 
            this.btnJsonResponse.Location = new System.Drawing.Point(3, 453);
            this.btnJsonResponse.Name = "btnJsonResponse";
            this.btnJsonResponse.Size = new System.Drawing.Size(130, 23);
            this.btnJsonResponse.TabIndex = 14;
            this.btnJsonResponse.Text = "View JSON Response";
            this.btnJsonResponse.UseVisualStyleBackColor = true;
            // 
            // btnCreateEmailMessage
            // 
            this.btnCreateEmailMessage.Location = new System.Drawing.Point(3, 235);
            this.btnCreateEmailMessage.Name = "btnCreateEmailMessage";
            this.btnCreateEmailMessage.Size = new System.Drawing.Size(130, 23);
            this.btnCreateEmailMessage.TabIndex = 13;
            this.btnCreateEmailMessage.Text = "Create Email Message";
            this.btnCreateEmailMessage.UseVisualStyleBackColor = true;
            // 
            // btnCreateSurvey
            // 
            this.btnCreateSurvey.Location = new System.Drawing.Point(3, 206);
            this.btnCreateSurvey.Name = "btnCreateSurvey";
            this.btnCreateSurvey.Size = new System.Drawing.Size(130, 23);
            this.btnCreateSurvey.TabIndex = 12;
            this.btnCreateSurvey.Text = "Create Survey";
            this.btnCreateSurvey.UseVisualStyleBackColor = true;
            // 
            // btnCreateRecipients
            // 
            this.btnCreateRecipients.Location = new System.Drawing.Point(3, 177);
            this.btnCreateRecipients.Name = "btnCreateRecipients";
            this.btnCreateRecipients.Size = new System.Drawing.Size(130, 23);
            this.btnCreateRecipients.TabIndex = 11;
            this.btnCreateRecipients.Text = "Create Recipients";
            this.btnCreateRecipients.UseVisualStyleBackColor = true;
            // 
            // btnSendFlow
            // 
            this.btnSendFlow.Location = new System.Drawing.Point(3, 119);
            this.btnSendFlow.Name = "btnSendFlow";
            this.btnSendFlow.Size = new System.Drawing.Size(130, 23);
            this.btnSendFlow.TabIndex = 10;
            this.btnSendFlow.Text = "Send Flow";
            this.btnSendFlow.UseVisualStyleBackColor = true;
            // 
            // btnGetUserDetails
            // 
            this.btnGetUserDetails.Location = new System.Drawing.Point(3, 61);
            this.btnGetUserDetails.Name = "btnGetUserDetails";
            this.btnGetUserDetails.Size = new System.Drawing.Size(130, 23);
            this.btnGetUserDetails.TabIndex = 9;
            this.btnGetUserDetails.Text = "Get User Details";
            this.btnGetUserDetails.UseVisualStyleBackColor = true;
            // 
            // btnGetResponseCounts
            // 
            this.btnGetResponseCounts.Location = new System.Drawing.Point(3, 380);
            this.btnGetResponseCounts.Name = "btnGetResponseCounts";
            this.btnGetResponseCounts.Size = new System.Drawing.Size(130, 23);
            this.btnGetResponseCounts.TabIndex = 8;
            this.btnGetResponseCounts.Text = "Get Response Counts";
            this.btnGetResponseCounts.UseVisualStyleBackColor = true;
            // 
            // btnGetResponses
            // 
            this.btnGetResponses.Location = new System.Drawing.Point(3, 351);
            this.btnGetResponses.Name = "btnGetResponses";
            this.btnGetResponses.Size = new System.Drawing.Size(130, 23);
            this.btnGetResponses.TabIndex = 7;
            this.btnGetResponses.Text = "Get Responses";
            this.btnGetResponses.UseVisualStyleBackColor = true;
            // 
            // btnGetRespondentList
            // 
            this.btnGetRespondentList.Location = new System.Drawing.Point(3, 322);
            this.btnGetRespondentList.Name = "btnGetRespondentList";
            this.btnGetRespondentList.Size = new System.Drawing.Size(130, 23);
            this.btnGetRespondentList.TabIndex = 6;
            this.btnGetRespondentList.Text = "Get Respondent List";
            this.btnGetRespondentList.UseVisualStyleBackColor = true;
            // 
            // btnCreateCollector
            // 
            this.btnCreateCollector.Location = new System.Drawing.Point(3, 293);
            this.btnCreateCollector.Name = "btnCreateCollector";
            this.btnCreateCollector.Size = new System.Drawing.Size(130, 23);
            this.btnCreateCollector.TabIndex = 5;
            this.btnCreateCollector.Text = "Create Collector";
            this.btnCreateCollector.UseVisualStyleBackColor = true;
            // 
            // btnGetSurveyDetails
            // 
            this.btnGetSurveyDetails.Location = new System.Drawing.Point(3, 32);
            this.btnGetSurveyDetails.Name = "btnGetSurveyDetails";
            this.btnGetSurveyDetails.Size = new System.Drawing.Size(130, 23);
            this.btnGetSurveyDetails.TabIndex = 4;
            this.btnGetSurveyDetails.Text = "Get Survey Details";
            this.btnGetSurveyDetails.UseVisualStyleBackColor = true;
            // 
            // btnCreateFlow
            // 
            this.btnCreateFlow.Location = new System.Drawing.Point(3, 3);
            this.btnCreateFlow.Name = "btnCreateFlow";
            this.btnCreateFlow.Size = new System.Drawing.Size(130, 23);
            this.btnCreateFlow.TabIndex = 3;
            this.btnCreateFlow.Text = "Create Flow";
            this.btnCreateFlow.UseVisualStyleBackColor = true;
            // 
            // btnGetCollectorList
            // 
            this.btnGetCollectorList.Location = new System.Drawing.Point(3, 148);
            this.btnGetCollectorList.Name = "btnGetCollectorList";
            this.btnGetCollectorList.Size = new System.Drawing.Size(130, 23);
            this.btnGetCollectorList.TabIndex = 2;
            this.btnGetCollectorList.Text = "Get Collector List";
            this.btnGetCollectorList.UseVisualStyleBackColor = true;
            // 
            // btnGetTemplateList
            // 
            this.btnGetTemplateList.Location = new System.Drawing.Point(3, 264);
            this.btnGetTemplateList.Name = "btnGetTemplateList";
            this.btnGetTemplateList.Size = new System.Drawing.Size(130, 23);
            this.btnGetTemplateList.TabIndex = 1;
            this.btnGetTemplateList.Text = "Get Template List";
            this.btnGetTemplateList.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(139, 26);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvSurveyList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.rbModify);
            this.splitContainer1.Panel2.Controls.Add(this.rbCreate);
            this.splitContainer1.Panel2.Controls.Add(this.rbTitle);
            this.splitContainer1.Panel2.Controls.Add(this.rbDefault);
            this.splitContainer1.Panel2.Controls.Add(this.txtTemplateID);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.txtCollectorID);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.txtResID3);
            this.splitContainer1.Panel2.Controls.Add(this.txtResID4);
            this.splitContainer1.Panel2.Controls.Add(this.txtResID2);
            this.splitContainer1.Panel2.Controls.Add(this.txtResID1);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.txtFields);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.txtSurveyName);
            this.splitContainer1.Panel2.Controls.Add(this.chkOrderAsc);
            this.splitContainer1.Panel2.Controls.Add(this.txtEndDate);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.txtStartDate);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtPageSize);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtPage);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtSurveyID);
            this.splitContainer1.Size = new System.Drawing.Size(723, 638);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvSurveyList
            // 
            this.dgvSurveyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSurveyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSurveyList.Location = new System.Drawing.Point(0, 0);
            this.dgvSurveyList.Name = "dgvSurveyList";
            this.dgvSurveyList.Size = new System.Drawing.Size(723, 377);
            this.dgvSurveyList.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtCollectorURL);
            this.panel3.Controls.Add(this.txtCollectorThanks);
            this.panel3.Controls.Add(this.txtCollectorName);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(9, 134);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(692, 52);
            this.panel3.TabIndex = 28;
            // 
            // txtCollectorURL
            // 
            this.txtCollectorURL.Location = new System.Drawing.Point(477, 22);
            this.txtCollectorURL.Name = "txtCollectorURL";
            this.txtCollectorURL.Size = new System.Drawing.Size(208, 20);
            this.txtCollectorURL.TabIndex = 6;
            // 
            // txtCollectorThanks
            // 
            this.txtCollectorThanks.Location = new System.Drawing.Point(260, 22);
            this.txtCollectorThanks.Name = "txtCollectorThanks";
            this.txtCollectorThanks.Size = new System.Drawing.Size(173, 20);
            this.txtCollectorThanks.TabIndex = 5;
            // 
            // txtCollectorName
            // 
            this.txtCollectorName.Location = new System.Drawing.Point(51, 22);
            this.txtCollectorName.Name = "txtCollectorName";
            this.txtCollectorName.Size = new System.Drawing.Size(134, 20);
            this.txtCollectorName.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(191, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Thank you : ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(439, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "URL : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Name : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Create Collector Fields";
            // 
            // rbModify
            // 
            this.rbModify.AutoSize = true;
            this.rbModify.Location = new System.Drawing.Point(544, 31);
            this.rbModify.Name = "rbModify";
            this.rbModify.Size = new System.Drawing.Size(85, 17);
            this.rbModify.TabIndex = 27;
            this.rbModify.Text = "Modify Order";
            this.rbModify.UseVisualStyleBackColor = true;
            // 
            // rbCreate
            // 
            this.rbCreate.AutoSize = true;
            this.rbCreate.Location = new System.Drawing.Point(453, 31);
            this.rbCreate.Name = "rbCreate";
            this.rbCreate.Size = new System.Drawing.Size(85, 17);
            this.rbCreate.TabIndex = 26;
            this.rbCreate.Text = "Create Order";
            this.rbCreate.UseVisualStyleBackColor = true;
            // 
            // rbTitle
            // 
            this.rbTitle.AutoSize = true;
            this.rbTitle.Location = new System.Drawing.Point(373, 31);
            this.rbTitle.Name = "rbTitle";
            this.rbTitle.Size = new System.Drawing.Size(74, 17);
            this.rbTitle.TabIndex = 25;
            this.rbTitle.Text = "Title Order";
            this.rbTitle.UseVisualStyleBackColor = true;
            // 
            // rbDefault
            // 
            this.rbDefault.AutoSize = true;
            this.rbDefault.Checked = true;
            this.rbDefault.Location = new System.Drawing.Point(281, 31);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(86, 17);
            this.rbDefault.TabIndex = 24;
            this.rbDefault.TabStop = true;
            this.rbDefault.Text = "Default order";
            this.rbDefault.UseVisualStyleBackColor = true;
            // 
            // txtTemplateID
            // 
            this.txtTemplateID.Location = new System.Drawing.Point(429, 82);
            this.txtTemplateID.Name = "txtTemplateID";
            this.txtTemplateID.Size = new System.Drawing.Size(100, 20);
            this.txtTemplateID.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(358, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Template ID";
            // 
            // txtCollectorID
            // 
            this.txtCollectorID.Location = new System.Drawing.Point(252, 82);
            this.txtCollectorID.Name = "txtCollectorID";
            this.txtCollectorID.Size = new System.Drawing.Size(100, 20);
            this.txtCollectorID.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(181, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Collector ID";
            // 
            // txtResID3
            // 
            this.txtResID3.Location = new System.Drawing.Point(398, 56);
            this.txtResID3.Name = "txtResID3";
            this.txtResID3.Size = new System.Drawing.Size(67, 20);
            this.txtResID3.TabIndex = 19;
            // 
            // txtResID4
            // 
            this.txtResID4.Location = new System.Drawing.Point(471, 56);
            this.txtResID4.Name = "txtResID4";
            this.txtResID4.Size = new System.Drawing.Size(67, 20);
            this.txtResID4.TabIndex = 18;
            // 
            // txtResID2
            // 
            this.txtResID2.Location = new System.Drawing.Point(325, 56);
            this.txtResID2.Name = "txtResID2";
            this.txtResID2.Size = new System.Drawing.Size(67, 20);
            this.txtResID2.TabIndex = 17;
            // 
            // txtResID1
            // 
            this.txtResID1.Location = new System.Drawing.Point(252, 56);
            this.txtResID1.Name = "txtResID1";
            this.txtResID1.Size = new System.Drawing.Size(67, 20);
            this.txtResID1.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Respondant IDs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fields";
            // 
            // txtFields
            // 
            this.txtFields.Location = new System.Drawing.Point(212, 108);
            this.txtFields.Name = "txtFields";
            this.txtFields.Size = new System.Drawing.Size(489, 20);
            this.txtFields.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Survey Name";
            // 
            // txtSurveyName
            // 
            this.txtSurveyName.Location = new System.Drawing.Point(252, 4);
            this.txtSurveyName.Name = "txtSurveyName";
            this.txtSurveyName.Size = new System.Drawing.Size(286, 20);
            this.txtSurveyName.TabIndex = 11;
            // 
            // chkOrderAsc
            // 
            this.chkOrderAsc.AutoSize = true;
            this.chkOrderAsc.Location = new System.Drawing.Point(190, 32);
            this.chkOrderAsc.Name = "chkOrderAsc";
            this.chkOrderAsc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkOrderAsc.Size = new System.Drawing.Size(76, 17);
            this.chkOrderAsc.TabIndex = 10;
            this.chkOrderAsc.Text = "Order ASC";
            this.chkOrderAsc.UseVisualStyleBackColor = true;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(66, 108);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(90, 20);
            this.txtEndDate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "End Date";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(66, 82);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(90, 20);
            this.txtStartDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Start Date";
            // 
            // txtPageSize
            // 
            this.txtPageSize.Location = new System.Drawing.Point(66, 56);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(90, 20);
            this.txtPageSize.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Page Size";
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(66, 30);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(90, 20);
            this.txtPage.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Page";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Survey ID";
            // 
            // txtSurveyID
            // 
            this.txtSurveyID.Location = new System.Drawing.Point(66, 4);
            this.txtSurveyID.Name = "txtSurveyID";
            this.txtSurveyID.Size = new System.Drawing.Size(90, 20);
            this.txtSurveyID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Return Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(290, 7);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 3;
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(309, 7);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMsg.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkSurveyAnswers);
            this.panel2.Controls.Add(this.chkFull);
            this.panel2.Controls.Add(this.lblErrorMsg);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(139, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 26);
            this.panel2.TabIndex = 3;
            // 
            // chkSurveyAnswers
            // 
            this.chkSurveyAnswers.AutoSize = true;
            this.chkSurveyAnswers.Location = new System.Drawing.Point(107, 6);
            this.chkSurveyAnswers.Name = "chkSurveyAnswers";
            this.chkSurveyAnswers.Size = new System.Drawing.Size(96, 17);
            this.chkSurveyAnswers.TabIndex = 6;
            this.chkSurveyAnswers.Text = "Flatten Results";
            this.chkSurveyAnswers.UseVisualStyleBackColor = true;
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.Location = new System.Drawing.Point(6, 6);
            this.chkFull.Name = "chkFull";
            this.chkFull.Size = new System.Drawing.Size(95, 17);
            this.chkFull.TabIndex = 5;
            this.chkFull.Text = "Run Full Mode";
            this.chkFull.UseVisualStyleBackColor = true;
            // 
            // SurveyTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 664);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SurveyTest";
            this.Text = "SurveyTest";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSurveyList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.Button btnGetSurveyList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvSurveyList;
        private System.Windows.Forms.Button btnGetTemplateList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblErrorMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkFull;
        private System.Windows.Forms.Button btnGetCollectorList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFields;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSurveyName;
        private System.Windows.Forms.CheckBox chkOrderAsc;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSurveyID;
        private System.Windows.Forms.Button btnSendFlow;
        private System.Windows.Forms.Button btnGetUserDetails;
        private System.Windows.Forms.Button btnGetResponseCounts;
        private System.Windows.Forms.Button btnGetResponses;
        private System.Windows.Forms.Button btnGetRespondentList;
        private System.Windows.Forms.Button btnCreateCollector;
        private System.Windows.Forms.Button btnGetSurveyDetails;
        private System.Windows.Forms.Button btnCreateFlow;
        private System.Windows.Forms.Button btnCreateEmailMessage;
        private System.Windows.Forms.Button btnCreateSurvey;
        private System.Windows.Forms.Button btnCreateRecipients;
        private System.Windows.Forms.TextBox txtResID3;
        private System.Windows.Forms.TextBox txtResID4;
        private System.Windows.Forms.TextBox txtResID2;
        private System.Windows.Forms.TextBox txtResID1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkSurveyAnswers;
        private System.Windows.Forms.TextBox txtCollectorID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnJsonResponse;
        private System.Windows.Forms.TextBox txtTemplateID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rbModify;
        private System.Windows.Forms.RadioButton rbCreate;
        private System.Windows.Forms.RadioButton rbTitle;
        private System.Windows.Forms.RadioButton rbDefault;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCollectorURL;
        private System.Windows.Forms.TextBox txtCollectorThanks;
        private System.Windows.Forms.TextBox txtCollectorName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnJsonRequest;
        private System.Windows.Forms.Button btnGetResponseSummary;
    }
}

