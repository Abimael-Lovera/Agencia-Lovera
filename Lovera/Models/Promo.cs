using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovera.Models
{
    [Table("Promo", Schema = "dbo")]
    public partial class Promo
    {
        
        public Promo()
        {
            Compras = new HashSet<Compra>();
        }

        [Key]
        public int IdPromo { get; set; }
        
        [Required]
        [Display(Name ="Promoção")]
        public string Nome { get; set; } = null!;

        [Required]
        [Display(Name = "Descrição")]
        public string Descripcao { get; set; } = null!;

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Destino")]
        public int IdDestino { get; set; }

        public virtual Destino IdDestinoNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
