namespace CarroLibrary
{
    internal class Carro
    {
        public string Placa { get; }
        public string Modelo { get; }
        private Motor _motor;
        public Motor Motor
        {

            get => _motor;
            set
            {
                if (value == null)
                    throw new ArgumentException("O carro não pode ficar sem motor.");

                if (value.CarroUsando != null)
                    throw new ArgumentException("O mesmo motor não pode ser usado em dois carros diferentes.");

                if (_motor != null)
                    _motor.CarroUsando = null;

                _motor = value;
                _motor.CarroUsando = this;
            }
        }

        public Carro(string placa, string modelo, Motor motor)
        {
            Placa = placa;
            Modelo = modelo;
            Motor = motor ?? throw new ArgumentException("O carro deve ter um motor.");
        }

        public double CalcularVelocidadeMaxima()
        {
            return Motor.Cilindrada switch
            {
                <= 1.0 => 140,
                <= 1.6 => 160,
                <= 2.0 => 180,
                _ => 220,
            };
        }

        public override string ToString()
        {
            return $"Placa: {Placa}, Modelo: {Modelo}, Motor: {_motor.Cilindrada}L, Velocidade Máxima: {CalcularVelocidadeMaxima()} km/h";
        }
    }
}
