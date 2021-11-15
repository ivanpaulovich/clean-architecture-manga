// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer.Modules.Common;
using IdentityServer.Quickstart;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer;

using Modules.Common;
using Quickstart;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        Environment = environment;
        Configuration = configuration;
    }

    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
            .AddTestUsers(TestUsers.Users);

        // in-memory, code config
        builder.AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryApiResources(Config.GetApis())
            .AddInMemoryClients(Config.GetClients(Configuration));

        // not recommended for production - you need to store your key material somewhere secure
        builder.AddDeveloperSigningCredential();

        services.AddAuthentication()
            .AddGoogle(options =>
            {
                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to http://localhost:5000/signin-google
                options.ClientId = "556852823610-st4qd2e8v7eu3unu6copt35dse8l34c7.apps.googleusercontent.com";
                options.ClientSecret = "WIAHI8YIT-Rg7ywSQnmYZZir";
            });

        services
            .AddCustomCors()
            .AddProxy()
            .AddCustomDataProtection();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseProxy(Configuration);
        app.UseCustomCors();

        app.UseStaticFiles();

        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
    }
}
