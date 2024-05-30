using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntervaloLibrary;

namespace ListaIntervaloLibrary
{
    internal class ListaIntervalo
    {
        private readonly List<Intervalo> _intervalos;

        public ListaIntervalo()
        {
            _intervalos = [];
        }

        public bool Add(Intervalo novoIntervalo)
        {
            if(Intervalos.Any( intervalo => intervalo.TemIntersecao(novoIntervalo))){
                return false;
            }
            _intervalos.Add(novoIntervalo);
            return true;
        }

        public IReadOnlyList<Intervalo> Intervalos
        {
            get
            {
                return new ReadOnlyCollection<Intervalo>(_intervalos.OrderBy(i => i.DataHoraInicial).ToList());
            }
        }
    }
}
