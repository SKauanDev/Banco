public class Menu
{
    private Banco banco;

    public Menu()
    {
        banco = new Banco(); // Inicializa o banco dentro do menu
    }

    public void ExibirMenu()
    {
        int opcao;

        do
        {
            Console.WriteLine("\n=== Simulador de Banco ===");
            Console.WriteLine("1. Criar Conta Corrente");
            Console.WriteLine("2. Criar Conta Poupança");
            Console.WriteLine("3. Depositar");
            Console.WriteLine("4. Sacar");
            Console.WriteLine("5. Exibir Histórico");
            Console.WriteLine("6. Listar Contas");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CriarContaCorrente();
                    break;
                case 2:
                    CriarContaPoupanca();
                    break;
                case 3:
                    RealizarDeposito();
                    break;
                case 4:
                    RealizarSaque();
                    break;
                case 5:
                    ExibirHistorico();
                    break;
                case 6:
                    banco.ListarContas();
                    break;
                case 0:
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        } while (opcao != 0);
    }

    private void CriarContaCorrente()
    {
        Console.Write("\nDigite o nome do cliente: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o CPF do cliente: ");
        string cpf = Console.ReadLine();
        Console.Write("Digite o endereço do cliente: ");
        string endereco = Console.ReadLine();
        Console.Write("Digite o limite do cheque especial: ");
        decimal limite = decimal.Parse(Console.ReadLine());

        var cliente = new Cliente(nome, cpf, endereco);
        int numeroConta = banco.BuscarConta(banco.ListarContas().Count + 1)?.NumeroConta ?? banco.ListarContas().Count + 1;
        var contaCorrente = new ContaCorrente(numeroConta, cliente, limite);

        banco.AdicionarConta(contaCorrente);
        Console.WriteLine("Conta Corrente criada com sucesso!");
    }

    private void CriarContaPoupanca()
    {
        Console.Write("\nDigite o nome do cliente: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o CPF do cliente: ");
        string cpf = Console.ReadLine();
        Console.Write("Digite o endereço do cliente: ");
        string endereco = Console.ReadLine();
        Console.Write("Digite a taxa de rendimento (em decimal, ex.: 0.01 para 1%): ");
        decimal taxaRendimento = decimal.Parse(Console.ReadLine());

        var cliente = new Cliente(nome, cpf, endereco);
        int numeroConta = banco.BuscarConta(banco.ListarContas().Count + 1)?.NumeroConta ?? banco.ListarContas().Count + 1;
        var contaPoupanca = new ContaPoupanca(numeroConta, cliente, taxaRendimento);

        banco.AdicionarConta(contaPoupanca);
        Console.WriteLine("Conta Poupança criada com sucesso!");
    }

    private void RealizarDeposito()
    {
        Console.Write("\nDigite o número da conta: ");
        int numeroConta = int.Parse(Console.ReadLine());
        var conta = banco.BuscarConta(numeroConta);

        if (conta == null)
        {
            Console.WriteLine("Conta não encontrada!");
            return;
        }

        Console.Write("Digite o valor do depósito: ");
        decimal valor = decimal.Parse(Console.ReadLine());

        conta.Depositar(valor);
        Console.WriteLine("Depósito realizado com sucesso!");
    }

    private void RealizarSaque()
    {
        Console.Write("\nDigite o número da conta: ");
        int numeroConta = int.Parse(Console.ReadLine());
        var conta = banco.BuscarConta(numeroConta);

        if (conta == null)
        {
            Console.WriteLine("Conta não encontrada!");
            return;
        }

        Console.Write("Digite o valor do saque: ");
        decimal valor = decimal.Parse(Console.ReadLine());

        if (conta.Sacar(valor))
        {
            Console.WriteLine("Saque realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente!");
        }
    }

    private void ExibirHistorico()
    {
        Console.Write("\nDigite o número da conta: ");
        int numeroConta = int.Parse(Console.ReadLine());
        var conta = banco.BuscarConta(numeroConta);

        if (conta == null)
        {
            Console.WriteLine("Conta não encontrada!");
            return;
        }

        conta.ExibirHistorico();
    }

    static void Main(string[] args)
    {
        Menu menu = new Menu(); // Inicializa a classe Menu
        menu.ExibirMenu();      // Chama o método que gerencia o menu do simulador
    }
}
