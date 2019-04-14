using Lab02.Models;
using System.Collections.Generic;

namespace Lab02.DataStorage
{
    internal interface IDataStorage
    {
        bool PersonExists(string email);

        Person GetPersonByEmail(string email);

        void RemovePerson(Person person);
        void AddPerson(Person person);
        List<Person> PersonsList { get; }
    }
}