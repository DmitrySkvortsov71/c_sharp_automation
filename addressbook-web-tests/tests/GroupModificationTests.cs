using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupModificationTests : AuthTestBase
  {
    [Test]
    public void GroupModificationTest()
    {
      if (app.Groups.GetGroupsCount() == 0)
        app.Groups.Create(new GroupData(""));

      var oldGroups = app.Groups.GetGroupsList();
      // copy for modified group
      var groupToModify = new GroupData(oldGroups[0].Name)
      {
          Id = oldGroups[0].Id,
          Header = oldGroups[0].Header,
          Footer = oldGroups[0].Footer
      };

      // action
      var newData = new GroupData("modified")
      {
          Header = null,
          Footer = null
      };

      app.Groups.Modify(0, newData);

      // verification
      Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

      var newGroups = app.Groups.GetGroupsList();
      oldGroups[0].Name = newData.Name;
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
      foreach (var group in newGroups)
        if (group.Id == groupToModify.Id)
          Assert.AreNotEqual(groupToModify.Name, group.Name);
    }
  }
}