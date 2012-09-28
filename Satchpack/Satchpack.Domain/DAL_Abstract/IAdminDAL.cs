using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Satchpack.Domain.Entities;

namespace Satchpack.Domain.AbstractRepository
{
    /// <summary>
    /// Represents the data access layer for persisting Users.
    /// 
    /// Root Aggregate: User
    /// </summary>
    public interface IAdminDAL
    {
        bool CreateUser(DAL_Object user);
        bool UpdateUser(DAL_Object user);
        bool DeleteUser(DAL_Object user);
        DAL_Object RetrieveUsers();
        DAL_Object RetrieveUserById(int userId);
    }
}
