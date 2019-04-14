using System;

namespace Lab02.Exceptions
{
    class UserIsNotExistsException : Exception
    {
        public override string Message => "User is not exist!";
    }
}