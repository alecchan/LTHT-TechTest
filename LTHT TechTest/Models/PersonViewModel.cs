using System.Collections.Generic;

namespace LTHTTechTest.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsEnabled { get; set; }
        public IEnumerable<ColourViewModel> Colours { get; set; }
    }
}