namespace SocialNetwork.BusinessLogic.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        private const string SALT = "$MYHASH$V1$";

        public string Hash(string password)
        {
            return SALT + password;
        }

        public bool IsHashSupported(string hashString)
        {
            return hashString.StartsWith(SALT);
        }

        public bool Verify(string password, string hashedPassword)
        {
            if (IsHashSupported(hashedPassword) == false)
            {
                return false;
            }

            return password == hashedPassword.Replace(SALT, string.Empty);
        }
    }
}
