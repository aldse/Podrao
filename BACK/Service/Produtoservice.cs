namespace BACK.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using DTO;
using Model;

public class ProdutoService : IProdutoService
{
    PodraoBcContext ctx;
    public ProdutoService(PodraoBcContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task Create(ProdutoData data)
    {
        Produto produto = new Produto();
     
        produto.NomeProduto = data.NomeProduto;
        produto.Preco = data.Preco;
        produto.DescricaoProduto = data.DescricaoProduto;
        
        this.ctx.Add(produto);
        await this.ctx.SaveChangesAsync();
    }
     public async Task<List<Produto>> GetAllProducts()
    {
        return await ctx.Produtos.ToListAsync();
    }
}