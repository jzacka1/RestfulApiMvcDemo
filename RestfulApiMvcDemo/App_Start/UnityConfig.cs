using System.Web.Mvc;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using RestfulApi;
using RestfulApi.GitHubService;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using Unity;
using Unity.Mvc5;

namespace RestfulApiMvcDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICacheService, InMemoryCache>();
            
            //JSonSerializer must be from the RestfulAPI class project
            container.RegisterType<IDeserializer, RestfulApi.JsonSerializer >();
            container.RegisterType<IErrorLogger, ErrorLogger>();

            container.RegisterType<IGitHubAPI, GitHubAPI>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}