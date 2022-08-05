using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_anotacao
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

        public override string ToString()
        {
            return String.Format("{0} - {1}", this.Title, this.Text);
        }
    }
}
