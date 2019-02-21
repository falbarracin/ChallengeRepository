using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Base
{
    /// <summary>
    /// Repo Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        protected Contexts.DBChallengeContext Context;
        public RepositoryBase(Contexts.IDBChallengeContext context)
        {
            Context = (Contexts.DBChallengeContext)context;
        }

        /// <summary>
        /// method for get all
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();           
        }

        /// <summary>
        /// method save entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(T entity)
        {
            try
            {
                var saveEntities = Context.Set<T>().Add(entity);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// method save list of entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public bool Save(List<T> entities)
        {
            try
            {
                var saveEntities = Context.Set<T>().AddRange(entities);
                Context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }           
        }
    }
}
