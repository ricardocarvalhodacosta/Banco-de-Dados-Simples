using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoEscola
{
    internal class Aluno
    {
        public string Nome { get; set; } // propriedade para o nome do aluno
        public float Nota1 { get; set; } // propriedade para a primeira nota do aluno
        public float Nota2 { get; set; } // propriedade para a segunda nota do aluno
        public float Media { get; set; } // propriedade para a média do aluno

        public Aluno(string nome, float nota1, float nota2, float media) // construtor da classe Aluno
        {
            Nome = nome; // atribui o nome recebido à propriedade Nome
            Nota1 = nota1; // atribui a primeira nota recebida à propriedade Nota1
            Nota2 = nota2; // atribui a segunda nota recebida à propriedade Nota2
            Media = (nota1 + nota2) / 2; // calcula a média e atribui o valor à propriedade Media
        }
    }
}
