using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Tiposregistro
{
    public int IdTipoRegistro { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();

    public virtual ICollection<Estado> Estados { get; } = new List<Estado>();

    public virtual ICollection<Localidad> Localidades { get; } = new List<Localidad>();

    public virtual ICollection<Provincia> Provincia { get; } = new List<Provincia>();

    public virtual ICollection<Solicitud> Solicitudes { get; } = new List<Solicitud>();

    public virtual ICollection<Transporte> Transportes { get; } = new List<Transporte>();
}
