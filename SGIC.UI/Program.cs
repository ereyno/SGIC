using SGIC.UI.Abstract;
using SGIC.UI.Infrastructure;
using SGIC.UI.Presenter;
using SGIC.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;

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

            var presenter = NinjectFactory.Instance.Kernel.Get<SplitPresenter>();

            Application.Run((SplitView)presenter.view);
        }
    }
}
