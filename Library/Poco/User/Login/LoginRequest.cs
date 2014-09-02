using System;
using ServiceStack;

namespace Library.Poco.User.Login
{
  /// <summary>
  /// Login request.
  /// </summary>
  [Route("/login")]
  public class LoginRequest
  {
    /// <summary>
    /// Gets or sets the login.
    /// </summary>
    /// <value>The login.</value>
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>The password.</value>
    public string Password { get; set; }
  }
}