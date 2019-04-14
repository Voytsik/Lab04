using System;

namespace Lab02.Exceptions
{
    class UserExistsException : Exception
    {
        public override string Message => "User is already exist!";
    }
}