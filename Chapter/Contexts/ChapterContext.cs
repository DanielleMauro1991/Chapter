using Microsoft.EntityFrameworkCore;

namespace Chapter.Contests
{
    public class ChapterContext : DbContext

    {
        public ChapterContext() { }
        public ChapterContext (DbContextOptions < ChapterContext > options) : base(options) 
        { }

    }
}
