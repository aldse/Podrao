using System.Threading.Tasks;

namespace BACK.Services;

using DTO;
using Model;

public interface IProdutoService
{
    Task Create(ProdutoData data);
    Task<List<Produto>> GetAllProducts();
}

