using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoDados
{
    internal static class ValidacaoExtensao
    {
        public static string LerNome(this Cliente cliente)
        {
            while (true)
            {
                Console.Write("Digite o nome (pelo menos 5 caracteres): ");
                string? nome = Console.ReadLine();
                if (nome.Length >= 5)
                    return nome;
                Console.WriteLine("Erro: Nome deve ter pelo menos 5 caracteres.");
            }
        }

        public static long LerCPF(this Cliente cliente)
        {
            while (true)
            {
                Console.Write("Digite o CPF (11 dígitos): ");
                string? cpfInput = Console.ReadLine();
                if (cpfInput.Length == 11 && long.TryParse(cpfInput, out long cpf))
                    return cpf;
                Console.WriteLine("Erro: CPF deve ter exatamente 11 dígitos numéricos.");
            }
        }

        public static DateTime LerDataNascimento(this Cliente cliente)
        {
            while (true)
            {
                Console.Write("Digite a data de nascimento (Dia/Mes/Ano): ");
                string? dataInput = Console.ReadLine();
                if (DateTime.TryParseExact(dataInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento) &&
                    dataNascimento <= DateTime.Now.AddYears(-18))
                    return dataNascimento;
                Console.WriteLine("Erro: Data de nascimento inválida ou cliente deve ter pelo menos 18 anos.");
            }
        }

        public static float LerRendaMensal(this Cliente cliente)
        {
            while (true)
            {
                Console.Write("Digite a renda mensal (valor >= 0 com duas casas decimais): ");
                if (float.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out float rendaMensal) && rendaMensal >= 0)
                    return rendaMensal;
                Console.WriteLine("Erro: Renda mensal deve ser um valor maior ou igual a 0.");
            }
        }

        public static char LerEstadoCivil(this Cliente cliente)
        {
            while (true)
            {
                Console.Write("Digite o estado civil (C, S, V ou D): ");
                char estadoCivil = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if ("CSVDC".Contains(estadoCivil))
                    return estadoCivil;
                Console.WriteLine("Erro: Estado civil deve ser C, S, V ou D.");
            }
        }

        public static int LerDependentes(this Cliente cliente)
        {
            while (true)
            {
                Console.Write("Digite o número de dependentes (0 a 10): ");
                if (int.TryParse(Console.ReadLine(), out int dependentes) && dependentes >= 0 && dependentes <= 10)
                    return dependentes;
                Console.WriteLine("Erro: Número de dependentes deve ser entre 0 e 10.");
            }
        }
    }
}
