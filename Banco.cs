public class Banco
{
    private List<Conta> contas = new List<Conta>();

    public List<Conta> ListarContas()
    {
        if (contas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
        }
        else
        {
            Console.WriteLine("\n=== Lista de Contas ===");
            foreach (var conta in contas)
            {
                Console.WriteLine($"Número: {conta.NumeroConta}, Cliente: {conta.Cliente.Nome}, Saldo: {conta.Saldo:C}");
            }
        }
        return contas;
    }

    public void AdicionarConta(Conta conta)
    {
        contas.Add(conta);
    }

    public Conta BuscarConta(int numeroConta)
    {
        return contas.FirstOrDefault(c => c.NumeroConta == numeroConta);
    }
}
