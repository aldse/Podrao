using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BACK.Services;

using DTO;
using Microsoft.Identity.Client;
using Model;

public class ClienteService : IClienteservice
{
    PodraoBnc1Context ctx;
    ISecurityService security;
    public ClienteService(PodraoBnc1Context ctx, ISecurityService security)
    {
        this.ctx = ctx;
        this.security = security;
    }

    public async Task Create(UserDataRegister data)
    {
        Cliente cliente = new Cliente();
        var salt = await security.GenerateSalt();

        cliente.Nome = data.Nome;
        cliente.Cpf = data.Login;
        cliente.Senha = await security.HashPassword(
            data.Password, salt
        );
        cliente.Salt = salt;
        cliente.Email = data.Email;
        cliente.Genero = data.Genero;
        
        this.ctx.Add(cliente);
        await this.ctx.SaveChangesAsync();
    }
    public async Task<Cliente> GetByLogin(string login)
    {
        var query =
            from u in ctx.Clientes
            where u.Cpf == login
            select u;
        
        return await query.FirstOrDefaultAsync();
    }
}