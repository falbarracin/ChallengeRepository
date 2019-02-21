using System.Web.Http;
using System.Web.Http.Cors;
using ChallengeManager;
using Unity;

namespace WebApiChallenge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            UnityContainer container = new UnityContainer();

            //User 
            container.RegisterType<Challenge.Repository.Contexts.IDBChallengeContext, Challenge.Repository.Contexts.DBChallengeContext>();
            container.RegisterType<IUserManager, UserManager>(new Unity.Lifetime.TransientLifetimeManager());
            container.RegisterType<Challenge.Repository.IUserRepository, Challenge.Repository.UserRepository>(new Unity.Lifetime.TransientLifetimeManager());
            container.RegisterType<WebApplicationChallenge.App_Start.ISetEntityDB, WebApplicationChallenge.App_Start.SetEntityDB>(new Unity.Lifetime.TransientLifetimeManager());
            config.DependencyResolver = new WebApplicationChallenge.App_Start.UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Call httpclient
            WebApplicationChallenge.App_Start.ISetEntityDB exporter = container.Resolve<WebApplicationChallenge.App_Start.ISetEntityDB>();
            exporter.ImportEntitiesFromApiAsync();

            //Resouerces Message
            Challenge.Managers.Helpers.ResourceHelper.Instance.SetResources(new System.Resources.ResourceManager("WebApplicationChallenge.Resources",
                System.Reflection.Assembly.GetExecutingAssembly()));
           
        }
    }
}
