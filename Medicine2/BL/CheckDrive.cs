using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL
{
   public class CheckDrive
    {
        public void Uplaod(HttpPostedFileBase file)
        {
            DAL.GoogleDriveAPIHelper g = new GoogleDriveAPIHelper();
            g.UplaodFileOnDrive(file);

        }
        public void del(string file)
        {
            DAL.GoogleDriveAPIHelper g = new GoogleDriveAPIHelper();
            List<GoogleDriveFile> u = g.GetDriveFiles();
            foreach (GoogleDriveFile f in u)
            {
                if (f.Name == file)
                {
                    g.DeleteFile(f);
                }
            }


        }

    }
}
