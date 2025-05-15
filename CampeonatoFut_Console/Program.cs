using CampeonatoFut_Console;

internal class Program
{
    public static Dictionary<string, Team> TeamList = new();
    private static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n\n##############################################");
            Console.WriteLine("Você chegou no CampeonatoFut!");
            Console.WriteLine("##############################################\n");
            Console.WriteLine("Digite 1 para registrar um Time de Futebol");
            Console.WriteLine("Digite 2 para registrar um Jogador de um Time de Futebol");
            Console.WriteLine("Digite 3 para mostrar todos os Times de Futebol");
            Console.WriteLine("Digite 4 para mostrar os Jogadores de um Time de Futebol");
            Console.WriteLine("Digite -1 para sair\n");

            Console.WriteLine("Informe sua opção:");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TeamRegistration();
                    break;
                case 2:
                    PlayerRegistration();
                    break;
                case 3:
                    TeamGet();
                    break;
                case 4:
                    PlayerGet();
                    break;
                case -1:
                    Console.Clear();
                    Console.WriteLine("Até mais\n");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida\n");
                    break;
            }
        }
    }
    private static void TeamRegistration()
    {
        Console.Clear();
        Console.WriteLine("### Registro de Time de Futebol ###");
        Console.WriteLine("\nDigite o nome do time que deseja registrar: ");
        string name = Console.ReadLine();
        Console.WriteLine("\nDigite o técnico do time que deseja registrar: ");
        string coach = Console.ReadLine();
        Team team = new Team(name, coach);
        TeamList.Add(name, team);
        Console.WriteLine($"\nO time de futebol {name} foi registrado com sucesso!\n");
    }

    private static void PlayerRegistration()
    {
        Console.Clear();
        Console.WriteLine("### Registro de Jogadores ###");
        Console.WriteLine("\nDigite o time cujo jogador deseja registrar: ");
        string TeamName = Console.ReadLine();
        if (TeamList.ContainsKey(TeamName))
        {
            Console.WriteLine($"\nInforme o nome do jogador do {TeamName}: ");
            string name = Console.ReadLine();
            Console.WriteLine($"\nInforme a posição do jogador do {TeamName}: ");
            string position = Console.ReadLine();
            Team team = TeamList[TeamName];
            team.AddPlayer(new Player(name, position));
            Console.WriteLine($"\nO jogador {name} do time {TeamName} foi registrado com sucesso!\n");
        }
        else
        {
            Console.WriteLine($"\nO time {TeamName} não foi encontrado.\n");
        }
    }

    private static void TeamGet()
    {
        Console.Clear();
        Console.WriteLine("Lista dos Times de Futebol:\n");
        foreach (var Team in TeamList)
        {
            Console.WriteLine(Team);
        }
    }

    private static void PlayerGet()
    {
        Console.Clear();
        Console.WriteLine("### Exibir detalhes do Time de Futebol ###");
        Console.WriteLine("\nDigite o time cujos jogadores deseja consultar: ");
        string TeamName = Console.ReadLine();
        if (TeamList.ContainsKey(TeamName))
        {
            Team team = TeamList[TeamName];
            team.ShowPlayers();
        }
        else
        {
            Console.WriteLine($"\nO time {TeamName} não foi encontrado.\n");
        }
    }
}
