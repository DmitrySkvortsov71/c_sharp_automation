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
      // 0. data's type (groups/contacts)
      // 1. objects' quantity
      // 2 file name
      // 3. file format

      const int numberMin = 1111111;
      const int numberMax = 9999999;

      var type = args[0];
      var count = Convert.ToInt32(args[1]);
      var filename = args[2];
      var format = args[3];

      var groups = new List<GroupData>();
      var contacts = new List<ContactData>();

      // generate data
      if (type != "groups" && type != "contacts")
      {
        Console.Out.WriteLine($"Unrecognized data format: {type}");
        return;
      }

      if (type == "groups")
        for (var i = 0; i < count; i++)
          groups.Add(new GroupData(
                  TestBase.GenerateRandomString(10))
              {
                  Header = TestBase.GenerateRandomString(20),
                  Footer = TestBase.GenerateRandomString(20)
              }
          );
      if (type == "contacts")
        for (var i = 0; i < count; i++)
          contacts.Add(new ContactData()
          {
              FirstName = TestBase.GenerateRandomString(10),
              LastName = TestBase.GenerateRandomString(10),
              EMail = $"{TestBase.GenerateRandomString(10)}@g.com",
              MainAddress = TestBase.GenerateRandomString(20),
              MobilePhone = TestBase.GenerateRandomNumber(numberMin, numberMax),
              HomePhone = TestBase.GenerateRandomNumber(numberMin, numberMax),
              WorkPhone = TestBase.GenerateRandomNumber(numberMin, numberMax),
              AllPhones = "",
              DetailsInformation = ""
          });


      // write data into file
      if (format == "excel")
      {
        WriteToExcelFile(groups, filename);
      }
      else
      {
        var writer = new StreamWriter(filename);

        switch (format)
        {
          case "csv":
            WriteGroupsToCsvFile(groups, writer);
            break;
          case "xml":
          {
            if (type == "groups") WriteGroupsToXmlFile(groups, writer);
            if (type == "contacts") WriteContactsToXmlFile(contacts, writer);
          }
            break;
          case "json":
          {
            if (type == "groups") WriteGroupsToJsonFile(groups, writer);
            if (type == "contacts") WriteContactsToJsonFile(contacts, writer);
          }
            break;
          default:
            Console.Out.WriteLine($"Unrecognized file format: {format}");
            break;
        }

        writer.Close();
      }
    }


    private static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
    {
      writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
    }

    private static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
    {
      writer.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
    }

    private static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
    {
      foreach (var group in groups) writer.WriteLine($"{group.Name},{group.Header},{group.Footer}");
    }

    private static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
    {
      new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
    }

    private static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
    {
      new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
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
      File.Delete(fullPath); // if file exists
      wb.SaveAs();
      wb.Close();

      app.Visible = false;
      app.Quit();
    }
  }
}