# Aula 1 – Introdução à Programação Orientada a Objetos (POO)

Bem-vindo à primeira aula do nosso curso de **Pensamento Computacional aplicado à criação de jogos eletrônicos com C#**.  
Nesta aula você terá o primeiro contato com o paradigma da **Programação Orientada a Objetos (POO)**, compreendendo seus fundamentos e sua importância no desenvolvimento de jogos.

---

## O que você vai aprender nesta aula
- O que é Programação Orientada a Objetos.  
- Quais são os quatro pilares fundamentais da POO.  
- Como relacionar conceitos do mundo real com objetos em programação.  
- Primeiros exemplos de código em C#.  
- Como modelar personagens e elementos de jogos utilizando classes e objetos.  

---

## Conceitos Fundamentais

### O que é POO?
A Programação Orientada a Objetos é um **paradigma de programação** que organiza o código em torno de **objetos**.  
Esses objetos representam elementos do mundo real ou de um jogo, como personagens, inimigos, itens ou veículos.  

### Os 4 Pilares da POO
1. **Encapsulamento** – protege os dados internos de um objeto e organiza seu acesso.  
2. **Herança** – permite que uma classe herde atributos e métodos de outra, evitando repetição de código.  
3. **Polimorfismo** – possibilita que diferentes classes usem métodos com o mesmo nome, mas com comportamentos distintos.  
4. **Abstração** – foca apenas nas características essenciais de um objeto, escondendo detalhes desnecessários.  

---

## Exemplo com Analogias
Imagine que temos uma **classe Carro**:  
- **Atributos:** cor, modelo, velocidade.  
- **Métodos:** acelerar(), frear().  

Agora, pense em um **jogo de corrida**. Cada carro no jogo é um **objeto** da classe **Carro**, cada um com atributos diferentes (um vermelho, outro azul, etc.) e comportamentos iguais (todos podem acelerar ou frear).  

---

## Exemplo em Código (C#)

```csharp
// Classe Personagem
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
```

## **Os Quatro Pilares da POO**

A POO se sustenta sobre **quatro princípios fundamentais**, que garantem a modularidade, reutilização e organização do código.

---

### **1. Encapsulamento**

#### Definição
Encapsulamento é o princípio que **protege os dados internos de um objeto**, permitindo o acesso apenas por meio de **métodos controlados**.  
Isso garante que partes externas do código não modifiquem diretamente informações sensíveis, mantendo a integridade do objeto.

#### Exemplo na temática de jogos:
Imagine um jogo de luta. Um personagem possui um atributo `vida`.  
Se qualquer parte do código pudesse alterar livremente esse valor, o jogo seria instável.  
Com o encapsulamento, usamos **métodos públicos de controle** para alterar a vida — como `ReceberDano()` e `Curar()`.

#### Exemplo em C#:
```csharp
class Personagem
{
    private int vida = 100; // atributo protegido

    public void ReceberDano(int dano)
    {
        vida -= dano;
        if (vida < 0) vida = 0;
        Console.WriteLine($"O personagem recebeu {dano} de dano. Vida atual: {vida}");
    }

    public void Curar(int valor)
    {
        vida += valor;
        if (vida > 100) vida = 100;
        Console.WriteLine($"O personagem se curou. Vida atual: {vida}");
    }
}
```

---

### **2. Herança**

#### Definição
A **herança** permite que uma classe **filha** herde atributos e métodos de uma **classe pai**, promovendo **reutilização de código** e **padronização de comportamentos**.

#### Exemplo na temática de jogos:
No desenvolvimento de um jogo, podemos ter uma classe genérica `Personagem`, e dela derivar classes específicas como `Heroi` e `Inimigo`, herdando atributos comuns como `Vida` e `Forca`.

#### Exemplo em C#:
```csharp
class Personagem
{
    public string Nome;
    public int Vida;

    public void Mover()
    {
        Console.WriteLine($"{Nome} está se movendo...");
    }
}

class Heroi : Personagem
{
    public void Atacar()
    {
        Console.WriteLine($"{Nome} atacou o inimigo!");
    }
}

class Inimigo : Personagem
{
    public void Rugir()
    {
        Console.WriteLine($"{Nome} soltou um rugido feroz!");
    }
}
```


