using System;
using System.Collections.Generic;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace addressbook_test_data_generators
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var count = Convert.ToInt32(args[0]);
      var writer = new StreamWriter(args[1]);
      var format = args[2];

      var groups = new List<GroupData>();

      for (var i = 0; i < count; i++)
        groups.Add(new GroupData(
                TestBase.GenerateRandomString(10))
            {
                Header = TestBase.GenerateRandomString(20),
                Footer = TestBase.GenerateRandomString(20)
            }
        );

      switch (format)
      {
        case "csv":
          WriteGroupsToCsvFile(groups, writer);
          break;
        case "xml":
          WriteGroupsToXmlFile(groups, writer);
          break;
        default:
          Console.Out.WriteLine($"Unrecognized file format: {format}");
          break;
      }
      writer.Close();
      
    }

    private static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
    {
      foreach (var group in groups) writer.WriteLine($"{group.Name},{group.Header},{group.Footer}");
    }

    private static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
    {
      new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
    }
  }
}