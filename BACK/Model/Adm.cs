using System;
using System.Collections.Generic;

namespace BACK.Model;

public partial class Adm
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;
}