---

### **3. Polimorfismo**

#### Definição
O **polimorfismo** permite que diferentes classes tenham **métodos com o mesmo nome**, mas com **comportamentos distintos**.  
É o princípio que possibilita criar sistemas flexíveis e adaptáveis, especialmente em jogos com múltiplos tipos de personagens.

#### Exemplo na temática de jogos:
Em um RPG, tanto o **Herói** quanto o **Inimigo** possuem o método `Atacar()`, porém cada um executa o ataque de maneira diferente.

#### Exemplo em C#:
```csharp
class Personagem
{
    public virtual void Atacar()
    {
        Console.WriteLine("O personagem atacou de forma genérica.");
    }
}

class Heroi : Personagem
{
    public override void Atacar()
    {
        Console.WriteLine("O herói atacou com uma espada!");
    }
}

class Inimigo : Personagem
{
    public override void Atacar()
    {
        Console.WriteLine("O inimigo atacou com garras afiadas!");
    }
}
```


---

### **4. Abstração**

#### Definição
A **abstração** consiste em **esconder detalhes complexos** e **expor apenas o que é relevante**.  
Ela permite modelar objetos de forma simplificada, focando nas ações e características essenciais para o funcionamento do jogo.

#### Exemplo na temática de jogos:
Podemos criar uma **classe abstrata** chamada `Personagem` que define o que todos os personagens devem ter (por exemplo, `Atacar()` e `Mover()`), mas deixa os detalhes de implementação para as subclasses (`Heroi`, `Inimigo`, etc.).

#### Exemplo em C#:
```csharp
abstract class Personagem
{
    public string Nome;
    public int Vida;

    public abstract void Atacar(); // método abstrato

    public void Mover()
    {
        Console.WriteLine($"{Nome} se moveu para uma nova posição.");
    }
}

class Mago : Personagem
{
    public override void Atacar()
    {
        Console.WriteLine($"{Nome} lançou uma bola de fogo!");
    }
}

class Arqueiro : Personagem
{
    public override void Atacar()
    {
        Console.WriteLine($"{Nome} disparou uma flecha!");
    }
}
```


---

##**Exemplo Completo Integrando os 4 Pilares**

```csharp
abstract class Personagem
{
    protected int vida;
    public string Nome { get; set; }

    public Personagem(string nome, int vida)
    {
        Nome = nome;
        this.vida = vida;
    }

    public abstract void Atacar(Personagem alvo);

    public void ReceberDano(int dano)
    {
        vida -= dano;
        if (vida < 0) vida = 0;
        Console.WriteLine($"{Nome} recebeu {dano} de dano. Vida atual: {vida}");
    }
}

class Guerreiro : Personagem
{
    public int Forca { get; set; }

    public Guerreiro(string nome, int vida, int forca) : base(nome, vida)
    {
        Forca = forca;
    }

    public override void Atacar(Personagem alvo)
    {
        Console.WriteLine($"{Nome} golpeou {alvo.Nome} com {Forca} de força!");
        alvo.ReceberDano(Forca);
    }
}

class Mago : Personagem
{
    public int PoderMagico { get; set; }

    public Mago(string nome, int vida, int poderMagico) : base(nome, vida)
    {
        PoderMagico = poderMagico;
    }

    public override void Atacar(Personagem alvo)
    {
        Console.WriteLine($"{Nome} lançou um feitiço em {alvo.Nome} causando {PoderMagico} de dano mágico!");
        alvo.ReceberDano(PoderMagico);
    }
}

class Program
{
    static void Main()
    {
        Guerreiro heroi = new Guerreiro("Arthas", 100, 20);
        Mago inimigo = new Mago("Kel'Thuzad", 80, 25);

        heroi.Atacar(inimigo);
        inimigo.Atacar(heroi);
    }
}
```
