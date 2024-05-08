using System;
using System.Collections.Generic;

namespace WSPruebaHDI.Models
{
    public partial class Mascota
    {
        public int IdMascota { get; set; }
        public int? IdPropietario { get; set; }
        public string? Nombre { get; set; }
        public int? IdRaza { get; set; }
        public int? Edad { get; set; }

        public virtual Propietario? objPropietario { get; set; }
        public virtual Raza? objRaza { get; set; }
    }
}
