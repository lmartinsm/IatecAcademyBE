using AtividadeRPiatec.Interface;
using AtividadeRPiatec.Models;

namespace AtividadeRPiatec.Services
{
    public class LivroService
    {
        private readonly IRepository<Livro> _LivroRepository;

        public LivroService(IRepository<Livro> LivroRepository)
        {
            _LivroRepository = LivroRepository;
        }

    
        public void AddLivro(Livro livro)
        {
            _LivroRepository.add(livro);
        }
        public void UpdateLivro(Livro livro)
        {
            _LivroRepository.Update(livro);
        }
        public Livro GetLivroById(int id)
        {
           
            var livro = _LivroRepository.GetById(id);
            if (livro == null)
            {
                throw new ArgumentException("Esse Livro não existe");
            }
            return livro;
        }
        public IEnumerable<Livro> GetAllLivros()
        {
           return _LivroRepository.GetAll();
        }

        internal Task<object?> GetLivroByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
