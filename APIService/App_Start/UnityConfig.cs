using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

using APIService.DataAccessRepository;
using APIService.Models;

namespace APIService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IDataAccessRepository<EmployeeInfo,int>, clsDataAccessRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}