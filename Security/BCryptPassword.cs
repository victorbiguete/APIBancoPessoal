namespace APIBanco.Security
{
    public class BCryptPassword
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string enteredPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, password);
        }
    }
}
