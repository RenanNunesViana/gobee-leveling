using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervaloLibrary
{
    public class Intervalo
    {
        public DateTime DataHoraInicial { get; }
        public DateTime DataHoraFinal { get; }

        public Intervalo(DateTime dataHoraInicial, DateTime dataHoraFinal)
        {
            if (dataHoraInicial >= dataHoraFinal)
            {
                throw new ArgumentException("A data/hora inicial deve ser anterior à data/hora final.");
            }

            DataHoraInicial = dataHoraInicial;
            DataHoraFinal = dataHoraFinal;
        }
        public bool TemIntersecao(Intervalo outro)
        {
            return DataHoraInicial < outro.DataHoraFinal && DataHoraFinal > outro.DataHoraInicial;
        }

        public override bool Equals(object? obj)
        {
            return obj is Intervalo intervalo &&
                   Duracao.Equals(intervalo.Duracao);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Duracao);
        }

        public TimeSpan Duracao
        {
            get
            {
                return DataHoraFinal - DataHoraInicial;
            }
        }

        public override string ToString()
        {
            return $"Início: {DataHoraInicial}, Fim: {DataHoraFinal}, Duração: {Duracao}";
        }

    }
}