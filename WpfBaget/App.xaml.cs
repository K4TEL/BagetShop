using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using WpfBaget.ViewModels;
using WpfBaget.Views;

namespace WpfBaget
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IKernel kernel { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            kernel = new StandardKernel(serviceModule);
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<BagetViewModel>().ToSelf();
            kernel.Bind<OrderViewModel>().ToSelf();
            kernel.Bind<ViewModelLocator>().ToSelf();
            kernel.Bind<MainWindow>().ToSelf();

            //kernel.Bind<MainViewModel>().
            MainWindow main = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
