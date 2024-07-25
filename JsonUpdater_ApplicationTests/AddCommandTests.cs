using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonUpdater_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUpdater_Application.Tests
{
    [TestClass()]
    public class AddCommandTests
    {
        [TestMethod()]
        public void ExecuteAddCommandTest()
        {
            try
            {
                new AddCommand("FirstName:Ivan", "LastName:Ivanov", "Salary:100.50").Execute();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }


        }
    }
}