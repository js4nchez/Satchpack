using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Satchpack.Domain.Entities
{
    public class ShippingMethod : DAL_Entity
    {
        [HiddenInput(DisplayValue = true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a carrier for this shipping method.")]
        public string Carrier { get; set; }

        [Required(ErrorMessage = "Please provide the method of shipping.")]
        public string Method { get; set; }

        [Required(ErrorMessage = "Please provide a tracking URL for this shipping method.")]
        public string TrackingUrl { get; set; }

        [Required(ErrorMessage = "Please provide a shipping rate for this method.")]
        public double Price { get; set; }

        public ShippingMethod()
        {
            CreateSproc = "dbo.CreateShippingMethod";
            RetrieveAllSproc = "dbo.RetrieveAllShippingMethods";
            RetrieveSingleSproc = "dbo.RetrieveShippingMethodById";
            UpdateSproc = "dbo.UpdateShippingMethod";
            DeleteSproc = "dbo.DeleteShippingMethod";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@id", Id),
                new SqlParameter("@carrier", Carrier),
                new SqlParameter("@method", Method),
                new SqlParameter("@trackingUrl", TrackingUrl),
                new SqlParameter("@price", Price)
            };
        }
        public override DAL_Entity ConvertToEntity(SqlDataReader reader)
        {
            return new ShippingMethod()
            {
                Id = int.Parse(reader["Id"].ToString()),
                Carrier = reader["Carrier"].ToString(),
                Method = reader["Method"].ToString(),
                TrackingUrl = reader["TrackingUrl"].ToString(),
                Price = double.Parse(reader["Price"].ToString())
            };
        }
    }
}