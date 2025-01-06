public class ContaPoupanca : Conta
{
    public decimal TaxaRendimento { get; private set; }

    public ContaPoupanca(int numeroConta, Cliente cliente, decimal taxaRendimento)
        : base(numeroConta, cliente)
    {
        TaxaRendimento = taxaRendimento;
    }

    public void AplicarRendimento()
    {
        decimal rendimento = Saldo * TaxaRendimento;
        Saldo += rendimento;
        Transacoes.Add($"Rendimento de R$ {rendimento:F2} aplicado - Saldo atual: R$ {Saldo:F2}");
    }
}
