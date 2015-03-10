using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTHTTechTest.Models
{
    public class PeopleViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsEnabled { get; set; }
        public string Colours { get; set; }
        public bool IsPalindrome
        {
            get
            {
                var name = string.Format("{0}{1}", FirstName, LastName);
                var reverseName = new string(name.Reverse().ToArray());
                return name.Equals(reverseName, StringComparison.CurrentCultureIgnoreCase);
            }
        }
    }
}