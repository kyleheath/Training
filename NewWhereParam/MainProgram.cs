using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess;

namespace NewWhereParam
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Data myData = new Data();
            Console.WriteLine("Enter Search Parameter:");
            Console.WriteLine("Will display Company Name, Contact Name and Position, City, and Country");
            string name = Console.ReadLine();
            myData.Set(name, Console.ReadLine());
            List<Data.model> datalist;
            datalist = myData.Execute();
            foreach (Data.model datarow in datalist)
            {
                Console.WriteLine(datarow.CompanyName + " -- " + datarow.ContactName + " -- " + datarow.ContactTitle + " -- " + datarow.City + " -- " + datarow.Country);
            }
            Console.ReadLine();
        }
    }
}
