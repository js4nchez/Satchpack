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
        public string RetrieveAllSproc { get; set; }
        public string RetrieveSingleSproc { get; set; }
        public string UpdateSproc { get; set; }
        public string DeleteSproc { get; set; }

        /// <summary>
        /// Converts the properties of a DAL object into a list of SQL Parameters.
        /// </summary>
        /// <returns>A list of SqlParameters.</returns>
        public abstract List<SqlParameter> ToSqlParams();

        /// <summary>
        /// Converts the sql into the c# properties.
        /// </summary>
        /// <param name="reader">The object containing the property values.</param>
        /// <returns>An entity with its properties set.</returns>
        public abstract DAL_Entity ConvertToEntity(SqlDataReader reader);
    }
}