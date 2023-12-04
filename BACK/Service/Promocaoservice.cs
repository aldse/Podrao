namespace BACK.Services;

using DTO;
using Model;

public class PromocaoService : IPromocaoService
{
    PodraoBcContext ctx;
    public PromocaoService(PodraoBcContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task Create(PromocaoData data)
    {
        Promocao promocao = new Promocao();
     
        promocao.NomePromocao = data.NomePromocao;
        promocao.Preco = data.Preco;
        promocao.DescricaoPromocao = data.DescricaoPromocao;
        
        this.ctx.Add(promocao);
        await this.ctx.SaveChangesAsync();
    }
    // public async Task<Produto> GetByProcurar(string procurar)
    // {
    //     var query =
    //         from u in ctx.Produtos
    //         where u.NomeProduto == procurar
    //         select u;
        
    //     return await query.FirstOrDefaultAsync();
    // }
}