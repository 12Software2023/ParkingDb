using System;
using System.Collections.Generic;

namespace ParkingDb.Models;

public partial class TipoVehiculo
{
    public int IdTipo { get; set; }

    public string? NombreTipo { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; } = new List<Vehiculo>();
}
