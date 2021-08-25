using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserPasswordBL
    {
        public bool CheckAdminPassword(UserPassword user)
        {
            UserPasswordDAL dal = new UserPasswordDAL();
            return dal.CheckAdminPassword(user);
        }
        public bool CheckDoctorPassword(UserPassword user)
        {
            UserPasswordDAL dal = new UserPasswordDAL();
            return dal.CheckDoctorPassword(user);
        }
        public void UpdatePassword(int id, string newPassword)
        {
            UserPasswordDAL dal = new UserPasswordDAL();
            dal.UpdatePassword(id, newPassword);
        }
        public void AddPassword(UserPassword user)
        {
            UserPasswordDAL dal = new UserPasswordDAL();
            dal.AddPassword(user);
        }
    }
}
