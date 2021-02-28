using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._3.Menus_Dynamiques
{

    public partial class Form1 : Form
    {
        List<String> ListPrenoms = new List<String>{"C#", "Java", "Python", "WinForms", "WPF", "Algo"};
        ToolStripMenuItem PolicemenuItem;  //6.4. Menus Contextuels
        ToolStripMenuItem ColorMenuItem;  //6.4. Menus Contextuels
        ContextMenuStrip menuStrip;  //6.4. Menus Contextuels



        public Form1()
        {
            InitializeComponent();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Enabled)
            {
                prenomsToolStripMenuItem.DropDownItems.Clear();
                prenomsToolStripMenuItem.DropDownItems.Add("C#").Click += new EventHandler(this.AyoubToolStripMenuItemView_Click); // i made a handler for the toolstripmenuitems i have added 
                prenomsToolStripMenuItem.DropDownItems.Add("Java").Click += new EventHandler(this.AyoubToolStripMenuItemView_Click);
                prenomsToolStripMenuItem.DropDownItems.Add("Python").Click += new EventHandler(this.AyoubToolStripMenuItemView_Click);
                prenomsToolStripMenuItem.DropDownItems.Add("Winforms").Click += new EventHandler(this.AyoubToolStripMenuItemView_Click);
                prenomsToolStripMenuItem.DropDownItems.Add("WPF").Click += new EventHandler(this.AyoubToolStripMenuItemView_Click);
                toolStripButton1.Enabled = false;
            }
            else
            {
                prenomsToolStripMenuItem.DropDownItems.Clear();
                prenomsToolStripMenuItem.DropDownItems.Add(" ");
                toolStripButton1.Enabled = true;
            }

        }

        private void AyoubToolStripMenuItemView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;// sender it provides a reference  to the object that raised this event ,
            // so i have 5 reference so eache one is  bound at its reference
            // because sender it's an object nullabl so i definded him like a ToolStripMenuItem using as 
            label1.Text = item.Text;
            foreach(ToolStripMenuItem tool in prenomsToolStripMenuItem.DropDownItems)
            {
                tool.Checked = false;
            }
            // first i made all checked items false , so when i click an item it will that only  wich is checked 
            item.Checked = true;
        }

        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripButton2.Enabled == true)
            {
                policeToolStripMenuItem.DropDownItems.Clear();
                foreach (var font in FontFamily.Families)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem(font.Name);
                    subItem.Click += new EventHandler(this.policeViex_Click);
                    policeToolStripMenuItem.DropDownItems.Add(subItem);
                }

                toolStripButton2.Enabled = false;
            }
            else
            {
                policeToolStripMenuItem.DropDownItems.Clear();
                policeToolStripMenuItem.DropDownItems.Add(" ");
                toolStripButton2.Enabled = true;
            }

        }

        private void policeViex_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            FontFamily font = new FontFamily(item.Text);
            label1.Font =new Font(font,label1.Font.Size);
            foreach (ToolStripMenuItem tool in policeToolStripMenuItem.DropDownItems)
            {
                tool.Checked = false;
            }
            item.Checked = true;
            PolicemenuItem.DropDownItems.Add(item.Text).Click += new EventHandler(PolicepopupMenu_Click);  //6.4. Menus Contextuels

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prenomsToolStripMenuItem.DropDownItems.Add(" ");
            policeToolStripMenuItem.DropDownItems.Add(" ");
            CreateContextMenu();
        }

        //6.4. Menus Contextuels
        private void CreateContextMenu()

        {
            menuStrip = new ContextMenuStrip();
            PolicemenuItem = new ToolStripMenuItem("Fonts");
            ColorMenuItem = new ToolStripMenuItem("Colors");
             ColorMenuItem.DropDownItems.Add("Red").Click+=new EventHandler(ColorspopupMenu_Click);
             ColorMenuItem.DropDownItems.Add("Green").Click += new EventHandler(ColorspopupMenu_Click);
             ColorMenuItem.DropDownItems.Add("Bleu").Click += new EventHandler(ColorspopupMenu_Click);
             ColorMenuItem.DropDownItems.Add("White").Click += new EventHandler(ColorspopupMenu_Click);
             ColorMenuItem.DropDownItems.Add("Yellow").Click += new EventHandler(ColorspopupMenu_Click);

          /*  foreach (KnownColor font in Enum.GetValues(typeof(KnownColor)))
            {
                Color color = Color.FromKnownColor(font);
                ToolStripMenuItem subItem = new ToolStripMenuItem(color.Name);
                subItem.Click += new EventHandler(ColorspopupMenu_Click);
                ColorMenuItem.DropDownItems.Add(subItem);
            }*/


            PolicemenuItem.DropDownItems.Add(" ");
            menuStrip.Items.Add(PolicemenuItem);
            menuStrip.Items.Add(ColorMenuItem);
            ContextMenuStrip = menuStrip;
            
        }

        //6.4. Menus Contextuels
        private void ColorspopupMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "Red":
                    label1.ForeColor = Color.Red;
                    break;
                case "Green":
                    label1.ForeColor = Color.Green;
                    break;
                case "Bleu":
                    label1.ForeColor = Color.Blue;
                    break;
                case "White":
                    label1.ForeColor = Color.White;
                    break;
                case "Yellow":
                    label1.ForeColor = Color.Yellow;
                    break;
            }
            foreach (ToolStripMenuItem tool in ColorMenuItem.DropDownItems)
            {
                tool.Checked = false;
            }
            item.Checked = true;
        }

        //6.4. Menus Contextuels
        private void PolicepopupMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            FontFamily font = new FontFamily(item.Text);
            label1.Font = new Font(font, label1.Font.Size);
            foreach (ToolStripMenuItem tool in PolicemenuItem.DropDownItems)
            {
                tool.Checked = false;
            }
            item.Checked = true;
        }
    }


}

