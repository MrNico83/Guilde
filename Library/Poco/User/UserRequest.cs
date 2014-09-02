using System;
using ServiceStack;

namespace Library.Poco.User
{
  /// <summary>
  /// User request.
  /// </summary>
  [Route("/user/{ApiKey}")]
  public class UserRequest
  {
    /// <summary>
    /// Gets or sets the API key.
    /// </summary>
    /// <value>The API key.</value>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>The first name.</value>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>The last name.</value>
    public string LastName { get; set; }

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