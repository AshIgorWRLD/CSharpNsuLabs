using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrincessChoicer.common.model;
using PrincessChoicer.common.model.impl;
using PrincessChoicer.lab4.db.conf;
using PrincessChoicer.lab4.repository;
using PrincessChoicer.lab4.repository.Impl;
using PrincessChoicer.lab4.service;
using PrincessChoicer.lab4.service.Impl;

namespace PrincessChoicer.lab4;

public class Lab4Executor
{
    private const string ConfigAppSettingsPath = "resources/application-properties.json";

    public static void Main(string[] args)
    {
        CreateConfiguration();
        CreateHostBuilderFomDbInit(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilderFomDbInit(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) => ConfigureServices(services))
            .ConfigureHostConfiguration(confHost => ConfigureHostConfiguration(confHost, args));
    }

    private static IConfiguration CreateConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile(ConfigAppSettingsPath)
            .Build();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddHostedService<HostDbService>();
        services.AddScoped<IPrincess, PrincessImpl>();
        services.AddScoped<IHall, HallImpl>();
        services.AddScoped<IFriend, FriendImpl>();
        services.AddScoped<IContentGenerator, ContentGeneratorImpl>();
        services.AddScoped<ISearchTryRepo, SearchTryRepoImpl>();
        services.AddScoped<ISearchTryService, SearchTryServiceImpl>();
        services.AddScoped<ISearchSimulationService, SearchSimulationServiceImpl>();
        services.AddDbContextFactory<EnvironmentContext>(options =>
            options.UseNpgsql("name=ConnectionStrings:EnvironmentDatabase"));
    }

    private static void ConfigureHostConfiguration(IConfigurationBuilder builder, string[] args)
    {
        builder.AddJsonFile(ConfigAppSettingsPath);
    }
}