namespace BACK.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using DTO;
using Model;

public class PromocaoService : IPromocaoService
{
    PodraoBnc1Context ctx;
    public PromocaoService(PodraoBnc1Context ctx)
    {
        this.ctx = ctx;
    }

    public async Task Create(PromocaoData data)
    {
        Promocao promocao = new Promocao
        {
            NomePromocao = data.NomePromocao,
            Preco = data.Preco,
            DescricaoPromocao = data.DescricaoPromocao,
            // ProdutoId = data.ProdutoId
        };

        this.ctx.Add(promocao);
        await this.ctx.SaveChangesAsync();
    }
    public async Task<List<Promocao>> GetAllPromocoes()
    {
        return await ctx.Promocaos.ToListAsync();
    }
}