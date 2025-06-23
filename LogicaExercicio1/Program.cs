using System;
namespace IdadeEmDias
{
  //Classe que representa a idade de uma pessoa com atributos para anos, meses e dias.
  public class Idade
  {
    //Propriedade encapsulada da idade
    public int Anos { get; private set; }
    public int Meses { get; private set; }
    public int Dias { get; private set; }

    // Construtor da classe idade com validação

    public Idade(int anos, int meses, int dias)
    {
      // Validação básica para evitar valores negativos
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
    // Calcula a idade total em dias (1 ano = 365 dias, 1 mês = 30 dias)


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

    //Metodo para ler inteiros válidados
    private static int LerEntradaInt(string mensagem)
    {
      int valor;
      while (true)
      {
        Console.WriteLine(mensagem);
        string? entrada = Console.ReadLine();

        //Valida se a entrada é um inteiro não negativo
        if (int.TryParse(entrada, out valor) && valor >= 0)
          return valor;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Por favor, insira um número inteiro não negativo.");
        Console.ResetColor();
      }
    }

  }

}