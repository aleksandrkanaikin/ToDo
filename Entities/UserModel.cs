namespace Entities
{
    public class UserModel
    {
        public string email;
        public string name;
        public string password;

        public UserModel(string email, string name, string password)
        {
            this.email = email;
            this.name = name;
            this.password = password;
        }

    }
}