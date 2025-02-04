using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Helpers.Exceptions
{
    public class AlreadySubscribedExceprion : Exception
    {
        public AlreadySubscribedExceprion(string message) : base(message) { }
    }
}
