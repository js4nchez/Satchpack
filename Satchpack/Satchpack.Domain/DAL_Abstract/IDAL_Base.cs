using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Satchpack.Domain.Entities;

namespace Satchpack.Domain.DAL_Abstract
{
    /// <summary>
    /// Represents the basic operations that can be done on the database.
    /// </summary>
    public abstract class IDAL_Base
    {
        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <param name="entity">The entity being created.</param>
        /// <returns>Determines whether the operation was successful.</returns>
        public virtual bool CreateEntity(DAL_Entity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an entity in the database
        /// </summary>
        /// <param name="entity">The entity being updated.</param>
        /// <returns>Determines whether the operation was successful.</returns>
        public virtual bool UpdateEntity(DAL_Entity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an entity in the database.
        /// </summary>
        /// <param name="entity">The entity being deleted.</param>
        /// <returns>Determines whether the operation was successful</returns>
        public virtual bool DeleteEntity(DAL_Entity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all entities in the database.
        /// </summary>
        /// <returns>A list of entities found in the database.</returns>
        public virtual List<DAL_Entity> RetrieveEntities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves an entity with the specified Id in the database.
        /// </summary>
        /// <param name="entityId">The Id of the entity we are querying for.</param>
        /// <returns>An enity</returns>
        public virtual DAL_Entity RetrieveEntityById(int entityId)
        {
            throw new NotImplementedException();
        }
    }
}
