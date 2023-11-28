using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class PedidodoCliente
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int PedidoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Pedido Pedido { get; set; } = null!;
}
