using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Respoances
{
    public class LoginRespoance
    {
        public string _email { get; set; }

        public string Token { get; set; }

        public DateTime _tokenexpirationdate { get; set; }

        public string _LoginErrorMsg { get; set; }
    }
}
