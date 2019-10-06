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
    public partial class Form2 : Form
    {
        Context context = new Context();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillcombo2();
            filldatagrid();
        }
        private void filldatagrid()
        {
            var quantdata2 = (from n in context.Categories
                              select n).ToList();
            foreach (var item in quantdata2)
            {
                test4(item.Name, item.ID);
            }
        }
        private void fillcombo()
        {
            var data = (from i in context.Categories
                        select i).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = data;

        }
        private void fillcombo2 ()
        {
            var data2 = (from i in context.Products
                         where i.Categories_ID == 1
                         select i).ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.DataSource = data2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool checkL = false;
            int selectedItem = int.Parse(comboBox1.SelectedValue.ToString());
            if (selectedItem == 5)
            { textBox2.Text = "0"; }
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                if (selectedItem == 5)
                {
                    foreach (char c in textBox1.Text)
                    {
                        if (Char.IsDigit(c))
                        {
                            checkL = true;
                            break;
                        }
                        else
                        { }
                    }
                }
                else
                {
                    
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
                    foreach (char c in textBox2.Text)
                    {
                        if (Char.IsDigit(c) || c == '.')
                        { }
                        else
                        {
                            MessageBox.Show("رقم غير صحيح");
                            textBox2.Text = "";
                            break;
                        }
                    }
                }
                if (textBox2.Text != "" && checkL == true )
                {
                    string name = textBox1.Text.ToString();
                    decimal price = Convert.ToDecimal(textBox2.Text);
                    var check = (from i in context.Products
                                 where i.Name == name && i.Price == price && i.Categories_ID == selectedItem
                                 select i).FirstOrDefault();

                    Product product = new Product();
                    if (check == null)
                    {
                        product.Name = name;
                        product.Price = price;
                        product.Categories_ID = selectedItem;
                        context.Products.Add(product);
                        context.SaveChanges();
                        MessageBox.Show("تمت الإضافة");
                        fillcombo2();
                        dataGridView1.Rows.Clear();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        var quantdata = (from n in context.Products
                                         where n.categories.ID == selectedItem
                                         select n).ToList();
                        foreach (var item in quantdata)
                        {
                            if ( selectedItem == 5)
                            {
                                test2(item.categories.Name, item.Name, item.ID);
                            }
                            else
                                test(item.categories.Name, item.Name, item.Price, item.ID);
                        }
                    }
                    else
                        MessageBox.Show("موجود مسبقاً");
                }
                else
                    MessageBox.Show("رجاء إدخال جميع البيانات");
            }
            else
                MessageBox.Show("رجاء إدخال جميع البيانات");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            int selectedItem = int.Parse(comboBox1.SelectedValue.ToString());
            if (selectedItem == 5)
            {
                textBox2.Hide();
                label4.Hide();
                
                var quantdata2 = (from n in context.Products
                                  where n.categories.ID == selectedItem
                                  select n).ToList();
                foreach (var item in quantdata2)
                {
                    test2(item.categories.Name, item.Name, item.ID);
                }
            }
            else
            {
                textBox2.Show();
                label4.Show();
                var quantdata = (from n in context.Products
                                 where n.categories.ID == selectedItem
                                 select n).ToList();
                foreach (var item in quantdata)
                {
                    test(item.categories.Name, item.Name, item.Price, item.ID);
                }
            }
        }
        private void test(string catName, string name, decimal price,int ID)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = catName;
            row.Cells[1].Value = name;
            row.Cells[2].Value = price;
            row.Cells[3].Value = ID;
            dataGridView1.Rows.Add(row);
            dataGridView1.CurrentCell.Selected = false;
        }
        private void test2(string catName, string name, int ID)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = catName;
            row.Cells[1].Value = name;
            row.Cells[3].Value = ID;
            dataGridView1.Rows.Add(row);
            dataGridView1.CurrentCell.Selected = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (dataGridView1.Rows.IndexOf(selectedRow) != dataGridView1.Rows.Count - 1)
                {
                    decimal Value = Convert.ToDecimal(selectedRow.Cells[3].Value.ToString());
                    var edit = (from i in context.Products
                                where i.ID == Value
                                select i).FirstOrDefault();
                    textBox1.Text = edit.Name.ToString();
                    textBox2.Text = edit.Price.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBox1.SelectedValue.ToString());
            bool checkL = false;
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                if (selectedItem == 5)
                {
                    foreach (char c in textBox1.Text)
                    {
                        if (Char.IsDigit(c))
                        {
                            checkL = true;
                            break;
                        }
                        else
                        { }
                    }
                }
                else
                {
                    foreach (char c in textBox1.Text)
                    {
                        if (Char.IsLetter(c) || Char.IsWhiteSpace(c))
                        {
                            checkL = true;
                            break;
                        }
                        else
                        { }
                    }
                    foreach (char c in textBox2.Text)
                    {
                        if (Char.IsDigit(c) || c == '.')
                        { }
                        else
                        {
                            MessageBox.Show("رقم غير صحيح");
                            textBox2.Text = "";
                            textBox2.Select();
                            break;
                        }
                    }
                }
                if (textBox2.Text != "" && checkL == true)
                {
                    if (selectedItem == 5)
                    {
                        string name = textBox1.Text.ToString();
                        var check = (from i in context.Products
                                     where i.Name == name
                                     select i).FirstOrDefault();
                        if (check == null)
                        {
                            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                            int Value = int.Parse(selectedRow.Cells[3].Value.ToString());
                            var edit = (from i in context.Products
                                        where i.ID == Value
                                        select i).FirstOrDefault();
                            edit.Name = name;
                            context.SaveChanges();
                            MessageBox.Show("تمت التعديل");
                            dataGridView1.Rows.Clear();
                            textBox1.Text = "";
                            var quantdata = (from n in context.Products
                                             where n.categories.ID == selectedItem
                                             select n).ToList();
                            foreach (var item in quantdata)
                            {
                                test2(item.categories.Name, item.Name,item.ID);
                            }
                        }
                        else MessageBox.Show("موجود مسبقاً");
                    }
                    else
                    {
                        string name = textBox1.Text.ToString();
                        decimal price = Convert.ToDecimal(textBox2.Text);
                        var check = (from i in context.Products
                                     where i.Name == name && i.Price == price && i.Categories_ID == selectedItem
                                     select i).FirstOrDefault();

                        Product product = new Product();
                        if (check == null)
                        {
                            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                            int Value = int.Parse(selectedRow.Cells[3].Value.ToString());
                            var check2 = (from i in context.Products
                                          where i.ID == Value
                                          select i).FirstOrDefault();
                            check2.Name = name;
                            check2.Price = price;
                            check2.Categories_ID = selectedItem;
                            context.SaveChanges();
                            MessageBox.Show("تم التعديل");
                            fillcombo2();
                            dataGridView1.Rows.Clear();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            var quantdata = (from n in context.Products
                                             where n.categories.ID == selectedItem
                                             select n).ToList();
                            foreach (var item in quantdata)
                            {
                                test(item.categories.Name, item.Name, item.Price, item.ID);
                            }
                        }
                        else
                            MessageBox.Show("موجود مسبقاً");
                    }
                }
                else
                    MessageBox.Show("رجاء إدخال جميع البيانات");
            }
            else
                MessageBox.Show("رجاء إدخال جميع البيانات");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            textBox3.Text = "";
            int selectedItem = int.Parse(comboBox2.SelectedValue.ToString());
            var quantdata2 = (from n in context.DolfColors
                              where n.Product_ID == selectedItem
                              select n).ToList();
            foreach (var item in quantdata2)
            {
                test3(item.Color,item.ID);
            }
        }
        private void test3(string color,int ID)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
            row.Cells[0].Value = color;
            row.Cells[1].Value = ID;
            dataGridView2.Rows.Add(row);
            dataGridView2.CurrentCell.Selected = false;
        }
        private void test4(string catName, int ID)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView3.Rows[0].Clone();
            row.Cells[0].Value = catName;
            row.Cells[1].Value = ID;
            dataGridView3.Rows.Add(row);
            dataGridView3.CurrentCell.Selected = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (char c in textBox3.Text)
            {
                if (Char.IsDigit(c))
                { }
                else
                {
                    MessageBox.Show("رقم غير صحيح");
                    textBox3.Text = "";
                    textBox3.Select();
                    break;
                }
            }
            if (textBox3.Text != "")
            {
                int selectedItem = int.Parse(comboBox2.SelectedValue.ToString());
                string color = textBox3.Text;
                var check = (from i in context.DolfColors
                             where i.Color == color && i.Product_ID == selectedItem
                             select i).FirstOrDefault();
                dolfColor dolfColor = new dolfColor();
                if (check == null)
                {
                    dolfColor.Color = color;
                    dolfColor.Product_ID = selectedItem;
                    context.DolfColors.Add(dolfColor);
                    context.SaveChanges();
                    MessageBox.Show("تمت الإضافة");
                    dataGridView2.Rows.Clear();
                    textBox3.Text = "";

                    var quantdata2 = (from n in context.DolfColors
                                      where n.Product_ID == selectedItem
                                      select n).ToList();
                    foreach (var item in quantdata2)
                    {
                        test3(item.Color,item.ID);
                    }
                }
                else
                    MessageBox.Show("موجود مسبقاً");
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                if (dataGridView2.Rows.IndexOf(selectedRow) != dataGridView2.Rows.Count-1)
                {
                    string Value = selectedRow.Cells[0].Value.ToString();
                    var edit = (from i in context.DolfColors
                                where i.Color == Value
                                select i).FirstOrDefault();
                    textBox3.Text = edit.Color.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (char c in textBox3.Text)
            {
                if (Char.IsDigit(c))
                { }
                else
                {
                    MessageBox.Show("رقم غير صحيح");
                    textBox3.Text = "";
                    textBox3.Select();
                    break;
                }
            }
            if (textBox3.Text != "")
            {
                int selectedItem = int.Parse(comboBox2.SelectedValue.ToString());
                string color = textBox3.Text;
                var check = (from i in context.DolfColors
                             where i.Color == color && i.Product_ID == selectedItem
                             select i).FirstOrDefault();
                dolfColor dolfColor = new dolfColor();
                if (check == null)
                {
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                    int Value = int.Parse(selectedRow.Cells[1].Value.ToString());
                    var edit = (from i in context.DolfColors
                                where i.ID == Value
                                select i).FirstOrDefault();

                    edit.Color = color;
                    edit.Product_ID = selectedItem;
                    context.SaveChanges();
                    MessageBox.Show("تم التعديل");
                    dataGridView2.Rows.Clear();
                    textBox3.Text = "";

                    var quantdata2 = (from n in context.DolfColors
                                      where n.Product_ID == selectedItem
                                      select n).ToList();
                    foreach (var item in quantdata2)
                    {
                        test3(item.Color,item.ID);
                    }
                }
                else
                    MessageBox.Show("موجود مسبقاً");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                string Value = selectedRow.Cells[0].Value.ToString();
                var edit = (from i in context.DolfColors
                            where i.Color == Value
                            select i).FirstOrDefault();
                context.DolfColors.Remove(edit);
                context.SaveChanges();
                dataGridView2.Rows.Clear();
                textBox3.Text = "";
                int selectedItem = int.Parse(comboBox2.SelectedValue.ToString());

                var quantdata2 = (from n in context.DolfColors
                                  where n.Product_ID == selectedItem
                                  select n).ToList();
                foreach (var item in quantdata2)
                {
                    test3(item.Color, item.ID);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int Value = int.Parse(selectedRow.Cells[3].Value.ToString());
                var edit = (from i in context.Products
                            where i.ID == Value
                            select i).FirstOrDefault();
                context.Products.Remove(edit);
                var edit2 = (from i in context.DolfColors
                            where i.Product_ID == edit.ID
                            select i).ToList();
                foreach (var item in edit2)
                {
                    context.DolfColors.Remove(item);
                }
                context.SaveChanges();
                dataGridView1.Rows.Clear();
                fillcombo2();
                textBox1.Text = "";
                textBox2.Text = "";
                int selectedItem = int.Parse(comboBox1.SelectedValue.ToString());

                var quantdata = (from n in context.Products
                                 where n.categories.ID == selectedItem
                                 select n).ToList();
                foreach (var item in quantdata)
                {
                    if (selectedItem == 5)
                    {
                        test2(item.categories.Name, item.Name, item.ID);
                    }
                    else
                        test(item.categories.Name, item.Name, item.Price, item.ID);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool checkL = false;
            foreach (char c in textBox4.Text)
            {
                if (Char.IsLetter(c))
                { checkL = true;
                    break;
                }
                else
                {}
            }
            string name = textBox4.Text.ToString();
            var check = (from i in context.Categories
                         where i.Name == name
                         select i).FirstOrDefault();
            Category category = new Category();
            if (textBox4.Text != "" && checkL == true)
            {
                if (check == null)
                {
                    category.Name = name;
                    context.Categories.Add(category);
                    context.SaveChanges();
                    MessageBox.Show("تمت الإضافة");
                    fillcombo();
                    dataGridView3.Rows.Clear();
                    textBox4.Text = "";
                    filldatagrid();
                }
                else
                    MessageBox.Show("موجود مسبقاً");
            }
            else { MessageBox.Show("رجاء إدخال جميع البيانات"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int Counter = 0;
            bool checkL = false;
            foreach (char c in textBox4.Text)
            {
                if (Char.IsLetter(c))
                {
                    checkL = true;
                    break;
                }
                else
                {}
            }
            string name = textBox4.Text.ToString();
            var check = (from i in context.Categories
                         where i.Name == name
                         select i).FirstOrDefault();
            Category category = new Category();
            if (textBox4.Text != "" && checkL == true && Counter != textBox4.TextLength)
            {
                if (check == null)
                {
                    DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
                    int Value = int.Parse(selectedRow.Cells[1].Value.ToString());
                    var edit = (from i in context.Categories
                                where i.ID == Value
                                select i).FirstOrDefault();
                    edit.Name = name;
                    context.SaveChanges();
                    MessageBox.Show("تمت التعديل");
                    fillcombo();
                    dataGridView3.Rows.Clear();
                    textBox4.Text = "";
                    filldatagrid();
                }
                else MessageBox.Show("موجود مسبقاً");
            }
            else MessageBox.Show("رجاء إدخال جميع البيانات");
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 1)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];
                if (dataGridView3.Rows.IndexOf(selectedRow) != dataGridView3.Rows.Count - 1)
                {
                    string Value = selectedRow.Cells[0].Value.ToString();
                    var edit = (from i in context.Categories
                                where i.Name == Value
                                select i).FirstOrDefault();
                    textBox4.Text = edit.Name.ToString();
                }
            }
        }
    }
}
