using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWPF.Models
{
    class User
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string access_token { get; set; }
    }
}
