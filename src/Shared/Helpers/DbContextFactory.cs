
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using global::examen.scr.Shared.Context;

namespace examen.src.Modules.Shared.Helpers;

public class DbContextFactory
{
    public static AppDbContext Create()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        string? connectionString =
        Environment.GetEnvironmentVariable("MySQL_CONECTION") ?? configuration.GetConnectionString("MysqlConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("connectionString 'MysqlConnection' is not configured");
        }
        var detectedVersion = MySqlVersionResolver.DetectVersion(connectionString);
        var minversion = new Version(8, 0, 0);
        if (detectedVersion < minversion)
        {
            throw new InvalidOperationException($"MySQL version {detectedVersion} is not supported. Minimum required Version is {minversion}");
        }

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql(connectionString, new MySqlServerVersion(detectedVersion))
            .Options;
        return new AppDbContext(options);

    }

}
