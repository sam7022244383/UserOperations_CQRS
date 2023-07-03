using Ecommerce.DataProvider.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataProvider.BusinessLogic.Implementation
{
    public class testclass : Itest
    {
        public async Task<int> getid(int id)
        {
            return id;
        }
    }
}
