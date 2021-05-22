﻿using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Mappers;

namespace BLL.Services
{
    public class TypeServ : ITypeServ
    {
        IUnitOfWork database { get; set; }
        public TypeServ(IUnitOfWork uow)
        {
            this.database = uow;
        }
        public ObservableCollection<TypeModel> LoadAll()
        {
            return database.TypeRep.LoadAll().MapToModelList();
        }

        public TypeModel Load(Guid id)
        {
            return database.TypeRep.Load(id).MapToModel();
        }
    }
}
