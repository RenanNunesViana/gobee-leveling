namespace CarroLibrary
{
    internal class Motor(double cilindrada)
    {
        public double Cilindrada { get; } = cilindrada;
        public Carro? CarroUsando { get; set; } = null;
    }
}
