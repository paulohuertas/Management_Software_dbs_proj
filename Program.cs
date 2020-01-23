using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentsList studentsList = new StudentsList();
            TeachersList teachersList = new TeachersList();

            Student paulohu = new Student("Paulo Huertas", 0899421291, "paulohu@google.com", ActiveEnum.Active, StudentStatusEnum.Postgrad, 12345);
            Student gabrielhu = new Student("Gabriel Huertas", 0854526615, "gbl@google.com", ActiveEnum.Active, StudentStatusEnum.Postgrad, 52874);
            Student mayarar = new Student("Mayara Spinardi", 0831618049, "mayarar@google.com", ActiveEnum.Active, StudentStatusEnum.Undergrad, 10581);
            
            studentsList.Add(paulohu);
            studentsList.Add(gabrielhu);
            studentsList.Add(mayarar);

            Teacher clare = new Teacher("Clare Caulfield", 0892427891, "clare@dbs.ie", 45000, ActiveEnum.Active, 98765, SubjectTaughtEnum.ComputerScience);
            Teacher dani = new Teacher("Daniela", 0851255816, "dani@fisk.ie", 32000, ActiveEnum.Inactive, 12478, SubjectTaughtEnum.English);

            teachersList.Add(clare);
            teachersList.Add(dani);

            bool keepShowing = true;
            while (keepShowing)
            {
                Utils.DisplayOption();
                Console.WriteLine();
                int userOption;
                int.TryParse(Console.ReadLine(), out userOption);

                switch (userOption)
                {
                    case 1:
                        Utils.AddMember(studentsList, teachersList);
                        break;
                    case 2:
                        Utils.DeleteMember(studentsList, teachersList);
                        break;
                    case 3:
                        Utils.ShowMembers(studentsList, teachersList);
                        break;
                    case 4:
                        Utils.FindMembers(studentsList, teachersList);
                        break;
                    case 5:
                        Utils.ShowActiveMembers(studentsList, teachersList);
                        break;
                    case 6:
                        Utils.DeactiveMember(studentsList, teachersList);
                        break;
                    case 7:
                        Utils.Reactivate(studentsList, teachersList);
                        break;
                    case 8:
                        Utils.ShowInactive(studentsList, teachersList);
                        break;
                    case 9:
                        keepShowing = false;
                        break;
                    default:
                        Console.WriteLine("Please choose an valid option");
                        break;

                }
            }
        }
    }
}
