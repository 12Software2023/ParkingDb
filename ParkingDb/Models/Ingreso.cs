using System;
using System.Collections.Generic;

namespace ParkingDb.Models;

public partial class Ingreso
{
    public int IdIngreso { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public TimeSpan? HoraIngreso { get; set; }

    public DateTime? FechaSalida { get; set; }

    public TimeSpan? HoraSalida { get; set; }

    public int? IdVehiculo { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Vehiculo? IdVehiculoNavigation { get; set; }
}
