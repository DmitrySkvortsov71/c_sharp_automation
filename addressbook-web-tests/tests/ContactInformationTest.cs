using System.Runtime.Remoting;
using NUnit.Framework;

namespace WebAddressbookTests
{
  [TestFixture]
  public class ContactInformationTests : ContactTestBase
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
    public void ContactDetailsVsEditFormInformationTest()
    {
      // compare Contact Edit Form Info & Contact Details Page info

      var index = 0;

      var contactFromEditForm = app.Contacts.GetContactInformationFromEditForm(index);
      var contactDetailedInformation = app.Contacts.GetContactDetailedInformationFromDetailsPage(index);

      Assert.AreEqual(contactFromEditForm.DetailsInformation, contactDetailedInformation);
    }
  }
}