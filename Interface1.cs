using System.Text;
using System.Threading.Tasks;

namespace BancoSimples
{
    internal interface Interface1
    {
        class InterfaceUsuario
        {
            private BancoDeDados bancoDeDados;

            public InterfaceUsuario(BancoDeDados bancoDeDados)
            {
                this.bancoDeDados = bancoDeDados;
            }

            public void Executar()
            {
                while (true)
                {
                    Console.WriteLine("** ADICIONE OS NOVOS DADOS!! **");
                    Console.WriteLine();
                    Console.Write("Digite o Nome do Cliente: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite o E-mail do Cliente: ");
                    string email = Console.ReadLine();

                    Console.Write("Digite o Telefone do Cliente: ");
                    string telefone = Console.ReadLine();

                    bancoDeDados.AdicionarCliente(nome, email, telefone);

                    Console.Write("Deseja adicionar mais clientes? Digite S/N: ");
                    string cont = Console.ReadLine();
                    Console.WriteLine();

                    if (cont.ToUpper() != "S")
                    {
                        Console.WriteLine("** DADOS ATUALZIADOS COM SUCESSO!! **");
                        Console.WriteLine();
                        break;
                    }

                }

                bancoDeDados.SalvarDados();

                List<string> dados = bancoDeDados.ObterDados();

                foreach (string dado in dados)
                {
                    Console.WriteLine(dado, true);
                    Console.WriteLine();
                }
            }
        }
    }
}
