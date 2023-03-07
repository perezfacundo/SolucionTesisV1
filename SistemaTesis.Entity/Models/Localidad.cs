using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Localidad
{
    public int IdLocalidad { get; set; }

    public string? Nombre { get; set; }

    public int IdProvincia { get; set; }

    public int IdTipoRegistro { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual Tiposregistro IdTipoRegistroNavigation { get; set; } = null!;

    public virtual ICollection<Solicitud> SolicitudeIdLocalidadDesdeNavigations { get; } = new List<Solicitud>();

    public virtual ICollection<Solicitud> SolicitudeIdLocalidadHastaNavigations { get; } = new List<Solicitud>();
}
