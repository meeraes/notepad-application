using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad_menustrip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("Untitled" + (tabControl1.SelectedIndex + 1));
            RichTextBox rtb = new RichTextBox();
            rtb.Location = new Point(0, 28);
            rtb.Size = new Size(1135, 580);
            MenuStrip mns = new MenuStrip();
            mns.Location = new Point(3, 3);
            mns.Size = new Size(1129, 28);
            ToolStripMenuItem fileToolStripMenuItem = new ToolStripMenuItem("File");
            fileToolStripMenuItem.DropDownItems.Add("New Tab");
            newTabToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            fileToolStripMenuItem.DropDownItems.Add("New Window");
            newWIndowToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.T;
            fileToolStripMenuItem.DropDownItems.Add("Open");
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            fileToolStripMenuItem.DropDownItems.Add("Save");
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            fileToolStripMenuItem.DropDownItems.Add("Save As");
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            fileToolStripMenuItem.DropDownItems.Add("Close Tab");
            closeTabToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            fileToolStripMenuItem.DropDownItems.Add("Close Window");
            closeWindowToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.W;
            newTabToolStripMenuItem.ShowShortcutKeys = true;
            mns.Items.Add(fileToolStripMenuItem);

            ToolStripMenuItem editToolStripMenuItem = new ToolStripMenuItem("Edit");
            editToolStripMenuItem.DropDownItems.Add("Undo");
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            editToolStripMenuItem.DropDownItems.Add("Redo");
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            editToolStripMenuItem.DropDownItems.Add("Cut");
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            editToolStripMenuItem.DropDownItems.Add("Copy");
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            editToolStripMenuItem.DropDownItems.Add("Paste");
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            mns.Items.Add(editToolStripMenuItem);

            ToolStripMenuItem viewToolStripMenuItem = new ToolStripMenuItem("View");
            viewToolStripMenuItem.DropDownItems.Add("Zoom In");
            zoomInToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Oemplus;
            viewToolStripMenuItem.DropDownItems.Add("Zoom Out");
            zoomOutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.OemMinus;
            mns.Items.Add(viewToolStripMenuItem);

            tabControl1.TabPages.Add(tp);
            tp.Controls.Add(mns);
            tp.Controls.Add(rtb);
            tabControl1.SelectedIndex = tabControl1.TabCount - 1;
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
            richTextBox1.Paste();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = richTextBox1.ZoomFactor + 0.1f;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = richTextBox1.ZoomFactor - 0.1f;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile("D:\\Meera\\Christ University\\Sem 4\\Advanced Java\\Material\\jdbc.txt");
            //string pathName = @"D:\Meera\Christ University\Sem 4\Advanced Java\Material\jdbc.txt";

            //// create a file at pathName and write "Hello World" to the file
            //File.WriteAllText(pathName, richTextBox1.Text());
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
        }
    }
}
