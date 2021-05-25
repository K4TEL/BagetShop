using BLL.Infrastructure;
using Ninject;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using WpfBaget.Views;

namespace WpfBaget.ViewModels
{
    public class ViewModelLocator
    {
        public static IKernel kernel { get; private set; }
        public ViewModelLocator() {
            kernel = new StandardKernel(new ServiceModule("DefaultConnection"));
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<AppViewModel>().ToSelf().InSingletonScope();
        }

        public AppViewModel AppViewModel { get { return kernel.Get<AppViewModel>(); } }
    }
}
