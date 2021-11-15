// <copyright file="ContextFactory.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess;

using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

/// <summary>
///     ContextFactory.
/// </summary>
public sealed class ContextFactory : IDesignTimeDbContextFactory<MangaContext>
{
    /// <summary>
    ///     Instantiate a MangaContext.
    /// </summary>
    /// <param name="args">Command line args.</param>
    /// <returns>Manga Context.</returns>
    public MangaContext CreateDbContext(string[] args)
    {
        string connectionString = ReadDefaultConnectionStringFromAppSettings();

        DbContextOptionsBuilder<MangaContext> builder = new DbContextOptionsBuilder<MangaContext>();
        Console.WriteLine(connectionString);
        builder.UseSqlServer(connectionString);
        builder.EnableSensitiveDataLogging();
        return new MangaContext(builder.Options);
    }

    private static string ReadDefaultConnectionStringFromAppSettings()
    {
        string? envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile($"appsettings.{envName}.json", false)
            .AddEnvironmentVariables()
            .Build();

        string connectionString = configuration.GetValue<string>("PersistenceModule:DefaultConnection");
        return connectionString;
    }
}
