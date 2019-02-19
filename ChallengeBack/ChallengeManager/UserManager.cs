using Challenge.Domain;
using Challenge.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeManager
{
    public class UserManager
    {
       
        /// <summary>
        /// method manager get users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            UserRepository _userRepository = new UserRepository();
            List<User> result = new List<User>();
            result = _userRepository.GetAll();
            return result;
        }

        /// <summary>
        /// method for get user by id
        /// </summary>
        /// <param name="IdValue"></param>
        /// <returns></returns>
        public List<User> GetById(long IdValue)
        {
            List<User> result = new List<User>();

            return result;
        }
    }
}
