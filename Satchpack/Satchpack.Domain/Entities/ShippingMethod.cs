using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Satchpack.Domain.Entities
{
    public class ShippingMethod : DAL_Object
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a carrier for this shipping method.")]
        public string Carrier { get; set; }

        [Required(ErrorMessage = "Please provide the method of shipping.")]
        public string Method { get; set; }

        [Required(ErrorMessage = "Please provide a tracking URL for this shipping method.")]
        public string TrackingUrl { get; set; }

        public override List<SqlParameter> ToSqlParams()
        {
            throw new NotImplementedException();
        }
    }
}
