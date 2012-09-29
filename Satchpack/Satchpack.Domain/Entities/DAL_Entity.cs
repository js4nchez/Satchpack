using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Satchpack.Domain.Entities
{
    /// <summary>
    /// Represents an object used for persistence.
    /// </summary>
    public abstract class DAL_Entity
    {
        public string CreateSproc { get; set; }
        public string RetrieveSproc { get; set; }
        public string UpdateSproc { get; set; }
        public string DeleteSproc { get; set; }

        /// <summary>
        /// Converts the properties of a DAL object into a list of SQL Parameters.
        /// </summary>
        /// <returns></returns>
        public abstract List<SqlParameter> ToSqlParams();
    }
}