using System;
using System.Collections.Generic;

namespace DapperTese01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool Want;
            bool Success;
            do
            {
                Console.WriteLine("Select your Item:\n1-GetAllPerson\n2-GetPersonById\n3-Create Person\n4.Edit\n5.Delete");
                int ItemSelect = Convert.ToInt32(Console.ReadLine());
                
                switch (ItemSelect)
                {
                    case 1:
                        List<Person> list = ManagePerson.GetAllPerson();                      
                        foreach (Person item in list)
                        {
                            Console.WriteLine(string.Format("ID : {0}  LName : {1}   FName : {2}", item.ID, item.LName, item.FName));
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter Id:");
                        int id = Convert.ToInt32(Console.ReadLine());                      
                       
                        Person getPersonById = ManagePerson.GetPersonById(id);
                        if (getPersonById != null)
                        {
                            Console.WriteLine(string.Format("ID : {0}  FName : {1}   LName : {2}", getPersonById.ID, getPersonById.FName, getPersonById.LName));
                        }
                        else { Utility.IsSuccess(false); }
                        break;

                    case 3:
                        CreatePerson person = new CreatePerson();                        
                        
                        Console.WriteLine("Enter Person First Name: ");
                        person.FName = Console.ReadLine();
                        Console.WriteLine("Enter Person Last Name: ");
                        person.LName = Console.ReadLine();

                        Success = ManagePerson.CreatePerson(person);
                        Utility.IsSuccess(Success);
                        break;
                    case 4:
                        Console.WriteLine("Enter ID: ");
                        int ID = Convert.ToInt32(Console.ReadLine());

                        Person Editperson = ManagePerson.GetPersonById(ID);
                        Console.WriteLine(string.Format("ID : {0}  FName : {1}   LName : {2}", Editperson.ID, Editperson.FName, Editperson.LName));

                        Console.WriteLine("First name : {0}", Editperson.FName);
                        Editperson.FName = Console.ReadLine();
                        Console.WriteLine("Last name : {0}", Editperson.LName);
                        Editperson.LName = Console.ReadLine();

                        Success = ManagePerson.EditPerson(Editperson);
                        Utility.IsSuccess(Success);
                        break;
                    case 5:
                        Console.WriteLine("Enter the Id : ");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        Success = ManagePerson.DeletePerson(Id);
                        Utility.IsSuccess(Success);
                        break;
                        break;
                }

                Console.WriteLine("do you want to continue? y/n");
                string Continue = Console.ReadLine();
                Want = String.Equals(Continue, "y") ? true : false;
               
            } while (Want);

        }
    }
}
