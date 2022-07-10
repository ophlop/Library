namespace EPAM.Library.Entities
{
    public class User
    {
        private Guid _id;
        private string _name;
        private string _email;
        private List<string> _roles;
        public Guid Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public List<string> Roles { get => _roles; set => _roles = value; }
    }
}
