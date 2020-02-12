using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _17
{
    class EntryPoint
    {
        public static void Main(string[] args)
        {
            var userRepository = new InMemoryUserRepository();
            var program = new Program(userRepository);
            program.CreateUser("nrs");

            // データを取り出して確認
            var head = userRepository.Store.Values.First();
            Assert.AreEqual("nrs", head.Name);
        }
    }
}
