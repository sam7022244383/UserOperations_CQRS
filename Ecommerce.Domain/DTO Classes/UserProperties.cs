using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.DTO_Classes
{
    public class UserProperties
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime registeredOn { get; set; }

        public string ForgetCode { get; set; }

        public int RegisterUserAddress_ID { get; set; }

        public string RegisterUserAddress_country { get; set; }

        public string RegisterUserAddress_state { get; set; }
        public string RegisterUserAddress_city { get; set; }

        public string RegisterUserAddress_PostalCode { get; set; }

        public string RegisterUserAddress_PhoneNumber { get; set; }
    }
}
