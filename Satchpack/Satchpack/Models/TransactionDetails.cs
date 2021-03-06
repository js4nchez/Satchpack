﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Satchpack.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Satchpack.Models
{
    public class TransactionDetails
    {
        [HiddenInput(DisplayValue = true)]
        public string Token { get; set; }

        [HiddenInput(DisplayValue = true)]
        public string PayerId { get; set; }
        public Invoice Invoice { get; set; }
    }
}