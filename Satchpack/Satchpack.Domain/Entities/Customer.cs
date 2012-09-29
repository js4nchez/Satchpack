using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class Customer : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide your first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide your last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide your street address.")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please provide the city this item will be shipped to.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide the state this item will be shipped to.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please provide the zip/postal code this item will be shipped to.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please provide the country this item will be shipped to.")]
        public string Country { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer()
        {
            CreateSproc = "dbo.CreateCustomer";
            RetrieveSproc = "dbo.RetrieveCustomer";
            UpdateSproc = "dbo.UpdateCustomer";
            DeleteSproc = "dbo.DeleteCustomer";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@id", Id),
                new SqlParameter("@firstName", FirstName),
                new SqlParameter("@lastName", LastName),
                new SqlParameter("@address1", Address1),
                new SqlParameter("@address2", Address2),
                new SqlParameter("@city", City),
                new SqlParameter("@state", State),
                new SqlParameter("@postalCode", PostalCode),
                new SqlParameter("@country", Country),
                new SqlParameter("@email", Email),
                new SqlParameter("@phone", Phone)
            };
        }
    }
}