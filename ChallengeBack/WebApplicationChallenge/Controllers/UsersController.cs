using ChallengeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationChallenge.Models;

namespace WebApplicationChallenge.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/GetUsers")]
        public List<UserResponse> GetAll()
        {
            List<UserResponse> response = new List<UserResponse>();
            UserManager _userManager = new UserManager();
            var result = _userManager.GetAll();
            //Map user to response model
            foreach(var item in result)
            {
                
            }
            return response;
        }
    }
}
