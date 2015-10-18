using Ninject;
using SGIC.Domain.Abstract;
using SGIC.Domain.Repository;
using SGIC.UI.Abstract;
using SGIC.UI.Presenter;
using SGIC.UI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGIC.UI.Infrastructure
{
    public class NinjectFactory
    {
        private static readonly Lazy<NinjectFactory> _instance = new Lazy<NinjectFactory>(() => new NinjectFactory());
        private IKernel ninjectKernel;
        private NinjectSettings settings = new NinjectSettings()
        {
            LoadExtensions = false
        };
        private NinjectFactory()
        {
            ninjectKernel = new StandardKernel(settings);
            this.AddBind();
        }

        public static NinjectFactory Instance
        {
            get { return _instance.Value; }
        }
        public IKernel Kernel { get { return ninjectKernel; } }

        private void AddBind()
        {
            //ninjectKernel.Bind<ILog>().ToConstant(LogManager.GetLogger("*"));
            ninjectKernel.Bind<IVehicleContext>().To<VehicleContext>();
            ninjectKernel.Bind<ISplitRepository>().To<SplitRepository>();
            ninjectKernel.Bind<ISplitView>().To<SGIC.UI.View.SplitView>();
        }

    }
}
