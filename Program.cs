using System;
using System.Collections.Generic;
using System.IO;
using static BancoSimples.Interface1;

class Program
{
    static void Main(string[] args)
    {
        BancoDeDados bancoDeDados = new BancoDeDados();
        InterfaceUsuario interfaceUsuario = new InterfaceUsuario(bancoDeDados);
        interfaceUsuario.Executar();
        Console.WriteLine("** DADOS ATUALIZADOS COM SUCESSO!! **");
    }
}