using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Solicitudesempleados
{
    public int IdSe { get; set; }

    public int IdSolicitud { get; set; }

    public int IdEmpleado { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Solicitud IdSolicitudNavigation { get; set; } = null!;
}
