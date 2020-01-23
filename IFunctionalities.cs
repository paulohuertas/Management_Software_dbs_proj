using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Software_Package
{
    interface IFunctionalities
    {
        bool CheckId(int id);
        void AddMember();
        void DeleteMember();
        void ShowAllMembers();
        void FindMember();
        void Deactivate();
        void GetActive();
        void GetInactive();
        void ShowActiveId();
        void ReactivateMember();
        bool IsAlphabetical(string name);
    }
}
