using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Product : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a SKU for this product.")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Please provide a name for this product.")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide a weight in lbs. for this product.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Please provide a price for this product.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please provide a color for this product")]
        public string Color { get; set; }

        public Product()
        {
            CreateSproc = "dbo.CreateProduct";
            RetrieveAllSproc = "dbo.RetrieveAllProducts";
            RetrieveSingleSproc = "dbo.RetrieveProductById";
            UpdateSproc = "dbo.UpdateProduct";
            DeleteSproc = "dbo.DeleteProduct";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@productId", Id),
                new SqlParameter("@sku", SKU),
                new SqlParameter("@name", Name),
                new SqlParameter("@description", Description),
                new SqlParameter("@weight", Weight),
                new SqlParameter("@price", Price),
                new SqlParameter("@color", Color)
            };
        }
        public override DAL_Entity ConvertToEntity(SqlDataReader reader)
        {
            return new Product()
            {
                Id = int.Parse(reader["Id"].ToString()),
                SKU = reader["SKU"].ToString(),
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                Weight = double.Parse(reader["Weight"].ToString()),
                Price = double.Parse(reader["Price"].ToString()),
                Color = reader["Color"].ToString()
            };
        }
    }
}
