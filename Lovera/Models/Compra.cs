using System;
using System.Collections.Generic;

namespace Lovera.Models
{
    public partial class Compra
    {
        public int IdCompra { get; set; }
        public int IdUser { get; set; }
        public int IdPacote { get; set; }
        public int IdPromo { get; set; }

        public virtual Pacote IdPacoteNavigation { get; set; } = null!;
        public virtual Promo IdPromoNavigation { get; set; } = null!;
        public virtual Usuario IdUserNavigation { get; set; } = null!;
    }
}
