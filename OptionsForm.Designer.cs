namespace NotepadLight
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonForeColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFont = new System.Windows.Forms.Button();
            this.labelPreview = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Backcolor:";
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(76, 12);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(28, 23);
            this.buttonBackColor.TabIndex = 1;
            this.buttonBackColor.Text = "...";
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Forecolor:";
            // 
            // buttonForeColor
            // 
            this.buttonForeColor.Location = new System.Drawing.Point(170, 12);
            this.buttonForeColor.Name = "buttonForeColor";
            this.buttonForeColor.Size = new System.Drawing.Size(28, 23);
            this.buttonForeColor.TabIndex = 3;
            this.buttonForeColor.Text = "...";
            this.buttonForeColor.Click += new System.EventHandler(this.buttonForeColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "F&ont:";
            // 
            // buttonFont
            // 
            this.buttonFont.Location = new System.Drawing.Point(241, 12);
            this.buttonFont.Name = "buttonFont";
            this.buttonFont.Size = new System.Drawing.Size(28, 23);
            this.buttonFont.TabIndex = 5;
            this.buttonFont.Text = "...";
            this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
            // 
            // labelPreview
            // 
            this.labelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPreview.BackColor = global::NotepadLight.Properties.Settings.Default.BackColor;
            this.labelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPreview.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::NotepadLight.Properties.Settings.Default, "ForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelPreview.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::NotepadLight.Properties.Settings.Default, "Font", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelPreview.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::NotepadLight.Properties.Settings.Default, "BackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelPreview.Font = global::NotepadLight.Properties.Settings.Default.Font;
            this.labelPreview.ForeColor = global::NotepadLight.Properties.Settings.Default.ForeColor;
            this.labelPreview.Location = new System.Drawing.Point(12, 38);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(257, 85);
            this.labelPreview.TabIndex = 6;
            this.labelPreview.Text = "Courier New; 10pt";
            this.labelPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelPreview.UseMnemonic = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(113, 126);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(32, 126);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.FontMustExist = true;
            // 
            // buttonDefault
            // 
            this.buttonDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDefault.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.buttonDefault.Location = new System.Drawing.Point(194, 126);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(75, 23);
            this.buttonDefault.TabIndex = 9;
            this.buttonDefault.Text = "&Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(281, 161);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.buttonFont);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonForeColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBackColor);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(297, 199);
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonForeColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button buttonDefault;
    }
}