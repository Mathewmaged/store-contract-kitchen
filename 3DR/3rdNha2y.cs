using EasyTabs;
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
    public partial class _3rdNha2y : Form
    {
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        public static int Value;
        Context context = new Context();
        public _3rdNha2y()
        {
            InitializeComponent();
        }
        public void fillGrid()
        {
            var query = (from i in context.Nha2s
                         orderby (i.ID) descending
                         select i).ToList();
            foreach (var item in query)
            {
                grid(item.ID, item.Name, item.clientAddress, item.PlaceAddress, item.Phone.ToString(),
                    item.totalPrice, item.dof3aMokdma, item.tare5t3akod,item.tare5astlam,
                    item.modelElmtb5);
            }
        }
        public void grid(int id,string name,string cAddress,string pAddress,string phone,decimal tPrice,decimal dmokdma,string tT3akod,string tTslem ,string model)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = id;
            row.Cells[1].Value = name;
            row.Cells[2].Value = cAddress;
            row.Cells[3].Value = pAddress;
            row.Cells[4].Value = '0'+phone;
            row.Cells[5].Value = tPrice;
            row.Cells[6].Value = dmokdma;
            row.Cells[7].Value = tT3akod;
            row.Cells[8].Value = tTslem;
            row.Cells[9].Value = model;
            dataGridView1.Rows.Add(row);
            dataGridView1.CurrentCell.Selected = false;
        }

        private void _3rdNha2y_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Value = int.Parse(selectedRow.Cells[0].Value.ToString());

            ParentTabs.Tabs.Add(new TitleBarTab(ParentTabs)
            {
                Content = new Form3
                {
                    Text = "عرض اسعار نهائي"
                }
            });
            ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count - 1;
            Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Value = int.Parse(selectedRow.Cells[0].Value.ToString());
            var q = (from i in context.Nha2s
                     where i.ID == Value
                     select i).FirstOrDefault();
            context.Nha2s.Remove(q);
            context.SaveChanges();
            dataGridView1.Rows.Clear();
            fillGrid();
        }
    }
}
