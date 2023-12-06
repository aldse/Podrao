using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateTime? TerminodoPedido { get; set; }

    public virtual ICollection<PedidodoCliente> PedidodoClientes { get; } = new List<PedidodoCliente>();

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
