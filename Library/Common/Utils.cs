using System;
using System.Security.Cryptography;
using System.Text;

namespace Library.Common
{
  /// <summary>
  /// Class utils
  /// </summary>
  public class Utils
  {
    /// <summary>
    /// The PRIVATEKEY.
    /// </summary>
    private const string PRIVATEKEY = "";

    /// <summary>
    /// Encode to MD5
    /// </summary>
    /// <returns>The d5 hash</returns>
    /// <param name="text">Text to encode</param>
    public static string MD5Hash(string text)
    {
      MD5 md5 = new MD5CryptoServiceProvider();

      // compute hash from the bytes of text
      md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text + PRIVATEKEY));

      // get hash result after compute it
      byte[] result = md5.Hash;

      StringBuilder strBuilder = new StringBuilder();
      for (int i = 0; i < result.Length; i++)
      {
        // change it into 2 hexadecimal digits for each byte
        strBuilder.Append(result[i].ToString("x2"));
      }

      return strBuilder.ToString();
    }
  }
}