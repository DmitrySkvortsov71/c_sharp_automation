using System;

namespace WebAddressbookTests
{
  public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
  {
    private string header = "";
    private string footer = "";

    public GroupData(string name)
    {
      Name = name;
      Header = header;
      Footer = footer;
    }

    public string Name { get; set; }

    public string Header { get; set; }

    public string Footer { get; set; }

    public string Id { get; set; }

    public bool Equals(GroupData other)
    {
      if (ReferenceEquals(other, null)) return false;
      if (ReferenceEquals(this, other)) return true;

      // comment hash ..., if you don't need it. 
      // if (GetHashCode() != other.GetHashCode()) return false;

      return Name.Equals(other.Name, StringComparison.Ordinal);
    }

    public int CompareTo(GroupData other)
    {
      if (ReferenceEquals(other, null)) return 1;
      return Name.CompareTo(other.Name);
    }

    public override int GetHashCode()
    {
      // return 0; if we don't want hash code equal optimisation.
      return Name.GetHashCode();
    }

    public override string ToString()
    {
      return $"name: {Name}\n header: {Header}\n footer: {Footer}";
    }
  }
}