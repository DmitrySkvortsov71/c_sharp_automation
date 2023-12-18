using System;
using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupRemovalTests : GroupTestBase
  {
    [Test]
    public void GroupRemovalTest()
    {
      // preparation
      if (app.Groups.GetGroupsCount() == 0)
        app.Groups.Create(new GroupData(""));

      var oldGroups = GroupData.GetAll();
      var groupToRemove = oldGroups[0];

      // action
      app.Groups.Remove(groupToRemove);

      // fast verification
      Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

      // full verification
      var newGroups = GroupData.GetAll();
      oldGroups.RemoveAt(0);
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
      foreach (var group in newGroups) Assert.AreNotEqual(groupToRemove.Id, group.Id);
    }
  }
}