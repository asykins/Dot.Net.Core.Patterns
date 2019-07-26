using System;
using System.Collections.Generic;

namespace Pattern.Factories
{
    public interface IMapperNamesHelper
    {
        IEnumerable<Type> GetAssociatedType(Type type);
    }
}