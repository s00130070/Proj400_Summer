﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proj400.Models.Entities
{
    public class CartIndex
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}