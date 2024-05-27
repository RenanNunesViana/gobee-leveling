using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerticeLibrary;

namespace PoligonoLibrary
{
    internal class Poligono
    {
        public List<Vertice> Vertices { get; set; }

        public Poligono(Vertice[] vertices)
        {
            if (vertices.Length < 3)
            {
                throw new ArgumentException("Um polígono deve ter pelo menos 3 vértices.");
            }

            Vertices = new List<Vertice>(vertices);
        }

        public IEnumerable<Vertice> Find(Vertice vertice)
        {
            return Vertices.Where(v => v.Equals(vertice));
        }

        public bool AddVertice(Vertice vertice)
        {
            var foundedVertice = Find(vertice);
            if (foundedVertice.Any()) {
                return false;
            }
            else
            {
                Vertices.Add(vertice);
                return true;
            }
        }

        public bool RemoveVertice(Vertice v) 
        {
            var foundedVertice = Find(v);
            if (Vertices.Count <= 3)
            {
                throw new ArgumentException("Um polígono deve ter pelo menos 3 vértices.");
            }
            else if (foundedVertice.Any())
            {
                Vertices.Remove(v);
                return true;
            }
            else
            {
                return false;
            }
        }

        public float CalcularPerimetro()
        {
            float perimetro = 0;

            Vertice verticeAnterior = Vertices[Vertices.Count - 1];

            foreach (Vertice verticeAtual in Vertices)
            {
                perimetro += verticeAnterior.CalcularDistancia(verticeAtual);
                verticeAnterior = verticeAtual;
            }

            return perimetro;
        }

        public int Size
        {
            get { return Vertices.Count; }
        }
    }
}
