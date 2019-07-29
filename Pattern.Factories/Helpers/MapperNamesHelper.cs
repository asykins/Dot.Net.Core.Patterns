using System;
using System.Collections.Generic;
using System.Linq;
using Pattern.Domain;
using Pattern.Mappers;

namespace Pattern.Factories
{
    public class MapperNamesHelpers : IMapperNamesHelper
    {
        private readonly Dictionary<Type, Type> typesCorrespondances;

        public MapperNamesHelpers()
        {
            this.typesCorrespondances = new Dictionary<Type, Type>();
            RegisterTypes(typesCorrespondances);
        }

        private void RegisterTypes(Dictionary<Type, Type> typesCorrespondances)
        {
            typesCorrespondances.Add<ProductMapper, Product>();
            typesCorrespondances.Add<NullProductMapper, NullProduct>();
            typesCorrespondances.Add<ProductViewModelMapper, Product>();
            typesCorrespondances.Add<NullProductViewModelMapper, NullProduct>();

        }

        public IEnumerable<Type> GetAssociatedType(Type type)
        {
            var types =  typesCorrespondances.Where(x => x.Value.Equals(type))
                                             .Select(x => x.Key)
                                             .Distinct()
                                             .ToList();

            return types;                                             
        }
    }
}