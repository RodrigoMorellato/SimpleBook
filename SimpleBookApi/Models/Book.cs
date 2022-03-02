using SimpleBookApi.Enums;

namespace SimpleBookApi.Models
{
    public class Book : BaseClass
    {
        public Book(string name, string author, DateTime registration, EnumCategory category, string description)
        {
            _name = name;
            _author = author;
            _registration = registration;
            _category = category;
            _description = description;
        }

        private string _name;

        private string _author;

        private DateTime _registration;

        private EnumCategory _category;

        private string _description;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public DateTime Registration
        {
            get { return _registration; }
            set { _registration = value; }
        }

        public EnumCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
