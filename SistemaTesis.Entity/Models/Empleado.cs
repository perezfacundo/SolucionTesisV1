using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int DniEmpleado { get; set; }

    public string? Apellidos { get; set; }

    public string? Nombres { get; set; }

    public DateOnly? FechaNac { get; set; }

    public int? PorcComision { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public int IdEstado { get; set; }

    public int IdTipoRegistro { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Tiposregistro IdTipoRegistroNavigation { get; set; } = null!;

    public virtual ICollection<Solicitudesempleados> Solicitudesempleados { get; } = new List<Solicitudesempleados>();
}
