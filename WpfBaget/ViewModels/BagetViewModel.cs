using BLL.Interfaces;
using Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfBaget.Command;

namespace WpfBaget.ViewModels
{
    public class BagetViewModel : ViewModelBase
    {
        private IBagetServ bagetServ;

        private BagetModel selectedBaget;
        public bool edit;

        private TypeModel selectedType;

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
                        SelectedBaget = bagetServ.Save(baget, !edit);
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

        public ObservableCollection<TypeModel> Types { get; set; }

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

        public BagetModel SelectedBaget
        {
            get { return selectedBaget; }
            set
            {
                selectedBaget = value;
                OnPropertyChanged("Baget");
            }
        }

        //public BagetViewModel(IKernel kernel, ITypeServ typeServ, IBagetServ bagetServ)
        //{
        //    SelectedBaget = kernel.Get<MainViewModel>().SelectedBaget;
        //    this.edit = kernel.Get<MainViewModel>().edit;

        //    Types = typeServ.LoadAll();
        //    this.bagetServ = bagetServ;

        //    if (!edit)
        //    {
        //        SelectedBaget.Amount = "1";
        //        SelectedBaget.Width = "0,1";
        //        SelectedBaget.Lenght = "0,1";

        //        SelectedType = Types[0];
        //    }
        //    else
        //    {
        //        SelectedType = bagetServ.LoadType(SelectedBaget.ID);
        //    }
        //}

        public BagetViewModel(IKernel kernel, ITypeServ typeServ, IBagetServ bagetServ,
            BagetModel baget, bool edit)
        {
            SelectedBaget = baget;
            this.edit = edit;

            Types = typeServ.LoadAll();
            this.bagetServ = bagetServ;

            if (!edit)
            {
                SelectedBaget.Amount = "1";
                SelectedBaget.Width = "0,1";
                SelectedBaget.Lenght = "0,1";

                SelectedType = Types[0];
            }
            else
            {
                SelectedType = bagetServ.LoadType(SelectedBaget.ID);
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
    }
}
