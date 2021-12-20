using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovera.Models
{
    [Table("Pacotes", Schema ="dbo")]
    public partial class Pacote
    {
        public Pacote()
        {
            Compras = new HashSet<Compra>();
        }

        [Key]
        public int IdPacote { get; set; }

        [Required]
        [Display(Name ="Pacote")]
        public string Nome { get; set; } = null!;

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; } = null!;

        [Display(Name = "Preço")]

        public decimal Preco { get; set; }


        [Display(Name = "Destino")]
        public int IdDestino { get; set; }

        [Display(Name ="Destinos")]
        public virtual Destino IdDestinoNavigation { get; set; } = null!;
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
