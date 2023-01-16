using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrincessChoicer.common.model;
using PrincessChoicer.common.model.impl;

namespace PrincessChoicer.lab2;

public class Lab2Executor
{
    // public static void Main(string[] args)
    // {
    //     CreateHostBuilder(args).Build().Run();
    // }

    static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<HostService>();
                services.AddScoped<IPrincess, PrincessImpl>();
                services.AddScoped<IHall, HallImpl>();
                services.AddScoped<IFriend, FriendImpl>();
                services.AddScoped<IContentGenerator, ContentGeneratorImpl>();
            });
    }
}