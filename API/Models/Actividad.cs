using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Actividad
{
    public int IdActividad { get; set; }

    public DateTime? CreateDate { get; set; }

    public long IdUsuario { get; set; }

    public string Actividad1 { get; set; } = null!;
}
