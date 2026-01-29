namespace PriceTracker.Business;

public interface IProdutoHistoricoBusiness
{
    Task ConsistirHistoricoPrecoProduto(long idProdutoSite, decimal valorAtualProduto);
}
