#define USE_DESIGNER

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NotepadLight.Properties;

namespace NotepadLight
{
    public partial class Form1 : Form
    {
        #region Fields/Properties
        private string filename;
        private string FileName
        {
            get
            {
                return string.IsNullOrEmpty(this.filename) ? "Untitled" : Path.GetFileName(this.filename);
            }
        }
        #endregion

        #region Ctor/dtor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void UpdateCaption()
        {
            this.Text = Application.ProductName + " - " + this.FileName + (this.textBox1.Modified ? " *" : string.Empty);
        }

        private bool SaveFile(string filename)
        {
            Debug.Assert(!string.IsNullOrEmpty(filename));
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.toolStripStatusLabel1.Text = "Saving...";
                Application.DoEvents();
                File.WriteAllText(filename, this.textBox1.Text, Encoding.Default);
                //Thread.Sleep(500);
                this.textBox1.Modified = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                this.toolStripStatusLabel1.Text = "Ready";
                this.Cursor = this.DefaultCursor; ;
            }
        }

        private bool LoadFile(string filename)
        {
            Debug.Assert(!string.IsNullOrEmpty(filename));
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.toolStripStatusLabel1.Text = "Loading...";
                Application.DoEvents();
                this.textBox1.Text = File.ReadAllText(filename, Encoding.Default);
                //Thread.Sleep(500);
                this.textBox1.Modified = false;
                this.filename = filename;
                this.textBox1.SelectionStart = 0;
                this.textBox1.SelectionLength = 0;
                this.UpdateCaption();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                this.toolStripStatusLabel1.Text = "Ready";
                this.Cursor = this.DefaultCursor;
            }
        }

        private bool SaveChanges(bool prompt)
        {
            if (!this.textBox1.Modified)
                return true;
            else if (prompt)
            {
                DialogResult result = MessageBox.Show(this, "Do you want to save changes made to " + this.FileName + "?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                    return false;
                else if (result == DialogResult.No)
                    return true;
            }

            // check filename
            if (string.IsNullOrEmpty(this.filename))
            {
#if(!USE_DESIGNER)
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.AddExtension = true;
                    sfd.CheckPathExists = true;
                    sfd.DefaultExt = "txt";
                    sfd.DereferenceLinks = true;
                    sfd.Filter = "Text Files|*.txt|All Files|*.*";
                    sfd.FilterIndex = 1;
                    sfd.OverwritePrompt = true;
                    sfd.Title = "Save File";
                    if (sfd.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                        return false;
                    this.filename = sfd.FileName;
                }
#else
                if (this.saveFileDialog1.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                    return false;
                this.filename = this.saveFileDialog1.FileName;
#endif
            }

            // now save
            return this.SaveFile(this.filename);
        }
        #endregion

        #region Event handlers
        private void Form1_Load(object sender, EventArgs e)
        {
            this.UpdateCaption();
            //this.textBox1.BackColor = Settings.Default.BackColor;
            //this.textBox1.ForeColor = Settings.Default.ForeColor;
            //this.textBox1.Font = Settings.Default.Font;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check if text has been modified, if so ask to save changes
            if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
                return;
            else if (!this.SaveChanges(true))
                e.Cancel = true;
        }

        private void textBox1_ModifiedChanged(object sender, EventArgs e)
        {
            this.UpdateCaption();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region File menu items
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check if text has been modified, if so ask to save changes
            if (!this.SaveChanges(true))
                return;

            // reset filename and modified flag
            this.filename = null;
            this.textBox1.Clear();
            this.textBox1.Modified = false;
            this.UpdateCaption();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // check if text has been modified, if so ask to save changes
            if (!this.SaveChanges(true))
                return;

#if(!USE_DESIGNER)
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.AddExtension = true;
                ofd.CheckFileExists = true;
                ofd.DefaultExt = "txt";
                ofd.DereferenceLinks = true;
                ofd.Filter = "Text Files|*.txt|All Files|*.*";
                ofd.FilterIndex = 1;
                ofd.Multiselect = false;
                ofd.Title = "Open File";
                if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.LoadFile(ofd.FileName);
                }
            }
#else
            if (this.openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.LoadFile(this.openFileDialog1.FileName);
            }
#endif
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if no filename has been set yet, invoke save as instead
            if (string.IsNullOrEmpty(this.filename))
            {
                this.saveAsToolStripMenuItem_Click(sender, e);
                return;
            }

            this.SaveFile(this.filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // aks for filename, then call save
#if(!USE_DESIGNER)
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.AddExtension = true;
                sfd.CheckPathExists = true;
                sfd.DefaultExt = "txt";
                sfd.DereferenceLinks = true;
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                sfd.FilterIndex = 1;
                sfd.OverwritePrompt = true;
                sfd.Title = "Save File";
                if (sfd.ShowDialog(this) != DialogResult.OK)
                    return;
                else if (this.SaveFile(sfd.FileName))
                {
                    this.filename = sfd.FileName;
                    this.UpdateCaption();
                }
            }
#else
            if (this.saveFileDialog1.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            else if (this.SaveFile(this.saveFileDialog1.FileName))
            {
                this.filename = this.saveFileDialog1.FileName;
                this.UpdateCaption();
            }
#endif
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.printDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog(this);
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Edit menu items
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.SelectAll();
        }
        #endregion

        #region Other menu items
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OptionsForm options = new OptionsForm())
            {
                options.ShowDialog(this);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 about = new AboutBox1())
            {
                about.ShowDialog(this);
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.WordWrap = !Settings.Default.WordWrap;
            Settings.Default.Save();
        }
        #endregion

        #region Printing stuff
        private string stringToPrint;

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.stringToPrint = this.textBox1.Text;
            this.printDocument1.DocumentName = this.FileName;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(this.stringToPrint, this.textBox1.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.textBox1.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            this.stringToPrint = this.stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (this.stringToPrint.Length > 0);
        }
        #endregion

        #region Drag & Drop stuff
        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files?.Any() ?? false)
                {
                    // for now process first file only
                    if (this.SaveChanges(true))
                    {
                        this.LoadFile(files.First());
                    }
                }
            }
        }
        #endregion
    }
}
