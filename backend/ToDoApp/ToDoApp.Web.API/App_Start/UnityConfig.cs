using System.Web.Http;
using ToDoApp.Data;
using ToDoApp.Models;
using Unity;
using Unity.WebApi;

namespace ToDoApp.Web.API.App_Start
{
    static public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IDataAccess,DataAccess>();
            container.RegisterType<ToDoAppDbContext>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}