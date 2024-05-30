using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armstrong
{
    public static class ExtensaoInteiros
    {
        public static bool IsArmstrong(this int n)
        {
            string numeroString = n.ToString();
            int digitosQuantidade = numeroString.Length;

            int sum = numeroString.Select(digit => (int)Math.Pow(char.GetNumericValue(digit), digitosQuantidade)).Sum();

            return sum == n;
        }
    }
}
