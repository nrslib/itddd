using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _21
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var myContext = MyDbContext.Create();

            var userRepository = new EFUserRepository(myContext);
            var program = new Program(userRepository);
            program.CreateUser("naruse");

            // データを取り出して確認
            var head = myContext.Users.First();
            Assert.AreEqual("naruse", head.Name);
        }
    }
}
