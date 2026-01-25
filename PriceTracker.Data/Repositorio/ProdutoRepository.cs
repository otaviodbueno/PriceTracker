namespace PriceTracker.Data;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(PriceTrackerContext context) : base(context)
    {
    }
}
