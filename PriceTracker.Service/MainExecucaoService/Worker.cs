namespace PriceTracker.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker executando em: {Hora}", DateTimeOffset.Now);

                try
                {
                    using (var scope = _scopeFactory.CreateScope()) // Cria um escopo para o jobExecuter
                    {
                        var jobExecuter = scope.ServiceProvider.GetRequiredService<IJobExecuter>();

                        await jobExecuter.ExecuteServiceAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ocorreu um erro executando o job.");
                }

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
