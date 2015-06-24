using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Here's where we add new System.'s
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Data
        //This is the same Data used in MainProgram.cs
    {
        SqlConnection myConnection = new SqlConnection("server=.\\SQLEXPRESS; Trusted_Connection=yes; database=NORTHWND");
        //myConnection is the namespace for class SqlConnection
        //and will be used as the namespace for all SqlConnection below
        SqlCommand myCommand;
        //and myCommand is the name of the instance for class SqlCommand
        //and will be used as the namespace for all SqlCommands below
        SqlParameter myParam, myParam2;
       //using myParam, myParam2 here because it is now labeled
       //as a class and can successfully be used as one

        public class model
        //'public'-any other class can use this class
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            //strong typing
        }

        public model updatemodel = new model();


        public Data()
        //why is there no 'void' or 'class'?
        //this is being used as a method

            //constructor is starting method for class
        {
            Prepare();
            //Open() and Prepare() are here to show they are executed when Data() is used
        }

        public void Open()
        //'public' = any other class can use this class
        //'void' = does NOT return value
        //'()' = what would normally go inside that is instead below[?]
        //'Open' is used as the namespace for the method
        {
            try                               // '.' means this computer                  //database is the NAME of database,
            {                                 // which would be used IF                   //not the type or kind
                myConnection.Open();          // on local server/internet
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }                   //e.Message prompts a message to the user
                                //telling him there was an error
            //
            //Always use try catch on connections
            //It makes it so much smoother and easier
            //to analyze if something foes awry
        }

        public void Prepare()
        //'public' = any class can use this method
        //'void' = does NOT return value
        {
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            //Since 'myConnection' was defined earlier, it can be stated as is
            myCommand.CommandText = "select * from Customers where CompanyName like @Companies and ContactName like @Contacts";
            //'CommandText' is what is run       //this is a proper where clause. Use for reference!!

            myParam = new SqlParameter("@Companies", SqlDbType.VarChar, 50);
            myParam2 = new SqlParameter("@Contacts", SqlDbType.VarChar, 50);
            //@Column, Type.charactertype, characterlength
            //If I have more Parameters, I need more buttons

            myCommand.Parameters.Add(myParam);
            myCommand.Parameters.Add(myParam2);
            //This adds these parameters to the Command
        }

        public void Set(string Companies, string Contacts)
        {
            myParam.Value = "%" + Companies.Trim() + "%";
            myParam2.Value = "%" + Contacts.Trim() + "%";
            //use '%' as a wild card, AKA user input
        }

        public List<model> Execute()
            //in this, 'model' is a class defined further down the code
        {
            Open();

            List<model> mylist = new List<model>();

            try
            {
                SqlDataReader myReader;
                //SqlDataReader reads the data given
                myReader = myCommand.ExecuteReader();
                //I am making myReader class the same as a command to execute the reader
                while (myReader.Read())
                //while loop is used so it constantly goes through this list to update accordingly
                {
                    model mymodel = new model();
                    mymodel.CustomerID = myReader["CustomerID"].ToString();
                    mymodel.CompanyName = myReader["CompanyName"].ToString();
                    mymodel.ContactName = myReader["ContactName"].ToString();
                    mymodel.ContactTitle = myReader["ContactTitle"].ToString();
                    mymodel.City = myReader["City"].ToString();
                    mymodel.Country = myReader["Country"].ToString();
                    mymodel.Address = myReader["Address"].ToString();
                    mymodel.Region = myReader["Region"].ToString();
                    mymodel.PostalCode = myReader["PostalCode"].ToString();
                    mymodel.Fax = myReader["Fax"].ToString();
                    mymodel.Phone = myReader["Phone"].ToString();
                    //It's cleaner if .model is the column also
                    

                    mylist.Add(mymodel);
                 //this adds an object to the end of System.Collections.Generic.List<T>
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            //ALWAYS use 'e.Message' and 'try...catch' to find out what exactly errored
            }

            myConnection.Close();
            //this closes the connection
            return mylist;
            //this makes sure we don't keep the connection open during searches and things
            //this allows minimal access to db

        }

        public void Update()
       
        {
            if (updatemodel.CustomerID != null)

            {
                SqlConnection Connection1 = new SqlConnection("server=.\\SQLEXPRESS; Trusted_Connection=yes; database=NORTHWND");
                try                               // '.' means this computer                  //database is the NAME of database,
                {                                 // which would be used IF                   //not the type or kind
                    Connection1.Open();          // on local server/internet
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                   //e.Message prompts a message to the user
                //telling him there was an error
                //
                //Always use try catch on connections
                //It makes it so much smoother and easier
                //to analyze if something foes awry

                SqlCommand Command1 = new SqlCommand();
                Command1.Connection = Connection1;
                //Since we are having a new command outside of the original connection
                //we must have a new connection
                // *For future try to make connections numerical in programs*

                Command1.CommandText = "update Customers set" +
                " CustomerID=@CustomerID" +
                ", ContactName=@ContactName" +
                ", CompanyName=@CompanyName" +
                ", ContactTitle=@ContactTitle " +
                ", Address=@Address" +
                ", City=@City" +
                ", Country=@Country" +
                ", Region=@Region" +
                ", PostalCode=@PostalCode" +
                ", Phone=@Phone" +
                ", Fax=@Fax" +
                " where CustomerID=@CustomerID";

                Command1.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@ContactName", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@CompanyName", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@ContactTitle", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@Address", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@City", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@Country", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@Region", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@Phone", SqlDbType.VarChar, 50));
                Command1.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 50));

                Command1.Parameters["@CustomerID"].Value = updatemodel.CustomerID;
                Command1.Parameters["@ContactName"].Value = updatemodel.ContactName;
                Command1.Parameters["@CompanyName"].Value = updatemodel.CompanyName;
                Command1.Parameters["@ContactTitle"].Value = updatemodel.ContactTitle;
                Command1.Parameters["@Address"].Value = updatemodel.Address;
                Command1.Parameters["@City"].Value = updatemodel.City;
                Command1.Parameters["@Country"].Value = updatemodel.Country;
                Command1.Parameters["@Region"].Value = updatemodel.Region;
                Command1.Parameters["@PostalCode"].Value = updatemodel.PostalCode;
                Command1.Parameters["@Phone"].Value = updatemodel.Phone;
                Command1.Parameters["@Fax"].Value = updatemodel.Fax;

                Command1.ExecuteNonQuery();

                Connection1.Close();

            }
        }
    }
}
