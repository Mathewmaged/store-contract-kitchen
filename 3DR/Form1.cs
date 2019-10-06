using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DR
{
    public partial class Form1 : Form
    {
        Context context = new Context();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rf3m2asat rf3 = new rf3m2asat();
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
            {
                rf3.Name = textBox1.Text.ToString();
                rf3.Address = textBox3.Text.ToString();
                bool checkL = false;
                foreach (char c in textBox1.Text)
                {
                    if (Char.IsLetter(c))
                    {
                        checkL = true;
                        break;
                    }
                    else
                    {}
                }
                bool checkL2 = false;
                foreach (char c in textBox3.Text)
                {
                    if (Char.IsLetter(c) || Char.IsDigit(c))
                    {
                        checkL2 = true;
                        break;
                    }
                    else
                    { }
                }
                foreach (char c in textBox2.Text)
                {
                    if (Char.IsDigit(c))
                    { }
                    else
                    {
                        MessageBox.Show("رقم غير صحيح");
                        textBox2.Text = "";
                        break;
                    }
                }
                if (textBox2.Text != "" && checkL == true && checkL2 == true)
                {
                    if (textBox2.Text.Length == 11 && textBox2.Text[0] == '0')
                    {
                        rf3.Phone = textBox2.Text;
                        rf3.tare5Eltlb = dateTimePicker1.Value.ToShortDateString();
                        rf3.m3adElrf3 = dateTimePicker2.Value.ToShortDateString();
                        context.Rf3s.Add(rf3);
                        context.SaveChanges();
                        MessageBox.Show("تم الحفظ");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        dataGridView1.Rows.Clear();
                        fillGrid();
                    }
                    else
                    {
                        MessageBox.Show("رقم غير صحيح");
                        textBox2.Text = "";
                    }
                }
                else
                    MessageBox.Show("رجاء إدخال البيانات صحيحة");
            }
            else
                MessageBox.Show("رجاء إدخال جميع البيانات");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillGrid();
        }
        private void fillGrid()
        {
            var Customers = (from i in context.Rf3s select i).ToList();
            foreach (var item in Customers)
            {
                test(item.Name, item.Phone, item.Address, item.tare5Eltlb, item.m3adElrf3, item.ID);
            }
        }
        private void test(string name, string Phone, string Address, string tare5tlb,  string m3adrf3, int ID)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = name;
            row.Cells[1].Value = Phone;
            row.Cells[2].Value = Address;
            row.Cells[3].Value = tare5tlb;
            row.Cells[4].Value = m3adrf3;
            row.Cells[5].Value = ID;
            dataGridView1.Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int Value = int.Parse(selectedRow.Cells[5].Value.ToString());
                var edit = (from i in context.Rf3s
                            where i.ID == Value
                            select i).FirstOrDefault();
                context.Rf3s.Remove(edit);
                context.SaveChanges();
                dataGridView1.Rows.Clear();
                fillGrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int Value = int.Parse(selectedRow.Cells[5].Value.ToString());
                var edit = (from i in context.Rf3s
                            where i.ID == Value
                            select i).FirstOrDefault();
                


                    if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                {
                    edit.Name = textBox1.Text.ToString();
                    edit.Address = textBox3.Text.ToString();
                    bool checkL = false;
                    foreach (char c in textBox1.Text)
                    {
                        if (Char.IsLetter(c))
                        {
                            checkL = true;
                            break;
                        }
                        else
                        { }
                    }
                    bool checkL2 = false;
                    foreach (char c in textBox3.Text)
                    {
                        if (Char.IsLetter(c) || Char.IsDigit(c))
                        {
                            checkL2 = true;
                            break;
                        }
                        else
                        { }
                    }
                    foreach (char c in textBox2.Text)
                    {
                        if (Char.IsDigit(c))
                        { }
                        else
                        {
                            MessageBox.Show("رقم غير صحيح");
                            textBox2.Text = "";
                            break;
                        }
                    }
                    if (textBox2.Text != "" && checkL == true && checkL2 == true)
                    {
                        if (textBox2.Text.Length == 11 && textBox2.Text[0] == '0')
                        {
                            edit.Phone = textBox2.Text;
                            edit.tare5Eltlb = dateTimePicker1.Value.ToShortDateString();
                            edit.m3adElrf3 = dateTimePicker2.Value.ToShortDateString();
                            context.SaveChanges();
                            MessageBox.Show("تم التعديل");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            dataGridView1.Rows.Clear();
                            fillGrid();
                        }
                        else
                        {
                            MessageBox.Show("رقم غير صحيح");
                            textBox2.Text = "";
                        }
                    }
                    else
                        MessageBox.Show("رجاء إدخال البيانات صحيحة");
                }
                else
                    MessageBox.Show("رجاء إدخال جميع البيانات");

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (dataGridView1.Rows.IndexOf(selectedRow) != dataGridView1.Rows.Count - 1)
                {
                    int Value = int.Parse(selectedRow.Cells[5].Value.ToString());
                    var edit = (from i in context.Rf3s
                                where i.ID == Value
                                select i).FirstOrDefault();
                    textBox1.Text = edit.Name.ToString();
                    textBox3.Text = edit.Address.ToString();
                    textBox2.Text = edit.Phone.ToString();
                }
            }
        }
    }
}
