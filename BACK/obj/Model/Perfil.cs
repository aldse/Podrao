using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Perfil
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int ImagemId { get; set; }

    public virtual Imagem Imagem { get; set; } = null!;

    public virtual Cliente Usuario { get; set; } = null!;
}
