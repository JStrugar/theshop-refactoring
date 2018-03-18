using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
namespace TheShop
{
    class Bindings : NinjectModule
    {
        StandardKernel kernel;
        public Bindings(StandardKernel kernel)
        {
            this.kernel = kernel;
        }
        public override void Load()
        {
            this.kernel.Bind<IArticleBroker>().To<ArticleBroker>().InSingletonScope();
            this.kernel.Bind<ILogger>().To<Logger>().InSingletonScope();
        }
    }
}
