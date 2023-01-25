using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Usuario
{
    public long IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string Pais { get; set; } = null!;

    public sbyte Contacto { get; set; }
}
