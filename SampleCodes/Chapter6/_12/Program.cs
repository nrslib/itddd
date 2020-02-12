using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    class Program
    {
        public static void Main(string[] args)
        {
            var user = new User(new UserName("test-user"));
            var userData = new UserData(user);
        }
    }
}
