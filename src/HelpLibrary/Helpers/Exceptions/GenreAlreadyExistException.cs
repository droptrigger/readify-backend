using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Helpers.Exceptions
{
    public class GenreAlreadyExistException : Exception
    {
        public GenreAlreadyExistException(string message) : base(message) { }
    }
}
