using System;
using System.Collections.Generic;

namespace Lovera.Models
{
    public partial class Pacote
    {
        public Pacote()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdPacote { get; set; }
        public string Nome { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Preco { get; set; }
        public int IdDestino { get; set; }

        public virtual Destino IdDestinoNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
