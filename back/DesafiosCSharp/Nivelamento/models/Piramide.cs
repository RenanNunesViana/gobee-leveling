using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivelamento.models
{
    internal class Piramide(int n)
    {
        public int N {  get; set; } = n >= 1 ? n : throw new Exception("n must be greater or iqual than 1");

        public string Desenha()
        {   
            string piramide = "";
            for (int i = 1; i <= N; i++)
            {
                if(i < n){
                    piramide += $"{Piramide.AddSpace(n - i)}{generateRow(i)}\n";
                }
                else { piramide += $"{Piramide.AddSpace(n - i)}{generateRow(i)}"; }
            }
                
                return piramide;
        }

        private static string AddSpace(int howManyTimes)
        {
            return string.Concat(Enumerable.Repeat(' ', howManyTimes));
        }

        private string generateRow(int n) {
            if (n == 0)
            {
                return string.Empty;
            }
            else
            {
                string row = string.Empty ;
                for (int i = 1; i <= n; i++)
                {
                    row += i;
                }

                for (int i = n - 1; i >= 1; i--)
                {
                    row += i;
                }
                return row;
            }
        }
    }
}
