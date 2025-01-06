public abstract class Conta
{
    public int NumeroConta { get; private set; }
    public Cliente Cliente { get; private set; }
    public decimal Saldo { get; protected set; }
    public List<string> Transacoes { get; private set; }

    public Conta(int numeroConta, Cliente cliente)
    {
        NumeroConta = numeroConta;
        Cliente = cliente;
        Saldo = 0;
        Transacoes = new List<string>();
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
        Transacoes.Add($"Depósito de R$ {valor:F2} - Saldo atual: R$ {Saldo:F2}");
    }

    public virtual bool Sacar(decimal valor)
    {
        if (Saldo >= valor)
        {
            Saldo -= valor;
            Transacoes.Add($"Saque de R$ {valor:F2} - Saldo atual: R$ {Saldo:F2}");
            return true;
        }
        return false;
    }

    public void ExibirHistorico()
    {
        Console.WriteLine($"Histórico de transações da conta {NumeroConta}:");
        foreach (var transacao in Transacoes)
        {
            Console.WriteLine($"- {transacao}");
        }
    }
}
