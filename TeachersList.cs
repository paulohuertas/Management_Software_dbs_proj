using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    class TeachersList : Employee, IFunctionalities
    {
        private List<Teacher> teachersList = new List<Teacher>();

        public bool CheckId(int id)
        {
            bool found = false;
            foreach (var t in teachersList)
            {
                if (t.TeacherID == id)
                {
                    found = true;
                }
            }
            if (found)
            {
                FailedColor();
                Console.WriteLine("Teacher ID already exists.");
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

        public bool Compare(Teacher teacher)
        {
            bool found = false;

            foreach (var t in teachersList)
            {
                if (teacher.TeacherID == t.TeacherID)
                {
                    found = true;
                }
            }
            if (!found)
            {
                SuccessfulColor();
                Console.WriteLine($"Teacher ID {teacher.TeacherID} has been added successfuly");
                StandardColor();
            }
            return true;
        }

        public void Add(Teacher teacher)
        {
            teachersList.Add(teacher);
        }

        public void AddMember()
        {
            Teacher teacher = new Teacher();
            int enumInput;
            teacher.IsActive = ActiveEnum.Active;
            Console.WriteLine("Enter teacher ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
            {
                FailedColor();
                Console.WriteLine("You entered an invalid ID number.");
                Console.WriteLine("Enter teacher ID. ID must be numbers only.");
                StandardColor();
            }
            teacher.TeacherID = id;
            if(CheckId(teacher.TeacherID) == true)
            {
                Console.WriteLine("Enter teacher name: ");
                teacher.Name = Console.ReadLine();
                while (!IsAlphabetical(teacher.Name))
                {
                    Console.WriteLine("Name must contain letters.");
                    Console.WriteLine("Please enter teacher name: ");
                    teacher.Name = Console.ReadLine();
                    teacher.Name.Trim();
                }
                teacher.Name.Trim();
                int teacherPhone;
                Console.WriteLine("Enter teacher phone number: ");
                while (!int.TryParse(Console.ReadLine(), out teacherPhone))
                {
                    Console.WriteLine("Enter teacher phone number: ");
                }

                teacher.Phone = teacherPhone;

                double salary;
                Console.WriteLine("Enter teacher annual salary: ");
                while (!double.TryParse(Console.ReadLine(), out salary) || salary <= 0)
                {
                    Console.WriteLine("Enter teacher annual salary: ");
                }
                teacher.Salary = salary;

                Console.WriteLine("Enter teacher email: ");
                teacher.Email = Console.ReadLine();
                while (!teacher.Email.Contains('@') || !teacher.Email.Contains(".com") && !teacher.Email.Contains(".ie"))
                {
                    Console.WriteLine("Enter teacher email as follows: teacher@domain.com or teacher@domain.ie");
                    teacher.Email = Console.ReadLine();

                }
                Console.WriteLine("Enter teacher subject taught:\n1. Mathmatics\n2. Science\n3. Physical Education\n4. Art\n5. Music\n6. Computer Science\n7. Algebra\n8. English");
                int.TryParse(Console.ReadLine(), out enumInput);
                while (enumInput < 1 || enumInput > 8)
                {
                    Console.WriteLine("Enter teacher subject taught:");
                    int.TryParse(Console.ReadLine(), out enumInput);
                }
                teacher.Subject = (SubjectTaughtEnum)enumInput;
                if (Compare(teacher))
                {
                    teachersList.Add(teacher);
                }
                else
                {
                    FailedColor();
                    Console.WriteLine("Teacher was already added in the system\n");
                    StandardColor();
                }
            }
            
        }

        public void DeleteMember()
        {
            int memberId;
            bool removed = false;
            Console.WriteLine("Please enter teacher ID: ");
            memberId = GetTeacherId();

            for (int i = 0; i < teachersList.Count; i++)
            {
                if (memberId == teachersList[i].TeacherID)
                {
                    teachersList.Remove(teachersList[i]);
                    removed = true;
                }
            }
            if (removed == true)
            {
                SuccessfulColor();
                Console.WriteLine("Teacher has been removed\n");
                StandardColor();
            }
            else
            {
                FailedColor();
                Console.WriteLine("Teacher ID was not found. No teacher was removed\n");
                StandardColor();
            }
        }

        public void ShowAllMembers()
        {
            foreach (Teacher t in teachersList)
            {
                SuccessfulColor();
                Console.WriteLine(t.ToString());
                StandardColor();
            }
            if (teachersList.Count == 0)
            {
                FailedColor();
                Console.WriteLine("There are no members registered in the system.\n");
                StandardColor();
            }
        }
        public void FindMember()
        {
            int id;
            bool found = false;
            Console.WriteLine("Please enter teacher ID: ");
            id = GetTeacherId();

            foreach (Teacher t in teachersList)
            {
                if (t.TeacherID == id)
                {
                    SuccessfulColor();
                    Console.WriteLine($"The teacher ID {t.TeacherID} was found successfuly.");
                    Console.WriteLine($"Find teacher details below:\n{t.ToString()}\n");
                    StandardColor();
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                FailedColor();
                Console.WriteLine("There is no record of teacher ID in our system\n");
                StandardColor();
            }
        }

        public void Deactivate()
        {
            ShowActiveId();
            bool found = false;
            Console.WriteLine("Please enter teacher ID to deactivate from our system: ");
            int id = GetTeacherId();

            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeacherID == id)
                {
                    teachersList[i].IsActive = ActiveEnum.Inactive;
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                SuccessfulColor();
                Console.WriteLine("Teacher has been deactivated from the system\n");
                StandardColor();
            }
            else
            {
                FailedColor();
                Console.WriteLine("Teacher not found. Please try again\n");
                StandardColor();
            }

        }
        public int GetTeacherId()
        {
            int id;
            int.TryParse(Console.ReadLine(), out id);
            return id;
        }

        public void GetActive()
        {
            int totalActive = 0;
            foreach (Teacher t in teachersList)
            {
                if (t.IsActive == ActiveEnum.Active)
                {
                    SuccessfulColor();
                    Console.WriteLine(t.ToString());
                    StandardColor();
                    totalActive++;
                }
            }
            ReferenceColor();
            Console.WriteLine("Total active: {0}", totalActive);
            StandardColor();
            if(totalActive == 0)
            {
                FailedColor();
                Console.WriteLine("There are no active teachers in the system\n");
                StandardColor();
            }
        }

        public void GetInactive()
        {
            int totalInactive = 0;
            foreach (Teacher t in teachersList)
            {
                if (t.IsActive == ActiveEnum.Inactive)
                {
                    SuccessfulColor();
                    Console.WriteLine(t.ToString());
                    StandardColor();
                    totalInactive++;
                }
            }
            ReferenceColor();
            Console.WriteLine("Total inactive teacher IDs = {0}", totalInactive);
            StandardColor();
            if(totalInactive == 0)
            {
                FailedColor();
                Console.WriteLine("There are no inactive teachers in the system\n");
                StandardColor();
            }
        }

        public void ShowActiveId()
        {
            ReferenceColor();
            Console.WriteLine("List of all active teacher IDs in the system:\n");
            foreach (Teacher t in teachersList)
            {
                if (t.IsActive == ActiveEnum.Active)
                {
                    Console.WriteLine("ID: " + t.TeacherID);
                }
            }
            StandardColor();
        }

        public void ReactivateMember()
        {
            GetInactive();
            Console.WriteLine("Please enter teacher ID to reactivate from our system: ");
            int id = GetTeacherId();
            bool found = false;
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeacherID == id && teachersList[i].IsActive == ActiveEnum.Inactive)
                {
                    teachersList[i].IsActive = ActiveEnum.Active;
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
            foreach (char c in name)
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
