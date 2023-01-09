using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInfo.Models
{
    [Table("Student")]
    public class Student
    {
        [Key,Required]
        public int StudentId { set; get; }
        public string StudentName { set; get; }
        public string Address { set; get; }
        public int Age { set; get; }
        public DateTime BirthDate { set; get; }

    }
}
