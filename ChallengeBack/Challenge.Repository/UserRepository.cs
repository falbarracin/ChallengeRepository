using Challenge.Domain;
using Challenge.Repository.Context;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Challenge.Repository
{
    public class UserRepository
    {
        DBChallengeContext Context;
        public UserRepository() //DBChallengeContext context
        {            
            //Context = context;
        }

        public static List<User> Entities { get; set; }

        /// <summary>
        /// method for get users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            if (Entities == null)
            {                
                Entities = GetEntitiesFromApi();
            }
            return Entities;
        }


        /// <summary>
        /// method for call api user
        /// </summary>
        /// <returns></returns>
        static List<User> GetEntitiesFromApi()
        {
            List<User> users = new List<User>();           

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https:/randomuser.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method                 
                HttpResponseMessage response =  client.GetAsync("api/?results=500").Result;
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.NoContent)
                {
                    users = response.Content.ReadAsAsync<List<User>>().Result;                    
                }
            }

            return users;
        }
    }
}
