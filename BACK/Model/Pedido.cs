using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Pedido
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int PromocaoId { get; set; }

    public int ProdutoId { get; set; }

    public DateTime? EntregadoPedido { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<PedidodoCliente> PedidodoClientes { get; } = new List<PedidodoCliente>();

    public virtual Produto Produto { get; set; } = null!;

    public virtual Promocao Promocao { get; set; } = null!;
}
