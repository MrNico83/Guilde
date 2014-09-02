using System;

namespace Library.Poco.User.Register
{
  /// <summary>
  /// Register response.
  /// </summary>
  public class RegisterResponse
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