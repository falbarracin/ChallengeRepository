using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationChallenge.Models
{
    public class UserRequest
    {
        public string IdValue { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Uuid { get; set; }
        public string UserName { get; set; }       
    }
}