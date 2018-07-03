using System;
using System.Windows.Forms;
using NotepadLight.Properties;

namespace NotepadLight
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            this.labelPreview.Text = this.labelPreview.Font.Name + ", " + this.labelPreview.Font.Size;
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = Settings.Default.BackColor;
            if (this.colorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Settings.Default.BackColor = this.colorDialog1.Color;
            }
        }

        private void buttonForeColor_Click(object sender, EventArgs e)
        {
            this.colorDialog1.Color = Settings.Default.ForeColor;
            if (this.colorDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Settings.Default.ForeColor = this.colorDialog1.Color;
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            this.fontDialog1.Font = Settings.Default.Font;
            if (this.fontDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Settings.Default.Font = this.fontDialog1.Font;
                this.labelPreview.Text = this.labelPreview.Font.Name + ", " + this.labelPreview.Font.Size;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            //this.Close();
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // user hit close button in caption
                this.buttonCancel_Click(sender, e);
            }
        }
    }
}
