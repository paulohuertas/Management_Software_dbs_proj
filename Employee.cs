using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    abstract class Employee : Person
    
    {
        public double Salary { get; set; }

        public Employee() {}

        public Employee(string name, int phone, string email, ActiveEnum isActive, double salary)
            :base(name, phone, email, isActive)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() + $"Annual Salary: {Salary}, ";
        }
    }

}
