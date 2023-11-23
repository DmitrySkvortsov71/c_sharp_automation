using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupCreationTests : AuthTestBase
  {
    [Test]
    public void GroupCreationTest()
    {
      var oldGroups = app.Groups.GetGroupsList();

      var group = new GroupData("bbb")
      {
          Header = "bbb header",
          Footer = "bbb footer"
      };
      app.Groups.Create(group);

      // verification
      Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

      var newGroups = app.Groups.GetGroupsList();
      oldGroups.Add(group);
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
    }

    [Test]
    public void EmptyGroupCreationTest()
    {
      // preparation
      var oldGroups = app.Groups.GetGroupsList();

      // action
      var group = new GroupData("")
      {
          Header = "",
          Footer = ""
      };
      app.Groups.Create(group);

      // fast verification
      Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

      // full verification
      var newGroups = app.Groups.GetGroupsList();
      oldGroups.Add(group);
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
      
    }
  }
}