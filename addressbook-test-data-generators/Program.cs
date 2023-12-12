using System;
using WebAddressbookTests;
using System.IO;
using System.Text;

namespace addressbook_test_data_generators
{
  internal class Programm
  {
    public static void Main(string[] args)
    {
      var count = Convert.ToInt32(args[0]);
      StreamWriter writer = new StreamWriter(args[1]);

      for (var i = 0; i < count; i++)
      {
        writer.WriteLine(
            $"{i}_{TestBase.GenerateRandomString(5)},{TestBase.GenerateRandomString(20)}," +
            $"{TestBase.GenerateRandomString(20)}"
            );
      }
      
      writer.Close();
    }
  }
}