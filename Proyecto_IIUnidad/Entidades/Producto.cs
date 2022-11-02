using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }

        public DateTime FechaCreacion { get; set; }
        public decimal Precio { get; set; }

        public byte [] Imagen { get; set; }

    }
}
