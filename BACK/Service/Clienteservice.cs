using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BACK.Services;

using DTO;
using Microsoft.Identity.Client;
using Model;

public class ClienteService : IClienteservice
{
    PodraoDbContext ctx;
    ISecurityService security;
    public ClienteService(PodraoDbContext ctx, ISecurityService security)
    {
        this.ctx = ctx;
        this.security = security;
    }

    public async Task Create(UserData data)
    {
        Cliente cliente = new Cliente();
        var salt = await security.GenerateSalt();

        cliente.Nome = data.Login;
        cliente.Senha = await security.HashPassword(
            data.Password, salt
        );
        cliente.Salt = salt;

        this.ctx.Add(cliente);
        await this.ctx.SaveChangesAsync();
    }
    public async Task<Cliente> GetByLogin(string login)
    {
        var query =
            from u in ctx.Clientes
            where u.Nome == login
            select u;
        
        return await query.FirstOrDefaultAsync();
    }
}