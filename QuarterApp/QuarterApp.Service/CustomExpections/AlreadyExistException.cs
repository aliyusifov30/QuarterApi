using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.CustomExpections
{
    public class AlreadyExistException : Exception
    {

        public AlreadyExistException(string msg):base(msg)
        {

        }

    }
}
