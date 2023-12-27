using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    public class UserModel
    {
        public UserModel(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public UserModel(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
