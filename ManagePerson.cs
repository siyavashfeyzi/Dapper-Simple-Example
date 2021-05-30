using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTese01
{
    public class ManagePerson
    {
        private static string ConnectionString = "Data Source =.; Initial Catalog = Name of DB; User ID =****; Password =********; ";

        public static List<Person> GetAllPerson()
        {
            List<Person> list;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                list = db.Query<Person>("Select * From Person").ToList();
            }

            return list;
        }

        public static Person GetPersonById(int Id)
        {
            Person person;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                person = db.Query<Person>("Select * From Person Where ID = @ID", new { ID = Id }).SingleOrDefault();
            }
            return person;
        }

        public static bool CreatePerson(CreatePerson person)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string query = "Insert Into Person (FName, LName) Values(@FName, @LName)";
                    db.Execute(query, person);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EditPerson(Person person)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string query = "Update Person Set  FName=@FName, LName=@LName Where ID = @ID";
                    db.Execute(query, person);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeletePerson(int Id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    string query = "Delete From Person Where ID = @ID";
                    db.Execute(query, new { ID = Id });
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
