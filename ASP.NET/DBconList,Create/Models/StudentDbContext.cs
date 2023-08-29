using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MVC_CRUD.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)  //초기화 변수
        {
        }
        public DbSet<Student> Student { get; set; }

        //public static implicit operator StreamContent(StudentDbContext v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
