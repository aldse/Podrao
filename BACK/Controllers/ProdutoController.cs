using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace BACK.Controllers;

using DTO;
using Services;


[ApiController]
[Route("produto")]

public class ProdutoController : ControllerBase
{
    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody] ProdutoData produto,
        [FromServices] IProdutoService service)
    {
        var errors = new List<string>();
        if (produto.NomeProduto.Length < 2)
            errors.Add("O produto deve conter mais letras.");
        if (produto.Preco < 1)
            errors.Add("Valor inválido.");
        if (produto.Preco > 999)
            errors.Add("Valor inválido.");
        if (produto.DescricaoProduto == null)
            errors.Add("Deve contér uma descrição.");
        if (errors.Count > 0)
        {
            return BadRequest(errors);
        }

        await service.Create(produto);
        return Ok();
    }

    [HttpGet("todosprodutos")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> GetAllProducts([FromServices] IProdutoService service)
    {
        var produto = await service.GetAllProducts();
        return Ok(produto);
    }

    [HttpDelete]
    [EnableCors("DefaultPolicy")]
    public IActionResult DeleteProduto()
    {
        throw new NotImplementedException();
    }
}