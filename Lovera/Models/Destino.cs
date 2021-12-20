using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovera.Models
{
    [Table("Destinos", Schema = "dbo")]
    public partial class Destino
    {
        public Destino()
        {
            Pacotes = new HashSet<Pacote>();
            Promos = new HashSet<Promo>();
        }

        [Key]
        public int IdDestino { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Nome Destino")]
        public string Nome { get; set; } = null!;

        [Required]
        [Display(Name = "Descrição")]
        public string Descripcao { get; set; } = null!;

        public virtual ICollection<Pacote> Pacotes { get; set; }
        public virtual ICollection<Promo> Promos { get; set; }
    }
}
