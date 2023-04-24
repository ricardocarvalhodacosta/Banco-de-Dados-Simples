using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEscola
{
    internal class SalaDeAula
    {
        public string Nome { get; set; } // propriedade para o nome da sala de aula
        public List<Aluno> Alunos { get; set; } // propriedade para a lista de alunos

        public SalaDeAula(string nome)
        {
            Nome = nome; // define o nome da sala de aula
            Alunos = new List<Aluno>(); // inicializa a lista de alunos
        }

        public void AdicionarAluno(Aluno aluno) // método para adicionar um aluno à lista
        {
            Alunos.Add(aluno);
        }

        public void RemoverAluno(Aluno aluno) // método para remover um aluno da lista
        {
            Alunos.Remove(aluno);
        }

        public void AtualizarAluno(Aluno aluno, string novoNome, float novaNota1, float novaNota2) // método para atualizar as informações de um aluno
        {
            aluno.Nome = novoNome; // atualiza o nome do aluno
            aluno.Nota1 = novaNota1; // atualiza a nota 1 do aluno
            aluno.Nota2 = novaNota2; // atualiza a nota 2 do aluno
        }

        // Método para salvar os dados da sala de aula em um arquivo de texto
        public void SalvarDados()
        {
            string nomeArquivo = Nome + ".txt";  // Define o nome do arquivo como o nome da sala de aula + ".txt"

            using (StreamWriter file = new StreamWriter(nomeArquivo))  // Cria um objeto StreamWriter para escrever no arquivo
            {
                foreach (Aluno aluno in Alunos)  // Percorre a lista de alunos da sala de aula
                {
                    file.WriteLine(aluno.Nome + ";" + aluno.Nota1 + ";" + aluno.Nota2);  // Escreve o nome e as notas do aluno separados por ";"
                }
            }
        }
    }
}
