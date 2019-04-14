using Lab02.Properties;
using Lab02.Exceptions;
using Lab02.Manager;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.Generic;

namespace Lab02.Models
{
    [Serializable]
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _dateOfBirth = DateTime.Today;
        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("E-mail");
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public bool IsAdult => _isAdult;

        public string SunSign => _sunSign;

        public string ChineseSign => _chineseSign;

        public bool IsBirthday => _isBirthday;

        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.Today)
        {
        }

        public Person(string name, string surname, DateTime dateOfBirth) : this(name, surname, "", DateTime.Today)
        {
        }

        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            IsCorrectDateOfBirth(dateOfBirth);
            IsEmailValid(email);
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
            OperateZodiac zodiac = new OperateZodiac();
            _isAdult = CalcAdult();
            _sunSign = zodiac.FindWestZodiac(DateOfBirth);
            _chineseSign = zodiac.FindChineseZodiac(DateOfBirth.Year);
            _isBirthday = zodiac.isBirthday(DateOfBirth);
        }

        public Person()
        {
        }

        private bool CalcAdult()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (age > 17)
                return true;
            return false;
        }

        private void IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
            }
            catch (FormatException)
            {
                throw new IllegalEmailException();
            }
        }

        private void IsCorrectDateOfBirth(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;

            if (date > DateTime.Today)
                throw new IsNotBirthException();
            else if (age > 135)
                throw new IsDeadException();
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}