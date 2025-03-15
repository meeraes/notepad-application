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

        private void createNewWindow()
        {
            Form1 f = new Form1();
            TabControl tabControl = new TabControl()
            {
                Location = new Point(12, 12),
                Size = new Size(1143, 639)
            };
            f.Controls.Add(tabControl);
            createNewTab(tabControl);
            f.Show();
        }

        private void createNewTab(TabControl tab)
        {
            if (tab == null) return;

            TabPage tp = new TabPage("Untitled" + (tabControl1.TabCount + 1));
            RichTextBox rtb = new RichTextBox()
            {
                Location = new Point(0, 28),
                Size = new Size(1135, 580),
                Font = new Font("Mongolian Baiti", 10)
            };

            MenuStrip mns = new MenuStrip();
            mns.Location = new Point(3, 3);
            mns.Size = new Size(1129, 28);

            // File Menu
            ToolStripMenuItem fileToolStripMenuItem = new ToolStripMenuItem("File");

            ToolStripMenuItem newTabToolStripMenuItem = new ToolStripMenuItem("New Tab", null, newTabToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.T,
                ShowShortcutKeys = true
            };
            fileToolStripMenuItem.DropDownItems.Add(newTabToolStripMenuItem);

            ToolStripMenuItem newWindowToolStripMenuItem = new ToolStripMenuItem("New Window", null, newWindowToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.Shift | Keys.T,
                ShowShortcutKeys = true
            };
            fileToolStripMenuItem.DropDownItems.Add(newWindowToolStripMenuItem);

            //ToolStripMenuItem openToolStripMenuItem = new ToolStripMenuItem("Open", null, openToolStripMenuItem_Click)
            //{
            //    ShortcutKeys = Keys.Control | Keys.O,
            //    ShowShortcutKeys = true
            //};
            //fileToolStripMenuItem.DropDownItems.Add(openToolStripMenuItem);

            fileToolStripMenuItem.DropDownItems.Add("Save");
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.ShowShortcutKeys = true;

            fileToolStripMenuItem.DropDownItems.Add("Save As");
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.ShowShortcutKeys = true;

            ToolStripMenuItem closeTabToolStripMenuItem = new ToolStripMenuItem("Close Tab", null, closeTabToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.W,
                ShowShortcutKeys = true
            };
            fileToolStripMenuItem.DropDownItems.Add(closeTabToolStripMenuItem);

            ToolStripMenuItem closeWindowToolStripMenuItem = new ToolStripMenuItem("Close Window", null, closeWindowToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.Shift | Keys.W,
                ShowShortcutKeys = true
            };
            fileToolStripMenuItem.DropDownItems.Add(closeWindowToolStripMenuItem);

            mns.Items.Add(fileToolStripMenuItem);

            // Edit Menu
            ToolStripMenuItem editToolStripMenuItem = new ToolStripMenuItem("Edit");

            ToolStripMenuItem undoToolStripMenuItem = new ToolStripMenuItem("Undo", null, undoToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.Z,
                ShowShortcutKeys = true
            };
            editToolStripMenuItem.DropDownItems.Add(undoToolStripMenuItem);

            ToolStripMenuItem redoToolStripMenuItem = new ToolStripMenuItem("Redo", null, redoToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.Y,
                ShowShortcutKeys = true
            };
            editToolStripMenuItem.DropDownItems.Add(redoToolStripMenuItem);

            ToolStripMenuItem cutToolStripMenuItem = new ToolStripMenuItem("Cut", null, cutToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.X,
                ShowShortcutKeys = true
            };
            editToolStripMenuItem.DropDownItems.Add(cutToolStripMenuItem);

            ToolStripMenuItem copyToolStripMenuItem = new ToolStripMenuItem("Copy", null, copyToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.C,
                ShowShortcutKeys = true
            };
            editToolStripMenuItem.DropDownItems.Add(copyToolStripMenuItem);

            ToolStripMenuItem pasteToolStripMenuItem = new ToolStripMenuItem("Paste", null, pasteToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.V,
                ShowShortcutKeys = true
            };
            editToolStripMenuItem.DropDownItems.Add(pasteToolStripMenuItem);

            mns.Items.Add(editToolStripMenuItem);

            // View Menu
            ToolStripMenuItem viewToolStripMenuItem = new ToolStripMenuItem("View");
            ToolStripMenuItem zoomToolStripMenuItem = new ToolStripMenuItem("Zoom");

            ToolStripMenuItem zoomInToolStripMenuItem = new ToolStripMenuItem("Zoom In", null, zoomInToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.Oemplus,
                ShowShortcutKeys = true
            };
            zoomToolStripMenuItem.DropDownItems.Add(zoomInToolStripMenuItem);

            ToolStripMenuItem zoomOutToolStripMenuItem = new ToolStripMenuItem("Zoom Out", null, zoomOutToolStripMenuItem_Click)
            {
                ShortcutKeys = Keys.Control | Keys.OemMinus,
                ShowShortcutKeys = true
            };
            zoomToolStripMenuItem.DropDownItems.Add(zoomOutToolStripMenuItem);

            viewToolStripMenuItem.DropDownItems.Add(zoomToolStripMenuItem);
            mns.Items.Add(viewToolStripMenuItem);

            tp.Controls.Add(mns);
            tp.Controls.Add(rtb);
            tab.TabPages.Add(tp);
            tab.SelectedTab = tp;
            //tabControl1.SelectedIndex = tabControl1.TabCount - 1;
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            if (activeForm != null) 
            {
                TabControl tabControl = (TabControl)activeForm.Controls[0];
                createNewTab(tabControl);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                RichTextBox rtb = tabControl.SelectedTab.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (rtb != null)
                {
                    rtb.Undo();
                }
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                RichTextBox rtb = tabControl.SelectedTab.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (rtb != null)
                {
                    rtb.Redo();
                }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                RichTextBox rtb = tabControl.SelectedTab.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (rtb != null)
                {
                    rtb.Cut();
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                RichTextBox rtb = tabControl.SelectedTab.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (rtb != null)
                {
                    rtb.Copy();
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                RichTextBox rtb = tabControl.SelectedTab.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (rtb != null)
                {
                    rtb.Paste();
                }
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                RichTextBox rtb = tabControl.SelectedTab.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (rtb != null)
                {
                    rtb.ZoomFactor = rtb.ZoomFactor + 0.1f;
                }   
            }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                RichTextBox rtb = tabControl.SelectedTab.Controls.OfType<RichTextBox>().FirstOrDefault();
                if (rtb != null)
                {
                    rtb.ZoomFactor = rtb.ZoomFactor - 0.1f;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //richTextBox1.SaveFile("D:\\Meera\\Christ University\\Sem 4\\Advanced Java\\Material\\jdbc.txt");
            //string pathName = @"D:\Meera\Christ University\Sem 4\Advanced Java\Material\jdbc.txt";

            //// create a file at pathName and write "Hello World" to the file
            //File.WriteAllText(pathName, richTextBox1.Text());
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            TabControl tabControl = activeForm.Controls.OfType<TabControl>().FirstOrDefault();
            if (tabControl != null && tabControl.TabCount > 0)
            {
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            }
            else if (tabControl.TabCount == 0)
            {
                activeForm.Close();
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewWindow();
        }

        private void closeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = Form.ActiveForm;
            activeForm.Close();
        }
    }
}
