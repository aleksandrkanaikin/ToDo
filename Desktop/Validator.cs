using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Desktop.Properties
{
    public static class Validator
    {
        public static string PassValid(TextBox passtb)
        {
            if (passtb.Text.Length <= 6) return "Неверный пароль";
            else return null;
        }
        

            public static string EmailValid(TextBox mailtb)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(mailtb.Text);
            if (match.Success) return null;
            else return "Неверный формат почты. Пример: example@mail.com";
        }

        public static string NameValid(TextBox nametb)
        {
            if (nametb.Text.Length > 3) return null;
            else return "Имя должно содержать 3 буквы";
        }

        public static string RepeatPassValid(TextBox passtb, TextBox reppasstb)
        {
            if (passtb.Text == reppasstb.Text) return null;
            else return "Пароли не совпадают";
        }
    }
}