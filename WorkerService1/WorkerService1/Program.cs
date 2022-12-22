using WorkerService1;
using WorkerService1.model;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Princess>();
        services.AddScoped<Hall>();
        services.AddScoped<Friend>();
        services.AddScoped<ContentGenerator>();
    })
    .Build();

await host.RunAsync();