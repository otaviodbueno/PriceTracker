namespace PriceTracker.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IJobExecuter _jobExecuter;

        public Worker(ILogger<Worker> logger, IJobExecuter jobExecuter)
        {
            _logger = logger;
            _jobExecuter = jobExecuter;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker executando em: {Hora}", DateTimeOffset.Now);

                try
                {
                    await _jobExecuter.ExecuteServiceAsync();
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
