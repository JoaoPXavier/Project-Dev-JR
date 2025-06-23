using System; //Importa funcionalidade básicas do .NET

//Define o namespace do projeto
namespace IntervaloValores
{
  //Classe principal que contém o ponto de entrada do programa
  class Program
  {
    static void Main(string[] args)
    {

      Intervalo intervalo = new Intervalo();
      intervalo.LerValores();
      intervalo.ImprimirResultados();
    }
  }
  //Classe que separa lógica de contagem e validação
  class Intervalo
  {
    private int contadorDentro;
    private int contadorFora;
    public Intervalo()
    {
      contadorDentro = 0;
      contadorFora = 0;
    }

    //Lê 10 números e classifica dentro ou fora do intervalo [1, 100]
    public void LerValores()
    {
      for (int i = 1; i <= 10; i++)
      {
        Console.Write($"Digite o valor {i}: ");
        if (int.TryParse(Console.ReadLine(), out int valor))
        {
          if (valor >= 1 && valor <= 100)
          {
            contadorDentro++;
          }
          else
          {
            contadorFora++;
          }
        }
        else
        {
          Console.WriteLine("Valor inválido. Por favor, insira um número inteiro");
          i--; // Repetição em caso de entrada inválida
        }
      }
    }
    public void ImprimirResultados()
    {
      Console.WriteLine($"Quantidade de valores dentro do intervalo[1, 100]: {contadorDentro}");
      Console.WriteLine($"Quantidade de valores fora do intervalo [1, 100]: {contadorFora}");
    }
  }
}