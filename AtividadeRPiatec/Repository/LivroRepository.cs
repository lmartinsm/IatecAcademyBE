using AtividadeRPiatec.Interface;
using AtividadeRPiatec.Models;

namespace AtividadeRPiatec.Infra
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public Livro GetById(int id)
        {
            return _context.Livros.FirstOrDefault(x => x.Id == id);
        }

    }
}
