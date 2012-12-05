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
        [HiddenInput(DisplayValue = true)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please provide the available quantity for this product.")]
        public int Quantity { get; set; }

        public Inventory()
        {
            CreateSproc = "dbo.CreateInventory";
            RetrieveAllSproc = "dbo.RetrieveAllInventory";
            RetrieveSingleSproc = "dbo.RetrieveInventoryById";
            UpdateSproc = "dbo.UpdateInventory";
            DeleteSproc = "dbo.DeleteInventory";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@inventoryId", Id),
                new SqlParameter("@quantity", Quantity)
            };
            parameters.AddRange(Product.ToSqlParams());
            return parameters;
        }
        public override DAL_Entity ConvertToEntity(SqlDataReader reader)
        {
            return new Inventory()
            {
                Id = int.Parse(reader["Id"].ToString()),
                Product = (Product)new Product().ConvertToEntity(reader),
                Quantity = int.Parse(reader["Quantity"].ToString())
            };
        }
    }
}