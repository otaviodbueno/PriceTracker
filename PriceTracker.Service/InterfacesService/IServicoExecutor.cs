namespace PriceTracker.Service;

public interface IServicoExecutor
{
    public int IdServico { get; }
    Task ExecuteAsync();
}
