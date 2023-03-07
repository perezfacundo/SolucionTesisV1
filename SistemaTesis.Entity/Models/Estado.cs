using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string? Descripcion { get; set; }

    public int IdTipoRegistro { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();

    public virtual Tiposregistro IdTipoRegistroNavigation { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicitudes { get; } = new List<Solicitud>();

    public virtual ICollection<Transporte> Transportes { get; } = new List<Transporte>();
}
