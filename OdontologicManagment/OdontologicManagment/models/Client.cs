using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace OdontologicManagment.models
{
    [Table("clients")]
    public class Client
    {
        [Key]
        public int Id { get; init; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(14)]
        public string Cpf { get; init; }
        //auterar para outro tipo
        [Required]
        [StringLength(10)]
        public DateTime BirthDate { get; set; }

        public Client(String name, String cpf, String birthDate) {

            if (!ValidarCPF(cpf))
            {
                throw new ArgumentException("Cpf deve ser válido");
            }

            if(name.Length < 5)
            {
                throw new ArgumentException("O nome do cliente deve ter pelo menos 5 caracteres");
            }

            if (!DateTime.TryParseExact(birthDate, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                throw new ArgumentException("Data de nascimento inválida. Use o formato DDMMAAAA.");
            }

            this.Name = name;
            this.Cpf = cpf;
            this.BirthDate = parsedDate;
        }

        // Construtor privado para uso pelo EF Core
        private Client(string name, string cpf, DateTime birthDate)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.BirthDate = birthDate;
        }

        //retorna true se for um cpf válido
        private bool ValidarCPF(string cpf)
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
    }
}
