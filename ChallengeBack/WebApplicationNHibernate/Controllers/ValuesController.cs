using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNHibernate.Data;

namespace WebApplicationNHibernate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly INHibernateHelper _nHibernateHelper;

        public ValuesController(INHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var data = new List<string>();

            using (var session = _nHibernateHelper.OpenSession())
            {
                foreach (var blog in session.Query<Blog>().ToList())
                {
                    data.Add($"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}");
                }
            }

            return data;
        }
    }
}
