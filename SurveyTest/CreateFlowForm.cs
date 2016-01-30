using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SurveyMonkey.Containers;
using SurveyMonkey;

namespace SurveyTest
{
    /// <summary>
    /// Form for creating a new survey to send out to respondents
    /// </summary>
    public partial class CreateFlowForm : Form
    {
        public CreateFlowRequest cfrData { get; set; }
        public CreateFlowForm()
        {
            InitializeComponent();

            btnDone.Click += BtnDone_Click;
            this.FormClosing += CreateFlowForm_FormClosing;

            cfrData = new CreateFlowRequest();

            cbxLanguage.DataSource = Enum.GetNames(typeof(LanguageEnum));

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
        /// Grabs input from textboxes in form and stores them in the CreateFlowRequest data object
        /// </summary>
        private void StoreData ()
        { 
            // =======================================================
            // Survey stuff...
            LanguageEnum lang;
            if (txtSurveyID.Text.Trim().Length > 0)
            {
                cfrData.Survey.SurveyID = txtSurveyID.Text;
            }
            if (txtTemplateID.Text.Trim().Length > 0)
            {
                cfrData.Survey.TemplateID = txtTemplateID.Text;
            }
            lang = (LanguageEnum) Enum.Parse(typeof(LanguageEnum), cbxLanguage.SelectedValue.ToString());
            if (lang != LanguageEnum.NotSet)
            {
                cfrData.Survey.Language = lang;
            }
            if (txtTitle.Text.Trim().Length > 0)
            {
                cfrData.Survey.Title = txtTitle.Text;
            }
            // =======================================================


            // =======================================================
            // Email mesage
            if (txtEmailBody.Text.Trim().Length > 0)
            {
                cfrData.EmailMessage.BodyText = txtEmailBody.Text.Trim();
            }
            if (txtEmailBody.Text.Trim().Length > 0)
            {
                cfrData.EmailMessage.BodyText = txtEmailBody.Text.Trim();
            }
            if (txtEmailReplyTo.Text.Trim().Length > 0)
            {
                cfrData.EmailMessage.ReplyEmail = txtEmailReplyTo.Text.Trim();
            }
            if (txtEmailSubject.Text.Trim().Length > 0)
            {
                cfrData.EmailMessage.Subject = txtEmailSubject.Text.Trim();
            }
            // =======================================================


            // =======================================================
            // Collector
            cfrData.Collector.RecipientList = ((List<RecipientInfo>)((BindingSource)dgvRecipients.DataSource).DataSource).ToArray();
            if (txtCollectorName.Text.Trim().Length > 0)
            {
                cfrData.Collector.Name = txtCollectorName.Text.Trim();
            }
            if (txtCollectorRedirectURL.Text.Trim().Length > 0)
            {
                cfrData.Collector.RedirectURL = txtCollectorRedirectURL.Text.Trim();
            }
            if (txtCollectorThankYou.Text.Trim().Length > 0)
            {
                cfrData.Collector.ThankYouMsg = txtCollectorThankYou.Text.Trim();
            }

            cfrData.Collector.SendEmailNotification = true;

            cfrData.Collector.Type = CollectorTypeEnum.Email; // only allows email for now.
            // =======================================================

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
