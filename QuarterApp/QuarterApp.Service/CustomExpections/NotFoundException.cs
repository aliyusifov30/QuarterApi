using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.CustomExpections
{
    public class NotFoundException : Exception
    {

        public NotFoundException(string msg) : base(msg)
        {

        }

    }
}
