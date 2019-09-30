using Demo.Controllers;
using Demo.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Demo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
       
            container.RegisterType<IUserRepository, UserService>();
            container.RegisterType<IDepartmentRepository, DepartmentService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}