using PriceTracker.Data;

namespace PriceTracker.Service;

public class JobExecuter : IJobExecuter
{
    private readonly ILogger<Servico> _logger;
    private readonly IServicoRepository _servicoRepository;
    private readonly IEnumerable<IServicoExecutor> _servicosExecutor;

    public JobExecuter(ILogger<Servico> logger, IServicoRepository servicoRepository, IEnumerable<IServicoExecutor> servicosExecutor)
    {
        _logger = logger;
        _servicoRepository = servicoRepository;
        _servicosExecutor = servicosExecutor;
    }

    public async Task ExecuteServiceAsync()
    {
        var listServicosExecucao = await _servicoRepository.ListAsNoTrackingAsync(x => x.DT_PROXIMA_EXECUCAO <= DateTime.Now);

        foreach (var servico in listServicosExecucao)
        {
            try
            {
                var executorServico = _servicosExecutor.FirstOrDefault(s => s.IdServico == servico.ID_SERVICO);

                if (executorServico == null)
                {
                    _logger.LogWarning($"Serviço sem executor: {servico.ID_SERVICO}");
                    continue;
                }

                await executorServico.ExecuteAsync();

                await _servicoRepository.AtualizaDatasServico(servico);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao executar o serviço: {servico.NM_SERVICO} - {ex.Message}");
            }
        }
    }
}
