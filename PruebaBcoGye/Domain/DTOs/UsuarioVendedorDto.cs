﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UsuarioVendedorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public short Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
