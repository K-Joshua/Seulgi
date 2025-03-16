using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryBasicInfo;

namespace LibraryBasicInfo.Tests
{
    [TestClass]
    public class BasicInfoTests
    {

        [TestMethod]
        public void Testing_Library()
        {
            var info = new BasicInfo()
            {
                FirstName = "Kanade",
                LastName = "Yoisaki",
                MiddleName = "Airi",
                Country = "Japan",
                City = "Tokyo",
                Street = "Sekai Street",
                Barangay = "Shibuya",
                HouseNumber = 39
            };

            Assert.AreEqual("Kanade", info.FirstName);
            Assert.AreEqual("Yoisaki", info.LastName);
            Assert.AreEqual("Airi", info.MiddleName);
            Assert.AreEqual('A', info.MiddleInitial);
            Assert.AreEqual("Japan", info.Country);
            Assert.AreEqual("Tokyo", info.City);
            Assert.AreEqual("Sekai Street", info.Street);
            Assert.AreEqual("Shibuya", info.Barangay);
            Assert.AreEqual(39, info.HouseNumber);
        }

        [TestMethod]
        public void AgeCalculation_KanadeYoisaki()
        {
            int age = BasicInfo.AgeCalculation(17, 3, 2025, 0, 2, 2004, 10);

            Assert.AreEqual(21, age); // Kanade turned 21 on February 10, 2025
        }
    }
}