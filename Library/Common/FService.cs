using System;
using ServiceStack;

namespace Library.Common
{
  /// <summary>
  /// F service.
  /// </summary>
  public class FService : Service
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FService" />
    /// </summary>
    public FService()
    {
      this.RedisConnection = new Library.Common.Data.RedisConnection();
    }

    /// <summary>
    /// Gets the connection.
    /// </summary>
    /// <value>The connection.</value>
    public Data.RedisConnection RedisConnection { get; private set; }

    /// <summary>
    /// Checks the API key.
    /// </summary>
    /// <returns>Not authorized if API key not exists</returns>
    /// <param name="apiKey">API key.</param>
    public HttpError CheckApiKey(string apiKey)
    {
      if (this.RedisConnection.Db.Exists("urn:apikey:" + apiKey) < 1) 
      {
        return new HttpError(System.Net.HttpStatusCode.Unauthorized, "Not authorized");
      }

      return null;
    }
  }
}