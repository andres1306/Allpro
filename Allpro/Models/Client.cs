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
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public string NameClient{ get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public int BanckClient { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public int DocumentClient{ get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public int PhoneClient{ get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public int RoleID{ get; set; }
        [Required(ErrorMessage = "El campo es obligatorio ")]
        public string Email { get; set; }

    }
}
