using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserPasswordDAL
    {

        public bool CheckDoctorPassword(UserPassword user)
        {
            using (var ctx = new MedicineContext())
            {
                if (ctx.Doctors.Find(user.Id) == null)
                    throw new Exception("משתמש לא קיים במערכת");
                UserPassword userPassword = ctx.UsersPasswords.Find(user.Id);
                if (user.Password != userPassword.Password)
                    return false;
                return true;

            }
        }

        public bool CheckAdminPassword(UserPassword user)
        {
            using (var ctx = new MedicineContext())
            {
                UserPassword userPassword = ctx.UsersPasswords.Find(user.Id);
                if (userPassword == null|| ctx.Doctors.Find(user.Id) != null)
                    throw new Exception("משתמש לא קיים במערכת");
                if (user.Password != userPassword.Password)
                    return false;
                return true;

            }
        }

        public void UpdatePassword(int id, string newPassword)
        {
            using (var ctx = new MedicineContext())
            {
                UserPassword userPassword = ctx.UsersPasswords.Find(id);
                if (userPassword == null)
                    throw new Exception("משתמש לא קיים במערכת");
                userPassword.Password = newPassword;
                ctx.SaveChanges();

            }
        }

        public void AddPassword(UserPassword user)
        {
            using (var ctx = new MedicineContext())
            {
                UserPassword userPassword = ctx.UsersPasswords.Find(user.Id);
                if (userPassword != null)
                    throw new Exception("משתמש  קיים במערכת");
                ctx.UsersPasswords.Add(user);
                ctx.SaveChanges();
                

            }
        }
        public void RemovePassword(UserPassword user)
        {
            using (var ctx = new MedicineContext())
            {
                UserPassword userPassword = ctx.UsersPasswords.Find(user.Id);
                if (userPassword == null)
                    throw new Exception("ת.ז לא קיימת ");
                ctx.UsersPasswords.Remove(user);
                ctx.SaveChanges();


            }
        }
    }
}
