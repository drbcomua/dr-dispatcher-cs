namespace dispatcher.Models
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType()!=typeof(Name)) return false;
            return string.Equals(FirstName, (obj as Name).FirstName) && string.Equals(LastName, (obj as Name).LastName);
        }
    }
}
