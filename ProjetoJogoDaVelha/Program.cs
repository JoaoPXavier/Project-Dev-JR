using System;

namespace JogoDaVelha
{
  class Program
  {
    static void Main(string[] args)
    {
      //Menu de seleção do modo de jogo
      Console.WriteLine(" Jogo Da Velha ");
      Console.WriteLine("Escolha o modo de jogo");
      Console.WriteLine("1 - Jogador vs Máquina");
      Console.WriteLine("2 - Máquina vs Máquina");
      Console.WriteLine("3 - Jogador vs Jogador");
      Console.WriteLine("Opção");

      string? escolha = Console.ReadLine();
      bool jogador1Auto = false;
      bool jogador2Auto = false;

      //Define os modos com base na opção escolhida
      switch (escolha)
      {
        case "1":

          jogador1Auto = false;
          jogador2Auto = true;
          break;

        case "2":

          jogador1Auto = true;
          jogador2Auto = true;
          break;

        case "3":

          jogador1Auto = false;
          jogador2Auto = false;
          break;

        default:
          Console.WriteLine("Opção inválida. Padrão: Jogador vs Máquina");
          jogador1Auto = false;
          jogador2Auto = true;
          break;
      }


      //Inicializa e inicia o jogo
      Jogo jogo = new Jogo(jogador1Auto, jogador2Auto);
      jogo.Iniciar();
    }
  }
  public class Jogo
  {
    private Tabuleiro tabuleiro;
    private Jogador jogador1;
    private Jogador jogador2;
    private Jogador jogadorAtual;

    public Jogo(bool jogador1Auto, bool jogador2Auto)
    {
      tabuleiro = new Tabuleiro();
      jogador1 = new Jogador("X", jogador1Auto);
      jogador2 = new Jogador("O", jogador2Auto);
      jogadorAtual = jogador1;
    }

    public void Iniciar()
    {
      while (true)
      {
        tabuleiro.Exibir();
        int posicao;

        if (jogadorAtual.Automatico)
        {
          Console.WriteLine($"Jogador {jogadorAtual.Marcador} (máquina está jogando...");

          Random rand = new Random();
          do
          {
            posicao = rand.Next(0, 9);
          } while (!tabuleiro.Marcar(posicao, jogadorAtual.Marcador));

          System.Threading.Thread.Sleep(800);
        }
        else
        {
          Console.WriteLine($"Jogador {jogadorAtual.Marcador}, Escolha uma posição (0-8): ");
          if (!int.TryParse(Console.ReadLine(), out posicao))
          {
            Console.WriteLine("Entrada inválida.");
            continue;
          }

          if (!tabuleiro.Marcar(posicao, jogadorAtual.Marcador))
          {
            Console.WriteLine("Posição inválida ou ocupada!");
            continue;
          }
        }


        //Verificar vitória ou empate
        if (tabuleiro.VerificarVitoria(jogadorAtual.Marcador))
        {
          tabuleiro.Exibir();
          Console.WriteLine($"Jogador {jogadorAtual.Marcador} venceu!");
          break;
        }

        if (tabuleiro.VerificarEmpate())
        {
          tabuleiro.Exibir();
          Console.WriteLine("Empate!");
          break;
        }

        //Alternar jogador
        jogadorAtual = (jogadorAtual == jogador1) ? jogador2 : jogador1;

      }
    }
  }

  public class Tabuleiro
  {
    private string[] posicoes;

    public Tabuleiro()

    {
      posicoes = new string[9];
      for (int i = 0; i < posicoes.Length; i++)
      {
        posicoes[i] = i.ToString();
      }
    }
    public void Exibir()
    {
      Console.WriteLine("Tabuleiro");
      for (int i = 0; i < 3; i++)
      {
        Console.WriteLine($"{posicoes[i * 3]} | {posicoes[i * 3 + 1]} | {posicoes[i * 3 + 2]}");
        if (i < 2) Console.WriteLine("---+---+---");
      }
      Console.WriteLine();
    }
    public bool Marcar(int posicao, string marcador)
    {
      if (posicao < 0 || posicao > 8 || posicoes[posicao] == "X" || posicoes[posicao] == "O")
      {
        return false;
      }
      posicoes[posicao] = marcador;
      return true;
    }

    //Verifica as combinações de vitórias possíveis
    public bool VerificarVitoria(string marcador)
    {

      return (posicoes[0] == marcador && posicoes[1] == marcador && posicoes[2] == marcador) ||
             (posicoes[3] == marcador && posicoes[4] == marcador && posicoes[5] == marcador) ||
             (posicoes[6] == marcador && posicoes[7] == marcador && posicoes[8] == marcador) ||
             (posicoes[0] == marcador && posicoes[3] == marcador && posicoes[6] == marcador) ||
             (posicoes[1] == marcador && posicoes[4] == marcador && posicoes[7] == marcador) ||
             (posicoes[2] == marcador && posicoes[5] == marcador && posicoes[8] == marcador) ||
             (posicoes[0] == marcador && posicoes[4] == marcador && posicoes[8] == marcador) ||
             (posicoes[2] == marcador && posicoes[4] == marcador && posicoes[6] == marcador);
    }

    //Verifica se todas as posições foram preenchidas
    public bool VerificarEmpate()
    {
      foreach (var posicao in posicoes)
      {
        if (posicao != "X" && posicao != "O")
        {
          return false;
        }
      }
      return true;
    }
  }

  public class Jogador
  {
    public string Marcador { get; private set; }
    public bool Automatico { get; private set; }
    public Jogador(string marcador, bool automatico)
    {
      Marcador = marcador;
      Automatico = automatico;
    }
  }

}