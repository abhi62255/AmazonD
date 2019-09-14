using System;
using System.Text;

namespace AmazonDream.Common
{
    public class Hashing
    {
        public static string Hash(string input)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }
}
