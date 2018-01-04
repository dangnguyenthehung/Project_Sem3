using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Security;
using Newtonsoft.Json;

namespace Helpers_Constants.Utilities
{
    public class Utilities
    {
        public static string CreateLoginToken(Login account)
        {
            var loginStr = JsonConvert.SerializeObject(account);

            var encryptor = new Encryptor.AESencrypt();
            return encryptor.EncryptString_Aes(loginStr);
        }

        public static Login ParseLoginToken(string token)
        {
            var encryptor = new Encryptor.AESdecrypt();
            var loginStr = encryptor.DecryptString_Aes(token);

            return JsonConvert.DeserializeObject<Login>(loginStr);
        }
    }
}
