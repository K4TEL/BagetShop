using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfBaget.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator() { }

        public AppViewModel AppViewModel { get { return App.kernel.Get<AppViewModel>(); } }
        public MainViewModel MainViewModel { get { return App.kernel.Get<MainViewModel>(); } }
        public BagetViewModel BagetViewModel { get { return App.kernel.Get<BagetViewModel>(); } }
        public OrderViewModel OrderViewModel { get { return App.kernel.Get<OrderViewModel>(); } }
    }
}
