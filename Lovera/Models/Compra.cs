using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovera.Models
{
    [Table("Compra", Schema ="dbo")]
    public partial class Compra
    {
        [Key]
        public int IdCompra { get; set; }

        [Required]
        [Display(Name ="Usuario")]
        public int IdUser { get; set; }

        [Display(Name = "Pacote")]
        public int IdPacote { get; set; }
        [Display(Name = "Promoção")]
        public int IdPromo { get; set; }

        public virtual Pacote IdPacoteNavigation { get; set; } = null!;
        public virtual Promo IdPromoNavigation { get; set; } = null!;
        public virtual Usuario IdUserNavigation { get; set; } = null!;
    }
}
