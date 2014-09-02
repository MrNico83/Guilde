using System;
using ServiceStack.Redis;

namespace Library.Common.Data
{
  /// <summary>
  /// Database connection.
  /// </summary>
  public class RedisConnection
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisConnection" />
    /// </summary>
    public RedisConnection()
    {
      this.Db = new RedisClient("localhost");
    }

    /// <summary>
    /// Gets the database.
    /// </summary>
    /// <value>The database.</value>
    public RedisClient Db { get; private set; }
  }
}