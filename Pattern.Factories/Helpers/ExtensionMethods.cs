using System;
using System.Collections.Generic;

namespace Pattern.Factories
{
    public static class ExtensionMethods
    {
        public static void Add<T,U>(this Dictionary<Type,Type> dictionary)
        {
            dictionary.Add(typeof(T), typeof(U));
        }
    }
}