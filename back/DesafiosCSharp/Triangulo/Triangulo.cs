using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerticeLibrary;


namespace TrianguloLibrary
{
    internal class Triangulo
    {
        public Vertice Vertice1 { get; private set; }
        public Vertice Vertice2 { get; private set; }
        public Vertice Vertice3 { get; private set; }

        public Triangulo(Vertice vertice1, Vertice vertice2, Vertice vertice3)
        {
            if(!FormamTriangulo(vertice1, vertice2, vertice3))
            {
                throw new ArgumentException("Os vértices fornecidos não formam um triângulo.");
            }

            Vertice1 = vertice1;
            Vertice2 = vertice2;
            Vertice3 = vertice3;
        }

        public float CalcularPerimetro()
        {
            return Vertice1.CalcularDistancia(Vertice2) +
                   Vertice2.CalcularDistancia(Vertice3) +
                   Vertice3.CalcularDistancia(Vertice1);
        }

        public TipoTriangulo Tipo
        {
            get
            {
                float lado1 = Vertice1.CalcularDistancia(Vertice2);
                float lado2 = Vertice2.CalcularDistancia(Vertice3);
                float lado3 = Vertice3.CalcularDistancia(Vertice1);

                if (lado1 == lado2 && lado2 == lado3)
                {
                    return TipoTriangulo.Equilatero;
                }
                else if (lado1 == lado2 || lado2 == lado3 || lado1 == lado3)
                {
                    return TipoTriangulo.Isosceles;
                }
                else
                {
                    return TipoTriangulo.Escaleno;
                }
            }
        }

        public float Area
        {
            get
            {
                float lado1 = Vertice1.CalcularDistancia(Vertice2);
                float lado2 = Vertice2.CalcularDistancia(Vertice3);
                float lado3 = Vertice3.CalcularDistancia(Vertice1);

                float semiperimetro = CalcularPerimetro() / 2;
                return MathF.Sqrt(semiperimetro * (semiperimetro - lado1) * (semiperimetro - lado2) * (semiperimetro - lado3));
            }
        }
        private bool FormamTriangulo(Vertice v1, Vertice v2, Vertice v3)
        {
            float determinante = v1.X * (v2.Y - v3.Y) + v2.X * (v3.Y - v1.Y) + v3.X * (v1.Y - v2.Y);
            return determinante != 0;
        }

        public bool Equals(Triangulo other)
        {
            if (other == null) return false;

            float[] thisSides = GetSortedSides();
            float[] otherSides = other.GetSortedSides();

            for (int i = 0; i < 3; i++)
            {
                if (thisSides[i] != otherSides[i]) return false;
            }
            return true;
        }

        protected float[] GetSortedSides()
        {
            float[] sides =
            [
                Vertice1.CalcularDistancia(Vertice2),
                Vertice2.CalcularDistancia(Vertice3),
                Vertice3.CalcularDistancia(Vertice1)
            ];
            Array.Sort(sides);
            return sides;
        }

    }
}
