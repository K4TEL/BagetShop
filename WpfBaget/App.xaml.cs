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
using Validators;
using WpfBaget.ViewModels;
using WpfBaget.Views;

namespace WpfBaget
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.Dispatcher.UnhandledException += OnDispatcherUnhandleException;

            MainWindow main = new MainWindow();
            Current.MainWindow.Show();
        }

        static void OnDispatcherUnhandleException(object sender, 
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            string ErrorMessage = "Oops, something went wrong!\n" + e.Exception.Message + "\n";

            if (e.Exception.InnerException != null)
                ErrorMessage += "Inner Exception Message: " + e.Exception.InnerException.Message + "\n";

            ErrorMessage += "Please check your data and repeat the action\n" + "Continue?";

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
