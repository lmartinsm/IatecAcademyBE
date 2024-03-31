using AtividadeRPiatec.Infra;
using AtividadeRPiatec.Interface;
using Microsoft.EntityFrameworkCore;

namespace AtividadeRPiatec.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public AppDbContext _dbContext { get; set; }
        public DbSet<T> _dbset { get; set; }
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<T>();
        }

        public void add(T entity)
        {
            _dbset.Add(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public T GetById(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }
    }
}
