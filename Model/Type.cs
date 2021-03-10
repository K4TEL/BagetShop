﻿using BagetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagetShop.Model
{
    public class Type
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public List<Material> Materials { get; set; }

        public Type() { this.ID = Guid.NewGuid(); this.Materials = new List<Material>(); }
        public Type(string title)
        {
            this.ID = Guid.NewGuid();
            this.Title = title;
            this.Materials = new List<Material>();
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}