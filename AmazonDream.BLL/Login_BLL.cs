using AmazonDream.Common;
using AmazonDream.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonDream.BLL
{
    public class Login_BLL
    {
        CommonDA _commonDA = new CommonDA();

        public string login(string email,string password)
        {
            password = Hashing.Hash(password);
             var user = _commonDA.login(email, password);
            if(user != null)
            {

                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                string token = Convert.ToBase64String(time.Concat(key).ToArray());
            }
            return user;
        }
    }
}
