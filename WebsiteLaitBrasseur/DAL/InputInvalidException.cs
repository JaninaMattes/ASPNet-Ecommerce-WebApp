using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteLaitBrasseur.BL
{
    public class InputInvalidException: Exception
    {

        public InputInvalidException()
        {

        }

        public InputInvalidException(string message): base(message)
        {
      
        }
        
        public InputInvalidException(string message, Exception inner): base(message, inner)
        {

        }
    }
}