using System;

namespace Tests
{
  /// <summary>
  /// Main class.
  /// </summary>
  public class MainClass
  {
    /// <summary>
    /// The entry point of the program, where the program control starts and ends.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
      // test user
      BLL.CRUD.UserTest.TestUser();
    }
  }
}