using System;

namespace _03
{
    class MyProgram
    {
        public void Main(User user, UserChangeNameRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentException("リクエストのNameがnullまたは空です。");
            }

            user.ChangeName(request.Name);
        }
    }
}
