using System;
using System.Collections.Generic;

namespace SistemaTesis.Entity.Models;

public partial class Solicitudestransportes
{
    public int IdSt { get; set; }

    public int IdSolicitud { get; set; }

    public int IdTransporte { get; set; }

    public virtual Solicitud IdSolicitudNavigation { get; set; } = null!;

    public virtual Transporte IdTransporteNavigation { get; set; } = null!;
}
