using Library.Common;
using Library.Poco.User;
using ServiceStack;
using BLL = Library.BLL.CRUD;

namespace Api.User
{
  /// <summary>
  /// User service.
  /// </summary>
  public class UserService : FService
  {
    /// <summary>
    /// Get the specified request.
    /// </summary>
    /// <param name="request">the request.</param>
    /// <returns>The response</returns>
    public object Get(UserRequest request)
    {
      HttpError error = this.CheckApiKey(request.ApiKey);
      if (error != null) 
      {
        return error;
      }

      // load user
      BLL.User user = BLL.User.GetUserByApiKey(this.RedisConnection, request.ApiKey);

      UserResponse response = new UserResponse();
      response.User = user;

      return response;
    }

    /// <summary>
    /// Update the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The response</returns>
    public object Put(UserRequest request)
    {
      HttpError error = this.CheckApiKey(request.ApiKey);
      if (error != null) 
      {
        return error;
      }

      // load user
      BLL.User user = BLL.User.GetUserByApiKey(this.RedisConnection, request.ApiKey);

      // update user
      user.UserFirstName = request.FirstName;
      user.UserLastName = request.LastName;
      user.UserLogin = request.Login;
      user.UserMail = request.Email;
      user.SetPassword(request.Password);
      user.Save(this.RedisConnection);

      UserResponse response = new UserResponse();
      response.User = user;

      return response;
    }
  }
}