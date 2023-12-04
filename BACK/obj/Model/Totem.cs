using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Totem
{
    public int Id { get; set; }

    public int CardapioId { get; set; }

    public int PromocaoId { get; set; }

    public virtual Cardapio Cardapio { get; set; } = null!;

    public virtual Promocao Promocao { get; set; } = null!;
}
