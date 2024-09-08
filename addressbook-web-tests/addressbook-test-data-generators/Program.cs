using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (type == "groups")
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"c:\Users\Anya\source\repos\Anyutka\csharp_training"+
                                      @"\addressbook-web-tests\addressbook-group-test-data-generators"+
                                       @"\bin\Debug\addressbook-group-test-data-generators.exe";
                p.StartInfo.Arguments = string.Join(" ", args.Skip(1));
                p.Start();
            }

            else if (type == "contacts")

            {

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = @"c:\Users\Anya\source\repos\Anyutka\csharp_training"+
                                      @"\addressbook-web-tests\addressbook-contact-test-data-generators"+
                                      @"\bin\Debug\addressbook_contact-test_data_generators.exe";
                p.StartInfo.Arguments = string.Join(" ", args.Skip(1));
                p.Start();
                
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
        }
    }
}
