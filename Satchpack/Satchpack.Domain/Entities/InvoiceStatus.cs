using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Satchpack.Domain.Entities
{
    public class InvoiceStatus : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name for this invoice status.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide a description for this invoice status.")]
        public string Description { get; set; }

        public InvoiceStatus()
        {
            CreateSproc = "dbo.CreateInvoiceStatus";
            RetrieveAllSproc = "dbo.RetrieveAllInvoiceStatus";
            RetrieveSingleSproc = "dbo.RetrieveInvoiceStatusById";
            UpdateSproc = "dbo.UpdateInvoiceStatus";
            DeleteSproc = "dbo.DeleteInvoiceStatus";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@id", Id),
                new SqlParameter("@name", Name),
                new SqlParameter("@description", Description)
            };
        }
        public override DAL_Entity ConvertToEntity(SqlDataReader reader)
        {
            return new InvoiceStatus()
            {
                Id = int.Parse(reader["Id"].ToString()),
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString()
            };
        }
    }
}