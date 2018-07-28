namespace Manga.MvcApp
{
    using Autofac;

    public class Module : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Manga.MvcApp
            //
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
