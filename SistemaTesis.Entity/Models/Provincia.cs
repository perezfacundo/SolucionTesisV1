using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Provincia
{
    public int IdProvincia { get; set; }

    public string? Nombre { get; set; }

    public int IdTipoRegistro { get; set; }

    public virtual Tiposregistro IdTipoRegistroNavigation { get; set; } = null!;

    public virtual ICollection<Localidad> Localidades { get; } = new List<Localidad>();
}
