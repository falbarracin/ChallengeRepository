using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Base
{
    /// <summary>
    /// Interface Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        List<T> GetAll();
        bool Save(T entity);
        bool Save(List<T> entities);
    }
}
