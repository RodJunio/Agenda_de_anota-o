using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_nota
{
    public class Nota
    {
        public string Nome { get; set; }
        public string FoNumber { get; set; }
        public string Email { get; set; }
        public string desc { get; set; }

        public Nota(string nome, string fone, string email, string nota )
        {
            this.Nome = nome;
            this.FoNumber = fone;
            this.Email = email;
            this.desc = nota;
        }
    }
}
