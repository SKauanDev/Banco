public class ContaCorrente : Conta
{
    public decimal LimiteChequeEspecial { get; private set; }

    public ContaCorrente(int numeroConta, Cliente cliente, decimal limiteChequeEspecial)
        : base(numeroConta, cliente)
    {
        LimiteChequeEspecial = limiteChequeEspecial;
    }

    public override bool Sacar(decimal valor)
    {
        if (Saldo + LimiteChequeEspecial >= valor)
        {
            Saldo -= valor;
            Transacoes.Add($"Saque de R$ {valor:F2} (com cheque especial) - Saldo atual: R$ {Saldo:F2}");
            return true;
        }
        return false;
    }
}
