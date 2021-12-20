using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lovera.Models
{
    [Table("Usuario", Schema = "dbo")]
    public partial class Usuario
    {
        public Usuario()
        {
            Compras = new HashSet<Compra>();
        }

        [Key]
        public int IdUser { get; set; }

        [Required]
        [Display(Name ="Cpf")]
        [MaxLength(11),MinLength(11)]
        public string Cpf { get; set; } = null!;

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = null!;

        [Required]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; } = null!;

        [Required]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = null!;

        [Required]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; } = null!;

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
