using System;
using System.Collections.Generic;

namespace _13
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> map = new Dictionary<Type, object>();

        public static TType Resolve<TType>()
        {
            var type = typeof(TType);
            var instance = map[type];

            return (TType)instance;
        }

        public static void Register<TType, TObject>() where TObject : new()
        {
            var type = typeof(TType);
            map[type] = new TObject();
        }
    }
}
