using Library.Common;
using Library.Poco.User.Login;
using ServiceStack;
using BLL = Library.BLL.CRUD;

namespace Api.User.Login
{
  /// <summary>
  /// Login service.
  /// </summary>
  public class LoginService : FService
  {
    /// <summary>
    /// Get the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The response</returns>
    public object Post(LoginRequest request)
    {
      BLL.User u = BLL.User.Login(this.RedisConnection, request.Login, request.Password);

      if (u == null) 
      {
        return new HttpError(System.Net.HttpStatusCode.BadRequest, "Bad Login or password");
      }

      LoginResponse response = new LoginResponse();
      response.User = u;
      response.ApiKey = u.GetNewApiKey(this.RedisConnection);

      return response;
    }
  }
}