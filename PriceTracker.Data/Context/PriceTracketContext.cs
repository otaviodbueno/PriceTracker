using Microsoft.EntityFrameworkCore;

namespace PriceTracker.Data;

public partial class PriceTrackerContext : DbContext
{
    public PriceTrackerContext()
    {
    }

    public PriceTrackerContext(DbContextOptions<PriceTrackerContext> options) : base(options)
    {
    }

    public virtual DbSet<Produto> Produto { get; set; }

    public virtual DbSet<ProdutoSite> ProdutoSite { get; set; }

    public virtual DbSet<ProdutoHistorico> ProdutoHistorico { get; set; }

}
