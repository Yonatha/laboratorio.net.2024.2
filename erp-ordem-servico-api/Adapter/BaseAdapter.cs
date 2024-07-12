namespace MapperVsAdapter.Application.Adapter
{
    public class BaseAdapter<TEntity, TModel>
    {
        public IEnumerable<TEntity> Map(IEnumerable<TModel> entities)
        {
            return entities.Select(Map);
        }

        public IEnumerable<TModel> Map(IEnumerable<TEntity> entities)
        {
            return entities.Select(Map);
        }

        public TModel Map(TEntity model)
        {
            var entity = (TModel)Activator.CreateInstance(typeof(TModel));
            var properties = GetProperties<TModel, TEntity>();

            foreach (var propertyName in properties)
            {
                var value = model.GetType().GetProperty(propertyName).GetValue(model);
                entity.GetType().GetProperty(propertyName).SetValue(entity, value);
            }

            return entity;
        }

        public TEntity Map(TModel model)
        {
            var entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
            var properties = GetProperties<TEntity, TModel>();

            foreach (var propertyName in properties)
            {
                var value = model.GetType().GetProperty(propertyName).GetValue(model);
                entity.GetType().GetProperty(propertyName).SetValue(entity, value);
            }

            return entity;
        }

        private static List<string> GetProperties<TFrom, Tto>()
        {
            var from = typeof(TFrom).GetProperties();
            var to = typeof(Tto).GetProperties();

            var properties = new List<string>();

            foreach (var property in to)
            {
                var fromProperty = from.FirstOrDefault(p => p.Name.Equals(property.Name) && p.CanWrite);
                if(fromProperty != null) properties.Add(property.Name);
            }

            return properties;  
        }
    }
}