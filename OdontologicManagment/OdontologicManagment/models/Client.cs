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
        public string Name { get; init; }
        
        [Required]
        [StringLength(11)]
        public string Cpf { get; init; }
        
        [Required]
        [StringLength(10)]
        public DateTime BirthDate { get; init; }

        [InverseProperty("Cliente")]
        public ICollection<Consulta> Consultas { get; init; }

        public Client(String name, String cpf, String birthDate)
        {

            if (!ValidarCPF(cpf))
            {
                throw new ArgumentException("Cpf deve ser válido");
            }

            if (name.Length < 5)
            {
                throw new ArgumentException("O nome do cliente deve ter pelo menos 5 caracteres");
            }

            if (!DateTime.TryParseExact(birthDate, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                throw new ArgumentException("Data de nascimento inválida. Use o formato DDMMAAAA.");
            }

            var age = CalcularIdade(parsedDate);
            if (age < 13)
            {
                throw new ArgumentException("O cliente deve ter pelo menos 13 anos.");
            }

            this.Name = name;
            this.Cpf = cpf;
            this.BirthDate = parsedDate;
            this.Consultas = [];
        }

        // Construtor privado para uso pelo EF Core
        private Client(string name, string cpf, DateTime birthDate)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.BirthDate = birthDate;
            this.Consultas = [];
        }

        public int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - BirthDate.Year;
            if (BirthDate.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }

        public void AddConsulta(Consulta consulta)
        {
            Consultas.Add(consulta);
        }

        public List<Consulta> RetornaConsultasFuturas()
        {
            var consultasFuturas = Consultas.Where(
                c => c.DataConsulta > DateTime.Now.Date
                    ||
                    (c.DataConsulta == DateTime.Now.Date && c.HoraInicial > DateTime.Now.TimeOfDay)
                ).ToList();

            return consultasFuturas;
        }

        public static int CalcularIdade(DateTime birthDate)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - birthDate.Year;
            if (birthDate.Date > hoje.AddYears(-idade)) idade--;
            return idade;
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

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   Cpf == client.Cpf;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cpf);
        }
    }
}
