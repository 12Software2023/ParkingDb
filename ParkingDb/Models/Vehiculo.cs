using System;
using System.Collections.Generic;

namespace ParkingDb.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Placa { get; set; }

    public int? Documento { get; set; }

    public string? Color { get; set; }

    public int? IdTipo { get; set; }

    public int? IdMarca { get; set; }

    public virtual Marca? IdMarcaNavigation { get; set; }

    public virtual TipoVehiculo? IdTipoNavigation { get; set; }

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();
}
