using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Inventory : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please provide the available quantity for this product.")]
        public int Quantity { get; set; }

        public Inventory()
        {
            CreateSproc = "dbo.CreateInventory";
            RetrieveSproc = "dbo.RetrieveInventory";
            UpdateSproc = "dbo.UpdateInventory";
            DeleteSproc = "dbo.DeleteInventory";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@id", Id),
                new SqlParameter("@productId", Product.Id),
                new SqlParameter("@quantity", Quantity)
            };
        }
    }
}