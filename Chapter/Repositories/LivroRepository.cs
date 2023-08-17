using Chapter.Contests;
using Chapter.Models;

namespace Chapter.Repositories
{
    public class LivroRepository
    {
        private readonly ChapterContext _context;
        public LivroRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()

        {
            return _context.Livros.ToList();
        }
        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);

        }
        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges(); 
        }
    }
}
