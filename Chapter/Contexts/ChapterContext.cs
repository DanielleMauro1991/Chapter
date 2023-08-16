using Chapter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Contests
{
    public class ChapterContext : DbContext

    {
        public ChapterContext() { }
        public ChapterContext (DbContextOptions < ChapterContext > options) : base(options) 
        { }

        //Vamos utilizar esse metodo para configurar o banco de dados

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
            {
                //Cada computador possui seu próprio caminho e sintaxe
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-8MJ680J\\SQLEXPRESS ; initial catalog = Chapter; Integrated Security = true");

                //Caso nao seja ID Microsoft:Data Source = DESKTOP-8MJ680J\\SQLEXPRESS ; initial catalog = Chapter; Integrated Security = banana; password = nanica123            
            }
        }

        public DbSet<Livro> Livros { get; set; }

    }
}
