using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.SqlTypes;
using LibraryBasicInfo;

namespace LinqUsingDbContext
{
    public class AppDbContext : DbContext
    {
        public void Insert(BasicInfo info)
        {
            Info.Add(info);
            SaveChanges();
        }

        public List<BasicInfo> Select()
        {
            return Info.ToList();
        }

        public void Delete(int id)
        {
            var entity = Info.Find(id);
            if (entity != null)
            {
                Info.Remove(entity);
                SaveChanges();
            }
        }
        public AppDbContext() : base("AppDbContext") 
        {
        }
        public DbSet<BasicInfo> Info { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Subject> Subjects { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=seulgi;Integrated Security=True;TrustServerCertificate=True;");
        //    }
        //}



        public class Enrollment
        {
            public int EnrollmentId { get; set; }
            public int StudentId { get; set; }
            public int SubjectId { get; set; }
            public int TeacherId { get; set; }
            public DateTime DateEnrolled { get; set; }

            public Student Student { get; set; }
            public Subject Subject { get; set; }
            public Teacher Teacher { get; set; }
        }

        public class Subject
        {
            public int SubjectId { get; set; }
            public string SubjectCode { get; set; } = "";
            public string SubjectName { get; set; } = "";
            public ICollection<Enrollment> Enrollments { get; set; }
        }

        public class Teacher
        {
            public int TeacherId { get; set; }
            public string FirstName { get; set; } = "";
            public string LastName { get; set; } = "";
            public ICollection<Enrollment> Enrollments { get; set; }
        }

        public class Student
        {
            public int StudentId { get; set; }
            public string FirstName { get; set; } = "";
            public string LastName { get; set; } = "";

            public ICollection<Enrollment> Enrollments { get; set; }
        }

        public class DatabaseService
        {
            private readonly AppDbContext _context;

            public DatabaseService()
            {
                _context = new AppDbContext();
            }

            public void Insert(BasicInfo info)
            {
                _context.Info.Add(info);
                _context.SaveChanges();
                Console.WriteLine("\nData saved successfully!");
            }

            public List<BasicInfo> Select()
            {
                return _context.Info.ToList();
            }

            public void Delete(int id)
            {
                var record = _context.Info.FirstOrDefault(x => x.ID == id);
                if (record != null)
                {
                    _context.Info.Remove(record);
                    _context.SaveChanges();
                    Console.WriteLine("Data deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Record not found.");
                }
            }
        }
    }
}








    

