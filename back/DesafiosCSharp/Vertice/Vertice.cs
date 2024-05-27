using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticeLibrary
{
    public class Vertice(float X, float Y)
    {
        public float X { get; private set; } = X;
        public float Y { get; private set; } = Y;

        public float CalcularDistancia(Vertice outroVertice)
        {
            float deltaX = this.X - outroVertice.X;
            float deltaY = this.Y - outroVertice.Y;
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public void Move(float novoX, float novoY)
        {
            this.X = novoX;
            this.Y = novoY;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vertice vertice &&
                   X == vertice.X &&
                   Y == vertice.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
