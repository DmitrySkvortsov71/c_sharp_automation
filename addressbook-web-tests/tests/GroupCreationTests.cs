using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupCreationTests : AuthTestBase
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

    public static IEnumerable<GroupData> GroupDataFromFile()
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
            Footer = parts[2],
        });
      }
      
      return groups;
    }


    [Test]
    [TestCaseSource(nameof(GroupDataFromFile))]
    public void GroupCreationTest(GroupData group)
    {
      var oldGroups = app.Groups.GetGroupsList();

      app.Groups.Create(group);

      // verification
      Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

      var newGroups = app.Groups.GetGroupsList();
      oldGroups.Add(group);
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
    }
  }
}