using Library.Common;
using Library.Poco.User.Register;
using ServiceStack;
using System.Linq;
using BLL = Library.BLL.CRUD;

namespace Api.User.Register
{
  /// <summary>
  /// Register service.
  /// </summary>
  public class RegisterService : FService
  {
    /// <summary>
    /// Post the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The response</returns>
    public object Post(RegisterRequest request)
    {
      // check param
      if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password)) 
      {
        return new HttpError(System.Net.HttpStatusCode.BadRequest, "Required parameters missing");
      }

      if (this.RedisConnection.Db.As<BLL.User>().GetAll().Any(u => u.UserMail == request.Email)) 
      {
        return new HttpError(System.Net.HttpStatusCode.Ambiguous, "Email already exists");
      }

      BLL.User user = new BLL.User()
      {
        UserFirstName = request.FirstName,
        UserLastName = request.LastName,
        UserLogin = request.Login,
        UserMail = request.Email
      };

      user.SetPassword(request.Password);
      user.Save(this.RedisConnection);

      Library.Poco.User.Register.RegisterResponse response = new Library.Poco.User.Register.RegisterResponse();
      response.User = user;
      response.ApiKey = user.GetNewApiKey(this.RedisConnection);

      return response;
    }
  }
}