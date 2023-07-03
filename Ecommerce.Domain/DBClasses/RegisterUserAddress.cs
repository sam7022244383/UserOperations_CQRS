using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.DBClasses
{
    public class RegisterUserAddress
    {
        [Key]
        public int RegisterUserAddress_ID { get; set; }

        public string RegisterUserAddress_country { get; set; }

        public string RegisterUserAddress_state { get; set; }
        public string RegisterUserAddress_city { get; set; }

        public string RegisterUserAddress_PostalCode { get; set; }

        public string RegisterUserAddress_PhoneNumber { get; set; }
    }
}
