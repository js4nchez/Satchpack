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

        [Required(ErrorMessage = "Please provide yout email.")]
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer()
        {
            CreateSproc = "dbo.CreateCustomer";
            RetrieveAllSproc = "dbo.RetrieveAllCustomers";
            RetrieveSingleSproc = "dbo.RetrieveCustomerById";
            UpdateSproc = "dbo.UpdateCustomer";
            DeleteSproc = "dbo.DeleteCustomer";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@customerId", Id),
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
        public override DAL_Entity ConvertToEntity(SqlDataReader reader)
        {
            return new Customer()
            {
                Id = int.Parse(reader["Id"].ToString()),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Address1 = reader["Address1"].ToString(),
                Address2 = reader["Address2"].ToString(),
                City = reader["City"].ToString(),
                State = reader["State"].ToString(),
                PostalCode = reader["PostalCode"].ToString(),
                Country = reader["Country"].ToString(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"].ToString()
            };
        }
    }
}