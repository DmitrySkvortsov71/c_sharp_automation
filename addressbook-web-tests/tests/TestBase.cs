using System;
using System.Text;
using NUnit.Framework;

namespace WebAddressbookTests
{
  public class TestBase
  {
    public ApplicationManager app;

    [SetUp]
    public void SetupApplicationManager()
    {
      app = ApplicationManager.GetInstance();
    }

    public static readonly Random Rnd = new Random();

    public static string GenerateRandomString(int randomStringLenght)
    {
      var l = Convert.ToInt32(Rnd.NextDouble() * randomStringLenght);
      var builder = new StringBuilder();

      for (var i = 0; i < l; i++) builder.Append(Convert.ToChar(32 + Convert.ToInt32(Rnd.NextDouble() * 223 + 32)));

      return builder.ToString();
    }

    public static string GenerateRandomNumber(int min, int max)
    {
      return Convert.ToString(Rnd.Next(min, max));
    }
  }
}