namespace InMemoryInfrastructure.Foundation.Factory
{
    public class SerialNumberAssigner
    {
        private int currentId;

        public int Next()
        {
            return ++currentId;
        }

        public void ChangeCurrent(int id)
        {
            currentId = id;
        }
    }
}
