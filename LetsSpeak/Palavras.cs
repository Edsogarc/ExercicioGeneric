using System.IO;
using System.Text.RegularExpressions;

namespace LetsSpeak
{
    public class Palavras
    {
        public string Path { get; set; }
        public Palavras(string path)
        {
            Path = path;
        }
        public string VerificaTermo()
        {
            Console.Write("Digite um termo: ");
            string palavra = Console.ReadLine().ToLower();
            while (string.IsNullOrEmpty(palavra))
            {
                Console.WriteLine("termo incorreto!");
                Console.Write("Digite um termo: ");
                palavra = Console.ReadLine();
            }
            return palavra;
            Console.Clear();
        }
        public void ConsultaPalavra(string palavra)
        {
            List<string> idio = BuscaTermos(palavra);
            if (idio.Count > 0)
            {
                foreach (var item in idio)
                {
                    string termo = item.Split(":")[0];
                    string sign = item.Split(":")[1];
                    Console.WriteLine($"Termo: {termo}\nSignificado: {sign}\n");
                }
            }
            else
            {
                Console.WriteLine("Termo não encontrado");
            }

        }
        public List<string> BuscaTermos(string termo)
        {
            List<string> idiomaticas = new();
            try
            {
                using (StreamReader sr = File.OpenText(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string temp = string.Empty;
                        string significado = string.Empty;
                        string line = sr.ReadLine();
                        temp = line.Split(':')[0];
                        significado = line.Split(':')[1];
                        if (temp.Contains(termo))
                        {
                            idiomaticas.Add(temp + ":" + significado);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro");
                Console.WriteLine(e.Message);
            }
            return idiomaticas;
        }
        public void InseriPalavras()
        {
            string termo;
            string significado;
            do
            {
                Console.Write("Digite um termo: ");
                termo = Console.ReadLine().ToLower();
                Console.Write("Digite o significado: ");
                significado = Console.ReadLine().ToLower();
            } while (termo == null || significado == null);
            
            try
            {
                using (StreamWriter sw = File.AppendText(Path))
                {
                    sw.WriteLine($"{termo}: {significado}");
                    Console.WriteLine("Termo e significado adicionado com sucesso!");
                    sw.Close();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Ocorreu um erro");
                Console.WriteLine(e.Message);
            }
        }
    }
}
