using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class EmptyRowException : Exception
    {

        public EmptyRowException()
        {

        }

        public EmptyRowException(string message) : base(message)
        {

        }

        public EmptyRowException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}