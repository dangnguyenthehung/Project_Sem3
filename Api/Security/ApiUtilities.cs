using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Models;
using Model.Security;
using Newtonsoft.Json;

namespace Api.Security
{
    public class ApiUtilities
    {
        public static Login ParseLoginToken(string token)
        {
            var encryptor = new Encryptor.AESdecrypt();
            var loginStr = encryptor.DecryptString_Aes(token);

            return JsonConvert.DeserializeObject<Login>(loginStr);
        }
    }
}