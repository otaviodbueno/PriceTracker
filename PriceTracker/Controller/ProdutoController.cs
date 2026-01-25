using Microsoft.AspNetCore.Mvc;
using PriceTracker.Data;

namespace PriceTracker.Controller;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Teste()
    {
        var produto = await _produtoRepository.ListAsNoTrackingAsync();
        return Ok(produto);
    }

}
