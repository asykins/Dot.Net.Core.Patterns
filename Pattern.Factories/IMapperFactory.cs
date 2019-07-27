using System;
using System.Collections.Generic;

namespace Pattern.Factories
{
    public interface IMapperFactory
    {
        TMapperType CreateMapper<TMapperType>(Type type);
        TMapperType CreateMapper<TMapperType, TEntityType>(IEnumerable<TEntityType> entities);
    }
}