using System.Net.Cache;

namespace StudentInfo.Models
{
    public class DbHelper
    {
        private StudentDbContext _context;

        public DbHelper(StudentDbContext context)
        {
            _context = context;
        }

        //Get Call for all data
        public List<Student> GetStudents()
        {
            List<Student> response = new List<Student>();

            var datalist=_context.Students.ToList();
            datalist.ForEach(row => response.Add(new Student()
            {
                StudentName = row.StudentName,
                StudentId = row.StudentId,
                Address = row.Address,
                Age = row.Age,
                BirthDate= row.BirthDate,
            }));
            return response;
        }

        //Get Call By Id
        public Student GetStudentById(int id)
        {
            Student response=new Student();
            var row = _context.Students.Where(d=>d.StudentId.Equals(id)).FirstOrDefault();

            return new Student() {
                StudentId = row.StudentId,
                StudentName = row.StudentName,
                Address = row.Address,
                Age = row.Age,
                BirthDate = row.BirthDate,
                };
        }
        public void SaveStudent(Student student)
        { 
            Student dtTable=new Student();

            if(dtTable.StudentId<0)
            {
                //Put Call
                dtTable = _context.Students.Where(s=>s.StudentId.Equals(student.StudentId)).FirstOrDefault();
                if(dtTable != null)
                {
                    dtTable.StudentId = student.StudentId;
                    dtTable.StudentName = student.StudentName;
                    dtTable.Address = student.Address;
                    dtTable.Age = student.Age;
                    dtTable.BirthDate = student.BirthDate;
                }
             
            }
            else
            {
                //Post Call
                dtTable.StudentName = student.StudentName;
                dtTable.Address = student.Address;
                dtTable.Age = student.Age;
                dtTable.BirthDate = student.BirthDate;
                _context.Students.Add(dtTable);
            }
            _context.SaveChanges();

        }

        public ResponseType DeleteStudent(int studentId)
        {
            var student=_context.Students.Where(d=>d.StudentId.Equals(studentId)).FirstOrDefault();
            if(student!=null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return ResponseType.Success;
            }
            else
            {
                return ResponseType.NotFound;
            }
        }
         
    }
}
