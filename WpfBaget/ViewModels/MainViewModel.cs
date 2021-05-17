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
        private IOrderServ orderServ;
        private IBagetServ bagetServ;
        //private ITypeServ typeServ;

        private OrderModel selectedOrder;
        private BagetModel selectedBaget;

        public OrderModel SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;

                OnPropertyChanged("Bagets");
                OnPropertyChanged("SelectedOrder");
            }
        }

        public BagetModel SelectedBaget
        {
            get { return selectedBaget; }
            set
            {
                selectedBaget = value;
                OnPropertyChanged("SelectedBaget");
            }
        }

        public bool edit;

        public MainViewModel(IKernel kernel)
        {
            orderServ = kernel.Get<IOrderServ>();
            bagetServ = kernel.Get<IBagetServ>();
            this.kernel = kernel;
            //typeServ = kernel.Get<ITypeServ>();

            //Orders = orderServ.LoadAll();
            //Types = typeServ.LoadAll();

            //SelectedOrder = null;

            CurrentViewModel = kernel.Get<OrderViewModel>();
        }
        private ViewModelBase currentVM;
        public ViewModelBase CurrentViewModel
        {
            get { return currentVM; }
            set
            {
                currentVM = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }
        private RelayCommand saveBagetCommand;
        public RelayCommand SaveBagetCommand
        {
            get
            {
                return saveBagetCommand ??
                    (saveBagetCommand = new RelayCommand(obj =>
                    {
                        BagetModel baget = obj as BagetModel;

                        //SelectedBaget = ViewModelLocator.BagetViewModel.SelectedBaget;
                        SelectedBaget.TypeID = kernel.Get<BagetViewModel>().SelectedType.ID;
                        if (edit)
                        {
                            SelectedBaget = bagetServ.Save(SelectedBaget, !edit);
                            SelectedOrder = orderServ.Load(SelectedBaget.OrderID);
                        }
                        else
                        {
                            SelectedBaget = bagetServ.Save(SelectedBaget, !edit);
                            //SelectedOrder = orderServ.AddBaget(SelectedOrder, baget);
                        }

                        SelectedOrder = null;
                        SelectedBaget = null;

                        //OnPropertyChanged("Bagets");
                        //OnPropertyChanged("Orders");

                        CurrentViewModel = kernel.Get<OrderViewModel>();

                    }, (obj) => obj != null));
            }
        }

        private RelayCommand cancelBagetCommand;
        public RelayCommand CancelBagetCommand
        {
            get
            {
                return cancelBagetCommand ??
                    (cancelBagetCommand = new RelayCommand(obj =>
                    {
                        CurrentViewModel = kernel.Get<OrderViewModel>();
                        SelectedOrder = null;
                        SelectedBaget = null;
                    }));
            }
        }

        private RelayCommand addBagetCommand;
        //done
        public RelayCommand AddBagetCommand
        {
            get
            {
                return addBagetCommand ??
                    (addBagetCommand = new RelayCommand(obj =>
                    {
                        OrderModel order = obj as OrderModel;

                        SelectedOrder = order;

                        var Edit = new Ninject.Parameters.ConstructorArgument("edit", false);
                        SelectedBaget = new BagetModel();
                        SelectedBaget.OrderID = SelectedOrder.ID;
                        var Baget = new Ninject.Parameters.ConstructorArgument("baget", SelectedBaget);

                        CurrentViewModel = kernel.Get<BagetViewModel>(Baget, Edit);

                    }, (obj) => obj != null));
            }
        }

        private RelayCommand editBagetCommand;
        //done
        public RelayCommand EditBagetCommand
        {
            get
            {
                return editBagetCommand ??
                    (editBagetCommand = new RelayCommand(obj =>
                    {
                        BagetModel baget = obj as BagetModel;

                        selectedOrder = orderServ.Load(baget.OrderID);
                        selectedBaget = baget;

                        var Edit = new Ninject.Parameters.ConstructorArgument("edit", true);
                        var Baget = new Ninject.Parameters.ConstructorArgument("baget", SelectedBaget);

                        CurrentViewModel = kernel.Get<BagetViewModel>(Baget, Edit);

                    }, (obj) => obj != null));
            }
        }

        //private RelayCommand addOrderCommand;
        ////done
        //public RelayCommand AddOrderCommand
        //{
        //    get
        //    {
        //        return addOrderCommand ??
        //            (addOrderCommand = new RelayCommand(obj =>
        //            {
        //                OrderModel order = new OrderModel();
        //                order.Customer = "???";
        //                SelectedOrder = orderServ.Save(order, true);

        //                OnPropertyChanged("Orders");
        //            }));
        //    }
        //}

        //private RelayCommand saveOrderCommand;
        ////done
        //public RelayCommand SaveOrderCommand
        //{
        //    get
        //    {
        //        return saveOrderCommand ??
        //            (saveOrderCommand = new RelayCommand(obj =>
        //            {
        //                OrderModel order = obj as OrderModel;
        //                SelectedOrder = orderServ.Save(order, false);

        //                OnPropertyChanged("Orders");

        //            }, (obj) => SelectedOrder != null));
        //    }
        //}

        //private RelayCommand delOrderCommand;
        ////done
        //public RelayCommand DelOrderCommand
        //{
        //    get
        //    {
        //        return delOrderCommand ??
        //            (delOrderCommand = new RelayCommand(obj =>
        //            {
        //                OrderModel order = obj as OrderModel;
        //                if (order != null)
        //                {
        //                    orderServ.Del(SelectedOrder);
        //                    SelectedOrder = null;

        //                    OnPropertyChanged("Orders");
        //                }
        //            }, (obj) => SelectedOrder != null));
        //    }
        //}



        //private RelayCommand delBagetCommand;
        ////done
        //public RelayCommand DelBagetCommand
        //{
        //    get
        //    {
        //        return delBagetCommand ??
        //            (delBagetCommand = new RelayCommand(obj =>
        //            {
        //                BagetModel baget = obj as BagetModel;

        //                SelectedOrder = orderServ.DelBaget(SelectedOrder, baget);
        //                SelectedBaget = null;

        //                OnPropertyChanged("Bagets");
        //                OnPropertyChanged("Orders");

        //            }, (obj) => SelectedBaget != null));
        //    }
        //}

        //private RelayCommand calculateCommand;
        ////done
        //public RelayCommand CalculateCommand
        //{
        //    get
        //    {
        //        return calculateCommand ??
        //            (calculateCommand = new RelayCommand(obj =>
        //            {
        //                OrderModel order = obj as OrderModel;

        //                MessageBoxResult result = MessageBox.Show(
        //                    orderServ.showMaterials(order));

        //            }, (obj) => SelectedOrder != null && Bagets.Count > 0));
        //    }
        //}



        //public ObservableCollection<OrderModel> Orders
        //{
        //    get { return orderServ.LoadAll(); }
        //    set
        //    {
        //        OnPropertyChanged("Orders");
        //    }
        //}

        //public ObservableCollection<TypeModel> Types
        //{
        //    get { return typeServ.LoadAll(); }
        //    set
        //    {
        //        OnPropertyChanged("Types");
        //    }
        //}

        //public ObservableCollection<MaterialModel> Materials
        //{
        //    get
        //    {
        //        return SelectedType != null ?
        //          SelectedType.Materials :
        //          new ObservableCollection<MaterialModel>();
        //    }
        //    set
        //    {
        //        OnPropertyChanged("Materials");
        //    }
        //}

        //public ObservableCollection<BagetModel> Bagets
        //{
        //    get
        //    {
        //        return SelectedOrder != null ?
        //          SelectedOrder.Bagets :
        //          new ObservableCollection<BagetModel>();
        //    }
        //    set
        //    {
        //        OnPropertyChanged("Bagets");
        //        OnPropertyChanged("SelectedBaget");
        //    }
        //}


        //public TypeModel SelectedType
        //{
        //    get { return selectedType; }
        //    set
        //    {
        //        selectedType = value;

        //        OnPropertyChanged("Baget");
        //        OnPropertyChanged("Materials");
        //        OnPropertyChanged("SelectedType");
        //    }
        //}
        

        //public string Customer
        //{
        //    get { return SelectedOrder.Customer; }
        //    set
        //    {
        //        SelectedOrder.Customer = value;
        //        OnPropertyChanged("SelectedOrder");
        //        OnPropertyChanged("Customer");
        //    }
        //}

        //public string Amount
        //{
        //    get { return SelectedBaget.Amount; }
        //    set
        //    {
        //        SelectedBaget.Amount = value;
        //        OnPropertyChanged("Baget");
        //        OnPropertyChanged("Amount");
        //    }
        //}
        //public string Width
        //{
        //    get { return SelectedBaget.Width; }
        //    set
        //    {
        //        SelectedBaget.Width = value;
        //        OnPropertyChanged("Baget");
        //        OnPropertyChanged("Width");
        //    }
        //}
        //public string Lenght
        //{
        //    get { return SelectedBaget.Lenght; }
        //    set
        //    {
        //        SelectedBaget.Lenght = value;
        //        OnPropertyChanged("Baget");
        //        OnPropertyChanged("Lenght");
        //    }
        //}


    }
}
