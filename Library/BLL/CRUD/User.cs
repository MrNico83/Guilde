using System;
using System.Collections.Generic;
using System.Linq;
using Library.Common.Data;
using ServiceStack;

namespace Library.BLL.CRUD
{
  /// <summary>
  /// User class
  /// </summary>
  public class User
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="User" />
    /// </summary>
    public User()
    {
      this.UserApiKeys = new List<string>();
    }

    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public long Id { get; set; }

    /// <summary>
    /// Gets the user API keys.
    /// </summary>
    /// <value>The user API keys.</value>
    public List<string> UserApiKeys { get; private set; }

    /// <summary>
    /// Gets or sets the fist name of the user
    /// </summary>
    public string UserFirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user
    /// </summary>
    public string UserLastName { get; set; }

    /// <summary>
    /// Gets or sets the user login.
    /// </summary>
    /// <value>The user login.</value>
    public string UserLogin { get; set; }

    /// <summary>
    /// Gets or sets the user mail.
    /// </summary>
    /// <value>The user mail.</value>
    public string UserMail { get; set; }

    /// <summary>
    /// Gets the user password.
    /// </summary>
    /// <value>The user password.</value>
    public string UserPassword { get; private set; }

    /// <summary>
    /// Gets the user by API key.
    /// </summary>
    /// <returns>The user by API key.</returns>
    /// <param name="cnn">Connection to database</param>
    /// <param name="apiKey">API key.</param>
    public static User GetUserByApiKey(RedisConnection cnn, string apiKey)
    {
      long userId = 0;
      long.TryParse(cnn.Db.GetEntry("urn:apikey:" + apiKey), out userId);

      if (userId > 0) 
      {
        return Load(cnn, userId);
      }

      return null;
    }

    /// <summary>
    /// Load the specified user by ID.
    /// </summary>
    /// <param name="cnn">Connection to database</param>
    /// <param name="id">Identifier of user</param>
    /// <returns>User loaded</returns>
    public static User Load(RedisConnection cnn, long id)
    {
      var redisuser = cnn.Db.As<User>();
      User user = redisuser.GetById(id);
      return user;
    }

    /// <summary>
    /// Login user
    /// </summary>
    /// <param name="cnn">Connection to database</param>
    /// <param name="login">User login</param>
    /// <param name="mdp">User password</param>
    /// <returns>User logged</returns>
    public static User Login(RedisConnection cnn, string login, string mdp)
    {
      string mdpEncode = Common.Utils.MD5Hash(mdp);
      var redisUsers = cnn.Db.As<User>();
      User user = redisUsers.GetAll().FirstOrDefault(u => u.UserLogin == login && u.UserPassword == mdpEncode);

      if (user == null)
      {
        return null;
      }

      // génère api key
      user.GetNewApiKey(cnn);
      return user;
    }

    /// <summary>
    /// Gets the new API key.
    /// </summary>
    /// <returns>The new API key.</returns>
    /// <param name="cnn">Connection to database</param>
    public string GetNewApiKey(RedisConnection cnn)
    {
      // delete the older api key
      if (this.UserApiKeys.Count >= 20) 
      {
        string old = this.UserApiKeys[0];

        // delete old api key
        cnn.Db.Remove("urn:apikey:" + old);

        // remove from list
        this.UserApiKeys.RemoveAt(0);
      }

      string apiKey = Guid.NewGuid().ToString();

      // add to apikey
      cnn.Db.Add("urn:apikey:" + apiKey, this.Id);

      // add to list
      this.UserApiKeys.Add(apiKey);
      this.Save(cnn);
      return apiKey;
    }

    /// <summary>
    /// Save the specified user.
    /// </summary>
    /// <param name="cnn">Connection to database</param>
    public void Save(RedisConnection cnn)
    {
      var redisuser = cnn.Db.As<User>();

      if (this.Id < 1) 
      {
        this.Id = redisuser.GetNextSequence();
      }

      redisuser.Store(this);
    }

    /// <summary>
    /// Sets the password.
    /// </summary>
    /// <param name="pwd">The password</param>
    public void SetPassword(string pwd)
    {
      this.UserPassword = Common.Utils.MD5Hash(pwd);
    }
  }
}