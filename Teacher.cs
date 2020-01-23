using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    class Teacher : Employee
    {
        public int TeacherID { get; set; }
        public SubjectTaughtEnum Subject { get; set; }

        public Teacher() {}

        public Teacher(string name, int phone, string email, double salary, ActiveEnum isActive, int ID, SubjectTaughtEnum subject)
            : base(name, phone, email, isActive, salary)
        {
            TeacherID = ID;
            Subject = subject;
        }
        public override string ToString()
        {
            return base.ToString() + $"Teaching Subject: {Subject}, ID: {TeacherID}, ";
        }
    }
}