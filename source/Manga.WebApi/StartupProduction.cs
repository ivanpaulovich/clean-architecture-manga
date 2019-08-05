using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manga.Application.Boundaries;
using Manga.Application.Repositories;
using Manga.Application.UseCases;
using Manga.Domain;
using Manga.Infrastructure.EntityFrameworkDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Manga.WebApi
{
    public sealed class StartupProduction
    {
        public StartupProduction(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            AddSwagger(services);
            AddMangaCore(services);
            AddSQLPersistence(services);
        }

        private void AddSQLPersistence(IServiceCollection services)
        {
            Console.WriteLine("SQL");


            services.AddDbContext<MangaContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API (Production)", Version = "v1" });
            });
        }

        private void AddMangaCore(IServiceCollection services)
        {
            services.AddScoped<IEntitiesFactory, DefaultEntitiesFactory>();

            services.AddScoped<Manga.WebApi.UseCases.CloseAccount.Presenter, Manga.WebApi.UseCases.CloseAccount.Presenter>();
            services.AddScoped<Manga.WebApi.UseCases.Deposit.Presenter, Manga.WebApi.UseCases.Deposit.Presenter>();
            services.AddScoped<Manga.WebApi.UseCases.GetAccountDetails.Presenter, Manga.WebApi.UseCases.GetAccountDetails.Presenter>();
            services.AddScoped<Manga.WebApi.UseCases.GetCustomerDetails.Presenter, Manga.WebApi.UseCases.GetCustomerDetails.Presenter>();
            services.AddScoped<Manga.WebApi.UseCases.Register.Presenter, Manga.WebApi.UseCases.Register.Presenter>();
            services.AddScoped<Manga.WebApi.UseCases.Withdraw.Presenter, Manga.WebApi.UseCases.Withdraw.Presenter>();

            services.AddScoped<Manga.Application.Boundaries.CloseAccount.IOutputHandler>(x => x.GetRequiredService<Manga.WebApi.UseCases.CloseAccount.Presenter>());
            services.AddScoped<Manga.Application.Boundaries.Deposit.IOutputHandler>(x => x.GetRequiredService<Manga.WebApi.UseCases.Deposit.Presenter>());
            services.AddScoped<Manga.Application.Boundaries.GetAccountDetails.IOutputHandler>(x => x.GetRequiredService<Manga.WebApi.UseCases.GetAccountDetails.Presenter>());
            services.AddScoped<Manga.Application.Boundaries.GetCustomerDetails.IOutputHandler>(x => x.GetRequiredService<Manga.WebApi.UseCases.GetCustomerDetails.Presenter>());
            services.AddScoped<Manga.Application.Boundaries.Register.IOutputHandler>(x => x.GetRequiredService<Manga.WebApi.UseCases.Register.Presenter>());
            services.AddScoped<Manga.Application.Boundaries.Withdraw.IOutputHandler>(x => x.GetRequiredService<Manga.WebApi.UseCases.Withdraw.Presenter>());

            services.AddScoped<Manga.Application.Boundaries.CloseAccount.IUseCase, Manga.Application.UseCases.CloseAccount>();
            services.AddScoped<Manga.Application.Boundaries.Deposit.IUseCase, Manga.Application.UseCases.Deposit>();
            services.AddScoped<Manga.Application.Boundaries.GetAccountDetails.IUseCase, Manga.Application.UseCases.GetAccountDetails>();
            services.AddScoped<Manga.Application.Boundaries.GetCustomerDetails.IUseCase, Manga.Application.UseCases.GetCustomerDetails>();
            services.AddScoped<Manga.Application.Boundaries.Register.IUseCase, Manga.Application.UseCases.Register>();
            services.AddScoped<Manga.Application.Boundaries.Withdraw.IUseCase, Manga.Application.UseCases.Withdraw>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            UseSwagger(app);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private void UseSwagger(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}