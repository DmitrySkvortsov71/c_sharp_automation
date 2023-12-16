using NUnit.Framework;

namespace WebAddressbookTests
{
  public class GroupTestBase : AuthTestBase
  {
    [TearDown]
    public void CompareGroupsInUiToDb()
    {
      if (PerformLongUiCheck)
      {
        var groupsFromUi = app.Groups.GetGroupsList();
        var groupsFromDb = GroupData.GetAll();

        groupsFromUi.Sort();
        groupsFromDb.Sort();

        Assert.AreEqual(groupsFromUi, groupsFromDb);
      }
    }
  }
}