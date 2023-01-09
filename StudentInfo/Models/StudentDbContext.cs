using Microsoft.EntityFrameworkCore;

namespace StudentInfo.Models
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { set; get; }

    }
}
