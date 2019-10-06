using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace _3DR
{
    public partial class Main : Form
    {
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }
        public Main()
        {
            InitializeComponent();
        }
       
        private void panel1_Click(object sender, EventArgs e)
        {
            ParentTabs.Tabs.Add(new TitleBarTab(ParentTabs)
            {
                Content = new Form2
                {
                    Text = "أضافة أصناف"
                }
            });
            ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count - 1;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            ParentTabs.Tabs.Add(new TitleBarTab(ParentTabs)
            {
                Content = new Form3
                {
                    Text = "عرض اسعار نهائي"
                }
            });
            ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count - 1;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ParentTabs.Tabs.Add(new TitleBarTab(ParentTabs)
            {
                Content = new Form4
                {
                    Text = "عرض اسعار ابتدائي"
                }
            });
            ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count - 1;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            ParentTabs.Tabs.Add(new TitleBarTab(ParentTabs)
            {
                Content = new Form1
                {
                    Text = "رفع مقاسات"
                }
            });
            ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count - 1;
        }

        private void panel4_Click_1(object sender, EventArgs e)
        {
            ParentTabs.Tabs.Add(new TitleBarTab(ParentTabs)
            {
                Content = new _3rdAbtda2y
                {
                    Text = "العروض الإبتدائية"
                }
            });
            ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count - 1;
        }

        private void panel6_Click_1(object sender, EventArgs e)
        {
            ParentTabs.Tabs.Add(new TitleBarTab(ParentTabs)
            {
                Content = new _3rdNha2y
                {
                    Text = "العروض النهائية"
                }
            });
            ParentTabs.SelectedTabIndex = ParentTabs.Tabs.Count - 1;
        }
    }
}
