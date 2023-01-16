using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrincessChoicer.lab2;
using PrincessChoicer.lab4.service;

namespace PrincessChoicer.lab4;

public class HostDbService : BackgroundService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ILogger<HostService> _logger;
    private readonly ISearchSimulationService _searchProcessSimulationService;
    private readonly IConfiguration _configuration;

    private readonly CallType _callType;
    private readonly int _triesNumber;

    public HostDbService(IHostApplicationLifetime hostApplicationLifetime, ILogger<HostService> logger,
        ISearchSimulationService searchProcessSimulationService, IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _logger = logger;
        _searchProcessSimulationService = searchProcessSimulationService;
        _configuration = configuration;

        _callType = _configuration.GetValue<CallType>("SearchParams:CallType");
        _triesNumber = _configuration.GetValue<int>("SearchParams:SearchTries");
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start searching challengers");
        await base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stop searching challengers");
        await base.StopAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var task = _callType switch
        {
            CallType.Update => SearchMultipleTimes(),
            CallType.Recall => Recall(),
            CallType.Avg => PrintAverage(),
            _ => InvalidUsingTypeLog()
        };

        return Task.CompletedTask;
    }

    private Task InvalidUsingTypeLog()
    {
        _logger.LogInformation("Given Invalid Using Type!");
        return Task.CompletedTask;
    }

    private Task Recall()
    {
        var searches = Environment.GetCommandLineArgs().Skip(1);

        foreach (var search in searches)
        {
            _logger.LogInformation($"Recalling search: {search}");
            var searchResult = _searchProcessSimulationService.RerunSearchTryByName(search, true);
            _logger.LogInformation($"Search result: {searchResult}");
        }

        _logger.LogInformation("Recalling searches done");
        _hostApplicationLifetime.StopApplication();

        return Task.CompletedTask;
    }

    private Task SearchMultipleTimes()
    {
        _logger.LogInformation("Searching process started");
        _searchProcessSimulationService.SimulateSearch(_triesNumber);
        _logger.LogInformation("Searching process ended");
        _hostApplicationLifetime.StopApplication();

        return Task.CompletedTask;
    }

    private Task PrintAverage()
    {
        _searchProcessSimulationService.GetAverageSearchResultValue(true);
        _hostApplicationLifetime.StopApplication();

        return Task.CompletedTask;
    }
}
