using System;
using System.Collections.Generic;
using System.Text;

namespace ITRI.Models.Helper
{
    public class Settings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public JWTSettings JWTSettings { get; set; }
    }

    public class ConnectionStrings
    {
        public string QRCodeConnection { get; set; }
    }

    public class JWTSettings
    {
        public string Secret { get; set; }
    }
}
