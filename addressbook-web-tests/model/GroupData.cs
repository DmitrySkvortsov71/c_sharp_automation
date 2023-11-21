using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Header
        {
            get => header;
            set => header = value;
        }

        public string Footer
        {
            get => footer;
            set => footer = value;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            
            // comment hash ..., if you don't need it. 
            // if (GetHashCode() != other.GetHashCode()) return false;
            
            return Name == other.Name;
        }

        // private int GetHashCode()
        // {
        //     // return 0; if we don't want hash code equal optimisation.
        //     return Name.GetHashCode();
        // }
    }
}
