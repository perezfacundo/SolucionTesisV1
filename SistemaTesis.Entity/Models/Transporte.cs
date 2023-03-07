using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Transporte
{
    public int IdTransporte { get; set; }

    public string? Patente { get; set; }

    public string? Marca { get; set; }

    public sbyte? Modelo { get; set; }

    public string? Nombre { get; set; }

    public int? Capacidad { get; set; }

    public int IdEstado { get; set; }

    public int IdTipoRegistro { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Tiposregistro IdTipoRegistroNavigation { get; set; } = null!;

    public virtual ICollection<Solicitudestransportes> Solicitudestransportes { get; } = new List<Solicitudestransportes>();
}
