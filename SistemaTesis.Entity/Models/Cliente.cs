using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int DniCliente { get; set; }

    public string? Apellidos { get; set; }

    public string? Nombres { get; set; }

    public DateOnly? FechaNac { get; set; }

    public string? Telefono { get; set; }

    public string? Domicilio { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public int IdEstado { get; set; }

    public int IdLocalidad { get; set; }

    public int IdTipoRegistro { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual Localidad IdLocalidadNavigation { get; set; } = null!;

    public virtual Tiposregistro IdTipoRegistroNavigation { get; set; } = null!;

    public virtual ICollection<Solicitud> Solicitudes { get; } = new List<Solicitud>();
}
