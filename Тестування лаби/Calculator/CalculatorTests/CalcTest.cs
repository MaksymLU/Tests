using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalcClassBr;
using ErrorLibrary;


namespace CalculatorTests
{
    [TestClass]
    public class CalcClassBrTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(local)\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True", "iabs", DataAccessMethod.Sequential)]
        public void IABSTest()
        {
            try
            {
                long test_value = Convert.ToInt64(TestContext.DataRow["test_value"]);

            
                int expected = Convert.ToInt32(TestContext.DataRow["result_value"]);

           
                
                int result = CalcClassBr.CalcClass.IABS(test_value);

                
                Assert.AreEqual(expected, result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                
                Assert.AreEqual(ErrorsExpression.ERROR_06, ex.ParamName);
            }
        }

    }
}
