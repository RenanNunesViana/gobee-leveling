using ValidacaoDados;

internal class Program
{
    private static void Main(string[] args)
    {
        //aqui eu quis usar o metodo de extensao so pra me acostumar mais com o mecanismo. Talvez não seja a melhor abordagem.
        Cliente cliente = new Cliente
        {
            Nome = new Cliente().LerNome(),
            CPF = new Cliente().LerCPF(),
            DataNascimento = new Cliente().LerDataNascimento(),
            RendaMensal = new Cliente().LerRendaMensal(),
            EstadoCivil = new Cliente().LerEstadoCivil(),
            Dependentes = new Cliente().LerDependentes()
        };

        Console.WriteLine("\nDados do Cliente:");
        Console.WriteLine(cliente);
    }
}