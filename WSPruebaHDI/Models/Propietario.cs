using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WSPruebaHDI.Models
{
    public partial class Propietario
    {
        public Propietario()
        {
            Mascota = new HashSet<Mascota>();
        }

        public int IdPropietario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Telefono { get; set; }
        [JsonIgnore]
        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
