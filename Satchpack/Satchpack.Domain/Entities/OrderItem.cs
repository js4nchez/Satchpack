using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Satchpack.Domain.Entities
{
    public class OrderItem : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide an invoice for this order item.")]
        public Invoice Invoice { get; set; }

        [Required(ErrorMessage = "Please provide a product for this order item.")]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Please provide the quantity you would like to purchase for this item.")]
        public int Quantity { get; set; }

        public OrderItem()
        {
            CreateSproc = "dbo.CreateOrderItem";
            RetrieveAllSproc = "dbo.RetrieveAllOrderItems";
            RetrieveSingleSproc = "dbo.RetrieveOrderItemById";
            UpdateSproc = "dbo.UpdateOrderItem";
            DeleteSproc = "dbo.DeleteOrderItem";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@id", Id),
                new SqlParameter("@invoiceId", Invoice.Id),
                new SqlParameter("@productId", Product.Id),
                new SqlParameter("@quantity", Quantity)
            };
        }
        public override DAL_Entity ConvertToEntity(SqlDataReader reader)
        {
            return new OrderItem()
            {
                Id = int.Parse(reader["Id"].ToString()),
                Invoice = (Invoice)new Invoice().ConvertToEntity(reader),
                Product = (Product)new Product().ConvertToEntity(reader),
                Quantity = int.Parse(reader["Quantity"].ToString())
            };
        }
    }
}
