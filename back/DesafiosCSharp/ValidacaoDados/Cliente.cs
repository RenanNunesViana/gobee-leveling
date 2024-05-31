using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacaoDados
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public long CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public float RendaMensal { get; set; }
        public char EstadoCivil { get; set; }
        public int Dependentes { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}\n" +
                   $"CPF: {CPF}\n" +
                   $"Data de Nascimento: {DataNascimento:dd/MM/yyyy}\n" +
                   $"Renda Mensal: {RendaMensal:F2}\n" +
                   $"Estado Civil: {EstadoCivil}\n" +
                   $"Dependentes: {Dependentes}";
        }
    }
}
