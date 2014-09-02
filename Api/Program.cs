using System;
using ServiceStack;

namespace Api
{
  /// <summary>
  /// The program.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// The entry point of the program, where the program control starts and ends.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
      var listeningOn = args.Length == 0 ? "http://*:1337/" : args[0];
      var appHost = new AppHost().Init().Start(listeningOn);

      Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);

      while (Console.ReadLine() != "q")
      {
        Console.WriteLine(".");
      }
    }
  }
}