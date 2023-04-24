using System;
using System.Collections.Generic;
using System.IO;

namespace BancoEscola
{
    internal class FileManager
    {
        // Definição do caminho padrão para os arquivos
        private const string PATH = @"C:\Users\Estudos C#\Desktop\Estudo C#\BancoEscolaCSharp-main";

        // Método para criar um arquivo com o nome de Alunos{classe}.csv
        public static void CreateFile(char classe)
        {
            try
            {
                string fileName = $"{PATH}Alunos{classe}.csv";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close(); // Fecha o arquivo para evitar erros
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer algum erro ao criar o arquivo, uma exceção é lançada
                throw new IOException("Erro ao criar arquivo.", ex);
            }
        }

        // Método para escrever os dados de um aluno em um arquivo csv com o nome de Alunos{classe}.csv
        public static void WriteToFile(char classe, Dados aluno)
        {
            try
            {
                string fileName = $"{PATH}Alunos{classe}.csv";
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine($"{aluno.nome},{aluno.nota1},{aluno.nota2}");
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer algum erro ao escrever no arquivo, uma exceção é lançada
                throw new IOException("Erro ao escrever no arquivo.", ex);
            }
        }

        // Método para atualizar os dados de um aluno em um arquivo csv com o nome de Alunos{classe}.csv
        public static void UpdateFile(char classe, string nomeAluno, Dados alunoAtualizado)
        {
            try
            {
                string fileName = $"{PATH}Alunos{classe}.csv";
                string[] lines = File.ReadAllLines(fileName);
                bool found = false;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith($"Nome: {alunoAtualizado.nome}"))
                    {
                        lines[i] = $"Nome: {alunoAtualizado.nome} / Nota 1: {alunoAtualizado.nota1} / Nota 2: {alunoAtualizado.nota2}";
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    // Se o aluno não for encontrado no arquivo, uma exceção é lançada
                    throw new Exception("Aluno não encontrado.");
                }
                File.WriteAllLines(fileName, lines);
            }
            catch (Exception ex)
            {
                // Se ocorrer algum erro ao atualizar o arquivo, uma exceção é lançada
                throw new IOException("Erro ao atualizar arquivo.", ex);
            }
        }

        // Método para ler os dados dos alunos de um arquivo csv com o nome de Alunos{classe}.csv
        public static List<Dados> ReadFromFile(char classe, string nomeAluno = null)
        {
            List<Dados> alunos = new List<Dados>();
            string fileName = $"{PATH}Alunos{classe}.csv";

            // Verifica se o arquivo existe antes de tentar lê-lo
            if (File.Exists(fileName))
            {
                // Lê todas as linhas do arquivo e itera sobre cada uma delas
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    // Divide a linha em partes, utilizando a vírgula como separador
                    string[] parts = line.Split(',');
                    Dados aluno = new Dados();

                    // Atribui os valores das partes às propriedades do objeto aluno
                    aluno.nome = parts[0];
                    aluno.nota1 = float.Parse(parts[1]);
                    aluno.nota2 = float.Parse(parts[2]);

                    // Adiciona o objeto aluno à lista de alunos
                    alunos.Add(aluno);
                }
            }

            // Retorna a lista de alunos
            return alunos;
        }

    }
}
