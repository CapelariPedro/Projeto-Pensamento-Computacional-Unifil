using System;

namespace RPGAcademy
{
    public class Personagem
    {
        private int vida;

        public int Vida
        {
            get => vida;
            protected set => vida = value < 0 ? 0 : value;
        }

        public string Nome { get; init; }
        public int Nivel { get; init; }

        public Personagem(string nome, int nivel)
        {
            Nome = nome;
            Nivel = nivel;
            Vida = 100;
        }

        public virtual int CalcularDano()
        {
            return Nivel * 10;
        }

        public virtual void Atacar(Personagem alvo)
        {
            int danoBase = CalcularDano();
            int dano = danoBase + Program.Random.Next(-5, 6);
            alvo.ReceberDano(dano);
            Console.WriteLine($"{Nome} ataca {alvo.Nome} causando {dano} de dano.");
        }
        
        public void ReceberDano(int dano)
        {
            Vida -= dano;
            Console.WriteLine($"{Nome} recebeu {dano} de dano. Vida restante: {Vida}");
        }

        public void ExibirStatus()
        {
            Console.WriteLine($"\n[STATUS] Nome: {Nome} | Vida: {Vida} | Nível: {Nivel}");
        }
    }

    public class Guerreiro : Personagem
    {
        public int Forca { get; init; }

        public Guerreiro(string nome, int nivel, int forca)
            : base(nome, nivel)
        {
            Forca = forca;
        }

        public override int CalcularDano()
        {
            return Forca * Nivel * 2;
        }

        public override void Atacar(Personagem alvo)
        {
            int dano = CalcularDano() + Program.Random.Next(0, 5);
            alvo.ReceberDano(dano);
            Console.WriteLine($"{Nome} desferiu um golpe de espada causando {dano} de dano!");
        }
    }

    public class Mago : Personagem
    {
        public int Mana { get; init; }

        public Mago(string nome, int nivel, int mana)
            : base(nome, nivel)
        {
            Mana = mana;
        }

        public override int CalcularDano()
        {
            return Mana * Nivel * 3;
        }

        public override void Atacar(Personagem alvo)
        {
            int dano = CalcularDano() + Program.Random.Next(0, 10);
            alvo.ReceberDano(dano);
            Console.WriteLine($"{Nome} lançou uma bola de fogo causando {dano} de dano!");
        }
    }
    
    public class Inimigo : Personagem
    {
        public Inimigo(string nome, int nivel, int vidaBase)
            : base(nome, nivel)
        {
            // Inimigos são mais frágeis, mas atacam
            Vida = vidaBase + nivel * 15;
        }

        public override int CalcularDano()
        {
            return Nivel * 8;
        }

        public override void Atacar(Personagem alvo)
        {
            int dano = CalcularDano() + Program.Random.Next(-3, 4);
            alvo.ReceberDano(dano);
            Console.WriteLine($"{Nome} te ataca causando {dano} de dano.");
        }
    }

    class Program
    {
        private const int NIVEL_INICIAL = 2;
        private const int FORCA_GUERREIRO = 5;
        private const int MANA_MAGO = 7;
        private const int SALAS_TOTAL = 3;
        private const int VIDA_BASE_INIMIGO = 50;

        public static readonly Random Random = new Random();

        static void Main()
        {
            Console.WriteLine("=== RPG Academy Console Demo ===\n");

            Console.Write("Digite seu nome de herói: ");
            string nome = Console.ReadLine() ?? "Herói Anônimo";

            Console.WriteLine("Escolha uma classe: 1 - Guerreiro | 2 - Mago");
            if (!int.TryParse(Console.ReadLine(), out int escolhaClasse))
            {
                escolhaClasse = 1;
            }

            Personagem jogador = (escolhaClasse == 1)
                ? new Guerreiro(nome, NIVEL_INICIAL, FORCA_GUERREIRO)
                : new Mago(nome, NIVEL_INICIAL, MANA_MAGO);

            jogador.ExibirStatus();

            bool vitoria = ExplorarMapa(jogador, SALAS_TOTAL);

            Console.WriteLine("\n====================================");
            if (vitoria)
            {
                Console.WriteLine("PARABÉNS! Você explorou todas as salas e venceu o jogo!");
            }
            else
            {
                Console.WriteLine("FIM DE JOGO. Seu herói foi derrotado.");
            }
            Console.WriteLine("====================================");
        }

        static bool ExplorarMapa(Personagem jogador, int totalSalas)
        {
            Console.WriteLine("\nExplorando o mapa...");
            for (int sala = 1; sala <= totalSalas; sala++)
            {
                Console.WriteLine($"\n--- Entrando na Sala {sala} de {totalSalas} ---");
                Console.WriteLine("Um inimigo apareceu! Prepare-se...");
                
                string nomeInimigo = $"Monstro da Sala {sala}";
                Inimigo inimigo = new Inimigo(nomeInimigo, jogador.Nivel, VIDA_BASE_INIMIGO);
                inimigo.ExibirStatus();

                if (!IniciarCombate(jogador, inimigo))
                {
                    return false; 
                }
            }
            return true;
        }
        
        static bool IniciarCombate(Personagem jogador, Inimigo inimigo)
        {
            Console.WriteLine("\n*** INÍCIO DO COMBATE ***");
            while (jogador.Vida > 0 && inimigo.Vida > 0)
            {
                // Turno do Jogador
                Console.WriteLine($"\nSeu turno ({jogador.Nome})");
                jogador.Atacar(inimigo);
                
                if (inimigo.Vida <= 0)
                {
                    Console.WriteLine($"\n{inimigo.Nome} foi derrotado!");
                    return true;
                }

                // Turno do Inimigo
                Console.WriteLine($"\nTurno do inimigo ({inimigo.Nome})");
                inimigo.Atacar(jogador);

                if (jogador.Vida <= 0)
                {
                    Console.WriteLine($"\n{jogador.Nome} foi derrotado por {inimigo.Nome}!");
                    return false;
                }

                jogador.ExibirStatus();
                Console.WriteLine($"{inimigo.Nome} | Vida: {inimigo.Vida}");
            }
            return jogador.Vida > 0;
        }
    }
}