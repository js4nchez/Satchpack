using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    public class User : DAL_Entity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide your password.")]
        public string Password { get; set; }
        public bool Lock { get; set; }

        public User()
        {
            CreateSproc = "dbo.CreateUser";
            RetrieveSproc = "dbo.RetrieveUser";
            UpdateSproc = "dbo.UpdateUser";
            DeleteSproc = "dbo.DeleteUser";
        }
        public override List<SqlParameter> ToSqlParams()
        {
            return new List<SqlParameter>()
            {
                new SqlParameter("@id", Id),
                new SqlParameter("@username", Username),
                new SqlParameter("@password", Password),
                new SqlParameter("@lock", Lock),
            };
        }
    }
}
