using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_nota
{
    public class Nota
    {
        public string Title { get; set; }
       
        public string Text { get; set; }       

        public Nota(string Title = "", string Text  = "")
        {
            this.Title = Title;
            this.Text = Text;
        }
    }
}
