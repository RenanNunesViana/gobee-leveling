using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontologicManagment.views
{
    public abstract class MenuTemplate
    {
        public String Titulo {  get; set; }
        public List<String> ListaDeOpcoes{ get; set; }

        public MenuTemplate(String titulo, params String[] list) { 
            Titulo = titulo;
            ListaDeOpcoes = new List<string>(list);
        }

        public int InitMenu()
        {
            Console.WriteLine(Titulo);

            for (int i = 1; i <= ListaDeOpcoes.Count; i++)
            {
                Console.WriteLine($"{i}-{ListaDeOpcoes[i - 1]}");
            }

            var opcao = Console.ReadKey();
            Console.WriteLine("\n");

            if (char.IsDigit(opcao.KeyChar))
            {
                return int.Parse(opcao.KeyChar.ToString());
            }
            return -1;
        }

    }
}
