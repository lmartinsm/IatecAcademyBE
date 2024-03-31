namespace AtividadeRPiatec.Interface
{
    public interface IRepository<T> where T : class
    {
        void add (T entity);
        void SaveChanges ();
        void Delete (T entity);
        void Update (T entity);
        T GetById (int id);
        IEnumerable<T> GetAll ();

      
    }
}
