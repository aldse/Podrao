using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Promocao
{
    public int Id { get; set; }

    public string NomePromocao { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public string DescricaoPromocao { get; set; } = null!;

    public decimal Preco { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();

    public virtual ICollection<Totem> Totems { get; } = new List<Totem>();
}
