namespace Manga.Infrastructure.Modules
{
    using Autofac;
    using System;
    using System.Reflection;

    public class WebApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Manga.WebApi
            //

            Type startup = Type.GetType("Manga.WebApi.Startup, Manga.WebApi");

            builder.RegisterAssemblyTypes(startup.Assembly)
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
