using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authDemo2.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }
        public string Role { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
    }
}
