using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Satchpack.Domain.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Satchpack.Domain.DAL_Abstract
{
    /// <summary>
    /// Represents the basic operations that can be done on the database.
    /// </summary>
    public abstract class IDAL_Base
    {
        private readonly string ConnectionString = @"Data Source=tcp:mssql1.cloudsites.gearhost.com;Initial Catalog=satchpack;User ID=satchpack;Pwd=w7ddrb84;";

        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <param name="entity">The entity being created.</param>
        /// <returns>The created entity's Id.</returns>
        public virtual int CreateEntity(DAL_Entity entity)
        {
            int entityId = 0;
            object obj = ExecuteScalar(entity.CreateSproc, entity.ToSqlParams().ToArray());
            if (obj is int)
                entityId = (int)obj;
            return entityId;
        }

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity">The entity being updated.</param>
        /// <returns>Determines whether the operation was successful.</returns>
        public virtual bool UpdateEntity(DAL_Entity entity)
        {
            return ExecuteSproc(entity.UpdateSproc, entity.ToSqlParams().ToArray());
        }

        /// <summary>
        /// Deletes an entity in the database.
        /// </summary>
        /// <param name="entity">The entity being deleted.</param>
        /// <returns>Determines whether the operation was successful.</returns>
        public virtual bool DeleteEntity(DAL_Entity entity)
        {
            return ExecuteSproc(entity.DeleteSproc, entity.ToSqlParams().ToArray());
        }

        /// <summary>
        /// Retrieves all entities in the database.
        /// </summary>
        /// <param name="entity">The entity being used for retrieving all entities.</param>
        /// <returns>A list of entities found in the database.</returns>
        public virtual List<DAL_Entity> RetrieveEntities(DAL_Entity entity)
        {
            List<DAL_Entity> entities = new List<DAL_Entity>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(entity.RetrieveAllSproc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        entities.Add(entity.ConvertToEntity(reader));
                }
            }
            return entities;
        }

        /// <summary>
        /// Retrieves an entity with the specified Id in the database.
        /// </summary>
        /// <param name="entity">The entity that contains the Id to query by.</param>
        /// <returns>An single enity.</returns>
        public virtual DAL_Entity RetrieveEntityById(DAL_Entity entity)
        {
            DAL_Entity dal_entity = null;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(entity.RetrieveSingleSproc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(entity.ToSqlParams().ToArray());
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        dal_entity = entity.ConvertToEntity(reader);
                }
            }
            return dal_entity;
        }

        /// <summary>
        /// Executes the specified sproc.
        /// </summary>
        /// <param name="sproc">The sproc that you want to execute.</param>
        /// <param name="sqlParameters">The parameters that the given sproc requires.</param>
        /// <returns>Determines whether the operation was successful.</returns>
        private bool ExecuteSproc(string sproc, params SqlParameter[] sqlParameters)
        {
            bool operationSucceeded = true;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sproc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameters);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { operationSucceeded = false; }
            return operationSucceeded;
        }

        /// <summary>
        /// Executes the specified sproc, returning a scalar.
        /// </summary>
        /// <param name="sproc">The sproc that you want to execute.</param>
        /// <param name="sqlParameters">The parameters that the given sproc requires.</param>
        /// <returns></returns>
        private object ExecuteScalar(string sproc, params SqlParameter[] sqlParameters)
        {
            object obj = new object();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sproc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameters);
                        obj = cmd.ExecuteScalar();
                    }
                }
            }
            catch { }
            return obj;
        }
    }
}