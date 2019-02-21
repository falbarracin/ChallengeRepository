using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Challenge.Domain;
using ChallengeManager;

namespace WebApplicationChallenge.App_Start
{
    public class SetEntityDB : ISetEntityDB
    {
       IUserManager _userManager;

        public SetEntityDB(IUserManager userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// method for call api user
        /// </summary>
        /// <returns></returns>
        public async void ImportEntitiesFromApiAsync()
        {
            List<User> users = new List<User>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https:/randomuser.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method                 
                HttpResponseMessage response = client.GetAsync("api/?results=500").Result;
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.NoContent)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(json);
                }
            }

            _userManager.Save(users);
        }
    }
}