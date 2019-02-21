using Challenge.Domain;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Challenge.Repository
{
    public class UserRepository : Base.RepositoryBase<User>, IUserRepository
    {
        public UserRepository(Contexts.IDBChallengeContext context) : base(context)
        {
        }

        /// <summary>
        /// method for 
        /// </summary>
        /// <param name="NumPage"></param>
        /// <param name="NumRegisters"></param>
        /// <returns></returns>
        public List<User> GetByFilter(int NumPage, int NumRegisters)
        {
            try
            {
                List<User> result = new List<User>();
                result = Context.Users.ToList().Skip(NumPage * NumRegisters).Take(NumRegisters).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Generico.");
            }

        }

        /// <summary>
        /// method for get by idvalue
        /// </summary>
        /// <param name="IdValue"></param>
        /// <returns></returns>
        public User GetById(string IdValue)
        {
            try
            {
                User result = new User();
                result = Context.Users.Find(IdValue);
                return result;
            }
            catch (Exception ex)
            {                
                throw new Exception("Error Generico.");
            }
        }

        public bool Delete(string IdValue)
        {
            try
            {
                User result = new User();
                result = Context.Users.Find(IdValue);

                Context.Users.Remove(result);
                Context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
