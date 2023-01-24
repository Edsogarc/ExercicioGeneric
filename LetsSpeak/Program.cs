using LetsSpeak;
class Program
{
    static void Main(string[] args)
    {
        string path = @"C:\projetoscsharp\LetsSpeak\ExpressoesIdiomaticas.txt";
        Palavras pl = new Palavras(path);
        string palavra;
        while (true)
        {
            Console.WriteLine("Escolha uma opção:\n");
            Console.WriteLine("1 - Pesquisar um termo");
            Console.WriteLine("2 - Cadastrar um novo termo");
            Console.WriteLine("3 - Sair do dicionário");
            char op = VerificaOpcao();
            if (op == '1')
            {
                Console.Clear();
                palavra = pl.VerificaTermo();
                pl.ConsultaPalavra(palavra);
            }
            else if(op == '2')
            {
                Console.Clear();
                pl.InseriPalavras();
            }
            else if (op == '3')
            {
                Console.WriteLine("Obrigado por usar o sistema!");
                break;
            }
        }
    }
    public static char VerificaOpcao()
    {
        char op = default;
        do
        {
            Console.Write("Digite opção valida: ");
            op = char.Parse(Console.ReadLine());
            Console.Clear();
        } while (op <= '0' && op > '3');
        return op;
    }
}