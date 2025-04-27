/*

string select = @"SELECT a.StudentId as 'STUDENT ID' (a.FirstName + " " + a.LastName) AS 'STUDENT FULLNAME', b.SubjectCode AS 'SUBJECT CODE', b.SubjectName AS 'Subject Name', (c.FirstName + " " + c.lastName) As' + 'Teacher', e.dateEnrolled AS 'DATE ENROLLED' FROM info.student a INNERJOIN info.enrollment d on a.StudentId = d.StudentId INNERJOIN info.subject b on b.SubjectId = d.SubjectID InnerJOIN info.teacher C on d.teacherID = C.teacherID;";


SELECT
    a.StudentId AS 'STUDENT ID',
    (a.FirstName + ' ' + a.LastName) AS 'STUDENT FULLNAME',
    b.SubjectCode AS 'SUBJECT CODE',
    b.SubjectName AS 'SUBJECT NAME',
    (c.FirstName + ' ' + c.LastName) AS 'TEACHER',
    e.dateEnrolled AS 'DATE ENROLLED'
FROM info.student a
INNER JOIN info.enrollment d ON a.StudentId = d.StudentId
INNER JOIN info.subject b ON b.SubjectId = d.SubjectID
INNER JOIN info.teacher c ON d.TeacherID = c.TeacherID;

---------------------------------------------------------------------------------------------------------------
PASS CODES
-------------------------------------------------------------------------------------------------------------------

string Selectquery = "SELECT a.StudentId AS 'STUDENT ID', (a.FirstName + ' ' + a.LastName) AS 'STUDENT FULLNAME', b.SubjectCode AS 'SUBJECT CODE', b.SubjectName AS 'SUBJECT NAME', (c.FirstName + ' ' + c.LastName) AS 'TEACHER', e.dateEnrolled AS 'DATE ENROLLED' FROM info.student a INNER JOIN info.enrollment d ON a.StudentId = d.StudentId INNER JOIN info.subject b ON b.SubjectId = d.SubjectID INNER JOIN info.teacher c ON d.TeacherID = c.TeacherID;";

using (SqlConnection SuperHardConnection = new SqlConnection(SeulgiServer))
{
    SuperHardConnection.Open();

    using (SqlCommand Checks = new SqlCommand(Selectquery, SuperHardConnection))
    using (SqlDataReader checksData = Checks.ExecuteReader())
    {
        Console.WriteLine("STUDENT ID\tSTUDENT FULLNAME\tSUBJECT CODE\tSUBJECT NAME\tTEACHER\tDATE ENROLLED");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------");

        while (checksData.Read())
        {
            Console.WriteLine($"{checksData["STUDENT ID"]}\t{checksData["STUDENT FULLNAME"]}\t{checksData["SUBJECT CODE"]}\t{checksData["SUBJECT NAME"]}\t{checksData["TEACHER"]}\t{checksData["DATE ENROLLED"]}");
        }
    }
}


---------------------------------------------------------------------------------------------------------------
SQL to LINQ
-------------------------------------------------------------------------------------------------------------------

SELECT * FROM info;	
context.Info.ToList();

SELECT * FROM info WHERE Age > 25;	
context.Info
       .Where(i => i.Age > 25)
       .ToList();

SELECT * FROM info ORDER BY LastName ASC;	
context.Info.OrderBy(i => i.LastName).ToList();

SELECT * FROM info ORDER BY LastName DESC;	
context.Info.OrderByDescending(i => i.LastName).ToList();

SELECT * FROM info WHERE FirstName LIKE 'J%';	
context.Info.Where(i => i.FirstName.StartsWith("J")).ToList();

SELECT Country, COUNT(*) FROM info GROUP BY Country;	
context.Info.GroupBy(i => i.Country).Select(g => new { g.Key, g.Count() }).ToList();

SELECT DISTINCT Country FROM info;	
context.Info.Select(i => i.Country).Distinct().ToList();

SELECT i.FirstName, d.DepartmentName 
FROM info i INNER JOIN department d ON i.DepartmentId = d.Id;

context.Info.Join
(context.Department, i => i.DepartmentId, d => d.Id, (i, d) => new { i.FirstName, d.DepartmentName }).ToList();





---------------------------------------------------------------------------------------------------------------
CONNECTION to DATABASE
-------------------------------------------------------------------------------------------------------------------

using (var context = new MyDbContext())
{
    var peopleOver25 = context.info
                               .Where(i => i.Age > 25)
                               .OrderBy(i => i.Name)
                               .ToList();

    foreach (var person in peopleOver25)
    {
        Console.WriteLine($"{person.Name}, Age: {person.Age}");
    }
}

---------------------------------------------------------------------------------------------------------------
EXTRA NOTES
-------------------------------------------------------------------------------------------------------------------


{
agile management
scrammer
}

ORM

WebApi - backends
API Coding Method
Post - Put - Delete - Get - Patch

Web Client - Frontend

Intellectual Property
    - Code
    - Design
    - Logo
    - Name
    - Brand
    - Product
    - Service
    - Process
    - Invention
    - Trade Secret
    - Patent
    - Trademark
        - How to protect your IP


- Inventory (qty in stock)
       - master file of all product
       - numbers of how many products are in stock



------------------------------------------------------------------------------------------------------------------------
TEST CONVERTION SQL to LINQ
------------------------------------------------------------------------------------------------------------------------



SELECT 
  a.StudentId AS 'STUDENT ID',
  (a.FirstName + ' ' + a.LastName) AS 'STUDENT FULLNAME',
  b.SubjectCode AS 'SUBJECT CODE',
  b.SubjectName AS 'SUBJECT NAME',
  (c.FirstName + ' ' + c.LastName) AS 'TEACHER',
  e.dateEnrolled AS 'DATE ENROLLED'
FROM info.student a
INNER JOIN info.enrollment d ON a.StudentId = d.StudentId
INNER JOIN info.subject b ON b.SubjectId = d.SubjectID
INNER JOIN info.teacher c ON d.TeacherID = c.TeacherID
INNER JOIN info.enrollment e ON e.StudentId = a.StudentId



   Student = a
   Subject = b
   Teacher = c
   Enrollment = d

----------------------------------------------------------------------------------------------

using (var context = new AppDbContext())
{
            var linq =
                      context.Students.Join(context.Enrollments,
                      student => student.StudentId,
                      enrollment => enrollment.StudentId,
                      (student, enrollment) => new { student, enrollment })
                .Join(context.Subjects,
                      ad => ad.enrollment.SubjectId,
                      subject => subject.SubjectId,
                       (ad, subject) => new { ad.student, ad.enrollment, subject })
                .Join(context.Teachers,
                      adb => adb.enrollment.TeacherId,
                      teacher => teacher.TeacherId,
                      (adb, teacher) => new
                      {
                          StudentId = adb.student.StudentId,
                          StudentFullName = adb.student.FirstName + " " + adb.student.LastName,
                          SubjectCode = adb.subject.SubjectCode,
                          SubjectName = adb.subject.SubjectName,
                          Teacher = teacher.FirstName + " " + teacher.LastName,
                          DateEnrolled = adb.enrollment.DateEnrolled
                      })
                .ToList();











            foreach (var seulgi in linq)
            {
                Console.WriteLine($"Student ID: {seulgi.StudentId}");
                Console.WriteLine($"Full Name : {seulgi.StudentFullName}");
                Console.WriteLine($"Subject   : {seulgi.SubjectCode} - {seulgi.SubjectName}");
                Console.WriteLine($"Teacher   : {seulgi.Teacher}");
                Console.WriteLine($"Enrolled  : {seulgi.DateEnrolled.ToShortDateString()}");
                Console.WriteLine("\n\n");
            }
}






if $1.0 == ON 
	if $2 == 1  
		if $3 == 0
		$100 = $100 + 5
		$4 = 1

			if $100 > 150
			$100 = $100 - 5
			$201 = $201 + 2
			$4 = 2
			ENDIF

			if $201 > 340
			$201 = $201 - 2
			$200 = $200 + 5
			$100 = $100 + 5
			$4 = 1
			endif

			if $200 > 900
			$200 = $200 - 5
			$100 = $100 - 5
			$4 = 3
			endif
		endif

		if $3 == 1
		$100 = $100 + 5
		$4 = 1

			if $100 > 150
			$100 = $100 - 5
			$201 = $201 + 2
			$4 = 2
			ENDIF

			if $201 > 340
			$201 = $201 - 2
			$200 = $200 + 5
			$100 = $100 + 5
			$4 = 1
			endif

			if $100 > 490
			$100 = $100 - 5
			$200 = $200 - 5
			$501 = $501 + 2
			$4 = 2
			ENDIF

			if $501 > 340
			$501 = $501 - 2
			$100 = $100 + 5
			$200 = $200 + 5
			$500 = $500 + 5
			$4 = 1
			ENDIF

			if $500 > 900
			$100 = $100 - 5
			$200 = $200 - 5
			$500 = $500 - 5
			$4 = 3
			ENDIF
		endif

		if $3 == 2
		$100 = $100 + 5
		$4 = 1

			if $100 > 150
			$100 = $100 - 5
			$201 = $201 + 2
			$4 = 2
			ENDIF

			if $201 > 340
			$201 = $201 - 2
			$200 = $200 + 5
			$100 = $100 + 5
			$4 = 1
			endif

			if $100 > 675
			$100 = $100 - 5
			$200 = $200 - 5
			$601 = $601 + 2
			$4 = 2
			endif

			if $601 > 335
			$601 = 335
			$200 = $200 + 5
			$100 = $100 + 5
			$600 = $600 + 5
			$4 = 1
			ENDIF

			if $600 > 900
			$200 = $200 - 5
			$100 = $100 - 5
			$600 = $600 - 5
			$4 = 3
		ENDIF
	endif	
ENDIF

if $1.0 == on
	if $2 == 2
		if $3 == 0
		$100 = $100 + 5
		$4 = 1

			if $100 > 250
			$100 = $100 - 5
			$301 = $301 + 2
			$4 = 2
			ENDIF

			if $301 > 340
			$301 = $301 - 2
			$100 = $100 + 5
			$300 = $300 + 5
			$4 = 1
			ENDIF

			if $300 > 900
			$300 = $300 - 5
			$100 = $100 - 5
			$4 = 3
			endif
		endif

		if $3 == 1
		$100 = $100 + 5
		$4 = 1

			if $100 > 250
			$100 = $100 - 5
			$301 = $301 + 2
			$4 = 2
			endif

			if $301 > 340
			$100 = $100 + 5
			$301 = $301 - 2
			$300 = $300 + 5
			$4 = 1
			ENDIF

			if $300 > 540
			$100 = $100 - 5
			$300 = $300 - 5
			$501 = $501 + 2
			$4 = 2
			endif

			if $501 > 340
			$501 = $501 - 2
			$100 = $100 + 5
			$300 = $300 + 5
			$500 = $500 + 5
			$4 = 1
			ENDIF

			if $300 > 900
			$300 = $300 - 5
			$100 = $100 - 5
			$500 = $500 - 5
			$4 = 3
			endif
		ENDIF

		if $3 == 2
		$100 = $100 + 5
		$4 = 1

			if $100 > 250
			$100 = $100 - 5
			$301 = $301 + 2
			$4 = 2
			endif

			if $301 > 340
			$100 = $100 + 5
			$301 = $301 - 2
			$300 = $300 + 5
			$4 = 1
			ENDIF

			if $300 > 720
			$100 = $100 - 5
			$300 = $300 - 5
			$601 = $601 + 2
			$4 = 2
			ENDIF

			if $601 > 340
			$601 = $601 - 2
			$100 = $100 + 5
			$300 = $300 + 5
			$600 = $600 + 5
			$4 = 1
			ENDIF

			if $300 > 900
			$300 = $300 - 5
			$100 = $100 - 5
			$600 = $600 - 5
			$4 = 3
			endif
		ENDIF
	endif	
endif

if $1.0 == on
	if $2 == 3
		if $3 == 0
		$100 = $100 + 5
		$4 = 1

			if $100 > 345
			$100 = $100 - 5
			$401 = $401 + 2
			$4 = 2
			ENDIF

			IF $401 > 340
			$100 = $100 + 5
			$401 = $401 - 2
			$400 = $400 + 5
			$4 = 1
			ENDIF

			IF $400 > 900
			$400 = $400 - 5
			$100 = $100 - 5
			$4 = 3
			ENDIF
		ENDIF

		IF $3 == 1
		$100 = $100 + 5
		$4 = 1

			if $100 > 345
			$100 = $100 - 5
			$401 = $401 + 2
			$4 = 2
			ENDIF

			IF $401 > 340
			$100 = $100 + 5
			$401 = $401 - 2
			$400 = $400 + 5
			$4 = 1
			ENDIF

			IF $100 > 490
			$100 = $100 - 5
			$400 = $400 - 5
			$501 = $501 + 2
			$4 = 2
			ENDIF

			IF $501 > 340
			$501 = $501 - 2
			$100 = $100 + 5
			$400 = $400 + 5
			$500 = $500 + 5
			$4 = 1
			ENDIF

			IF $400 > 900
			$400 = $400 - 5
			$100 = $100 - 5
			$500 = $500 - 5
			$4 = 3
			ENDIF
		ENDIF

		IF $3 == 2
		$100 = $100 + 5
		$4 = 1

			if $100 > 345
			$100 = $100 - 5
			$401 = $401 + 2
			$4 = 2
			ENDIF

			IF $401 > 340
			$100 = $100 + 5
			$401 = $401 - 2
			$400 = $400 + 5
			$4 = 1
			ENDIF

			IF $100 > 670
			$100 = $100 - 5
			$400 = $400 - 5
			$601 = $601 + 2
			$4 = 2
			ENDIF

			IF $601 > 340
			$601 = $601 - 2
			$100 = $100 + 5
			$400 = $400 + 5
			$600 = $600 + 5
			$4 = 1
			ENDIF

			IF $400 > 900
			$400 = $400 - 5
			$100 = $100 - 5
			$600 = $600 - 5
			$4 = 3
			ENDIF
		ENDIF
	ENDIF
endif
ENDIF
*/



