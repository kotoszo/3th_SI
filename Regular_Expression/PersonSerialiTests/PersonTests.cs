using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonSeriali;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSeriali.Tests
{
    [TestClass()]
    public class PersonTests
    {

        private Person béla;

        private void Béla()
        {
            béla = new Person("Béla", new DateTime(1991,05,07), 0);
        }

        [TestMethod()]
        public void PersonWithValidInput_ReturnSameName()
        {
            Person béla = new Person("Béla", new DateTime(1991, 05, 07), 0);
            string name = "Béla";
            Assert.AreEqual(béla.Name, name);
        }

        [TestMethod()]
        public void PersonWithValidInput_ReturnSameBirthDate()
        {
            Béla();
            DateTime birthDate = new DateTime(1991, 05, 07);
            Assert.AreEqual(béla.BirthDate, birthDate);
        }

        [TestMethod()]
        public void PersonWithValidInput_ReturnSameGender()
        {
            Béla();
            Genders gender = Genders.Male;
            Assert.AreEqual(béla.Gender, gender);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonNameIsNull_ThrowException()
        {
            new Person(null, new DateTime(), 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonGenderCodeIsNOtValid_ThrowException()
        {
            new Person("Béla", new DateTime(), 3);
        }

        [TestMethod()]
        public void PersonTOString_ReturnThePersonName()
        {
            Béla();
            string name = "Béla";
            DateTime birthDate = béla.BirthDate;
            int age = béla.Age;
            Genders gender = béla.Gender;
            string result = string.Format("{0} was born on {1} {2} years old {3}.", 
                name, birthDate.ToShortDateString(), age, gender);
            Assert.AreEqual(béla.ToString(), result);
        }

        [TestMethod]
        public void WhenSerialize_CreateBinFile()
        {
            Béla();
            béla.Serialize();
            string fileName = FileNameForSerializaton(béla.Name);
            Assert.IsTrue(File.Exists(fileName));
        }
        
        [TestMethod]
        public void WhenSerialize_AfterDelete()
        {
            Béla();
            béla.Serialize();
            string fileName = FileNameForSerializaton(béla.Name);
            File.Delete(fileName);
            Assert.IsFalse(File.Exists(fileName));
        }

        private string FileNameForSerializaton(string name)
        {
            return name + ".bin";
        }
    }
}