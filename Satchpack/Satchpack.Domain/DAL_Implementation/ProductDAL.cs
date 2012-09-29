using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Satchpack.Domain.Entities;
using Satchpack.Domain.DAL_Abstract;

namespace Satchpack.Domain.DAL_Implementation
{
    public class ProductDAL : IProductDAL
    {
        public override bool UpdateInventory(DAL_Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}