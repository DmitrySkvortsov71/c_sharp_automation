﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupCreationTests : GroupTestBase
  {
    public static IEnumerable<GroupData> RandomGroupDataProvider()
    {
      var lenth = 5;
      var randomStringLengh = 5;

      var groups = new List<GroupData>();

      for (var i = 0; i < lenth; i++)
        groups.Add(new GroupData(GenerateRandomString(randomStringLengh))
        {
            Header = GenerateRandomString(2 * randomStringLengh),
            Footer = GenerateRandomString(2 * randomStringLengh)
        });

      return groups;
    }

    public static IEnumerable<GroupData> GroupDataFromCsvFile()
    {
      // to read comma-separated data from a file 

      var groups = new List<GroupData>();

      var lines = File.ReadAllLines(@"groups.csv");
      foreach (var l in lines)
      {
        var parts = l.Split(',');
        groups.Add(new GroupData(parts[0])
        {
            Header = parts[1],
            Footer = parts[2]
        });
      }

      return groups;
    }

    public static IEnumerable<GroupData> GroupDataFromXmlFile()
    {
      return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>))
          .Deserialize(new StreamReader(@"groups.xml"));
    }

    public static IEnumerable<GroupData> GroupDataFromJsonFile()
    {
      return JsonConvert
          .DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
    }

    public static IEnumerable<GroupData> GroupDataFromExcelFile()
    {
      var groups = new List<GroupData>();

      var app = new Application
      {
          Visible = false
      };

      var fullPath = Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx");
      var wb = app.Workbooks.Open(fullPath);
      var sheet = (Worksheet)wb.Sheets[1];

      var range = sheet.UsedRange;
      for (var i = 0; i < range.Rows.Count; i++)
        groups.Add(new GroupData()
        {
            Name = range.Cells[i, 1].ToString(),
            Header = range.Cells[i, 2].ToString(),
            Footer = range.Cells[i, 3].ToString()
        });
      wb.Close();
      app.Quit();

      return groups;
    }


    [Test]
    [TestCaseSource(nameof(GroupDataFromJsonFile))]
    public void GroupCreationTest(GroupData group)
    {
      var oldGroups = GroupData.GetAll();

      app.Groups.Create(group);

      // verification
      Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

      var newGroups = GroupData.GetAll();
      oldGroups.Add(group);
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
    }

    [Test]
    public void TestDbConnectivity()
    {
      var newGroups = app.Groups.GetGroupsList();
      var fromDb = GroupData.GetAll();

      foreach (var contact in GroupData.GetAll()[0].GetContacts()) System.Console.Out.WriteLine(contact);
    }
  }
}