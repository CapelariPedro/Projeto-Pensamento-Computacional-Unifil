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

// Exemplo de uso
Personagem heroi = new Personagem("Herói", 100, 20);
Personagem inimigo = new Personagem("Monstro", 80, 10);

heroi.Atacar(inimigo);
