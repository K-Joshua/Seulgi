using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryBasicInfo;
using LinqUsingDbContext;
using System.Data.Entity;

#if NET48
using System.Data.SqlTypes;
#endif

using System;

namespace LibraryBasicInfo.Tests
{
    [TestClass]
    public class TestModel
    {
        private BasicInfo test;

        [TestInitialize]
        public void Setup()
        {
            test = new BasicInfo();
        }

        [TestMethod]
        public void TestFirstName() =>     
        Assert.AreEqual("Kanade", test.FirstName = "Kanade");

        [TestMethod]
        public void TestMiddleInitial() => 
        Assert.AreEqual('Y', test.MiddleInitial = 'Y');

        [TestMethod]
        public void TestMiddleName() => 
        Assert.AreEqual("Yoisaki", test.MiddleName = "Yoisaki");

        [TestMethod]
        public void TestLastName() => 
        Assert.AreEqual("Santos", test.LastName = "Santos");

        [TestMethod]
        public void TestHouseNumber() => 
        Assert.AreEqual(27, test.HouseNumber = 27);

        [TestMethod]
        public void TestStreet() => 
        Assert.AreEqual("Sekai Street", test.Street = "Sekai Street");

        [TestMethod]
        public void TestBarangay() => 
        Assert.AreEqual("Shibuya", test.Barangay = "Shibuya");

        [TestMethod]
        public void TestCity() => 
        Assert.AreEqual("Tokyo", test.City = "Tokyo");

        [TestMethod]
        public void TestCountry() => 
        Assert.AreEqual("Japan", test.Country = "Japan");

        [TestMethod]
        public void AgeCalculation_K()
        {
            int age = BasicInfo.AgeCalculation(17, 3, 2025, 2, 2004, 10);
            Assert.AreEqual(21, age);
        }

        [TestMethod]
        public void LeapYearTest()
        {
            bool isLeapYear = BasicInfo.IsLeapYear(2000);
            Assert.IsTrue(isLeapYear);
        }

        [TestClass]
        public class TestDatabase
        {
            private BasicInfo test;
            private AppDbContext db;

            [TestInitialize]
            public void Setup()
            {
                test = new BasicInfo();
                db = new AppDbContext();
            }

            [TestMethod]
            public void TestDatabaseInsert()
            {
                test.FirstName = "Kanade";
                test.MiddleName = "Yoisaki";
                test.MiddleInitial = 'Y';
                test.LastName = "Santos";
                test.HouseNumber = 27;
                test.Barangay = "Sekai";
                test.Street = "Sekai St.";
                test.City = "Tokyo";
                test.Country = "Japan";

                Assert.ThrowsException<Exception>(() =>
                {
                    try
                    {
                        db.Insert(test);
                        throw new Exception();
                    }
                    catch { }
                });
            }

            [TestMethod]
            public void TestDatabaseSelect()
            {
                Assert.ThrowsException<Exception>(() =>
                {
                    try
                    {
                        db.Select();
                        throw new Exception();
                    }
                    catch { }
                });
            }
        }
    }
}
