using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    static class Utils
    {
        public  static void DisplayOption()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("|     >>>>>>>>>>> WELCOME TO MANAGEMENT SOFTWARE PACKAGE SYSTEM <<<<<<<<<<" + "    " + DateTime.Now + "|");
            Console.WriteLine("--------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("Choose one of the options below: ");
            Console.WriteLine("1. Add a new student/teacher: ");
            Console.WriteLine("2. Delete a student/teacher: ");
            Console.WriteLine("3. Show all students/teachers in the system: ");
            Console.WriteLine("4. Find a student/teacher in the system: ");
            Console.WriteLine("5. Show all active students/teachers in the system: ");
            Console.WriteLine("6. Deactivate students/teachers: ");
            Console.WriteLine("7. Reactivate students/teachers: ");
            Console.WriteLine("8. Show all inactive students/teachers: ");
            Console.WriteLine("9. QUIT: ");
        }

        public static void AddMember(StudentsList studentsList, TeachersList teachersList)
        {
            int add;
            Console.WriteLine("Would like to add a student or a teacher? Choose below: ");
            Console.WriteLine("1. Add a student: ");
            Console.WriteLine("2. Add a teacher: ");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(),out add);
            while (add != 1 && add != 2 && add != 3)
            {
                
                Console.WriteLine("Choose:\n1. Add a student\n2. Add a teacher");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out add);
            }
            if (add == 1)
            {
                studentsList.AddMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if(add == 2)
            {
                teachersList.AddMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }

        public static void DeleteMember(StudentsList studentsList, TeachersList teachersList)
        {
            int remove;
            Console.WriteLine("Would like to remove a student or a teacher? Choose below: ");
            Console.WriteLine("1. Remove a student: ");
            Console.WriteLine("2. Remove a teacher: ");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(), out remove);
            while (remove != 1 && remove != 2 && remove != 3)
            {
                Console.WriteLine("Choose:\n1. Remove a student\n2. Remove a teacher");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out remove);
            }
            if (remove == 1)
            {
                studentsList.ShowAllMembers();
                studentsList.DeleteMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if (remove == 2)
            {
                teachersList.ShowAllMembers();
                teachersList.DeleteMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }

        public static void ShowMembers(StudentsList studentsList, TeachersList teachersList)
        {
            int showList;
            Console.WriteLine("Choose below: ");
            Console.WriteLine("1. List of all students: ");
            Console.WriteLine("2. List of all teachers: ");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(), out showList);
            while (showList != 1 && showList != 2 && showList != 3)
            {
                Console.WriteLine("Choose:\n1. Remove a student\n2. Remove a teacher");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out showList);
            }
            if (showList == 1)
            {
                studentsList.ShowAllMembers();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if (showList == 2)
            {
                
                teachersList.ShowAllMembers();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }

        public static void FindMembers(StudentsList studentsList, TeachersList teachersList)
        {
            int find;
            Console.WriteLine("Would like to find a student or a teacher? Choose below: ");
            Console.WriteLine("1. Find students: ");
            Console.WriteLine("2. Find teachers: ");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(), out find);

            while (find != 1 && find != 2 && find != 3)
            {
                Console.WriteLine("Choose below:\n1: Find students:\n2: Find teachers: ");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out find);
            }
            if (find == 1)
            {
                
                studentsList.ShowActiveId();
                studentsList.FindMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if (find == 2)
            {
                teachersList.ShowActiveId();
                teachersList.FindMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }

        public static void ShowActiveMembers(StudentsList studentsList, TeachersList teachersList)
        {
            int active;
            Console.WriteLine("Choose below: ");
            Console.WriteLine("1. Show all active students: \n2: Show all active teachers: ");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(), out active);
            while (active != 1 && active != 2 && active != 3)
            {
                Console.WriteLine("Choose below:\n1: Find students:\n2: Find teachers: ");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out active);
            }
            if (active == 1)
            {
                studentsList.GetActive();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if (active == 2)
            {
                teachersList.GetActive();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }

        public static void DeactiveMember(StudentsList studentsList, TeachersList teachersList)
        {
            int deactivate;
            Console.WriteLine("Would you like to deactivate a student or a teacher? Choose below: ");
            Console.WriteLine("1. Deactivate a student: \n2: Deactivate a teacher: ");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(), out deactivate);
            while (deactivate != 1 && deactivate != 2 && deactivate != 3)
            {
                Console.WriteLine("Choose below:\n1: Find students:\n2: Find teachers: ");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out deactivate);
            }
            if (deactivate == 1)
            {
                studentsList.Deactivate();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if (deactivate == 2)
            {
                teachersList.Deactivate();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }

        public static void ShowInactive(StudentsList studentsList, TeachersList teachersList)
        {
            int getInactive;
            Console.WriteLine("Would you like to show all inactive studetns or teachers in the system? Choose below: ");
            Console.WriteLine("1. Inactive studetns\n2. Inactive teachers ");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(), out getInactive);
            while(getInactive != 1 && getInactive != 2 && getInactive != 3)
            {
                Console.WriteLine("Would you like to show all inactive students or teachers in the system? Choose below: ");
                Console.WriteLine("1. Inactive students\n2. Inactive teachers");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out getInactive);
            }
            if(getInactive == 1)
            {
                Console.WriteLine("Showing all inactive students below:");
                studentsList.GetInactive();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if(getInactive == 2)
            {
                Console.WriteLine("Showing all inactive teachers below:");
                teachersList.GetInactive();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }

        public static void Reactivate(StudentsList studentsList, TeachersList teachersList)
        {
            int id;
            Console.WriteLine("Would you like to reactivate a student or a teacher? Choose below: ");
            Console.WriteLine("1. Reactivate student\n2. Reactivate teacher");
            Console.WriteLine("3. Go back to the main options page");
            int.TryParse(Console.ReadLine(), out id);
            while(id != 1 && id != 2 && id != 3)
            {
                Console.WriteLine("Would you like to reactivate a student or a teacher? Choose below: ");
                Console.WriteLine("1. Reactivate student\n2. Reactivate teacher");
                Console.WriteLine("3. Go back to the main options page");
                int.TryParse(Console.ReadLine(), out id);
            }
            if(id == 1)
            {
                studentsList.ReactivateMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();
            }
            else if(id == 2)
            {
                teachersList.ReactivateMember();
                Console.WriteLine("Press any key to continue...\n");
                Console.ReadKey();

            }
            else
            {
                Utils.DisplayOption();
                Console.Clear();
            }
        }
    }
}
