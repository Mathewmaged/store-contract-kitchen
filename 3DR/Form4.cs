using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace _3DR
{
    public partial class Form4 : Form
    {
        Context context = new Context();
        decimal sum = 0;
        decimal totalSum = 0;
        int x = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var data = (from i in context.Rf3s
                        select i).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = data;
            var dataMtb5 = (from i in context.Products
                            where i.Categories_ID == 1
                            select i).ToList();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.DataSource = dataMtb5;
           
            var dataMfslat = (from i in context.Products
                              where i.Categories_ID == 2
                              select i).ToList();
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";
            comboBox3.DataSource = dataMfslat;
            var dataMgary = (from i in context.Products
                             where i.Categories_ID == 3
                             select i).ToList();
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "ID";
            comboBox4.DataSource = dataMgary;
            var dataAccessories = (from i in context.Products
                                   where i.Categories_ID == 4
                                   select i).ToList();
            comboBox5.DisplayMember = "Name";
            comboBox5.ValueMember = "ID";
            comboBox5.DataSource = dataAccessories;
            var dataM2bd = (from i in context.Products
                            where i.Categories_ID == 5
                            select i).ToList();
            comboBox8.DisplayMember = "Name";
            comboBox8.ValueMember = "ID";
            comboBox8.DataSource = dataM2bd;

            x = _3rdAbtda2y.Value;
            if (x != 0)
            {
                getByID(x);
                x = 0;
            }
        }
        private void getByID(int y)
        {
            var q = (from i in context.Abtda2s where i.ID == y select i).FirstOrDefault();
            comboBox1.SelectedIndex = comboBox1.FindStringExact(q.Name);
            comboBox2.SelectedIndex = comboBox2.FindStringExact(q.modelElmtb5);
            comboBox3.SelectedIndex = comboBox3.FindStringExact(q.modelelmfslat);
            comboBox4.SelectedIndex = comboBox4.FindStringExact(q.modelMgary);
            comboBox8.SelectedIndex = comboBox8.FindStringExact(q.m2bd.ToString());
            textBox2.Text = q.nationalId;
            textBox5.Text = q.PlaceAddress;
            textBox1.Text = q.totalPrice.ToString();
            textBox7.Text = q.totalPriceText;
            textBox6.Text = q.dof3aMokdma.ToString();
            textBox8.Text = q.dof3aMokdmaText;
            textBox10.Text = q.metersNumber.ToString();
            textBox18.Text = q.mfslatNumber.ToString();
            textBox20.Text = q.mgaryNumber.ToString();
            textBox11.Text = q.totalmetermatb5.ToString();
            textBox17.Text = q.totalmfslat.ToString();
            textBox19.Text = q.totalmgary.ToString();
            textBox16.Text = q.totalPrice.ToString();
            textBox14.Text = q.totalAccessories.ToString();
            var query = (from i in context.Abtda2YArkams where i.Abtda2YId == y select i).ToList();
            foreach (var item in query)
            {
                test2(item.Arkam, item.ID);
            }
            var que = (from i in context.Abtda2YAcces where i.Abtda2YId == y select i).ToList();
            foreach (var item in que)
            {
                test(item.Name,item.Price,item.ID);
            }
        }
        private void test(string Name, decimal price, int ID)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = Name;
            row.Cells[1].Value = price;
            row.Cells[2].Value = ID;
            dataGridView1.Rows.Add(row);

            sum = sum + price;
            textBox14.Text = sum.ToString();
        }
        private void test2(string Name, int ID)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
            row.Cells[0].Value = Name;
            row.Cells[1].Value = ID;
            dataGridView2.Rows.Add(row);
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBox1.SelectedValue.ToString());
            var data = (from i in context.Rf3s
                        where i.ID == selectedItem
                        select i).FirstOrDefault();
            textBox3.Text = data.Address;
            textBox4.Text = data.Phone.ToString();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBox2.SelectedValue.ToString());
            var data = (from i in context.DolfColors
                        where i.Product_ID == selectedItem
                        select i).ToList();
            comboBox6.DisplayMember = "Color";
            comboBox6.ValueMember = "ID";
            comboBox6.DataSource = data;
            var dataMtb5 = (from i in context.Products
                            where i.ID == selectedItem
                            select i).FirstOrDefault();
            textBox9.Text = dataMtb5.Price.ToString();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBox3.SelectedValue.ToString());
            var dataMtb5 = (from i in context.Products
                            where i.ID == selectedItem
                            select i).FirstOrDefault();
            textBox12.Text = dataMtb5.Price.ToString();
        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBox4.SelectedValue.ToString());
            var dataMtb5 = (from i in context.Products
                            where i.ID == selectedItem
                            select i).FirstOrDefault();
            textBox13.Text = dataMtb5.Price.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                    DataGridViewRow row1 = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    sum = sum - Convert.ToDecimal(row.Cells[1].Value.ToString());
                }
                textBox14.Text = sum.ToString();
            }
        }

        private void textBox10_Leave_1(object sender, EventArgs e)
        {  if (textBox10.Text.Length != 0)
            {
                foreach (char c in textBox10.Text)
                {
                    if (Char.IsDigit(c) || c == '.')
                    { }
                    else
                    {
                        MessageBox.Show("رقم غير صحيح");
                        textBox10.Text = "";
                        textBox10.Select();
                        break;
                    }
                }
                if (textBox10.Text != "")
                {
                    decimal egmaly = 0;
                    egmaly = Convert.ToDecimal(textBox10.Text) * Convert.ToDecimal(textBox9.Text);
                    textBox11.Text = egmaly.ToString();
                }
            }
            else
            {
                MessageBox.Show("رقم غير صحيح");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            foreach (char c in textBox2.Text)
            {
                if (Char.IsDigit(c))
                { }
                else
                {
                    MessageBox.Show("رقم غير صحيح");
                    textBox2.Text = "";
                    textBox2.Select();
                }
            }
            if (textBox2.Text != "")
            {
                if (textBox2.TextLength != 14)
                {
                    MessageBox.Show("رقم غير صحيح");
                    textBox2.Text = "";
                    textBox2.Select();
                }
            }
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            foreach (char c in textBox1.Text)
            {
                if (Char.IsDigit(c))
                { }
                else
                {
                    MessageBox.Show("رقم غير صحيح");
                    textBox1.Text = "";
                    textBox1.Select();
                    break;
                }
            }
        }

        private void textBox6_Leave_1(object sender, EventArgs e)
        {
            foreach (char c in textBox6.Text)
            {
                if (Char.IsDigit(c) || Char.IsPunctuation(c))
                { }
                else
                {
                    MessageBox.Show("رقم غير صحيح");
                    textBox6.Text = "";
                    textBox6.Select();
                    break;
                }
            }
            if (textBox6.Text != "")
            {
                string LiteralNo = NumericToLiteral.Convert(Convert.ToDecimal(textBox6.Text));
                LiteralNo = LiteralNo.Replace("(", "").Replace(")", "");
                textBox8.Text = LiteralNo;
            }
        }

        private void textBox7_Leave_1(object sender, EventArgs e)
        {
            foreach (char c in textBox7.Text)
            {
                if (Char.IsLetter(c) || Char.IsWhiteSpace(c) || Char.IsPunctuation(c))
                { }
                else
                {
                    MessageBox.Show("نص غير صحيح");
                    textBox7.Text = "";
                    textBox7.Select();
                    break;
                }
            }
        }

        private void textBox8_Leave_1(object sender, EventArgs e)
        {
            foreach (char c in textBox8.Text)
            {
                if (Char.IsLetter(c) || Char.IsWhiteSpace(c) || Char.IsPunctuation(c))
                { }
                else
                {
                    MessageBox.Show("نص غير صحيح");
                    textBox8.Text = "";
                    textBox8.Select();
                    break;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox14.Text == ""){ textBox14.Text = "0"; }
            if (textBox11.Text == "") { textBox11.Text = "0"; textBox10.Text = "0"; }
            if (textBox17.Text == "") { textBox17.Text = "0"; textBox18.Text = "0"; }
            if (textBox19.Text == "") { textBox19.Text = "0"; textBox20.Text = "0"; }
            totalSum = Convert.ToDecimal(textBox11.Text) + Convert.ToDecimal(textBox17.Text)
                    + Convert.ToDecimal(textBox19.Text) + Convert.ToDecimal(textBox14.Text);
            textBox16.Text = totalSum.ToString();
                textBox1.Text = totalSum.ToString();
                string LiteralNo = NumericToLiteral.Convert(Convert.ToDecimal(textBox1.Text));
                LiteralNo = LiteralNo.Replace("(", "").Replace(")", "");
                textBox7.Text = LiteralNo;
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBox5.SelectedValue.ToString());
            var dataMtb5 = (from i in context.Products
                            where i.ID == selectedItem
                            select i).FirstOrDefault();
            test(dataMtb5.Name, dataMtb5.Price, dataMtb5.ID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == ""){ textBox6.Text = "0"; }
            if (textBox14.Text == "") { textBox14.Text = "0"; }
            if (textBox16.Text == "") { textBox16.Text = "0"; }
            if (textBox1.Text == "") { textBox1.Text = "0"; }
            if (textBox11.Text == "") { textBox11.Text = "0"; textBox10.Text = "0"; }
            if (textBox17.Text == "") { textBox17.Text = "0"; textBox18.Text = "0"; }
            if (textBox19.Text == "") { textBox19.Text = "0"; textBox20.Text = "0"; }
            abtda2y abtda2Y = new abtda2y();
            string t3akodDate = (dateTimePicker1.Value.ToShortDateString());
            abtda2Y.nationalId = textBox2.Text.ToString();
            abtda2Y.tare5t3akod = t3akodDate;
            abtda2Y.PlaceAddress = textBox5.Text.ToString();
            abtda2Y.clientAddress = textBox3.Text.ToString();
            abtda2Y.Phone = textBox4.Text.ToString();
            abtda2Y.totalPrice = Convert.ToDecimal(textBox1.Text.ToString());
            abtda2Y.totalPriceText = textBox7.Text.ToString();
            abtda2Y.dof3aMokdma = Convert.ToDecimal(textBox6.Text.ToString());
            abtda2Y.dof3aMokdmaText = textBox8.Text.ToString();
            abtda2Y.Notes = textBox15.Text.ToString();
            abtda2Y.meterPrice = Convert.ToDecimal(textBox9.Text.ToString());
            abtda2Y.metersNumber = int.Parse(textBox10.Text.ToString());
            abtda2Y.mfslatNumber = int.Parse(textBox18.Text.ToString());
            abtda2Y.mgaryNumber = int.Parse(textBox20.Text.ToString());
            abtda2Y.totalmetermatb5 = Convert.ToDecimal(textBox11.Text.ToString());
            abtda2Y.totalmfslat = Convert.ToDecimal(textBox17.Text.ToString());
            abtda2Y.totalmgary = Convert.ToDecimal(textBox19.Text.ToString());
            abtda2Y.mgaryPrice = Convert.ToDecimal(textBox12.Text.ToString());
            abtda2Y.mfslatPrice = Convert.ToDecimal(textBox13.Text.ToString());
            abtda2Y.totalAccessories = Convert.ToDecimal(textBox14.Text.ToString());
            abtda2Y.Name = comboBox1.Text;
            abtda2Y.modelElmtb5 = comboBox2.Text;
            abtda2Y.modelelmfslat = comboBox3.Text;
            abtda2Y.modelMgary = comboBox4.Text;
            abtda2Y.m2bd = comboBox8.Text;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                abtda2yAcces accesories = new abtda2yAcces();
                accesories.Name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                accesories.Price = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value.ToString());
                abtda2Y.Accesories.Add(accesories);
                context.SaveChanges();
            }
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                abtda2yArkam accesories = new abtda2yArkam();
                accesories.Arkam = dataGridView2.Rows[i].Cells[0].Value.ToString();
                abtda2Y.Abtda2YArkams.Add(accesories);
                context.SaveChanges();
            }
            context.Abtda2s.Add(abtda2Y);
            context.SaveChanges();

                Form6 f6 = new Form6();
                CrystalReport3 cr = new CrystalReport3();
                TextObject text = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text3"];
                text.Text = comboBox1.Text;
                TextObject nationalId = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text12"];
                nationalId.Text = textBox2.Text;
                TextObject address = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text13"];
                address.Text = textBox3.Text;
                TextObject phone = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text14"];
                phone.Text = textBox4.Text;
                TextObject addressplace = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text15"];
                addressplace.Text = textBox5.Text;
                TextObject agmaly = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text16"];
                agmaly.Text = textBox1.Text;
                TextObject agmalyText = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text22"];
                agmalyText.Text = textBox7.Text;
                TextObject dof3a = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text17"];
                dof3a.Text = textBox6.Text;
                TextObject dof3aText = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text23"];
                dof3aText.Text = textBox8.Text;
                TextObject t3akod = (TextObject)cr.ReportDefinition.Sections["Section1"]
                    .ReportObjects["Text18"];
                t3akod.Text = t3akodDate;
                TextObject modelMtb5 = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text35"];
                modelMtb5.Text = comboBox2.Text;
                TextObject meterPrice = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text36"];
                meterPrice.Text = textBox9.Text;
                TextObject noMeter = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text37"];
                noMeter.Text = textBox10.Text;
                TextObject totalMeter = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text38"];
                totalMeter.Text = textBox11.Text;
                TextObject no3Mfslat = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text43"];
                no3Mfslat.Text = comboBox3.Text;
                TextObject tklfMfslat = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text44"];
                tklfMfslat.Text = textBox12.Text;
                TextObject no3Mgary = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text45"];
                no3Mgary.Text = comboBox4.Text;
                TextObject tklfMgary = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text46"];
                tklfMgary.Text = textBox13.Text;
            TextObject addMfslat = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text68"];
            addMfslat.Text = textBox18.Text;
            TextObject agmalyMfslat = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text69"];
            agmalyMfslat.Text = textBox17.Text;
            TextObject addMgary = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text72"];
            addMgary.Text = textBox20.Text;
            TextObject agmalyMgary = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text73"];
            agmalyMgary.Text = textBox19.Text;
            TextObject m2bd = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text52"];
                m2bd.Text = comboBox8.Text;
                TextObject notes = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text64"];
                notes.Text = textBox15.Text;
                TextObject totwlAccessories = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text57"];
                totwlAccessories.Text = textBox14.Text;
                TextObject total = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text55"];
                total.Text = textBox16.Text;
                TextObject accessoriesPrint = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text62"];
                TextObject accessoriesPrintPrice = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text63"];
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    accessoriesPrint.Text += dataGridView1.Rows[i].Cells[0].Value.ToString();
                    accessoriesPrint.Text += "\n";
                    accessoriesPrintPrice.Text += Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    accessoriesPrintPrice.Text += "\n";
                }
                TextObject dolfColor = (TextObject)cr.ReportDefinition.Sections["Section4"]
                    .ReportObjects["Text50"];
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    dolfColor.Text += dataGridView2.Rows[i].Cells[0].Value.ToString();
                    dolfColor.Text += "\n";
                }
                f6.crystalReportViewer1.ReportSource = cr;
                f6.Show();
        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int selectedItem = int.Parse(comboBox6.SelectedValue.ToString());
            var dataMtb5 = (from i in context.DolfColors
                            where i.ID == selectedItem
                            select i).FirstOrDefault();
            test2(dataMtb5.Color, dataMtb5.ID);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    dataGridView2.Rows.RemoveAt(row.Index);
                    DataGridViewRow row1 = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                }
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (textBox18.Text.Length != 0)
            {
                foreach (char c in textBox18.Text)
                {
                    if (Char.IsDigit(c))
                    { }
                    else
                    {
                        MessageBox.Show("رقم غير صحيح");
                        textBox18.Text = "";
                        textBox18.Select();
                        break;
                    }
                }
                if (textBox18.Text != "")
                {
                    decimal egmaly = 0;
                    egmaly = Convert.ToDecimal(textBox18.Text) * Convert.ToDecimal(textBox12.Text);
                    textBox17.Text = egmaly.ToString();
                }
            }
            else
            {
                MessageBox.Show("رقم غير صحيح");
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Text.Length != 0)
            {
                foreach (char c in textBox20.Text)
                {
                    if (Char.IsDigit(c))
                    { }
                    else
                    {
                        MessageBox.Show("رقم غير صحيح");
                        textBox20.Text = "";
                        textBox20.Select();
                        break;
                    }
                }
                if (textBox20.Text != "")
                {
                    decimal egmaly = 0;
                    egmaly = Convert.ToDecimal(textBox20.Text) * Convert.ToDecimal(textBox13.Text);
                    textBox19.Text = egmaly.ToString();
                }
            }
            else
            {
                MessageBox.Show("رقم غير صحيح");
            }
        }
    }
}
