using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Allpro.Models
{
    public class Propertys
    {
        public int PropertyID { get; set; }
        public string Address { get; set; }
        public string Location{ get; set; }
        public string Area { get; set; }
        public int Num_rooms { get; set; }
        public int Num_bathrooms { get; set; }
        public byte Parking{ get; set; }
        public int Price { get; set; }
        public int Stratum { get; set; }
        public string Image{ get; set; }
        public int Condition{ get; set; }
        public int ClientID { get; set; }
        public int TypeHouseID{ get; set; }
        public int TypePropertyID { get; set; }
    }
}
