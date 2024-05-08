using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WSPruebaHDI.Models
{
    public partial class Especie
    {
        public Especie()
        {
            Razas = new HashSet<Raza>();
        }

        public int IdEspecie { get; set; }
        public string? NombreEspecie { get; set; }
        [JsonIgnore]
        public virtual ICollection<Raza> Razas { get; set; }
    }
}
