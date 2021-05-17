using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Current.MainWindow = new MainWindow
            {
                DataContext = new OrderViewModel(new ServiceLocator("DefaultConnection"))
            };
            Current.MainWindow.Show();
        }
    }
}
