using ShoesApp.Entities;

namespace ShoesApp.Services
{
    public class CrudService<T> where T : BaseEntity
    {
        protected static readonly List<T> entities = new List<T>();
        private static int lastId = 0;

        public void Create(T entity)
        {
            entity.Id = ++lastId;
            entity.CreatedAt = DateTime.Now;
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            var oldEntity = entities.Single(e => e.Id == entity.Id);
            entities.Remove(oldEntity);
            entities.Add(entity);
        }

        public void Delete(int entityId)
        {
            var entity = entities.Single(e => e.Id == entityId);
            entities.Remove(entity);
        }

        public T GetById(int entityId) =>
            entities.Single(e => e.Id == entityId);
    }
}
