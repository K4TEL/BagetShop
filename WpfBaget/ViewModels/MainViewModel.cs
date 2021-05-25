using BLL.Interfaces;
using Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using WpfBaget.Command;

namespace WpfBaget.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IKernel kernel;

        private OrderViewModel orderVM;
        private BagetViewModel bagetVM;

        public MainViewModel(IKernel kernel)
        {
            this.kernel = kernel;
            OrderViewModel = new OrderViewModel(this);
        }

        public OrderViewModel OrderViewModel
        {
            get { return orderVM; }
            set
            {
                orderVM = value;
                OnPropertyChanged("OrderViewModel");
            }
        }

        public BagetViewModel BagetViewModel
        {
            get { return bagetVM; }
            set
            {
                bagetVM = value;
                OnPropertyChanged("BagetViewModel");
            }
        }
    }
}
