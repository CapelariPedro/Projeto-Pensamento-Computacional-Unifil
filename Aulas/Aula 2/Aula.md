# Aula 2 – Ambiente e Lógica em C#

## 1. Instalação e Configuração do Visual Studio Community

* Acesso ao site oficial da Microsoft para download.
* Seleção da versão **Visual Studio Community** (gratuita para uso acadêmico e individual).
* Escolha do instalador adequado para Windows.
* Execução do instalador e seleção das *workloads* necessárias.
* Inclusão dos seguintes componentes recomendados:

  * .NET Desktop Development.
  * Ferramentas de desenvolvimento C#.
  * SDK .NET mais recente.
  * Extensões opcionais para produtividade (ex.: IntelliCode).
* Configuração inicial pós-instalação:

  * Definição do tema do editor.
  * Ajuste de atalhos conforme padrão Visual Studio.
  * Configuração de formatação automática do código.
  * Personalização da estrutura de diretórios dos projetos.
* Verificação do ambiente executando um projeto *Console App* de teste.

---

## 2. Introdução à Lógica de Programação em C#

### Fundamentos Teóricos

* Lógica como base do pensamento computacional.
* Construção de algoritmos a partir de problemas do mundo real.
* Paradigma orientado a objetos aplicado como forma de estruturar códigos em jogos.
* Relação entre lógica, mecânicas de jogo e ciclos de atualização (*game loop*).

### Conceitos Fundamentais

* Variáveis como elementos dinâmicos do estado do jogo.
* Operadores para manipulação de atributos (ex.: vida, energia, pontuação).
* Estruturas condicionais para tomada de decisão em tempo real.
* Estruturas de repetição para modelagem de ciclos e comportamentos contínuos.

### Exemplos Aplicados à Programação de Jogos

#### Estrutura Sequencial

```csharp
using System;

class Programa
{
    static void Main()
    {
        Console.WriteLine("Digite a pontuação inicial do jogador:");
        int pontuacao = int.Parse(Console.ReadLine());

        pontuacao = pontuacao + 10; // Power-up

        Console.WriteLine($"Pontuação atualizada: {pontuacao}");
    }
}
```

#### Estrutura Condicional

```csharp
using System;

class Programa
{
    static void Main()
    {
        Console.WriteLine("Digite a vida do personagem:");
        int vida = int.Parse(Console.ReadLine());

        if (vida <= 0)
        {
            Console.WriteLine("Game Over!");
        }
        else
        {
            Console.WriteLine("Continue lutando!");
        }
    }
}
```

#### Estrutura de Repetição

```csharp
using System;

class Programa
{
    static void Main()
    {
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine($"Iniciando em {i}...");
        }

        Console.WriteLine("GO!");
    }
}
```

---

## 3. Estrutura Básica da Linguagem C#

### Conceitos Fundamentais

A estrutura básica de um programa em C# segue um padrão modular orientado a objetos. A linguagem organiza o código em *namespaces*, classes e métodos, garantindo escalabilidade, encapsulamento e manutenção consistente — requisitos essenciais em projetos de jogos eletrônicos.

### Declaração de Variáveis

Variáveis representam estados mutáveis no jogo, como vida, energia, munição ou pontuação. Em C#, toda variável precisa ser declarada com um tipo, garantindo segurança de tipos e previsibilidade em tempo de compilação.

* **Tipos primitivos**: `int`, `float`, `double`, `bool`, `char`.
* **Tipos compostos**: classes, structs e arrays.
* **Boas práticas**:

  * Usar nomes descritivos.
  * Controlar escopo para evitar conflitos.
  * Inicializar variáveis sempre que possível.

#### Exemplo

```csharp
int vida = 100;
bool gameOver = false;
string nomeJogador = "Archer";
```

### Estruturas Condicionais

Representam tomadas de decisão no fluxo do jogo, como detectar colisões, checar fim de fase ou validar ações do usuário. Condicionais são blocos lógicos que guiam o comportamento do jogo conforme o estado do sistema.

* **if / else**: decisão binária.
* **else if**: múltiplas condições.
* **switch**: decisões baseadas em valores categóricos.

#### Exemplo

```csharp
if (vida <= 0)
{
    Console.WriteLine("Game Over");
}
else if (vida < 20)
{
    Console.WriteLine("Vida crítica!");
}
else
{
    Console.WriteLine("Estado estável.");
}
```

### Laços de Repetição

Utilizados para modelar comportamentos contínuos, como loops de atualização, movimentação de inimigos e verificações recorrentes.

* **for**: repetição com contador.
* **while**: repetição condicionada.
* **foreach**: iteração sobre coleções.

#### Exemplo

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Spawnando inimigo {i}");
}
```

### Funções (Métodos)

Funções encapsulam comportamentos, permitindo modularidade, reutilização e testabilidade — pilares da programação orientada a objetos aplicada a jogos.

* Reduzem duplicação de código.
* Organizam responsabilidades.
* Permitem criar comportamentos de personagens, IA, física e regras do jogo.

#### Exemplo

```csharp
static int CalcularDano(int ataqueBase, int multiplicador)
{
    return ataqueBase * multiplicador;
}
```

---

## 4. Criação do Primeiro Projeto de Console

* Passo a passo para gerar um projeto *Console App*.
* Geração de estrutura base.
* Execução, depuração e leitura da saída.
* Ajustes no `Program.cs` conforme boas práticas de desenvolvimento orientado a objetos.

### Script Exemplo – Simulação Inicial de Personagem

```csharp
using System;

namespace RPGConsole
{
    class Personagem
    {
        public string Nome { get; set; }
        public int Vida { get; set; } = 100;
    }

    class Programa
    {
        static void Main()
        {
            Personagem heroi = new Personagem();

            Console.WriteLine("Digite o nome do herói:");
            heroi.Nome = Console.ReadLine();

            Console.WriteLine($"Herói criado: {heroi.Nome} | Vida: {heroi.Vida}");
        }
    }
}
```

---

