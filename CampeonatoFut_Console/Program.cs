﻿using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut_Console;

internal class Program
{
    public static Dictionary<string, Team> TeamList = new();
    private static void Main(string[] args)
    {
        //var TeamDAL = new TeamDAL();
        var TeamDAL = new DAL<Team>();
        //var PlayerDAL = new PlayerDAL();

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
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

        void TeamRegistration()
        {
            Console.Clear();
            Console.WriteLine("### Registro de Time de Futebol ###");
            Console.WriteLine("\nDigite o nome do time que deseja registrar: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nDigite o técnico do time que deseja registrar: ");
            string coach = Console.ReadLine();
            Team team = new Team(name, coach);            
            TeamDAL.Create(team);
            Console.WriteLine($"\nO time de futebol {name} foi registrado com sucesso!\n");
            Console.ReadKey();
        }

        void PlayerRegistration()
        {
            Console.Clear();
            Console.WriteLine("### Registro de Jogadores ###");
            Console.WriteLine("\nDigite o time cujo jogador deseja registrar: ");
            string teamName = Console.ReadLine();
            var targetTeam = TeamDAL.ReadBy(a=> a.Name.Equals(teamName));
            if (targetTeam is not null)
            {
                Console.WriteLine($"\nInforme o nome do jogador do {teamName}: ");
                string name = Console.ReadLine();                
                targetTeam.AddPlayer(new Player(name));
                TeamDAL.Update(targetTeam);
                Console.WriteLine($"\nO jogador {name} do time {teamName} foi registrado com sucesso!\n");
            }
            else
            {
                Console.WriteLine($"\nO time {teamName} não foi encontrado.\n");
            }
            Console.ReadKey();
        }

        void TeamGet()
        {
            Console.Clear();
            Console.WriteLine("Lista dos Times de Futebol:\n");
            foreach (var Team in TeamDAL.Read())
            {
                Console.WriteLine(Team);
            }
            Console.ReadKey();
        }

        void PlayerGet()
        {
            Console.Clear();
            Console.WriteLine("### Exibir detalhes do Time de Futebol ###");
            Console.WriteLine("\nDigite o time cujos jogadores deseja consultar: ");
            string teamName = Console.ReadLine();
            var targetTeam = TeamDAL.ReadBy(a => a.Name.Equals(teamName));
            if (targetTeam is not null)
            {
                targetTeam.ShowPlayers();
            }
            else
            {
                Console.WriteLine($"\nO time {teamName} não foi encontrado.\n");
            }
            Console.ReadKey();
        }
    }
}