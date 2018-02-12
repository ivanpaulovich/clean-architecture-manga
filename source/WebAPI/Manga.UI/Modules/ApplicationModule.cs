namespace Manga.UI.Modules
{
    using Autofac;

    public class ApplicationModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in Manga.Application
            //
            builder.RegisterAssemblyTypes(typeof(Application.UseCases.Register.RegisterInteractor).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
