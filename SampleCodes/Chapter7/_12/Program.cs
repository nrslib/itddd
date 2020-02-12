using System;
using System.Collections.Generic;
using System.Text;

namespace _12
{
    class Program
    {
        public static void Main(string[] args)
        {
            ServiceLocator.Register<IUserRepository, InMemoryUserRepository>();
            var userApplicationService = new UserApplicationService();
        }
    }
}
