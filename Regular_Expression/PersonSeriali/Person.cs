using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace PersonSeriali
{
    public enum Genders { Male, Female, Monkey }

    [Serializable]
    public class Person : IDeserializationCallback
    {
        private string name, fileName;
        public string Name { get => name; set => name = value; }

        [NonSerialized]
        private int age;
        public int Age { get => age; set => age = value; }

        private Genders gender;
        public Genders Gender { get => gender; set => gender = value; }

        private DateTime birthDate;
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public Person(string name, DateTime birthDate, int genderCode)
        {
            GenderSelecter(genderCode);
            Validator(name, birthDate);
            Name = name;
            BirthDate = birthDate;
            AgeCalculator(birthDate);
            fileName = string.Format("{0}.bin", Name);
        }
        private void Validator(string name, DateTime birthDate)
        {
            if (name == null || birthDate == null || Gender.Equals(Genders.Monkey))
            {
                throw new ArgumentNullException();
            }
        }

        private void AgeCalculator(DateTime birthDate)
        {
            int now = DateTime.Now.Year;
            Age = now - birthDate.Year;
        }

        private void GenderSelecter(int genderCode)
        {
            switch (genderCode)
            {
                case 0:
                    Gender = Genders.Male;
                    break;
                case 1:
                    Gender = Genders.Female;
                    break;
                default:
                    Gender = Genders.Monkey;
                    break;
            }
        }

        public void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            
            using (Stream stream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
        }

        public static void Deserialize(string name)
        {
            Person obj;
            string fileName = name + ".bin";
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName,
                FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = (Person)formatter.Deserialize(stream); 
            }
            Console.WriteLine("Name: "+obj.Name);
            Console.WriteLine("BirthDate: "+obj.BirthDate);
            Console.WriteLine("Age: \n"+obj.Age + " from file");
            obj.AgeCalculator(obj.BirthDate);
            Console.WriteLine(obj.Age + " recalculated");
        }

        public override string ToString()
        {
            return string.Format("{0} was born on {1} {2} years old {3}.",
                Name, BirthDate.ToShortDateString(), Age, Gender);
        }

        public void OnDeserialization(object sender)
        {
            string message = "Deserialization started";
            for (int i = 0; i < 10; i++)
            {
                Console.Write(message);
                Thread.Sleep(500);
                message = ".";
            }
            Console.WriteLine();
        }
    }
}
