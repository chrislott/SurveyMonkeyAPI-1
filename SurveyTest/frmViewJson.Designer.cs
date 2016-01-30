namespace SurveyTest
{
    partial class frmViewJson
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
            this.txtJSON = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtJSON
            // 
            this.txtJSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJSON.Location = new System.Drawing.Point(0, 0);
            this.txtJSON.Multiline = true;
            this.txtJSON.Name = "txtJSON";
            this.txtJSON.Size = new System.Drawing.Size(483, 461);
            this.txtJSON.TabIndex = 0;
            // 
            // frmViewJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 461);
            this.Controls.Add(this.txtJSON);
            this.Name = "frmViewJson";
            this.Text = "frmViewJson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJSON;
    }
}