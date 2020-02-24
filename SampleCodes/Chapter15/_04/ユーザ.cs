using System;

namespace _04
{
    public class ユーザ
    {
        private ユーザ名 name;

        public ユーザ(ユーザ名 name)
        {
            this.name = name;
        }

        public void 名前を変更する(ユーザ名 name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name)); 
            
            this.name = name;
        }
    }
}
