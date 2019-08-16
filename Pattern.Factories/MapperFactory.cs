using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Pattern.Mappers;

namespace Pattern.Factories
{
    public class MapperFactory : IMapperFactory
    {

        private readonly IServiceProvider serviceProvider;
        private readonly IMapperNamesHelper mapperNamesHelper;

        public MapperFactory(IMapperNamesHelper mapperNamesHelper, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
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

            return (TMapperType)serviceProvider.GetService(correspondingType);
        }

        public TMapperType CreateMapper<TMapperType, TEntityType>(IEnumerable<TEntityType> entities)
        {
            if(entities == null || !entities.Any())
                throw new ArgumentNullException("IEnumerable of entities cannot be null");

            var type = entities.First().GetType();

            return CreateMapper<TMapperType>(type);
        }

        public TMapperType CreateMapper<TMapperType, TEntityType>(TEntityType entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            return this.CreateMapper<TMapperType>(entity.GetType());
        }
    }
}
