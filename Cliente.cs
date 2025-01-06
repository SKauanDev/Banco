public class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Endereco { get; set; }

    public Cliente(string nome, string cpf, string endereco)
    {
        Nome = nome;
        CPF = cpf;
        Endereco = endereco;
    }

    public override string ToString()
    {
        return $"{Nome} (CPF: {CPF})";
    }
}
