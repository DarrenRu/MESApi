using System;
using System.Collections.Generic;
using System.Text;
using ITRI.Models.Helper;
using Jose;

namespace ITRI.Services
{
    public class BaseService
    {
        public string GenerateToken(int id, string mode, JWTSettings jwtSettings, string type = "")
        {
            var payload = new Dictionary<string, string>
            {
                {"Id", id.ToString()},
                {"Type", type},
                {"CreateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
            };
            var token = JWT.Encode(payload, Encoding.UTF8.GetBytes(jwtSettings.Secret), JwsAlgorithm.HS256);
            return token;
        }
    }
}
