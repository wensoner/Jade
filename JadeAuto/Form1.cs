using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JadeAuto
{
    public partial class JadeAuto : Form
    {
        bool load = true;
        string[] Table1Row = new string[10];
        int i=0;
        public JadeAuto()
        {
            InitializeComponent();
        }

        private void JadeAuto_Load(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, "Table_1.txt");
            using (StreamReader sw = new StreamReader(fileName))
            {
                while (!sw.EndOfStream)
                {
                    string ReadTable1String= sw.ReadLine();
                    string[] ReadTable1Element = ReadTable1String.Split(' ');
                    for(int j=0;j<10;j++)
                    { Table1Row[j] = ReadTable1Element[j]; }
                    AddToTable1_Click(sender,e);
                }
                load = false;
            }
            
        }

        private void butnContract_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabPage1;
        }

        private void butnAnnex_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabPage2;
        }

        private void butnAdditional_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabPage3;
        }

        private void butnInvoice_Click(object sender, EventArgs e)
        {
            TabControl1.SelectedTab = tabPage4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TabControl2.SelectedTab = tabPage5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TabControl2.SelectedTab = tabPage6;
            TabControl3.SelectedTab = tabPage9;
            button8.Enabled = false;
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TabControl3.SelectedTab = tabPage7;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TabControl3.SelectedTab = tabPage8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            TabControl3.SelectedTab = tabPage7;
            button8.Enabled = true;
            button7.Enabled = true;
        }









        private void AddToTable1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();
            Button btn = new Button();
            if (!load)
            {
                Table1Row[0] = Table1CarIn.Text; Table1Row[1] = Table1BodyIn.Text; Table1Row[2] = Table1ExportIn.Text; Table1Row[3] = Table1AssemblingIn.Text; Table1Row[4] = Table1DistillationIn.Text;
                Table1Row[5] = Table1DryIn.Text; Table1Row[6] = Table1ExpensesIn.Text; Table1Row[7] = Table1ResultIn.Text; Table1Row[8] = Table1StatusIn.Text;
            }
            if (i==0)
            {
                tableLayoutPanel1.RowCount++;
                i = tableLayoutPanel1.RowCount+1;
                for (int j = 0; j < 10; j++)
                {
                    Label lab = new Label();
                    if (j != 9)
                    {
                        tableLayoutPanel1.Controls.Add(lab, j, i);
                        lab.Text = Table1Row[j];
                        lab.Size = new Size(70, 30);
                        lab.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                        lab.ForeColor = Color.White;
                        lab.Name = $"Elem_{j}_{i}";
                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Add(btn, j, i);
                        btn.Name = $"btn{i - 1}";
                        btn.Click += new EventHandler(Tab1RedBtn);
                        btn.Text = " ";
                        btn.Size = new Size(30, 30);
                        btn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                        btn.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                
                i += 1;
                
                for (int j = 0; j < 10; j++)
                {
                    Label lab = new Label();
                    if (j != 9)
                    {
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(j, i));
                        tableLayoutPanel1.Controls.Add(lab, j, i);
                        lab.Text = Table1Row[j];
                        lab.Size = new Size(70, 30);
                        lab.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                        lab.ForeColor = Color.White;
                        lab.Name = $"Elem_{j}_{i}";
                    }
                    else
                    {
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(j, i));
                        tableLayoutPanel1.Controls.Add(btn, j, i);
                        btn.Name = $"btn{i - 1}";
                        btn.Click += new EventHandler(Tab1RedBtn);
                        btn.Text = " ";
                        btn.Size = new Size(30, 30);
                        btn.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                        btn.ForeColor = Color.White;
                    }
                }
            }

            EditStatText.Text = "Добавить строку:";
            tableLayoutPanel1.ResumeLayout();
            i = 0;
            
        }
        void Tab1RedBtn(object sender, EventArgs e)
        {
            EditStatText.Text = "Изменить строку:";
            Button btn = sender as Button;
            string name = btn.Name;
            name = name.Substring(3);
            i = Int32.Parse(name);
        }

        private void SaveTable1_Click(object sender, EventArgs e)
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, "Table_1.txt");
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                
                for (int j=3;j <= tableLayoutPanel1.RowCount+1; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {

                        if (tableLayoutPanel1.Controls[$"Elem_{k}_{j}"] as Label!=null)
                        {
                            string ElemTable1 = (tableLayoutPanel1.Controls[$"Elem_{k}_{j}"] as Label).Text;
                            sw.Write(ElemTable1 + " ");
                        }
                        
                    }
                    sw.Write("\n");
                }
                

            }
        }
    }
}
