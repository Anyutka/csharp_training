using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class TestBase

    {
        public ApplicationManager app;

        [TestFixtureSetUp]
        public void initApplication()
        {
            app = new ApplicationManager();
        }
        
        [TestFixtureTearDown]

        public void stopApplication()
        {
            app.Stop();
        }

    }   
    
}
