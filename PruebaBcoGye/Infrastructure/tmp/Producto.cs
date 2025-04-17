using System;
using System.Collections.Generic;

namespace Infrastructure.tmp;

public partial class Producto
{
    public int Id { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
