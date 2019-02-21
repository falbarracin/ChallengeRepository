using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Repository.Base
{
    public class ResourceHelper
    {
        private static ResourceHelper _instance;
        public static ResourceHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResourceHelper();
                }
                return _instance;
            }
        }

        public System.Resources.ResourceManager Resources { get; private set; }


        public void SetResources(System.Resources.ResourceManager value)
        {
            Resources = value;
        }
    }
}
