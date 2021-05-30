using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTese01
{
    public class Utility
    {
        public static void IsSuccess(bool success) 
        {
            if (success)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("failed");
            }
        }
    }
}
