using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain;

namespace ChallengeManager
{
    /// <summary>
    /// interface for user manager
    /// </summary>
    public interface IUserManager
    {
        DataExecutionResult<List<User>> GetByFilter(int NumPage, int NumRegisters);
        DataExecutionResult<User> GetById(string IdValue);
        ExecutionResult Save(User user);
        ExecutionResult Save(List<User> users);
        ExecutionResult Delete(string IdValue);

    }
}
