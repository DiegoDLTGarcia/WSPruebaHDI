using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WSPruebaHDI.Models
{
    public partial class Raza
    {
        public Raza()
        {
            Mascota = new HashSet<Mascota>();
        }

        public int IdRaza { get; set; }
        public int? IdEspecie { get; set; }
        public string? NombreRaza { get; set; }

        public virtual Especie? objEspecie { get; set; }
        [JsonIgnore]
        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
