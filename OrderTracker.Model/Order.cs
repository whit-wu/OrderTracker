﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
