using System;
using System.Collections.Generic;

namespace Lovera.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdUser { get; set; }
        public string Cpf { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Cidade { get; set; } = null!;

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
