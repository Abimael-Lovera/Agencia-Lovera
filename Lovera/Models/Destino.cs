using System;
using System.Collections.Generic;

namespace Lovera.Models
{
    public partial class Destino
    {
        public Destino()
        {
            Pacotes = new HashSet<Pacote>();
            Promos = new HashSet<Promo>();
        }

        public int IdDestino { get; set; }
        public string Nome { get; set; } = null!;
        public string Descripcao { get; set; } = null!;

        public virtual ICollection<Pacote> Pacotes { get; set; }
        public virtual ICollection<Promo> Promos { get; set; }
    }
}
