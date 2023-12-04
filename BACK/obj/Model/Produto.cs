using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string NomeProduto { get; set; } = null!;

    public byte[]? Foto { get; set; }

    public decimal Preco { get; set; }

    public string DescricaoProduto { get; set; } = null!;

    public virtual ICollection<Cardapio> Cardapios { get; } = new List<Cardapio>();

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();

    public virtual ICollection<Promocao> Promocaos { get; } = new List<Promocao>();
}
