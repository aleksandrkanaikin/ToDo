using System.Collections.Generic;
using System.Windows.Documents;
using Entities;

namespace Desktop.Repository
{
    public class UserRepository
    {
        private static readonly List<UserModel> Users = new List<UserModel>
        {
            new UserModel("alex123@mail.com", "Alex", "1357908642"),
            new UserModel("ruslan147@mail.com", "Ruslan", "Qert135!")
        };

        public static UserModel LogIn(string email, string password)
        {
            foreach (var item in Users)
            {
                if (item.email == email && item.password == password)
                {
                    return item;
                }
            }
            return null;
        }

        public static UserModel Registration(string name, string email, string password)
        {
            foreach (var item in Users)
            {
                if(item.email == email)
                {
                    return null;
                }
            }
            var user = new UserModel(email, name, password);
            Users.Add(user);
            return user;
        }
    }
}