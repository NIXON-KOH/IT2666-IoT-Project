using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin
{
    class Session
    {
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static int UserId { get; set; }

        public static string Email { get; set; }

        public static string TotpSecret { get; set; }
        public static void Clear()
        {
            Username = null;
            Role = null;
            UserId = 0;
            Email = null;
            TotpSecret = null;
        }
    }
}
