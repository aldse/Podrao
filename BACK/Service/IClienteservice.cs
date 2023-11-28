using System.Threading.Tasks;

namespace BACK.Services;

using DTO;
using Model;

public interface IClienteservice
{
    Task Create(UserData data);
    Task<Cliente> GetByLogin(string login);
}