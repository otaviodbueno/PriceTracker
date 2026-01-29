namespace PriceTracker.Data;

public class ProdutoHistoricoRepository : Repository<ProdutoHistorico>, IProdutoHistoricoRepository
{
    public ProdutoHistoricoRepository(PriceTrackerContext context) : base(context)
    {
    }
}
