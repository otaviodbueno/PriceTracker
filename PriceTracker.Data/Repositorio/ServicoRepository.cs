using Microsoft.EntityFrameworkCore;

namespace PriceTracker.Data;

public class ServicoRepository : Repository<Servico>, IServicoRepository
{
    public ServicoRepository(PriceTrackerContext priceTrackerContext) : base(priceTrackerContext)
    {
    }

    public async Task AtualizaDatasServico(Servico servico)
    {
        await Entity().Where(s => s.ID_SERVICO ==  servico.ID_SERVICO).ExecuteUpdateAsync(setters => setters
            .SetProperty(s => s.DT_ULTIMA_EXECUCAO, DateTime.Now)
            .SetProperty(s => s.DT_PROXIMA_EXECUCAO, DateTime.Now.AddMinutes(servico.NU_MINUTOS_INTERVALO))
        );
    }
}
