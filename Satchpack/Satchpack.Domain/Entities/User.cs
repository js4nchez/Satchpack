using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Satchpack.Domain.Entities
{
    class User
    {
        [Required(ErrorMessage = "")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "")]
        public string Password { get; set; }

        [Required(ErrorMessage = "")]
        public int Lock { get; set; }
    }
}
