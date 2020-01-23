using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    abstract class Person
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public ActiveEnum IsActive { get; set; }

        public Person() {}

        public Person(string name, int phone, string email, ActiveEnum isActive)
        {
            Name = name;
            Phone = phone;
            Email = email;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return $"\nName: {Name}, Phone: {Phone}, Email: {Email}, Active Status: {IsActive}, ";
        }

        public void SuccessfulColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void FailedColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void StandardColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void ReferenceColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }

}
