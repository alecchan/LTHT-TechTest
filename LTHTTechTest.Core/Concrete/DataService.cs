using System;
using LTHTTechTest.Core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace LTHTTechTest.Core.Concrete
{
    public class DataService : IDataService
    {
        private TechTestEntities _database = new TechTestEntities();

        public IEnumerable<Person> People
        {
            get { return _database.People; }
        }

        public IEnumerable<Colour> Colours
        {
            get { return _database.Colours; }
        }

        public Person GetPerson(int id)
        {
            return _database.People.SingleOrDefault(x => x.PersonId == id);
        }

        public void SaveChanges()
        {
            _database.SaveChanges();
        }

        public void Dispose()
        {
            if (_database != null)
            {
                _database.Dispose();
                _database = null;
            }
        }
    }
}
