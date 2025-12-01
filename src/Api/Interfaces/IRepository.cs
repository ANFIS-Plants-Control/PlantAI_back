namespace PlantAI.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {

        public void Create(T entity);
        public List<T> Read();
        public T ReadById(int id);
        public void Update(T entity);
        public void Delete(T entity);

    }
}
