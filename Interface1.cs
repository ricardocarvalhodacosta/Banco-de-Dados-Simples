using System;
using System.Collections.Generic;
using System.Linq;
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
                    Console.Write("Digite o Nome do Cliente (ou 'sair' para encerrar): ");
                    string nome = Console.ReadLine();

                    if (nome == "sair")
                        break;

                    Console.Write("Digite o E-mail do Cliente: ");
                    string email = Console.ReadLine();

                    Console.Write("Digite o Telefone do Cliente: ");
                    string telefone = Console.ReadLine();

                    bancoDeDados.AdicionarCliente(nome, email, telefone);
                }

                bancoDeDados.SalvarDados();

                List<string> dados = bancoDeDados.ObterDados();

                foreach (string dado in dados)
                {
                    Console.WriteLine(dado, true);
                }
            }
        }
    }
}
