using System;

namespace DungeonExplorer
{
    // Classe que representa o jogador
    class Jogador
    {
        public string Nome { get; set; }
        public int Vida { get; set; } = 100;
        public int Pontuacao { get; set; } = 0;

        public void ReceberDano(int dano)
        {
            Vida -= dano;
        }

        public void GanharPontos(int pontos)
        {
            Pontuacao += pontos;
        }
    }

    // Classe com funções auxiliares para o jogo
    class SistemaJogo
    {
        public static void MostrarStatus(Jogador player)
        {
            Console.WriteLine($"\nStatus do Jogador: {player.Nome}");
            Console.WriteLine($"Vida: {player.Vida}");
            Console.WriteLine($"Pontuação: {player.Pontuacao}");
        }

        public static int CalcularDanoAtaque(int nivel)
        {
            return nivel * 5; // Função simples para cálculo de dano
        }
    }

    class Programa
    {
        static void Main()
        {
            Console.WriteLine("=== Dungeon Explorer – Versão Console ===\n");
            Console.WriteLine("Digite o nome do herói:");
            string nome = Console.ReadLine();

            // Criação e inicialização do personagem
            Jogador heroi = new Jogador
            {
                Nome = nome
            };

            SistemaJogo.MostrarStatus(heroi);

            // Estrutura condicional
            Console.WriteLine("\nUm goblin aparece! Deseja atacar? (s/n)");
            string escolha = Console.ReadLine().ToLower();

            if (escolha == "s")
            {
                int dano = SistemaJogo.CalcularDanoAtaque(2);
                Console.WriteLine($"Você atacou o goblin e causou {dano} de dano!");
                heroi.GanharPontos(20);
            }
            else
            {
                Console.WriteLine("Você ignorou o goblin, mas ele atacou você!");
                heroi.ReceberDano(15);
            }

            SistemaJogo.MostrarStatus(heroi);

            // Laço de repetição – simulação de rodada
            Console.WriteLine("\nIniciando rodada de exploração...");
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Explorando sala {i}...");
            }

            // Condição final
            if (heroi.Vida <= 0)
            {
                Console.WriteLine("\nGAME OVER – Seu herói não resistiu.");
            }
            else
            {
                Console.WriteLine("\nExploração concluída com sucesso!");
            }

            SistemaJogo.MostrarStatus(heroi);

            Console.WriteLine("\nEncerrando o jogo...");
        }
    }
}
