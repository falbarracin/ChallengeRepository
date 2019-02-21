using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge.Domain;

namespace Challenge.Repository
{
    public interface IUserRepository: Base.IRepositoryBase<User>
    {
        User GetById(string IdValue);
        List<User> GetByFilter(int NumPage, int NumRegisters);
        bool Delete(string IdValue);
    }
}
