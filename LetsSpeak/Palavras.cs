using System.Text.RegularExpressions;

namespace LetsSpeak
{
    public class Palavras
    {
        private static Regex _Regex;

        public Palavras(string palavra)
        {
            _Regex = new Regex(@"\b(?<name>" + palavra + ")\\b", RegexOptions.IgnoreCase);
        }
        public bool ValidaPalavra(string palavra)
        {
            Match match = _Regex.Match(palavra);
            if (match.Groups["name"].Success)
            {
                return match.Success;
            }
            return false;
        }
        public void VerificaTermo(Dictionary<string, string> palavras)
        {
            int count = 0;
            foreach (var item in palavras)
            {
                if (!palavras.ContainsKey(item.Key))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("Termo não encontrado");
                count = 0;
            }
            else
            {
                ConsultaPalavra(palavras);
                return;
            }
        }
        public void ConsultaPalavra(Dictionary<string, string> palavra)
        {
            var result = from pl in palavra
                         where ValidaPalavra(pl.Key)
                         select pl;
            foreach (KeyValuePair<string, string> item in result)
            {
                Console.WriteLine($"Termo: {item.Key} ==> Significado: {item.Value}");
            }
            result = null;
        }
        public void BuscaPalavra(string path)
        {
            Dictionary<string, string> idiomaticas = new();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string chave = string.Empty;
                        string valor = string.Empty;
                        string line = sr.ReadLine();
                        chave = line.Split(':')[0];
                        valor = line.Split(':')[1];
                        idiomaticas.Add(chave, valor);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro");
                Console.WriteLine(e.Message);
            }
            VerificaTermo(idiomaticas);
        }


        public void InseriPalavras(string path, string chave, string valor)
        {
            Dictionary<string, string> idiomaticas = new();

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
