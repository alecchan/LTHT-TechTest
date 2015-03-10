using System;
using System.Collections.Generic;
using LTHTTechTest.Core.Concrete;

namespace LTHTTechTest.Core.Contracts
{
    public interface IDataService : IDisposable
    {
        IEnumerable<Person> People { get; }
        IEnumerable<Colour> Colours { get; }
        Person GetPerson(int id);
        void SaveChanges();
    }
}
