class Personagem
{
    public string Nome;
    public int Vida;
    public int Forca;

    // Construtor
    public Personagem(string nome, int vida, int forca)
    {
        Nome = nome;
        Vida = vida;
        Forca = forca;
    }

    // Método
    public void Atacar(Personagem alvo)
    {
        Console.WriteLine($"{Nome} atacou {alvo.Nome} causando {Forca} de dano!");
        alvo.Vida -= Forca;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Personagem heroi = new Personagem("Herói", 100, 20);
        Personagem inimigo = new Personagem("Monstro", 80, 10);
        heroi.Atacar(inimigo);
        Console.WriteLine($"{inimigo.Nome} agora tem {inimigo.Vida} de vida.");
    }
}