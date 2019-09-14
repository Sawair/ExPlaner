using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPlaner.API.ViewModel
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
