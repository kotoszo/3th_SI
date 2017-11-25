using System;
using PersonSeriali;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PersonTest
    {
        private Person béla;

        private void Béla()
        {
            béla = new Person("Béla", new DateTime(1991 - 05 - 07), 0);
        }

        [TestMethod]
        public void PersonWithValidInput_ReturnSameName()
        {
            Person béla = new Person("Béla", new DateTime(1991 - 05 - 07), 0);
            string name = "Béla";
            Assert.AreEqual(béla.Name, name);
        }

        [TestMethod]
        public void PersonWithValidInput_ReturnSameBirthDate()
        {
            Béla();
            DateTime birthDate = new DateTime(1991 - 05 - 07);
            Assert.AreEqual(béla.BirthDate, birthDate);
        }

        [TestMethod]
        public void PersonWithValidInput_ReturnSameGender()
        {
            Béla();
            Genders gender = Genders.Male;
            Assert.AreEqual(béla.Gender, gender);
        }
    }
}
