
namespace ExtensaoLista
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Cliente(string nome, string cpf)
        {

            if (!ValidarCPF(cpf))
            {
                throw new ArgumentException("CPF inválido.");
            }

            Nome = nome;
            CPF = cpf;


        }

        public bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
            {
                return false;
            }

            var cpfNumeros = cpf.Select(c => int.Parse(c.ToString())).ToArray();

            return Verifica10e11digitos(0, cpfNumeros) && Verifica10e11digitos(1, cpfNumeros);
        }

        // funcao auxiliar para a verificacao do cpf. Verifica o decimo e decimo primeiro digito
        private bool Verifica10e11digitos(int modificador, int[] arr) // 0 para o decimo e 1 para o 11º
        {
            int soma = 0;
            for (int i = 0; i < 9 + modificador; i++)
            {
                soma += arr[i] * (10 + modificador - i);
            }
            int resto = soma % 11;
            int digitoVerificador = resto < 2 ? 0 : 11 - resto;

            if (arr[9 + modificador] != digitoVerificador)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   CPF == cliente.CPF;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CPF);
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nCPF: {CPF}";
        }
    }
}
