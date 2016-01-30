using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SurveyMonkey.Containers;
using SurveyMonkey;

namespace SurveyTest
{
    /// <summary>
    /// Form for sending out an existing survey
    /// </summary>
    public partial class SendFlowForm : Form
    {
        public SendFlowRequest sfrData { get; set; }
        public SendFlowForm()
        {
            InitializeComponent();

            btnDone.Click += BtnDone_Click;
            this.FormClosing += CreateFlowForm_FormClosing;

            sfrData = new SendFlowRequest();

            List<RecipientInfo> rfi = new List<RecipientInfo>();
            BindingSource bs = new BindingSource();
            bs.DataSource = rfi;
            dgvRecipients.DataSource = bs;

        }

        private void CreateFlowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StoreData();

            this.Visible = false;
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            StoreData();

            this.Visible = false;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Grabs input from textboxes in form and stores them in the SendFlowRequest data object
        /// </summary>
        private void StoreData ()
        {
            // =======================================================
            // Survey stuff...
            if (txtSurveyID.Text.Trim().Length > 0)
            {
                sfrData.SurveyID = txtSurveyID.Text;
            }            
            // =======================================================


            // =======================================================
            // Email mesage
            if (txtEmailBody.Text.Trim().Length > 0)
            {
                sfrData.EmailMessage.BodyText = txtEmailBody.Text.Trim();
            }
            if (txtEmailBody.Text.Trim().Length > 0)
            {
                sfrData.EmailMessage.BodyText = txtEmailBody.Text.Trim();
            }
            if (txtEmailReplyTo.Text.Trim().Length > 0)
            {
                sfrData.EmailMessage.ReplyEmail = txtEmailReplyTo.Text.Trim();
            }
            if (txtEmailSubject.Text.Trim().Length > 0)
            {
                sfrData.EmailMessage.Subject = txtEmailSubject.Text.Trim();
            }
            // =======================================================


            // =======================================================
            // Collector
            sfrData.Collector.RecipientList = ((List<RecipientInfo>)((BindingSource)dgvRecipients.DataSource).DataSource).ToArray();
            if (txtCollectorName.Text.Trim().Length > 0)
            {
                sfrData.Collector.Name = txtCollectorName.Text.Trim();
            }
            if (txtCollectorRedirectURL.Text.Trim().Length > 0)
            {
                sfrData.Collector.RedirectURL = txtCollectorRedirectURL.Text.Trim();
            }
            if (txtCollectorThankYou.Text.Trim().Length > 0)
            {
                sfrData.Collector.ThankYouMsg = txtCollectorThankYou.Text.Trim();
            }

            sfrData.Collector.SendEmailNotification = true;

            sfrData.Collector.Type = CollectorTypeEnum.Email; // only email is supported by surveymonkey as of Jan, 2016
            // =======================================================

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void SendFlowForm_Load(object sender, EventArgs e)
        {

        }
    }
}
