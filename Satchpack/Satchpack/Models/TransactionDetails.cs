using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Satchpack.Domain.Entities;

namespace Satchpack.Models
{
    public class TransactionDetails
    {
        public Invoice MyProperty { get; set; }
        public string Token { get; set; }
        public string PayerId { get; set; }
    }
}