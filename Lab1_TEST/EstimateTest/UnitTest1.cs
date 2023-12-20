using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AnalaizerClassLibrary;
using ErrorLibrary;

namespace EstimateTest
{
    [TestClass]
    public class EstimateTestClass
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=DESKTOP-55R71MF;Initial Catalog=testla1;Integrated Security=True", "estimate", DataAccessMethod.Sequential)]
        public void EstimateTest()
        {
            try
            {
                AnalaizerClass.expression = Convert.ToString(TestContext.DataRow["testvalues"]);


                string expected = Convert.ToString(TestContext.DataRow["result_values"]);


                string result = AnalaizerClass.Estimate();

                Assert.AreEqual(expected, result);
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual(ErrorsExpression.ERROR_01, ex.ParamName);
            }
        }
    }
}
