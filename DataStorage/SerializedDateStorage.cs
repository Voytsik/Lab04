using Lab02.Models;
using Lab02.Tools;
using Lab02.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab02.DataStorage
{
    internal class SerializedDataStorage : IDataStorage
    {
        private readonly List<Person> _persons;

        internal SerializedDataStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                for (int i = 0; i < 50; i++)
                {
                    RandomDateTime random = new RandomDateTime();
                    _persons.Add(new Person(random.GenRandomString(i), "Person_" + i, "user_" + i + "@gmail.com",
                        random.GenRandomDateTime(new DateTime(1960 + i, i % 12 + 1, 1, 8, 30, 52), DateTime.Today)));
                }
                SaveChanges();
            }
        }

        public bool PersonExists(string email)
        {
            return _persons.Exists(u => u.Email == email);
        }

        public Person GetPersonByEmail(string email)
        {
            return _persons.FirstOrDefault(u => u.Email == email);
        }

        public void RemovePerson(Person person)
        {
            _persons.Remove(person);
            SaveChanges();
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
            SaveChanges();
        }

        public List<Person> PersonsList
        {
            get { return _persons.ToList(); }
        }

        private void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }
    }
}