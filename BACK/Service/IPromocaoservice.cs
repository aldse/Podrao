using System.Threading.Tasks;

namespace BACK.Services;

using DTO;
using Model;

public interface IPromocaoService
{
    Task Create(PromocaoData data);
    // Task<Produto> GetByProcurar(string procurar);
}

