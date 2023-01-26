using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Actividad
{
    public int IdActividad { get; set; }

    public DateTime? CreateDate { get; set; }

    public long IdUsuario { get; set; }

    public string descripcion { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
