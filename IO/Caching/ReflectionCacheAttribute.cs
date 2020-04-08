using System;

namespace Halo.IO.Caching
{
    public class ReflectionCacheAttribute : Attribute
    {
        public Type Type { get; private set; }

        public ReflectionCacheAttribute(Type type)
        {
            Type = type;
        }
    }
}