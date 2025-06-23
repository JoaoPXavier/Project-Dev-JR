using System;
namespace IdadeEmDias
{
  //Class representing a person's age with attributes for years, months, and days.
  public class Idade
  {
    //Encapsulated property of age.
    public int Anos { get; private set; }
    public int Meses { get; private set; }
    public int Dias { get; private set; }

    // Age class constructor with validation.

    public Idade(int anos, int meses, int dias)
    {
      //Basic validation to avoid negative values
      if (anos < 0 || meses < 0 || dias < 0)
        throw new ArgumentException("Anos, meses e dias não podem ser negativos.");

      if (meses > 12)
        throw new ArgumentException("Meses devem estar entre 0 e 12.");

      if (dias > 30)
        throw new ArgumentException("Dias devem estar entre 0 e 30.");

      Anos = anos;
      Meses = meses;
      Dias = dias;

    }
    //Calculates total age in days (1 year = 365 days, 1 month = 30 days).

    public int CalcularIdadeEmDias()
    {
      int totalDias = (Anos * 365) + (Meses * 30) + Dias;
      return totalDias;
    }

    public override string ToString()
    {
      return $"{Anos} anos, {Meses} meses e {Dias} dias";
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Console.Title = "Calculadora de Idade em Dias";
      try
      {

        Console.WriteLine("Digite a idade da pessoa:");
        int anos = LerEntradaInt("Anos: ");
        int meses = LerEntradaInt("Meses: ");
        int dias = LerEntradaInt("Dias: ");


        Idade idade = new Idade(anos, meses, dias);


        int idadeEmDias = idade.CalcularIdadeEmDias();


        Console.WriteLine();
        Console.WriteLine($"A idade de {idade} equivale a {idadeEmDias} dias.");
      }
      catch (ArgumentException ex)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Erro: {ex.Message}");
        Console.ResetColor();
      }
      catch (FormatException)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Erro: Entrada inválida, por favor digite números inteiros.");
        Console.ResetColor();
      }
      catch (Exception ex)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Erro inesperado: {ex.Message}");
        Console.ResetColor();
      }
      finally
      {

        Console.WriteLine();
        Console.WriteLine("Precssione qualquer tecla para sair....");
        Console.ReadKey();
      }
    }

    //Method to read valid integers
    private static int LerEntradaInt(string mensagem)
    {
      int valor;
      while (true)
      {
        Console.WriteLine(mensagem);
        string? entrada = Console.ReadLine();

        //Validates if the input is a non-negative integer
        if (int.TryParse(entrada, out valor) && valor >= 0)
          return valor;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Por favor, insira um número inteiro não negativo.");
        Console.ResetColor();
      }
    }

  }

}