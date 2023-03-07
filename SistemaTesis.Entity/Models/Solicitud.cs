using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public int IdCliente { get; set; }

    public string? CoordDesde { get; set; }

    public string? CoordHasta { get; set; }

    public DateOnly? FechaSolicitud { get; set; }

    public DateOnly? FechaTrabajo { get; set; }

    public decimal? PagoFaltante { get; set; }

    public int IdEstado { get; set; }

    public int IdLocalidadDesde { get; set; }

    public int IdLocalidadHasta { get; set; }

    public int IdTipoRegistro { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Localidad IdLocalidadDesdeNavigation { get; set; } = null!;

    public virtual Localidad IdLocalidadHastaNavigation { get; set; } = null!;

    public virtual Tiposregistro IdTipoRegistroNavigation { get; set; } = null!;

    public virtual ICollection<Solicitudesempleados> Solicitudesempleados { get; } = new List<Solicitudesempleados>();

    public virtual ICollection<Solicitudestransportes> Solicitudestransportes { get; } = new List<Solicitudestransportes>();
}
