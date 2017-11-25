using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regular_Log
{
    public class Validator
    {
        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^([A-Za-z]*\s*)+$");
        }

        public bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(\d{2}-d{2}-d{4}-d{3})+$");
        }

        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([A-Za-z0-9]*{@}*)+$");
        }

    }
}
