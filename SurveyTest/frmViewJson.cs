using System.Windows.Forms;

namespace SurveyTest
{
    /// <summary>
    /// Form for viewing Json request and response data
    /// </summary>
    public partial class frmViewJson : Form
    {
        public string JSON
        {
            set { txtJSON.Text = value; }
        }
        public frmViewJson()
        {
            InitializeComponent();
            this.FormClosing += FrmViewJson_FormClosing;
        }

        private void FrmViewJson_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
