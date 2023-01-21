namespace Desktop.Properties
{
    public class Validator
    {
        public static string PassValid(string pass)
        {
            if (pass.Length >= 7) return null;
            return "Длина должна быть 7 символов";
        }
    }
}