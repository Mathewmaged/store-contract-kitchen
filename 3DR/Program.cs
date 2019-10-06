using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
namespace _3DR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppContainer container = new AppContainer();
            container.Tabs.Add(
                new TitleBarTab(container)
                {
                    Content = new Main
                    {
                        Text = "الرئيسية"
                    }
                }
                );
            container.SelectedTabIndex=0;
            TitleBarTabsApplicationContext context = new TitleBarTabsApplicationContext();
            context.Start(container);
            Application.Run(context);
        }
    }
}
