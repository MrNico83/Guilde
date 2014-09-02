using Funq;
using ServiceStack;
using ServiceStack.Text;

namespace Api
{
  /// <summary>
  /// App host.
  /// </summary>
  public class AppHost : AppSelfHostBase
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AppHost" />
    /// </summary>
    public AppHost() 
      : base("HttpListener Self-Host", typeof(User.Login.LoginService).Assembly) 
    {
    }

    /// <summary>
    /// Configuration du host
    /// </summary>
    /// <param name="container">COntainer de la config</param>
    public override void Configure(Container container)
    {
      // Configuration du JSON de sortie
      JsConfig.EmitCamelCaseNames = true;
      JsConfig.DateHandler = DateHandler.DCJSCompatible;
    }
  }
}
