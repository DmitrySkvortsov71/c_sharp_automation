using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupRemovalTests : AuthTestBase
  {
    [Test]
    public void GroupRemovalTest()
    {
      // preparation
      if (app.Groups.GetGroupsCount() == 0)
        app.Groups.Create(new GroupData(""));
      
      var oldGroups = app.Groups.GetGroupsList();
      var groupToRemove = oldGroups[0];

      // action
      app.Groups.Remove(0);

      // fast verification
      Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

      // full verification
      var newGroups = app.Groups.GetGroupsList();
      oldGroups.RemoveAt(0);
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
      foreach (var group in newGroups) Assert.AreNotEqual(groupToRemove.Id, group.Id);
    }
  }
}