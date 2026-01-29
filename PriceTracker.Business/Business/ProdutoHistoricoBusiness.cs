using PriceTracker.Data;
using System.Threading.Tasks;

namespace PriceTracker.Business;

public class ProdutoHistoricoBusiness : IProdutoHistoricoBusiness
{
    private IProdutoHistoricoRepository _produtoHistoricoRepository;

    public ProdutoHistoricoBusiness(IProdutoHistoricoRepository produtoHistoricoRepository)
    {
        _produtoHistoricoRepository = produtoHistoricoRepository;
    }

    public async Task ConsistirHistoricoPrecoProduto(long idProdutoSite, decimal valorAtualProduto)
    {
        var historico = new ProdutoHistorico
        {
            ID_PRODUTO_SITE = idProdutoSite, 
            VL_PRODUTO = valorAtualProduto,
            DT_PROCURA = DateTime.Now
        };

        await _produtoHistoricoRepository.AddAsync(historico);

        await _produtoHistoricoRepository.SaveChangesAsync();
    }
}
