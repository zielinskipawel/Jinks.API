﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jink.Repository.Models
{
  public class Product 
  {
    public long Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
  }
}
