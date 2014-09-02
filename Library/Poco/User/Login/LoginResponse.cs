using System;

namespace Library.Poco.User.Login
{
  /// <summary>
  /// Login response.
  /// </summary>
  public class LoginResponse
  {
    /// <summary>
    /// Gets or sets the API key.
    /// </summary>
    /// <value>The API key.</value>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>The user.</value>
    public Library.BLL.CRUD.User User { get; set; }
  }
}