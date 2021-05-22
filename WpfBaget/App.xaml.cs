using BLL.Infrastructure;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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

            this.Dispatcher.UnhandledException += OnDispatcherUnhandleException;

            kernel = new StandardKernel(new ServiceModule("DefaultConnection"));
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<BagetViewModel>().ToSelf().InTransientScope();
            kernel.Bind<OrderViewModel>().ToSelf().InTransientScope();
            kernel.Bind<MainViewModel>().ToSelf().InTransientScope();

            kernel.Bind<AppViewModel>().ToSelf().InTransientScope();

            kernel.Bind<ViewModelLocator>().ToSelf().InTransientScope();

            kernel.Bind<MainWindow>().ToSelf().InTransientScope();

            MainWindow main = kernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }

        static void OnDispatcherUnhandleException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            string ErrorMessage = string.Format("Oops, something went wrong!\n"
                + e.Exception.Message + "\n"
                + (e.Exception.InnerException != null ? e.Exception.InnerException.Message + "\n" : null)
                + "Please check your data and repeat the action\n"
                + "Click Да to contine and Нет to close the application");

            if (MessageBox.Show(ErrorMessage, "Error", 
                MessageBoxButton.YesNoCancel, 
                MessageBoxImage.Error) == MessageBoxResult.No)
            {
                if (MessageBox.Show("Are you sure?", 
                    "Close the Application", 
                    MessageBoxButton.YesNoCancel, 
                    MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
            }
            //MessageBox.Show(ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
