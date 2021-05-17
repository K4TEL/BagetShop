using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfBaget.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator() { }

        public static BagetViewModel BagetViewModel { get { return App.kernel.Get<BagetViewModel>(); } }
        public static OrderViewModel OrderViewModel { get { return App.kernel.Get<OrderViewModel>(); } }
    }
}
