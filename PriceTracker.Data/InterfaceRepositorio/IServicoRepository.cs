namespace PriceTracker.Data;

public interface IServicoRepository :  IRepository<Servico>
{
    Task AtualizaDatasServico(Servico servico);
}
