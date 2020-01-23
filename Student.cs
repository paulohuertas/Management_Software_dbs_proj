using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    class Student : Person
    {

        public StudentStatusEnum Status { get; set; }
        public int StudentID { get; set; }

        public Student() {}

        public Student(string name, int phone, string email, ActiveEnum isActive, StudentStatusEnum status, int studentId)
            : base(name, phone, email, isActive)
        {
            Status = status;
            StudentID = studentId;

        }

        public override string ToString()
        {
            return base.ToString() + $"Status: {Status}, StudentID: {StudentID}";
        }
    }
}
