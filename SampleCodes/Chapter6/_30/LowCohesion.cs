using System;

namespace _30
{
    public class LowCohesion
    {
        private int value1;
        private int value2;
        private int value3;
        private int value4;

        public int MethodA()
        {
            return value1 + value2;
        }

        public int MethodB()
        {
            return value3 + value4;
        }
    }
}
