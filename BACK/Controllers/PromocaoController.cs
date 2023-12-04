using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace BACK.Controllers;

using DTO;
using Services;


[ApiController]
[Route("promocao")]

public class PromocaoController : ControllerBase
{
    // [HttpPost("procurar")]
    // [EnableCors("DefaultPolicy")]
    // public async Task<IActionResult> Procurar(
    //     [FromBody] ProdutoData produto,
    //     [FromServices] IProdutoService service)
    // {
    //     System.Console.WriteLine(produto.Procurar);
    //     var procurarProduto = await service
    //         .GetByProcurar(produto.Procurar);
    //     System.Console.WriteLine(procurarProduto);

    //     return Ok();
    // }

    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody] PromocaoData promocao,
        [FromServices] IPromocaoService service)
    {
        var errors = new List<string>();
        if (promocao.NomePromocao.Length < 2)
            errors.Add("O produto deve conter mais letras.");
        if(promocao.Preco < 1)
            errors.Add("Valor inválido.");
        if(promocao.Preco > 999)
            errors.Add("Valor inválido.");
        if(promocao.DescricaoPromocao == null)
            errors.Add("Deve contér uma descrição.");
        if (errors.Count > 0)
        {
            return BadRequest(errors);
        }

        await service.Create(promocao);
        return Ok();
    }

}

