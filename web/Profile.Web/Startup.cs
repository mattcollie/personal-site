using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;
using Profile.Access.Repository.Interfaces;
using Profile.Access.Repository.Repositories;
using Profile.Access.Service.Interfaces;
using Profile.Access.Service.Services;
using Profile.Data.Access.Context;
using Profile.Web;
using Profile.Web.Helpers;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace Profile.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<FixContentTypeHeader>();

            ContainerBuilder builder = new ContainerBuilder();
            Assembly assembly = Assembly.GetExecutingAssembly();

            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();
            builder.RegisterControllers(assembly);
            builder.RegisterApiControllers(assembly);

            RegisterServices(builder);

            IContainer container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Map the help path and force next to be invoked
            app.Map("/Help", appbuilder => appbuilder.UseHandlerAsync((request, response, next) => next()));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            app.UseAutofacWebApi(GlobalConfiguration.Configuration);
            app.UseWebApi(GlobalConfiguration.Configuration);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ProfileContext>().InstancePerRequest();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ContactService>().As<IContactService>().InstancePerLifetimeScope();
        }
    }
}