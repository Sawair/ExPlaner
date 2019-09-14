using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPlaner.API.ViewModel
{
    public class LoginResult
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
