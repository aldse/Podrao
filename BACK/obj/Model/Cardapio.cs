using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Cardapio
{
    public int Id { get; set; }

    public int ProdutoId { get; set; }

    public virtual Produto Produto { get; set; } = null!;

    public virtual ICollection<Totem> Totems { get; } = new List<Totem>();
}
