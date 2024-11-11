using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net.FtpClient;
using System.Linq;
using System.Threading.Tasks;

namespace mantis_tests
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {

        [TestFixtureSetUp]

        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config/config_inc.php");
            using (Stream localfile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config/config_inc.php", localfile);
            }
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php");
        }
    }
}


