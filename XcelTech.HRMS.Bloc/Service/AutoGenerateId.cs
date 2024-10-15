using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;

namespace XcelTech.HRMS.Bloc.Service
{
    public class AutoGenerateId : IAutoGenerateId
    {

        //private const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //private const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        //private const string digits = "0123456789";
        //private const string symbols = "!@#$%^&*()_+";
        //private readonly List<string> _characterSets = new List<string> { uppercase, lowercase, digits, symbols };

        //public string GenerateRandomPassword(int length = 8)
        //{
        //    StringBuilder password = new StringBuilder();
        //    using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        //    {
        //        foreach (var charSet in _characterSets)
        //        {
        //            byte[] randomBytes = new byte[1];
        //            rng.GetBytes(randomBytes);
        //            password.Append(charSet[Math.Abs(randomBytes[0]) % charSet.Length]);
        //        }

        //        byte[] bytes = new byte[length - _characterSets.Count];
        //        rng.GetBytes(bytes);
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            string charSet = _characterSets[Math.Abs(bytes[i]) % _characterSets.Count];
        //            password.Append(charSet[Math.Abs(bytes[i]) % charSet.Length]);
        //        }

        //        char[] passwordChars = password.ToString().ToCharArray();
        //        Shuffle(passwordChars, rng);
        //        password = new StringBuilder(new string(passwordChars));
        //    }

        //    return password.ToString();
        //}

        //private void Shuffle(char[] array, RNGCryptoServiceProvider rng)
        //{
        //    int n = array.Length;
        //    while (n > 1)
        //    {
        //        n--;
        //        byte[] randomBytes = new byte[1];
        //        rng.GetBytes(randomBytes);
        //        int k = Math.Abs(randomBytes[0]) % (n + 1);
        //        char value = array[k];
        //        array[k] = array[n];
        //        array[n] = value;
        //    }
        //}

    public  string GenerateUniqueId(int length = 11)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
            var random = new Random();
            var sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }

            return sb.ToString();
    }
}
}
