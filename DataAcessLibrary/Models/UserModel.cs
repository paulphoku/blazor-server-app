using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLibrary.Models
{
    public class UserModel
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public DateTime datecreated { get; set; }
        public DateTime dateupdated { get; set; }
    }
}
