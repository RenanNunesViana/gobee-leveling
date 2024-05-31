
namespace ExtensaoLista
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   CPF == cliente.CPF;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CPF);
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\nCPF: {CPF}";
        }
    }
}
