using System;
using System.Collections.Generic;

namespace Infrastructure.tmp;

public partial class UsuarioVendedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string DocumentoIdentidad { get; set; } = null!;

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasenia { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
