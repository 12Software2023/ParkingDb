using System;
using System.Collections.Generic;

namespace ParkingDb.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? IdTipoUsuario { get; set; }

    public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();
}
