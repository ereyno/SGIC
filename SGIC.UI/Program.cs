using SGIC.UI.Abstract;
using SGIC.UI.Presenter;
using SGIC.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGIC.UI
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

            SplitView view = new SplitView();
            SplitPresenter presenter = new SplitPresenter(view);
            Application.Run(view);
        }
    }
}
