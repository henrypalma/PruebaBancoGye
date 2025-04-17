using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductosDto
    {
        public int Id { get; set; }

        public string CodigoProducto { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public short? Estado { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}
