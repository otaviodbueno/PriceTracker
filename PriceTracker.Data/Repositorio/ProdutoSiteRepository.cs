namespace PriceTracker.Data;

public class ProdutoSiteRepository : Repository<ProdutoSite>, IProdutoSiteRepository
{
    public ProdutoSiteRepository(PriceTrackerContext context) : base(context)
    {
    }
}
