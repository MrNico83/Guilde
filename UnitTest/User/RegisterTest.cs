using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Poco.User.Register;

namespace UnitTest.User
{
  /// <summary>
  /// Class pour tester l'inscription
  /// </summary>
  [TestClass]
  public class RegisterTest : BaseTest
  {
    /// <summary>
    /// Test de l'inscription
    /// </summary>
    [TestMethod]
    public void TestRegister()
    {
      RegisterRequest request = new RegisterRequest()
      {
        Email = "nlautridou@i-resa.com",
        FirstName = "Nicolas",
        LastName = "Lautridou",
        Login = "nicolas",
        Password = "kikoulol",
      };

      try
      {
        RegisterResponse response = this.WebService.Post<RegisterResponse>(request);
        
        Assert.AreNotEqual(response.ApiKey, string.Empty);
        Assert.IsNotNull(response.User);
        Assert.IsTrue(response.User.UserFirstName == "Nicolas", "Bad firstname");
        Assert.IsTrue(response.User.UserLastName == "Lautridou", "Bad lastname");
        Assert.IsTrue(response.User.UserMail == "nlautridou@i-resa.com", "Bad email");
        Assert.IsTrue(response.User.UserLogin == "nicolas", "Bad login");
      }
      catch(Exception e)
      {
        Assert.Fail(e.Message);
      }
    }
  }
}
