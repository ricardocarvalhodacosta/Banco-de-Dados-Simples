using BancoEscola;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Cria uma nova instância de FileManager
        FileManager FileManager = new FileManager();

        // Cria uma nova instância de Menu
        Menu menu = new Menu();

        // Exibe o menu de seleção de classe e lê a opção escolhida pelo usuário
        menu.SelectClass();
        menu.menu = char.Parse(Console.ReadLine().ToUpper());

        // Chama o método SelectFuncion da instância de Menu, passando como argumento a instância de FileManager
        menu.SelectFuncion(FileManager);
    }
}
