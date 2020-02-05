// <copyright file="ContextFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.EntityFrameworkDataAccess
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public sealed class ContextFactory : IDesignTimeDbContextFactory<MangaContext>
    {
        public MangaContext CreateDbContext(string[] args)
        {
            string connectionString = ReadDefaultConnectionStringFromAppSettings();

            var builder = new DbContextOptionsBuilder<MangaContext>();
            builder.UseSqlServer(connectionString);
            return new MangaContext(builder.Options);
        }

        private string ReadDefaultConnectionStringFromAppSettings()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Production.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
