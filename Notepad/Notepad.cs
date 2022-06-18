using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void oepToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader outputReader;
            openFileDialog.InitialDirectory = @"D:\";
            openFileDialog.Filter = "Text Files |*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {


                outputReader = File.OpenText(openFileDialog.FileName);
                while (!outputReader.EndOfStream)
                {
                    richTextBox1.Text += outputReader.ReadLine();
                }
                outputReader.Close();
            }
            }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            if (fontDialog.ShowDialog() == DialogResult.OK)
                 richTextBox1.Font = fontDialog.Font;
            

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            if (colorDialog.ShowDialog() == DialogResult.OK) 
                    richTextBox1.ForeColor = colorDialog.Color;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                    richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.SelectionStart, richTextBox1.SelectionLength);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, DateTime.Now.ToString());

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length != 0)
            {
                saveFileDialog.InitialDirectory = @"D:\";
                saveFileDialog.Filter = "Text Files |*.txt";
        
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter inputWriter;
                    inputWriter = File.AppendText(saveFileDialog.FileName);
                    richTextBox1.Clear();
                    inputWriter.Close();
                }
            } else
            {
                richTextBox1.Clear();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter inputFile;
                saveFileDialog.InitialDirectory = @"D:\";
                saveFileDialog.Filter = "Text Files |*.txt";
                inputFile = File.AppendText(saveFileDialog.FileName);
                inputFile.WriteLine(richTextBox1.Text);
                inputFile.Close();
            } else
            {
                MessageBox.Show("You Cancelled and No File Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
