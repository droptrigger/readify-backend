using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Helpers
{
    public class JwtSection
    {
        public string? SecretKey { get; set; }
        public TimeSpan Expires { get; set; }
    }
}
