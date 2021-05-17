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
    public class MainViewModel : ViewModelBase
    {
        private IOrderServ orderServ;
        private IBagetServ bagetServ;
        private ITypeServ typeServ;

        private OrderModel selectedOrder;
        private BagetModel selectedBaget;
        private TypeModel selectedType;

        private bool edit;

        private RelayCommand saveBagetCommand;
        public RelayCommand SaveBagetCommand
        {
            get
            {
                return saveBagetCommand ??
                    (saveBagetCommand = new RelayCommand(obj =>
                    {
                        BagetModel baget = obj as BagetModel;

                        baget.TypeID = SelectedType.ID;
                        if (edit)
                        {
                            SelectedBaget = bagetServ.Save(baget, !edit);
                            SelectedOrder = orderServ.Load(SelectedBaget.OrderID);
                        }
                        else
                            SelectedOrder = orderServ.AddBaget(SelectedOrder, baget);

                        SelectedType = null;
                        SelectedBaget = null;

                        OnPropertyChanged("Bagets");
                        OnPropertyChanged("Orders");

                    }, (obj) => SelectedBaget != null));
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
                        SelectedBaget = null;
                        SelectedType = null;
                    }));
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

                        edit = false;
                        SelectedBaget = new BagetModel();
                        SelectedBaget.Amount = "1";
                        SelectedBaget.Width = "0,1";
                        SelectedBaget.Lenght = "0,1";
                        SelectedBaget.OrderID = order.ID;

                        SelectedType = Types[0];

                    }, (obj) => SelectedOrder != null));
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

                        edit = true;
                        SelectedBaget = baget;
                        SelectedType = typeServ.Load(baget.TypeID);

                    }, (obj) => SelectedBaget != null));
            }
        }

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

        public ObservableCollection<TypeModel> Types
        {
            get { return typeServ.LoadAll(); }
            set
            {
                OnPropertyChanged("Types");
            }
        }

        public ObservableCollection<MaterialModel> Materials
        {
            get
            {
                return SelectedType != null ?
                  SelectedType.Materials :
                  new ObservableCollection<MaterialModel>();
            }
            set
            {
                OnPropertyChanged("Materials");
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


        public TypeModel SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;

                OnPropertyChanged("Baget");
                OnPropertyChanged("Materials");
                OnPropertyChanged("SelectedType");
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

        public string Amount
        {
            get { return SelectedBaget.Amount; }
            set
            {
                SelectedBaget.Amount = value;
                OnPropertyChanged("Baget");
                OnPropertyChanged("Amount");
            }
        }
        public string Width
        {
            get { return SelectedBaget.Width; }
            set
            {
                SelectedBaget.Width = value;
                OnPropertyChanged("Baget");
                OnPropertyChanged("Width");
            }
        }
        public string Lenght
        {
            get { return SelectedBaget.Lenght; }
            set
            {
                SelectedBaget.Lenght = value;
                OnPropertyChanged("Baget");
                OnPropertyChanged("Lenght");
            }
        }

        public MainViewModel(IService services)
        {
            orderServ = services.GetService<IOrderServ>();
            bagetServ = services.GetService<IBagetServ>();
            typeServ = services.GetService<ITypeServ>();

            Orders = orderServ.LoadAll();
            Types = typeServ.LoadAll();

            SelectedOrder = null;
        }
    }
}
