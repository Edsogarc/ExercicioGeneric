using LetsSpeak;
using System.IO;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\projetoscsharp\LetsSpeak\ExpressoesIdiomaticas.txt";
        while (true)
        {
            Console.Write("Informe a palavra ou digite x para sair ");
            string palavra = Console.ReadLine();
            if (palavra == "x"){ break; }
            Palavras pl = new Palavras(palavra);
            pl.BuscaPalavra(path);
        }
        
    }
}