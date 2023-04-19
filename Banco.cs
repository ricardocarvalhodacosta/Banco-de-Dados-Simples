using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BancoDeDados
{
    private List<string> dados = new List<string>();

    public BancoDeDados()
    {
        if (File.Exists("C:\\Users\\C#Unity\\Documents\\ProjetoCS1\\BancoSimples\\dados.txt"))
        {
            string[] linhas = File.ReadAllLines("C:\\Users\\C#Unity\\Documents\\ProjetoCS1\\BancoSimples\\dados.txt");
            dados.AddRange(linhas);
        }
    }

    public void AdicionarCliente(string nome, string email, string telefone)
    {
        string novoCliente = $"Nome: {nome} || E-mail: {email} || Telefone: {telefone}";
        dados.Add(novoCliente);
    }

    public void SalvarDados()
    {
        using (StreamWriter writer = new StreamWriter("C:\\Users\\C#Unity\\Documents\\ProjetoCS1\\BancoSimples\\dados.txt"))
        {
            foreach (string linha in dados)
            {
                writer.WriteLine(linha, true);
            }
        }
    }

    public List<string> ObterDados()
    {
        return dados;
    }
}
