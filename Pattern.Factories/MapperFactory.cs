using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Pattern.Factories
{
    public class MapperFactory : IMapperFactory
    {

        private readonly IMapperNamesHelper mapperNamesHelper;

        public MapperFactory(IMapperNamesHelper mapperNamesHelper)
        {
            this.mapperNamesHelper = mapperNamesHelper ?? throw new ArgumentNullException(nameof(mapperNamesHelper));
        }

        public TMapperType CreateMapper<TMapperType>(Type type)
        {
            var types = mapperNamesHelper.GetAssociatedType(type);

            if(types == null || !types.Any())
                throw new ArgumentNullException(nameof(types));

            var correspondingType = types.FirstOrDefault(x => typeof(TMapperType).IsAssignableFrom(x));

            if(correspondingType == null)
                throw new ArgumentException(nameof(correspondingType));

            return (TMapperType)Activator.CreateInstance(correspondingType);
        }

        public TMapperType CreateMapper<TMapperType, TEntityType>(IEnumerable<TEntityType> entities)
        {
            if(entities == null || !entities.Any())
                throw new ArgumentNullException("IEnumerable of entities cannot be null");

            var type = entities.First().GetType();

            return CreateMapper<TMapperType>(type);
        }
    }
}
