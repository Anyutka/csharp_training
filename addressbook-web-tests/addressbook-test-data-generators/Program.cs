using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args.FirstOrDefault();
            if (type == "groups")
            {
                GroupGenerator.Generate(args.Skip(1).ToArray());
            }
            else if (type == "contacts")
            {
                ContactGenerator.Generate(args.Skip(1).ToArray());
            }
            else
            {
                System.Console.Out.Write("Unrecognized type " + type);
            }
        }
    }
}
