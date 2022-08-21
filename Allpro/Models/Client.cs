using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Allpro.Models
{
    public class Client:MasterAllpro
    {
        public int ClientID { get; set; }
        public string NameClient{ get; set; }
        public int BanckClient { get; set; }
        public int DocumentClient{ get; set; }
        public int PhoneClient{ get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int RoleID{ get; set; }
        public string Email { get; set; }

    }
}
