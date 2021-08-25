using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            DrugDAL drugDAL = new DrugDAL();
           // drugDAL.AddDrug(new Drug() { NDC = "123", Name = "Acamol"});
            //drugDAL.RemoveDrug("123");
            drugDAL.AddDrug(new Drug() { NDC = "123", Name = "Advil" ,GenericName = "cccc"});
        }
    }
}
