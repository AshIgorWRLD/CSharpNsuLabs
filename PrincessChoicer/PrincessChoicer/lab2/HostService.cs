using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrincessChoicer.common.model;
using PrincessChoicer.common.utils;

namespace PrincessChoicer.lab2;

public class HostService : BackgroundService
{
    private readonly IHall _hall;
    private readonly IPrincess _princess;
    private readonly IContentGenerator _contentGenerator;

    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly ILogger<HostService> _logger;

    private const int WaitingTime = 1000;

    public HostService(IHall hall, IPrincess princess,
        IContentGenerator contendersFactory, ILogger<HostService> logger,
        IHostApplicationLifetime hostApplicationLifetime)
    {
        _hall = hall;
        _princess = princess;
        _contentGenerator = contendersFactory;

        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;
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

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await EngagementProcess();
    }

    private async Task EngagementProcess()
    {
        _logger.LogInformation("Searching process started");
        InitHall();
        var answer = _princess.TellWhoIsHusband();
        Printer.PrintResultToFile(answer);
        await Task.Delay(WaitingTime);
        _logger.LogInformation("Searching process ended");

        _hostApplicationLifetime.StopApplication();
    }
    
    private void InitHall()
    {
        _hall.SetChallengerList(_contentGenerator.GenerateChallengerList());
    }
}