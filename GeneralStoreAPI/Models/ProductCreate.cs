﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class ProductCreate
    {
        [Required]

        public string Sku { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]

        public double Cost { get; set; }

        [Required]

        public int NumberInInventory { get; set; }

        [Required]

        public bool IsInStock { get; set; }
    }
}