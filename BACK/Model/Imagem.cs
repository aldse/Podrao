using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Imagem
{
    public int Id { get; set; }

    public byte[] Foto { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Perfil> Perfils { get; } = new List<Perfil>();
}
