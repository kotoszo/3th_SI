using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regular_Expression
{
    public class Validator
    {
        public bool IsValidName(string name)
        {
            string nameField = "[A-Za-z]+";
            string spaceField = @"\s";
            string pattern = "^(" + nameField + spaceField + "*)+$";
            return Regex.IsMatch(name, pattern);
           // return Regex.IsMatch(name, @"^([A-Za-z]+\s*)+$");
        }

        public bool IsValidPhone(string phone)
        {
            string fourNumber = @"\d{4}-";
            string threeNumber = @"\d{3}";
            string pattern = "^(" + fourNumber + fourNumber + threeNumber + ")+$";
            return Regex.IsMatch(phone, pattern);
            //return Regex.IsMatch(phone, @"^(\d{4}-\d{4}-\d{3})+$");
        }

        public bool IsValidEmail(string email)
        {
            string address = "[A-Za-z0-9]*";
            string domain = @"\@[a-z]{1,20}";
            string tail = @"\.[a-z]{1,20}";
            string pattern = "^(" + address + domain + tail + ")+$";
            return Regex.IsMatch(email, pattern);
            //return Regex.IsMatch(email, @"^([A-Za-z0-9]*\@[a-z]{1,20}\.[a-z]{1,20})+$");
        }
    }
}
