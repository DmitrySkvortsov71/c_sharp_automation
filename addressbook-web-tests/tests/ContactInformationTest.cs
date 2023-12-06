using System.Runtime.Remoting;
using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactInformationTests : AuthTestBase
  {
    [Test]
    public void ContactInformationTest()
    {
      var index = 0;

      var contactFromTable = app.Contacts.GetContactInformationFromTable(index);
      var contactFromEditForm = app.Contacts.GetContactInformationFromEditForm(index);

      // verification

      Assert.AreEqual(contactFromTable, contactFromEditForm); // standard Equals
      Assert.AreEqual(contactFromTable.MainAddress, contactFromEditForm.MainAddress);

      var first = contactFromTable.AllPhones;
      var second = contactFromEditForm.AllPhones;

      Assert.AreEqual(contactFromTable.AllPhones, contactFromEditForm.AllPhones);
    }
    
    [Test]
    public void ContactDetailInformationTest()
    {
      var index = 0;
      
      var contactFromTable = app.Contacts.GetContactInformationFromTable(index);
      var contactDetailedInformationFromDetailPage = app.Contacts.GetContactDetailedInformationFromDetailsPage(index);
      
      Assert.AreEqual(contactFromTable.DetailedInformation, contactDetailedInformationFromDetailPage);

    }    
  }
}