using HtmlAgilityPack;
using PriceTracker.Business;
using PriceTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceTracker.Service;

public class KabumSearchItemPriceService : IServicoExecutor
{
    public int IdServico => 1;

    private ISiteRepository _siteRepository;
    private IProdutoSiteRepository _produtoSiteRepository;
    private IProdutoHistoricoBusiness _produtoHistoricoBusiness;

    public KabumSearchItemPriceService(IProdutoSiteRepository produtoSiteRepository, IProdutoHistoricoBusiness produtoHistoricoBusiness, ISiteRepository siteRepository)
    {
        _produtoSiteRepository = produtoSiteRepository;
        _produtoHistoricoBusiness = produtoHistoricoBusiness;
        _siteRepository = siteRepository;
    }

    private static HttpClient _clientRequest = CreateHttpClient();

    public async Task ExecuteAsync()
    {
        var listProdutosToSearch = await _produtoSiteRepository.ListAsNoTrackingAsync(x => x.ID_SITE == 4);

        foreach(var produto in listProdutosToSearch)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, produto.DS_URL_PRODUTO);
            var response = await _clientRequest.SendAsync(request);

            var html = await response.Content.ReadAsStringAsync();

            var precoProduto = BuscaPrecoFinalProdutoFromHtml(html, await GetXPathPrecoProduto(produto.ID_SITE));

            await _produtoHistoricoBusiness.ConsistirHistoricoPrecoProduto(produto.ID_PRODUTO_SITE, precoProduto);
        }
    }

    private async Task<string> GetXPathPrecoProduto(long idSite)
    {
        var site = await _siteRepository.GetByIdAsync(idSite);
        return site!.DS_XPATH_PRECO;
    }

    private decimal BuscaPrecoFinalProdutoFromHtml(string html, string xPath)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var precoNode = doc.DocumentNode.SelectSingleNode(xPath);

        return ExtrairNumeroPrecoHtml(precoNode.InnerText);
    }

    private static decimal ExtrairNumeroPrecoHtml(string tagPrecoBruto)
    {
        var precoLimpo = tagPrecoBruto.Where(char.IsDigit).ToArray();

        var precoLimpoNumerico = decimal.Parse(precoLimpo);

        if (tagPrecoBruto.Contains(',')) precoLimpoNumerico /= 100;

        return precoLimpoNumerico;
    }
    private static HttpClient CreateHttpClient()
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip
                                    | DecompressionMethods.Deflate
                                    | DecompressionMethods.Brotli
        };

        var client = new HttpClient(handler);

        return client;
    }
}
