using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    class StudentsList : Student, IFunctionalities
    {
        private List<Student> studentsList = new List<Student>();

        public bool CheckId(int id)
        {
            bool found = false;
            foreach (var s in studentsList)
            {
                if (s.StudentID == id)
                {
                    found = true;
                }
            }
            if (found)
            {
                FailedColor();
                Console.WriteLine("Student ID already exists.");
                StandardColor();
                return false;
            }
            else
            {
                SuccessfulColor();
                Console.WriteLine("Such ID has never been introduced before. Go ahead and complete the registration");
                StandardColor();
                return true;
            }
        }

        public bool Compare(Student student)
        {
            bool found = false;

            foreach (var s in studentsList)
            {
                if (student.StudentID == s.StudentID)
                {
                    found = true;
                }
            }
            if (!found)
            {
                SuccessfulColor();
                Console.WriteLine($"Student {student.StudentID} has been added successfuly");
                StandardColor();
            }
            return true;
        }

        public void Add(Student student)
        {
            studentsList.Add(student);
        }

        public void AddMember()
        {
            Student student = new Student();
            string enumInput;
            student.IsActive = ActiveEnum.Active;
            Console.WriteLine("Enter student ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) ||  id < 0)
            {
                FailedColor();
                Console.WriteLine("You entered an invalid ID number.");
                Console.WriteLine("Enter student ID. ID must be numbers only.");
                StandardColor();
            }
            student.StudentID = id;
            if(CheckId(student.StudentID) == true)
            {
                Console.WriteLine("Enter student name: ");
                student.Name = Console.ReadLine();
                while (!IsAlphabetical(student.Name))
                {
                    Console.WriteLine("Name must contain letters.");
                    Console.WriteLine("Please enter student name: ");
                    student.Name = Console.ReadLine();

                }
                student.Name.Trim();
                int studentPhone;
                Console.WriteLine("Enter student phone number: ");
                while (!int.TryParse(Console.ReadLine(), out studentPhone))
                {
                    Console.WriteLine("Enter student phone number: ");
                }
                student.Phone = studentPhone;
                Console.WriteLine("Enter student email: ");
                student.Email = Console.ReadLine();
                student.Email.Trim();
                while (!student.Email.Contains('@') || !student.Email.Contains(".com") && !student.Email.Contains(".ie"))
                {
                    Console.WriteLine("Enter student email as follows: student@domain.com or student@domain.ie");
                    student.Email = Console.ReadLine();
                    student.Email.Trim();
                }
                Console.WriteLine("Enter student status: Undergrad OR Postgrad");
                enumInput = Console.ReadLine();
                while (enumInput.ToUpper() != "UNDERGRAD" && enumInput.ToUpper() != "POSTGRAD")
                {
                    Console.WriteLine("Enter student status: Undergrad OR Postgrad");
                    enumInput = Console.ReadLine();
                }
                if (enumInput == "POSTGRAD")
                {
                    student.Status = StudentStatusEnum.Postgrad;
                }
                else
                {
                    student.Status = StudentStatusEnum.Undergrad;
                }
                if (Compare(student))
                {
                    studentsList.Add(student);
                }
            }
            
        }

        public void DeleteMember()
        {
            int memberId;
            bool removed = false;
            Console.WriteLine("Please enter student ID (numbers only): ");
            memberId = GetStudentId();

            for(int i = 0; i < studentsList.Count; i++)
            {
                if(memberId == studentsList[i].StudentID)
                {
                    studentsList.Remove(studentsList[i]);
                    removed = true;
                }
            }
            if(removed == true)
            {
                SuccessfulColor();
                Console.WriteLine("Student has been removed\n");
                StandardColor();
            }
            else
            {
                FailedColor();
                Console.WriteLine("Student ID was not found. No student was removed\n");
                StandardColor();
            }
        }

        public void ShowAllMembers()
        {
            foreach (Student s in studentsList)
            {
                if (studentsList.Count == 0)
                {
                    FailedColor();
                    Console.WriteLine("There are no members registered in the system.\n");
                    StandardColor();
                }
                else
                {
                    SuccessfulColor();
                    Console.WriteLine(s.ToString());
                    StandardColor();
                }
            }
            
        }
        public void FindMember()
        {
            int id;
            bool found = false;
            Console.WriteLine("Please enter student ID: ");
            id = GetStudentId();

            foreach (Student s in studentsList)
            {
                if(s.StudentID == id)
                {
                    SuccessfulColor();
                    Console.WriteLine($"The student ID {s.StudentID} was found successfuly.\n");
                    Console.WriteLine($"Find student details below:\n{s.ToString()}\n");
                    StandardColor();
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                FailedColor();
                Console.WriteLine("There is no record of student id in our system\n");
                StandardColor();
            }
        }

        public void Deactivate()
        {
            ShowActiveId();
            bool found = false;
            Console.WriteLine("Please enter student id to deactivate from our system: ");
            int id = GetStudentId();

            for(int i = 0; i < studentsList.Count; i++)
            {
                if(studentsList[i].StudentID == id)
                {
                    studentsList[i].IsActive = ActiveEnum.Inactive;
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                SuccessfulColor();
                Console.WriteLine("Student has been deactivated from the system\n");
                StandardColor();
            }
            else
            {
                FailedColor();
                Console.WriteLine("Unable to deactivate student from the system. Do you have the correct ID?\n");
                StandardColor();

            }
           
        }
        public int GetStudentId()
        {
            int id;
            int.TryParse(Console.ReadLine(), out id);
            return id;
        }

        public void GetActive()
        {
            int totalActive = 0;
            foreach (Student s in studentsList)
            {
                if(s.IsActive == ActiveEnum.Active)
                {
                    SuccessfulColor();
                    Console.WriteLine(s.ToString());
                    StandardColor();
                    totalActive++;
                }
            }
            ReferenceColor();
            Console.WriteLine("Total active students: {0}", totalActive);
            StandardColor();
            if (totalActive == 0)
            {
                FailedColor();
                Console.WriteLine("There are no active students in the system\n");
                StandardColor();
            }
        }  

        public void GetInactive()
        {
            int totalInactive = 0;
            foreach(Student s in studentsList)
            {
                if(s.IsActive == ActiveEnum.Inactive)
                {
                    SuccessfulColor();
                    Console.WriteLine(s.ToString());
                    totalInactive++;
                    StandardColor();
                }
            }
            ReferenceColor();
            Console.WriteLine("Total inactive student IDs = {0}", totalInactive);
            StandardColor();
            if(totalInactive == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no inactive students in the system.\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void ShowActiveId()
        {
            ReferenceColor();
            Console.WriteLine("List of all active student IDs in the system:\n");
            foreach (Student s in studentsList)
            {
                if(s.IsActive == ActiveEnum.Active)
                { 
                    Console.WriteLine("ID: " + s.StudentID);
                    
                }
            }
            StandardColor();
        }
        
        public void ReactivateMember()
        {
            GetInactive();
            Console.WriteLine("Please enter student ID to reactivate from our system: ");
            int id = GetStudentId();
            bool found = false;
            for(int i = 0; i < studentsList.Count; i++)
            {
                if(studentsList[i].StudentID == id && studentsList[i].IsActive == ActiveEnum.Inactive)
                {
                    studentsList[i].IsActive = ActiveEnum.Active;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                SuccessfulColor();
                Console.WriteLine($"The ID {id} has been reactivated successfully");
                StandardColor();
            }
            else
            {
                FailedColor();
                Console.WriteLine($"The ID {id} does not match a valid ID in our system. Do you have the correct ID?");
                StandardColor();
            }
        }
        public bool IsAlphabetical(string name)
        {
            foreach(char c in name)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
