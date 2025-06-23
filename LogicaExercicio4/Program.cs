using System; 

namespace IntervaloValores
{
  class Program
  {
    static void Main(string[] args)
    {

      Intervalo intervalo = new Intervalo();
      intervalo.LerValores();
      intervalo.ImprimirResultados();
    }
  }
  //Class that separates counting and validation logic
  class Intervalo
  {
    private int contadorDentro;
    private int contadorFora;
    public Intervalo()
    {
      contadorDentro = 0;
      contadorFora = 0;
    }

    //Reads 10 numbers and sorts them into or out of the range [1, 100]
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
          i--; //Retry on invalid input
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