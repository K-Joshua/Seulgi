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

using (var context = new AppDbContext())
{
            var linq = context.Students
                .Join(context.Enrollments,
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



*/