/*
 * 
 * namespace kanade
{
    public class Student
    {
        public required int StudentId { get; set; }
        public required string Name { get; set; }
        public required string Subject { get; set; }
        public required int Age { get; set; }
        public double Grade { get; set; }
        public required int DepartmentId { get; set; } 
    }
    public class Department
    {
        public required int DepartmentId { get; set; }
        public required string DName { get; set; }
    }
    public class StudentNameGrade
    {
        public required IEnumerable<string> Name { get; set; }
        public double Grade { get; set; }
        public required string Department { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            //var students = new List<Student>
            //{
            //    new Student { Name = "MAV", Subject = "IT104A", Age = 18, Grade = 1.9 },
            //    new Student { Name = "JUL", Subject = "IT104A", Age = 19, Grade = 2.0 },
            //    new Student { Name = "LEA", Subject = "IT104A", Age = 18, Grade = 3.5 },
            //};

            //var studentsNameAndSpecificSubject =
            //  (from student in students
            //   where student.Subject == "IT104A"
            //   select new
            //   {
            //       Name = student.Name
            //        ,
            //       Subject = student.Subject
            //   }).ToList();

            //foreach (var student in studentsNameAndSpecificSubject)
            //{
            //    Console.WriteLine(student.Name);
            //    Console.WriteLine(student.Subject);
            //}


            var student = new List<Student>();

            student.AddRange(
                new List<Student>
                {
                    new Student {StudentId = 1 ,Name = "Kanade" , Subject = "IT1014A" , Age = 18 , Grade = 2.8, DepartmentId = 1},
                    new () {StudentId = 2, Name = "MAV", Subject = "IT104A", Age = 18, Grade = 1.9, DepartmentId = 1},
                    new () {StudentId = 3, Name = "Glenjay" , Subject = "ITI104A" , Age = 18, Grade = 2.1  , DepartmentId = 2}
                });

            var department = new List<Department>();

            department.AddRange
            (
                new List<Department>
                {
                    new () {DepartmentId = 1, DName = "IT"},
                    new Department {DepartmentId = 2, DName = "ME" } 
                }
            );

            var linq = from students in student
                       join departments in department
                       on students.DepartmentId equals departments.DepartmentId
                       where students.Grade <= 3.0
                       group students by departments.DName into StudentDepartment
                       orderby StudentDepartment.Key // or any other property to order by, like DName
                       select new StudentNameGrade
                       {
                           Department = StudentDepartment.Key,
                           Name = (from record in StudentDepartment
                                  orderby record.Name
                                  select new
                                  {
                                      record.Name,
                                      record.Grade
                                  })
                       };




        }
    }
}

*/
