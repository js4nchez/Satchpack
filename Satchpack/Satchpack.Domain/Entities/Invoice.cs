using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Invoice : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide the customer associated with this invoice.")]
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please provide the shipping method for this invoice.")]
        public ShippingMethod ShippingMethod { get; set; }

        [Required(ErrorMessage = "Please provide the date this order was placed on.")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Please provide the total price for this invoice.")]
        public double InvoiceTotal { get; set; }

        [Required(ErrorMessage = "Please provide the current status of this invoice.")]
        public InvoiceStatus InvoiceStatus { get; set; }

        public Invoice()
        {
            CreateSproc = "dbo.CreateInvoice";
            RetrieveAllSproc = "dbo.RetrieveAllInvoices";
            RetrieveSingleSproc = "dbo.RetrieveInvoiceById";
            UpdateSproc = "dbo.UpdateInvoice";
            DeleteSproc = "dbo.DeleteInvoice";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@invoiceId", Id),
                new SqlParameter("@orderDate", OrderDate),
                new SqlParameter("@invoiceTotal", InvoiceTotal),
                new SqlParameter("@shippingMethodId", ShippingMethod.Id),
                new SqlParameter("@invoiceStatusId", InvoiceStatus.Id)
            };
            parameters.AddRange(Customer.ToSqlParams());
            return parameters;
        }
        public override DAL_Entity ConvertToEntity(SqlDataReader reader)
        {
            return new Invoice()
            {
                Id = int.Parse(reader["Id"].ToString()),
                Customer = (Customer)new Customer().ConvertToEntity(reader),
                ShippingMethod = (ShippingMethod)new ShippingMethod().ConvertToEntity(reader),
                OrderDate = DateTime.Parse(reader["OrderDate"].ToString()),
                InvoiceTotal = double.Parse(reader["InvoiceTotal"].ToString()),
                InvoiceStatus = (InvoiceStatus)new InvoiceStatus().ConvertToEntity(reader)
            };
        }
    }
}
