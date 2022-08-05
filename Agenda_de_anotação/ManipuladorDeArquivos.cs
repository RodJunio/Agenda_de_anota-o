using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_anotacao
{
    public class ManipuladorDeArquivos
    {
        private static string EnderecoArquivo = AppDomain.CurrentDomain.BaseDirectory + "Nota.txt";
        public static List<Nota> LerArquivo()
        {
            List<Nota> notaList = new List<Nota>();
            if(File.Exists(@EnderecoArquivo))
            {
                using (StreamReader sr = File.OpenText(@EnderecoArquivo))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linha = sr.ReadLine();
                        string[] linhaComSplit = linha.Split(';');
                        if(linhaComSplit.Count() == 2)
                        {
                            Nota nota = new Nota();
                            nota.Title = linhaComSplit[0];
                            nota.Text = linhaComSplit[1];
                            notaList.Add(nota);
                        }
                    }
                }
            }
            return notaList;
        }

        public static void EscreverArquivo(List<Nota> NotaList)
        {

            using (StreamWriter sw = new StreamWriter(@EnderecoArquivo, false))
            {
                foreach (Nota nota in NotaList)
                {
                    string linha = String.Format("{0};{1}", nota.Title, nota.Text);
                    sw.WriteLine(linha);
                }
                sw.Flush();//para limpar
            } //já libera a memória

        }


    }
}
