namespace PriceTracker.Data;

public class SiteRepository : Repository<Site>, ISiteRepository
{
    public SiteRepository(PriceTrackerContext context) : base(context)
    {
    }
}
