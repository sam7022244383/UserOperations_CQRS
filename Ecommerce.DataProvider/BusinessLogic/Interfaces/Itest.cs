using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataProvider.BusinessLogic.Interfaces
{
    public interface Itest
    {
       Task<int> getid(int id);
    }
}
