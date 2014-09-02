using System.Configuration;
using ServiceStack;

namespace UnitTest
{
  /// <summary>
  /// Class de base des test
  /// </summary>
  public class BaseTest
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="BaseTest" />
    /// </summary>
    public BaseTest()
    {
      this.WebService = new JsonServiceClient(ConfigurationManager.AppSettings["UrlWebService"]);
    }

    /// <summary>
    /// Accès au web service
    /// </summary>
    public JsonServiceClient WebService { get; set; }
  }
}
