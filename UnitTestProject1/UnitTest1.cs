using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }


        private Calculation c;
        [TestInitialize]
        public void Setup()
        {
            c = new Calculation(10, 5);
        }
        [TestMethod]
        public void TestAddOperator()
        {
            int Expected, Actual;
           // Calculation c = new Calculation(10, 5);
            Expected = 15;
            Actual = c.Exectute("+");
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void TestSubOperator()
        {
            int Expected, Actual;
            // Calculation c = new Calculation(10, 5);
            Expected = 5;
            Actual = c.Exectute("-");
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void TestMulOperator()
        {
            int Expected, Actual;
            // Calculation c = new Calculation(10, 5);
            Expected = 50;
            Actual = c.Exectute("*");
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void TestDivOperator()
        {
            int Expected, Actual;
            // Calculation c = new Calculation(10, 5);
            Expected = 2;
            Actual = c.Exectute("/");
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZeroOperator()
        {
            int Expected, Actual;
              c = new Calculation(10, 0);
            
             c.Exectute("/");
         
        }
      //liên kết test data với project
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TextData.csv", "TextData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource()
        {
            string operation;//4,6,'+,10
            int expected;
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            operation = TestContext.DataRow[2].ToString();
            operation = operation.Remove(0, 1);
             expected = int.Parse(TestContext.DataRow[3].ToString());
           

            Calculation c = new Calculation(a, b);
            int actual = c.Exectute("+");
            Assert.AreEqual(expected, actual);
        }
    }
}
