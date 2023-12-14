using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
  public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
  {
    private string e_mail;
    private string first_name;
    private string last_name;
    private string main_address = "";
    private string mobile_phone = "";
    private string second_address = "";
    private string work_phone = "";
    private string all_phones;
    private string detailsInformation;

    public ContactData(string first_name, string last_name, string e_mail)
    {
      this.first_name = first_name;
      this.last_name = last_name;
      this.e_mail = e_mail;
    }

    // for data generators
    public ContactData()
    {
    }

    public string FirstName
    {
      get => first_name;
      set => first_name = value;
    }

    public string LastName
    {
      get => last_name;
      set => last_name = value;
    }

    public string EMail
    {
      get => e_mail;
      set => e_mail = value;
    }

    public string DetailsInformation
    {
      set => detailsInformation = value;
      get
      {
        if (detailsInformation != null)
        {
          return detailsInformation;
        }
        else
        {
          // non trimmed way to construct Details

          detailsInformation = "";
          var mobile = !string.IsNullOrWhiteSpace(MobilePhone);
          var home = !string.IsNullOrWhiteSpace(HomePhone);
          var work = !string.IsNullOrWhiteSpace(WorkPhone);
          var first = !string.IsNullOrWhiteSpace(FirstName);
          var last = !string.IsNullOrWhiteSpace(LastName);
          var address = !string.IsNullOrWhiteSpace(MainAddress);
          var email = !string.IsNullOrWhiteSpace(EMail);

          if (first && last)
          {
            detailsInformation += $"{FirstName} {LastName}";
          }
          else
          {
            if (first) detailsInformation += FirstName;
            if (last) detailsInformation += LastName;
          }

          if ((first || last) && address) detailsInformation += $"\r\n";

          if (address) detailsInformation += $"{MainAddress}";
          if ((first || last || address) && (mobile || home || work)) detailsInformation += $"\r\n\r\n";

          if (home) detailsInformation += $"H: {HomePhone}";
          if (home && (mobile || work)) detailsInformation += $"\r\n";

          if (mobile) detailsInformation += $"M: {MobilePhone}";
          if (mobile && work) detailsInformation += $"\r\n";

          if (work) detailsInformation += $"W: {WorkPhone}";

          if ((first || last || address || home || mobile || work) && email) detailsInformation += $"\r\n\r\n";
          if (email) detailsInformation += $"{EMail}";

          return detailsInformation;

          // trimmed Details info (without "\r\n")

          // detailsInformation = "";
          //
          // if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
          // {
          //   detailsInformation += $"{FirstName} {LastName}";
          // }
          // else
          // {
          //   if (!string.IsNullOrWhiteSpace(FirstName)) detailsInformation += FirstName;
          //   if (!string.IsNullOrWhiteSpace(LastName)) detailsInformation += LastName;
          // }
          //
          // if (!string.IsNullOrWhiteSpace(MainAddress)) detailsInformation += $"{MainAddress}";
          // if (!string.IsNullOrWhiteSpace(HomePhone)) detailsInformation += $"H: {HomePhone}";
          // if (!string.IsNullOrWhiteSpace(MobilePhone)) detailsInformation += $"M: {MobilePhone}";
          // if (!string.IsNullOrWhiteSpace(WorkPhone)) detailsInformation += $"W: {WorkPhone}";
          // if (!string.IsNullOrWhiteSpace(EMail)) detailsInformation += $"{EMail}";
          //return detailsInformation;
        }
      }
    }

    // all phones by one record
    public string AllPhones
    {
      set => all_phones = value;
      get
      {
        if (all_phones != null)
          return all_phones;
        else
          return (PhoneFieldCleanUp(HomePhone) + PhoneFieldCleanUp(MobilePhone)
                                               + PhoneFieldCleanUp(WorkPhone)).Trim();
      }
    }

    private string PhoneFieldCleanUp(string phoneField)
    {
      if (string.IsNullOrEmpty(phoneField))
        return "";
      else
          // return phoneField.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        return Regex.Replace(phoneField, "[ -()]", "") + "\r\n";
    }

    public string HomePhone { set; get; }

    public string MobilePhone
    {
      get => mobile_phone;
      set => mobile_phone = value;
    }

    public string WorkPhone
    {
      get => work_phone;
      set => work_phone = value;
    }

    public string MainAddress
    {
      get => main_address;
      set => main_address = value;
    }

    public string SecondAddress
    {
      get => second_address;
      set => second_address = value;
    }

    public bool Equals(ContactData other)
    {
      if (ReferenceEquals(other, null)) return false;
      if (ReferenceEquals(this, other)) return true;

      if (FirstName == other.FirstName && LastName == other.LastName) return true;
      else
        return false;
    }

    public int CompareTo(ContactData other)
    {
      if (ReferenceEquals(other, null)) return 1;

      var compareLastName = LastName.CompareTo(other.LastName);
      return compareLastName != 0 ? compareLastName : FirstName.CompareTo(other.FirstName);
    }

    public override string ToString()
    {
      return $"first name: {FirstName} | last name: {LastName} | e-mail: {EMail} |" +
             $"home phone: {HomePhone} | mobile: {MobilePhone} | work phone: {WorkPhone} |" +
             $"address: {MainAddress}";
    }
  }
}