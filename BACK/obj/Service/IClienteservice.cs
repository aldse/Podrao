using System.Threading.Tasks;

namespace BACK.Services;

using DTO;
using Model;

public interface IClienteservice
{
    Task Create(UserDataRegister data);
    Task<Cliente> GetByLogin(string login);
}

