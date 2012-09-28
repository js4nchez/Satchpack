using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Satchpack.Domain.Entities;

namespace Satchpack.Domain.AbstractRepository
{
    /// <summary>
    /// Represents the data access layer for persisting Products.
    /// 
    /// Root Aggregate: Product
    /// Aggregate Members: Inventory
    /// </summary>
    public interface IProductDAL
    {
        bool CreateProduct(DAL_Object product);
        bool UpdateProduct(DAL_Object product);
        bool UpdateInventory(DAL_Object productInventory);
        bool DeleteProduct(DAL_Object product);
        DAL_Object RetrieveProducts();
        DAL_Object RetrieveProductById(int productId);
    }
}