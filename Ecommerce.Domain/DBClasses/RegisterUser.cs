using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.DBClasses
{
    public class RegisterUser
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime registeredOn { get; set; }

        public string ForgetCode { get; set; }

        public RegisterUserAddress Address { get; set; }




    }
}
