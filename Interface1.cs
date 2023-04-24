using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEscola
{
    // Classe Menu é responsável por exibir menus e receber a entrada do usuário.
    internal class Menu
    {
        public char menu { get; set; } // variável para armazenar a classe selecionada pelo usuário
        public int op { get; set; } // variável para armazenar a opção de menu selecionada pelo usuário
        public string leitura { get; set; } // variável para armazenar entrada do usuário que não seja número

        // construtor que recebe a classe selecionada pelo usuário
        public Menu(char classe)
        {
            menu = classe;
        }

        // construtor vazio
        public Menu()
        {
        }

        // método para exibir mensagem inicial ao usuário
        public void SelectClass()
        {
            Console.WriteLine("Olá, eu sou o banco de dados da Escola,");
            Console.WriteLine("e estou aqui para ajudar!");
            Console.WriteLine("Antes de começarmos, me diga:");
            Console.WriteLine("Qual classe você gostaria de acessar?");
            Console.WriteLine();
            Console.WriteLine("Classe A, Classe B ou Classe C?");
            Console.WriteLine();
            Console.Write("Por favor, digite a letra da Classe: ");
        }

        // método para exibir o menu principal e receber a entrada do usuário
        public void SelectFuncion(FileManager FileManager)
        {
            Console.WriteLine();
            Console.WriteLine("Ótimo, você escolheu a Classe " + menu + ", agora me diga, o que iremos fazer hoje?");
            Console.WriteLine();
            Console.WriteLine("1. Adicionar um novo Aluno;");
            Console.WriteLine("2. Alterar os Dados de um Aluno;");
            Console.WriteLine();

            // recebe a entrada do usuário e a converte em um inteiro
            op = int.Parse(Console.ReadLine());

            // faz a seleção da opção do menu com base na entrada do usuário
            switch (op)
            {
                // opção para adicionar um novo aluno
                case 1:
                    // cria um novo objeto Dados
                    Dados aluno = new Dados();
                    Console.WriteLine("Digite o nome do aluno:");
                    // recebe o nome do aluno e armazena no objeto Dados
                    aluno.nome = Console.ReadLine();
                    Console.WriteLine("Digite a nota 1:");
                    // recebe a nota 1 do aluno e armazena no objeto Dados
                    aluno.nota1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a nota 2:");
                    // recebe a nota 2 do aluno e armazena no objeto Dados
                    aluno.nota2 = float.Parse(Console.ReadLine());
                    // grava as informações do aluno no arquivo correspondente à classe selecionada
                    FileManager.WriteToFile(menu, aluno);
                    Console.WriteLine("Aluno adicionado com sucesso!");
                    break;
                case 2:
                    // Pede o nome do aluno a ser alterado
                    Console.WriteLine("Digite o nome do aluno a ser alterado:");
                    string nomeAluno = Console.ReadLine();

                    // Lê os dados antigos do aluno a partir do arquivo
                    Dados dadosAntigos = FileManager.ReadFromFile(menu, nomeAluno);

                    // Verifica se o aluno existe
                    if (dadosAntigos == null)
                    {
                        Console.WriteLine("Aluno não encontrado");
                        break;
                    }

                    // Cria um objeto com os novos dados
                    Dados dadosNovos = new Dados();
                    dadosNovos.nome = nomeAluno;

                    // Exibe os dados antigos para o usuário
                    Console.WriteLine("Dados antigos:");
                    Console.WriteLine($"Nome: {dadosAntigos.nome}");
                    Console.WriteLine($"Nota 1: {dadosAntigos.nota1}");
                    Console.WriteLine($"Nota 2: {dadosAntigos.nota2}");

                    // Pede as novas informações
                    Console.WriteLine("Digite as novas informações:");
                    Console.WriteLine("Digite a nota 1:");
                    dadosNovos.nota1 = float.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a nota 2:");
                    dadosNovos.nota2 = float.Parse(Console.ReadLine());

                    // Atualiza o arquivo com os novos dados
                    FileManager.UpdateFile(menu, nomeAluno, dadosNovos);
                    Console.WriteLine("Dados atualizados com sucesso!");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;

            }
        }
    }

    internal class Dados
    {
        public string nome { get; set; }
        public float nota1 { get; set; }
        public float nota2 { get; set; }
    }

}
