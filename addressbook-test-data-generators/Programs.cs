using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      var count = Convert.ToInt32(args[0]);
      var filename = args[1];
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

      if (format == "excel")
      {
        WriteToExcelFile(groups, filename);
      }
      else
      {
        var writer = new StreamWriter(args[1]);
        switch (format)
        {
          case "csv":
            WriteGroupsToCsvFile(groups, writer);
            break;
          case "xml":
            WriteGroupsToXmlFile(groups, writer);
            break;
          case "json":
            WriteGroupsToJsonFile(groups, writer);
            break;
          default:
            Console.Out.WriteLine($"Unrecognized file format: {format}");
            break;
        }

        writer.Close();
      }
    }

    private static void WriteToExcelFile(List<GroupData> groups, string filename)
    {
      var app = new Excel.Application
      {
          Visible = true
      };
      var wb = app.Workbooks.Add();
      var sheet = (Excel.Worksheet)wb.ActiveSheet;

      var row = 1;
      foreach (var group in groups)
      {
        sheet.Cells[row, 1] = group.Name;
        sheet.Cells[row, 2] = group.Header;
        sheet.Cells[row, 3] = group.Footer;
        row++;
      }

      var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
      File.Delete(fullPath);  // if file exists
      wb.SaveAs();
      wb.Close();

      app.Visible = false;
      app.Quit();
    }

    private static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
    {
      writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
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