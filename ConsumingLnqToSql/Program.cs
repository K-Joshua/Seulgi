using System;
using System.Linq;
using LinqUsingDbContext;
using Microsoft.Data.SqlClient;
using System.Data.Entity;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            var query = context.Students
                .Join(context.Enrollments,
                      student => student.StudentId,
                      enrollment => enrollment.StudentId,
                      (student, enrollment) => new { student, enrollment })
                .Join(context.Subjects,
                      se => se.enrollment.SubjectId,
                      subject => subject.SubjectId,
                      (se, subject) => new { se.student, se.enrollment, subject })
                .Join(context.Teachers,
                      ses => ses.enrollment.TeacherId,
                      teacher => teacher.TeacherId,
                      (ses, teacher) => new
                      {
                          StudentId = ses.student.StudentId,
                          StudentFullName = ses.student.FirstName + " " + ses.student.LastName,
                          SubjectCode = ses.subject.SubjectCode,
                          SubjectName = ses.subject.SubjectName,
                          Teacher = teacher.FirstName + " " + teacher.LastName,
                          DateEnrolled = ses.enrollment.DateEnrolled
                      })
                .ToList();

            foreach (var result in query)
            {
                Console.WriteLine($"Student ID: {result.StudentId}");
                Console.WriteLine($"Full Name : {result.StudentFullName}");
                Console.WriteLine($"Subject   : {result.SubjectCode} - {result.SubjectName}");
                Console.WriteLine($"Teacher   : {result.Teacher}");
                Console.WriteLine($"Enrolled  : {result.DateEnrolled.ToShortDateString()}");
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }

        Console.WriteLine("Query complete.");
    }
}