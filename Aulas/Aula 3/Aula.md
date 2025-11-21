# Aula 3 – Sintaxe e Pilares da POO em C#

## 1. Declaração de Classes e Objetos

A Programação Orientada a Objetos (POO) estabelece um modelo mental alinhado ao modo como designers de jogos estruturam mundos, entidades e interações. Em C#, **classes** representam abstrações formais de elementos do jogo, enquanto **objetos** constituem instâncias concretas utilizadas pelo motor lógico do sistema.

### Fundamento Teórico

* A classe funciona como um *blueprint*, definindo atributos e comportamentos.
* O objeto é a materialização dessa definição durante a execução.
* Essa abordagem facilita modularidade, manutenção, expansão e criação de sistemas escaláveis para jogos.
* Jogos utilizam extensivamente objetos: personagens, projéteis, inimigos, itens, mecanismos de física, controladores de cena, entre outros.

### Exemplo Conceitual

No desenvolvimento de um RPG, "Personagem", "Inimigo" e "Item" são classes distintas. Já "Goblin", "Espada Lendária" e "Mago Nv. 1" são objetos derivados dessas classes.

### Exemplo de Código

```csharp
class Inimigo
{
    public string Nome;
    public int Vida;
}

class Programa
{
    static void Main()
    {
        Inimigo goblin = new Inimigo();
        goblin.Nome = "Goblin Verde";
        goblin.Vida = 50;
    }
}
```

A Programação Orientada a Objetos (POO) em C# é estruturada por meio de **classes**, que funcionam como modelos, e **objetos**, que representam instâncias concretas desses modelos. Essa abordagem é fundamental para o desenvolvimento de jogos, pois permite criar entidades como personagens, inimigos, itens e sistemas de física.

### Conceitos Fundamentais

* **Classe:** Define atributos, propriedades e comportamentos.
* **Objeto:** Instância criada a partir de uma classe.
* **Abstração:** Representação simplificada de um elemento do jogo.

### Exemplo Básico

```csharp
class Inimigo
{
    public string Nome;
    public int Vida;
}

class Programa
{
    static void Main()
    {
        Inimigo goblin = new Inimigo();
        goblin.Nome = "Goblin Verde";
        goblin.Vida = 50;
    }
}
```

---

## 2. Atributos, Propriedades e Métodos

A estrutura interna de uma classe depende de três elementos essenciais: **atributos**, **propriedades** e **métodos**, que juntos determinam como as entidades se comportam (métodos) e como mantêm seu estado interno (atributos e propriedades).

### Fundamento Teórico

* **Atributos** representam dados internos brutos e geralmente devem ser encapsulados.
* **Propriedades** introduzem mecanismos de controle sobre leitura e escrita, permitindo validações.
* **Métodos** estabelecem capacidades do objeto: movimentação, ataque, coleta, interação, IA básica.

### Relevância em Jogos

* Atributos como `Vida`, `Dano`, `Velocidade` ou `Energia` definem estatísticas importantes.
* Propriedades controlam acesso refinado — por exemplo, impedir que a vida seja negativa.
* Métodos permitem orquestrar comportamento: lógica de ataque, rotinas de perseguição, checagem de colisão.

### Exemplos

```csharp
public int Vida;
```

```csharp
public int Energia { get; set; }
```

```csharp
public void Atacar()
{
    Console.WriteLine("O inimigo atacou!");
}
```

### Exemplo Completo

```csharp
class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; } = 100;

    public void SofrerDano(int dano)
    {
        Vida -= dano;
        Console.WriteLine($"{Nome} sofreu {dano} de dano.");
    }
}
```

No desenvolvimento de jogos, atributos e propriedades representam o estado dos personagens e objetos, enquanto os métodos modelam comportamentos e interações.

### Atributos

São campos internos da classe.

```csharp
public int Vida;
```

### Propriedades

Encapsulam leitura e escrita com maior controle.

```csharp
public int Energia { get; set; }
```

### Métodos

Definem ações, como movimentar, atacar ou coletar itens.

```csharp
public void Atacar()
{
    Console.WriteLine("O inimigo atacou!");
}
```

### Exemplo Completo

```csharp
class Personagem
{
    public string Nome { get; set; }
    public int Vida { get; set; } = 100;

    public void SofrerDano(int dano)
    {
        Vida -= dano;
        Console.WriteLine($"{Nome} sofreu {dano} de dano.");
    }
}
```

---

## 3. Construtores e Modificadores de Acesso

### Fundamentação Teórica

