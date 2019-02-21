using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationChallenge.App_Start
{
    public interface ISetEntityDB
    {
        void ImportEntitiesFromApiAsync();
    }
}
