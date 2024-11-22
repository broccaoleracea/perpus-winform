using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desainperpus_vanya
{
    internal class UserInfo
    {
        public static string UserName { get; set; }

        public static void Logout(Form form)
        {
            UserName = null;
            form.Close();
        }
    }
}
