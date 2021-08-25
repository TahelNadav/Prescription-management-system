using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine.Models
{
    public class Passwordmodel
    {
        public bool CheckAdminPassword(int id, string passWord)
        {
            UserPasswordBL user = new UserPasswordBL();
            return user.CheckAdminPassword(new UserPassword() { Id = id, Password = passWord });
        }
        public bool CheckDoctorPassword(int id, string passWord)
        {
            UserPasswordBL user = new UserPasswordBL();
            return user.CheckDoctorPassword(new UserPassword() { Id = id, Password = passWord });
        }

        public void AddPassword(UserPassword pass)
        {
            UserPasswordBL user = new UserPasswordBL();
            user.AddPassword(pass);
        }
    }
}