using BLL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using WpfBaget.Command;

namespace WpfBaget.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private IOrderServ orderServ;

        private OrderModel selectedOrder;
        private BagetModel selectedBaget;

        private BagetViewModel bagetViewModel;
        public BagetViewModel BagetViewModel
        {
            get { return bagetViewModel; }
            set
            {
                bagetViewModel = value;
                OnPropertyChanged("BagetViewModel");
            }
        }

        private RelayCommand addOrderCommand;
        //done
        public RelayCommand AddOrderCommand
        {
            get
            {
                return addOrderCommand ??
                    (addOrderCommand = new RelayCommand(obj =>
                    {
                        OrderModel order = new OrderModel();
                        order.Customer = "???";
                        SelectedOrder = orderServ.Save(order, true);

                        OnPropertyChanged("Orders");
                    }));
            }
        }

        private RelayCommand saveOrderCommand;
        //done
        public RelayCommand SaveOrderCommand
        {
            get
            {
                return saveOrderCommand ??
                    (saveOrderCommand = new RelayCommand(obj =>
                    {
                        OrderModel order = obj as OrderModel;
                        SelectedOrder = orderServ.Save(order, false);

                        OnPropertyChanged("Orders");

                    }, (obj) => SelectedOrder != null));
            }
        }

        private RelayCommand delOrderCommand;
        //done
        public RelayCommand DelOrderCommand
        {
            get
            {
                return delOrderCommand ??
                    (delOrderCommand = new RelayCommand(obj =>
                    {
                        OrderModel order = obj as OrderModel;
                        if (order != null)
                        {
                            orderServ.Del(SelectedOrder);
                            SelectedOrder = null;

                            OnPropertyChanged("Orders");
                        }
                    }, (obj) => SelectedOrder != null));
            }
        }

        //private RelayCommand addBagetCommand;
        ////done
        //public RelayCommand AddBagetCommand
        //{
        //    get
        //    {
        //        return addBagetCommand ??
        //            (addBagetCommand = new RelayCommand(obj =>
        //            {
        //                OrderModel order = obj as OrderModel;

        //                BagetViewModel = new BagetViewModel(
        //                    this, new BagetModel { OrderID = order.ID }, false);
        //                SwitchView = 1;

        //            }, (obj) => SelectedOrder != null));
        //    }
        //}

        //private RelayCommand editBagetCommand;
        ////done
        //public RelayCommand EditBagetCommand
        //{
        //    get
        //    {
        //        return editBagetCommand ??
        //            (editBagetCommand = new RelayCommand(obj =>
        //            {
        //                BagetModel baget = obj as BagetModel;

        //                BagetViewModel = new BagetViewModel(
        //                    this, baget, true);
        //                SwitchView = 1;

        //            }, (obj) => SelectedBaget != null));
        //    }
        //}

        private RelayCommand delBagetCommand;
        //done
        public RelayCommand DelBagetCommand
        {
            get
            {
                return delBagetCommand ??
                    (delBagetCommand = new RelayCommand(obj =>
                    {
                        BagetModel baget = obj as BagetModel;

                        SelectedOrder = orderServ.DelBaget(SelectedOrder, baget);
                        SelectedBaget = null;

                        OnPropertyChanged("Bagets");
                        OnPropertyChanged("Orders");

                    }, (obj) => SelectedBaget != null));
            }
        }

        private RelayCommand calculateCommand;
        //done
        public RelayCommand CalculateCommand
        {
            get
            {
                return calculateCommand ??
                    (calculateCommand = new RelayCommand(obj =>
                    {
                        OrderModel order = obj as OrderModel;

                        MessageBoxResult result = MessageBox.Show(
                            orderServ.showMaterials(order));

                    }, (obj) => SelectedOrder != null && Bagets.Count > 0));
            }
        }

        public ObservableCollection<OrderModel> Orders
        {
            get { return orderServ.LoadAll(); }
            set
            {
                OnPropertyChanged("Orders");
            }
        }

        public ObservableCollection<BagetModel> Bagets
        {
            get
            {
                return SelectedOrder != null ?
                  SelectedOrder.Bagets :
                  new ObservableCollection<BagetModel>();
            }
            set
            {
                OnPropertyChanged("Bagets");
                OnPropertyChanged("SelectedBaget");
            }
        }

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

        public string Customer
        {
            get { return SelectedOrder.Customer; }
            set
            {
                SelectedOrder.Customer = value;
                OnPropertyChanged("SelectedOrder");
                OnPropertyChanged("Customer");
            }
        }

        public OrderViewModel(IOrderServ orderServ)
        {
            this.orderServ = orderServ;
            
            Orders = orderServ.LoadAll();

            SelectedOrder = null;
        }

        //private int switchView;
        //public int SwitchView
        //{
        //    get { return switchView; }
        //    set
        //    {
        //        switchView = value;
        //        SelectedOrder = orderServ.Load(SelectedOrder.ID);
        //        OnPropertyChanged("SwitchView");
        //    }
        //}
    }
}
