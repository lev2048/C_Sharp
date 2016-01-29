using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager;

namespace JIAMI2
{
    class Program
    {
        static void Main(string[] args)
        {
            string srr, str = "123";
            srr = StringSecurity.DESEncrypt(str);
            Console.WriteLine("{0}", srr);         
            //string swr, ser = "";
            //swr = StringSecurity.DESDecrypt(ser);
            //Console.WriteLine("{0}", swr);
            Console.ReadKey();
        }
    }
}
