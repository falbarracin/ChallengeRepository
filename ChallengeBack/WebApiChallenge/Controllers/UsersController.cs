using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ChallengeManager;
using WebApplicationChallenge.Models;
using Challenge.Domain;


namespace WebApiChallenge.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserManager _userManager;
        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("api/user/GetByFilter/{NumPage}/{NumRegisters}")]
        public IHttpActionResult GetByFilter(int NumPage, int NumRegisters)
        {
            var response = new RespnseBase.ResponseBase<List<UserResponse>>();

            var result = _userManager.GetByFilter(NumPage, NumRegisters);

            //Map user to response model
            response.Data = (from x in result.Data
                             select new UserResponse
                             {
                                 IdValue = x.IdValue,
                                 Email = x.Email,
                                 FirstName = x.FirstName,
                                 Gender = x.Gender,
                                 LastName = x.LastName,
                                 UserName = x.UserName,
                                 Uuid = x.Uuid
                             }).ToList();

            return Ok(response);
        }

        [HttpGet]
        [Route("api/user/GetById/{IdValue}")]
        public IHttpActionResult GetById(string IdValue)
        {
            var response = new RespnseBase.ResponseBase<UserResponse>();

            var result = _userManager.GetById(IdValue);

            //Map user to response model
            response.Data = new UserResponse
            {
                IdValue = result.Data.IdValue,
                Email = result.Data.Email,
                FirstName = result.Data.FirstName,
                LastName = result.Data.LastName,
                Gender = result.Data.Gender,
                UserName = result.Data.UserName,
                Uuid = result.Data.Uuid
            };

            return Ok(response);
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromBody] string IdValue)
        {
            var response = new RespnseBase.ResponseBase<bool>();

            var result = _userManager.Delete(IdValue);

            //Map user to response model
            response.Data = result.Success;
            response.Message = result.Message;

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] UserRequest request)
        {
            var response = new RespnseBase.ResponseBase<bool>();
            if (request == null)
            {
                return BadRequest("El usuario es nulo");
            }

            User user = new User
            {
                IdValue = request.IdValue,
                BirthDate = request.BirthDate,
                Email = request.Email,
                FirstName = request.FirstName,
                Gender = request.Gender,
                LastName = request.LastName,               
                UserName = request.UserName,
                Uuid = request.Uuid
            };
            var result = _userManager.Save(user);

            //Map user to response model
            response.Data = result.Success;
            response.Message = result.Message;

            return Ok(response);
        }
    }
}