Construtores representam rotinas de inicialização, garantindo que objetos sejam criados com estados válidos. Modificadores de acesso definem o nível de visibilidade dos membros da classe, assegurando encapsulamento, segurança e integridade do sistema.

### Importância em Jogos

* Criar personagens já configurados com atributos iniciais.
* Criar itens pré-carregados com valores.
* Controlar acesso para impedir alterações indevidas durante a execução do jogo.

### Construtores

```csharp
class Item
{
    public string Nome { get; set; }
    public int Valor { get; set; }

    public Item(string nome, int valor)
    {
        Nome = nome;
        Valor = valor;
    }
}
```

### Modificadores de Acesso

* **public:** exposto globalmente.
* **private:** exclusivo da classe.
* **protected:** utilizado em herança.
* **internal:** restrito ao assembly.

```csharp
class Cofre
{
    private int ouro = 100;

    public int Coletar()
    {
        return ouro;
    }
}
```

Construtores são utilizados para inicializar objetos automaticamente com valores padrão ou obrigatórios. Modificadores de acesso controlam como atributos e métodos podem ser utilizados dentro ou fora da classe.

### Construtores

```csharp
class Item
{
    public string Nome { get; set; }
    public int Valor { get; set; }

    public Item(string nome, int valor)
    {
        Nome = nome;
        Valor = valor;
    }
}
```

### Modificadores de Acesso

* **public:** Acessível por qualquer código.
* **private:** Restrito à própria classe.
* **protected:** Visível apenas em heranças.
* **internal:** Disponível apenas no mesmo assembly.

```csharp
class Cofre
{
    private int ouro = 100;

    public int Coletar()
    {
        return ouro;
    }
}
```

---

## 4. Demonstração Prática – Hierarquia de Classes

A herança é um componente essencial da POO e permite criar estruturas de entidades reutilizáveis e escaláveis. Em jogos, hierarquias são usadas para categorizar comportamentos similares e reutilizar lógica entre diferentes tipos de personagens, inimigos ou objetos.

### Fundamento Teórico dos Pilares da POO

* **Abstração:** Simplificação de entidades para o essencial.
* **Encapsulamento:** Controle do acesso a dados internos.
* **Herança:** Criação de subclasses que reaproveitam comportamentos de classes base.
* **Polimorfismo:** Capacidade de redefinir comportamentos conforme o tipo específico.

### Aplicações Típicas em Jogos

* `Entidade` → classe base genérica.
* `Heroi`, `Inimigo`, `NPC` → subclasses com comportamentos específicos.
* Implementação simples de polimorfismo via métodos sobrescritos.

### Exemplo de Herança Aplicada à Estrutura de Jogo

```csharp
class Entidade
{
    public string Nome { get; set; }
    public int Vida { get; set; }

    public void MostrarStatus()
    {
        Console.WriteLine($"Nome: {Nome} | Vida: {Vida}");
    }
}

class Heroi : Entidade
{
    public void Atacar()
    {
        Console.WriteLine($"{Nome} realizou um ataque!");
    }
}

class Inimigo : Entidade
{
    public int Dano { get; set; }
}

class Programa
{
    static void Main()
    {
        Heroi heroi = new Heroi { Nome = "Archer", Vida = 120 };
        Inimigo orc = new Inimigo { Nome = "Orc Guerreiro", Vida = 80, Dano = 15 };

        heroi.MostrarStatus();
        orc.MostrarStatus();

        heroi.Atacar();
    }
}
```

Hierarquias são essenciais em jogos para estruturar categorias de entidades, como personagens, NPCs e monstros. Aproveitam o conceito de **herança**, um dos pilares da POO.

### Exemplo de Herança

```csharp
class Entidade
{
    public string Nome { get; set; }
    public int Vida { get; set; }

    public void MostrarStatus()
    {
        Console.WriteLine($"Nome: {Nome} | Vida: {Vida}");
    }
}

class Heroi : Entidade
{
    public void Atacar()
    {
        Console.WriteLine($"{Nome} realizou um ataque!");
    }
}

class Inimigo : Entidade
{
    public int Dano { get; set; }
}

class Programa
{
    static void Main()
    {
        Heroi heroi = new Heroi { Nome = "Archer", Vida = 120 };
        Inimigo orc = new Inimigo { Nome = "Orc Guerreiro", Vida = 80, Dano = 15 };

        heroi.MostrarStatus();
        orc.MostrarStatus();

        heroi.Atacar();
    }
}
```

---

