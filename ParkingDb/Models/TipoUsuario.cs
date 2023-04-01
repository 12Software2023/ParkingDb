using System;
using System.Collections.Generic;

namespace ParkingDb.Models;

public partial class TipoUsuario
{
    public int IdTipoUsuario { get; set; }

    public string? NombreTipoUsuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
