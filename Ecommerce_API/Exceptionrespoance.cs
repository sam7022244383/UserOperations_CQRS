using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.DTO_Classes
{
    public class Exceptionrespoance
    {
        public bool Success { get; set; }

        public string message { get; set; }

        public string StackTrace { get; set; }
    }
}
