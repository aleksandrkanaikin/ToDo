using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Desktop.Model;

namespace Desktop.Repository
{
    public static class UserRepository
    {
        private static readonly ObservableCollection<UserModel> Users = new ObservableCollection<UserModel>
        {
            new UserModel("Alex", "alex@gmail.com", "123123"),
            new UserModel("admin", "admin@gmail.com", "123123")
        };
        public static IEnumerable<UserModel> GetUser() { return Users; }
        public static void AddUser(UserModel user) { Users.Add(user); }
        public static void RemoveUser(UserModel user) { Users.Remove(user); }
        public static string CheckUser(UserModel user)
        {
            foreach (var item in Users)
            {
                if (user.email == item.email)
                {
                    return null;
                }
            }
            return "Такого пользователя не существует!";
        }
        public static string Checkpass(UserModel user)
        {
            foreach (var item in Users)
            {
                if (user.password == item.password)
                {
                    return null;
                }
            }
            return "Пароль неверный";
        }
        public static string RegisterUser(UserModel user)
        {
            foreach (var item in Users)
            {
                if (item.email == user.email)
                {
                    return "Данная почта уже используется!";
                }
            }
            return null;

        }
        public static string NameTranfer(string loginEmail)
        {
            var name = "";
            foreach (var user in Users)
            {
                if (loginEmail == user.email)
                {
                    name = user.name;
                    return name;
                }
            }
            return null;
        }
    }
}
