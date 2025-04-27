using System.Security;

namespace LinqPrac
{
    public class Student
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required List<int> Score { get; set; }
    }

    public class SameFirstName
    {
        public required string FirstName { get; set; }
        public required string FullNameA { get; set; }
        public required string FullNameB { get; set; }
    }
    public class FailedStudent
    {
        public required string FullName { get; set; }
        public required double ScoreAve { get; set; }
    }
    public class StudentNames
    {
        public required string Names { get; set; }
    }

    public class GradeNames
    {
        public required int Grade { get; set; }
        public required List<StudentNames> Names { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var Student = new List<Student>();

            Student.AddRange(
                new List<Student>
                {
                    new Student { Id = 1, FirstName = "Kanade", LastName = "Yoisaki", Score = new List<int> { 95, 99, 92 } },
                    new Student { Id = 2, FirstName = "Kaguya", LastName = "Shinomiya", Score = new List<int> { 89, 87, 92 } },
                    new Student { Id = 3, FirstName = "Chika", LastName = "Fujiwara", Score = new List<int> { 81, 85, 79} },
                    new Student { Id = 4, FirstName = "Ai", LastName = "Hayasaka", Score = new List<int> { 91, 86, 92 } },
                    new Student { Id = 5, FirstName = "Maki", LastName = "Shijo", Score = new List<int> { 90, 81, 85 } },
                });

            var morestudents = new List<Student>()
            {
                new Student { Id = 6, FirstName = "Miyuki", LastName = "Shirogane", Score = new List<int> { 89, 91, 82 } },
                new Student { Id = 7, FirstName = "Shinomiya", LastName = "Kaguya", Score = new List<int> { 85, 88, 92 } },
                new () { Id = 8, FirstName = "Carl", LastName = "Joshua" , Score = new List<int> { 75, 79, 78} },
                new () { Id = 9, FirstName = "Sophia", LastName = "Lee", Score = new List<int> { 85, 88, 90 } },
                new () { Id = 10, FirstName = "Michael", LastName = "Smith", Score = new List<int> { 92, 87, 89 } },
                new () { Id = 11, FirstName = "Sophia", LastName = "Brown", Score = new List<int> { 80, 82, 78 } },
                new () { Id = 12, FirstName = "Liam", LastName = "Johnson", Score = new List<int> { 91, 89, 93 } },
                new () { Id = 13, FirstName = "Olivia", LastName = "Martinez", Score = new List<int> { 70, 75, 72 } },
                new () { Id = 14, FirstName = "Shiro", LastName = "Davis", Score = new List<int> { 88, 84, 86 } },
                new () { Id = 15, FirstName = "Shiro", LastName = "Kumo" , Score = new List<int> {89, 91, 91,89} }
            };

            Student.AddRange(morestudents);

            //3. write a function to get the count of student who has an average of less than 75

            //var count = Student.Count(s => s.Score.Average() < 75);

            var FailedStudent = (from Students in Student
                        where Students.Score.Average() < 75
                        select new FailedStudent
                        {
                            FullName = Students.FirstName + " " + Students.LastName,
                            ScoreAve = Students.Score.Average(),
                        }
                        ).ToList();

            Console.WriteLine($"Count of students with average less than 75: {FailedStudent.Count}");


            Console.WriteLine("\n");


            //var FailesStudents = Student.Count(std => std.Score.Average() < 75);

            //4. Wirte a function to get the count of the students who has the same first name

            //var count = Student.GroupBy(s => s.FirstName).Where(g => g.Count() > 1).Select(g => g.Key).Count();
            //This is for Lam


            var Name = (from StudentsA in Student
                        from StudentsB in Student
                        where StudentsA.FirstName == StudentsB.FirstName && StudentsA.Id < StudentsB.Id 
                        select new SameFirstName
                        {
                            FirstName = StudentsA.FirstName,
                            FullNameA = StudentsA.FirstName + " " + StudentsA.LastName,
                            FullNameB = StudentsB.FirstName + " " + StudentsB.LastName,

                        }
                        ).Distinct().ToList();

            Console.WriteLine($"There Are {Name.Count} Same First Names: ");

            foreach (var FN in Name)
            {
                Console.WriteLine($"{FN.FirstName}: {FN.FullNameA} and {FN.FullNameB}");
            }
            //var Name = (from Students in Student
            //             where (from StudentsB in Student
            //                    where StudentsB.FirstName == Students.FirstName
            //                    select StudentsB).Count() > 1
            //             select Students).Count();

            Console.WriteLine("\n");



            //5.Given that each index in the scores is a subject, get the names of students with the same grade of each subject

            // - for example, if the first index of the scores is 75, then get the names of students with 75 in that index


            var Subjects = new List<string> { "Math", "English", "Science" };
            for (int subjectIndex = 0; subjectIndex <=2; subjectIndex++)
            {

                var groupedByGrade =
                    from student in Student
                    group student by student.Score[subjectIndex] into gradeGroup
                    where gradeGroup.Count() > 1
                    select new GradeNames
                    {
                        Grade = gradeGroup.Key,
                        Names = (from s in gradeGroup
                                 select new StudentNames
                                 {
                                     Names = s.FirstName + " " + s.LastName
                                 }).ToList()
                    };


                foreach (var group in groupedByGrade)
                {
                    Console.WriteLine($"{Subjects[subjectIndex]}: {group.Grade}");
                    foreach (var student in group.Names)
                    {
                        Console.WriteLine($" - {student.Names}");
                    }
                }

            }

            //var numbers = new List<int> { 10, 20, 30, 40, 50 };
            //var indexedNumbers = numbers.Select((number, index) => new { Index = index, Value = number });

            //foreach (var item in indexedNumbers)
            //{
            //    Console.WriteLine($"Index: {item.Index}, Value: {item.Value}");
            //}

        }
    }
}