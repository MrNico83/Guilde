using System;
using Library.BLL.CRUD;
using Library.Common.Data;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace Tests.BLL.CRUD
{
  /// <summary>
  /// User test.
  /// </summary>
  public class UserTest
  {
    /// <summary>
    /// Tests the user.
    /// </summary>
    public static void TestUser()
    {
      RedisConnection cnn = new RedisConnection();
      var redisuser = cnn.Db.As<User>();
      redisuser.FlushDb();

      User u = new User();
      u.UserFirstName = "Nicolas";
      u.UserLastName = "Lautridou";
      u.UserLogin = "nicolas";
      u.SetPassword("toto");
      u.Save(cnn);

      u = new User();
      u.UserFirstName = "Aurore";
      u.UserLastName = "Lautridou";
      u.SetPassword("tata");
      u.Save(cnn);

      redisuser.GetAll().PrintDump();

      u = User.Load(cnn, 1);
      u.PrintDump();

      u.UserFirstName = "nicolas2";
      u.Save(cnn);
      u.PrintDump();

      User toto = User.Login(cnn, "nicolas", "toto");
      toto.UserMail = "nlautridou@i-resa.com";
      toto.PrintDump();

      User toto2 = User.GetUserByApiKey(cnn, toto.UserApiKeys[0]);
      toto2.PrintDump();
    }
  }
}