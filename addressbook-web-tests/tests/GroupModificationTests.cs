using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class GroupModificationTests : GroupTestBase
  {
    [Test]
    public void GroupModificationTest()
    {
      if (app.Groups.GetGroupsCount() == 0)
        app.Groups.Create(new GroupData(""));

      // var oldGroups = app.Groups.GetGroupsList();
      var oldGroups = GroupData.GetAll();
      
      // copy for modified group
      var groupToModify = new GroupData(oldGroups[0].Name)
      {
          Id = oldGroups[0].Id,
          Header = oldGroups[0].Header,
          Footer = oldGroups[0].Footer
      };

      // action
      var newGroupData = new GroupData("modified")
      {
          Header = null,
          Footer = null
      };

      app.Groups.Modify(groupToModify, newGroupData);

      // verification
      Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

      // var newGroups = app.Groups.GetGroupsList();
      var newGroups = GroupData.GetAll();
      
      oldGroups[0].Name = newGroupData.Name;
      oldGroups.Sort();
      newGroups.Sort();

      Assert.AreEqual(oldGroups, newGroups);
      foreach (var group in newGroups)
        if (group.Id == groupToModify.Id)
          Assert.AreNotEqual( group.Name, groupToModify.Name);
    }
  }
}