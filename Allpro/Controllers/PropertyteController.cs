using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Allpro.Models;
using Allpro.Datos;
namespace Allpro.Controllers
{
    public class PropertyteController : Controller
    {
        Logica logica = new Logica();
        bool MethodSucess=false;
        public IActionResult NewProperty()
        {
            return View();
        }

        [HttpPost]
        public bool NewProperty(Propertys propertys)
        {
            var Respuesta = logica.NewProperty(propertys);
            if (Respuesta)
            {
                MethodSucess = true;
            }
            return MethodSucess;
        }
        
        public bool RentHouse(HouseRents houseRents)
        {
            var Respuesta = logica.RentHouse(houseRents);
            if (Respuesta)
            {
                MethodSucess = true;
            }
            return MethodSucess;

        }
    }
}
    