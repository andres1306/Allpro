using Allpro.Datos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Allpro.Models;
using Allpro.Datos;

namespace Allpro.Controllers
{
    public class AccesoController : Controller
    {
        Logica logica =new Logica();
        Client CL = new Client();

        public IActionResult LoginUsers()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult LoginUsers(string password,string username)
        {
            bool LoginValider = false;
            int ASD;
            try
            
           {
                var Respuesta =logica.LoginUsers(username, password);
                if (Respuesta.UserValideter)
                {
                    LoginValider = true;
                return RedirectToAction("Index","Home");
                }
                return RedirectToAction("Acceso", "LoginUser");
            }
            catch(Exception e)
            {
               CL.Message=($"Algo esta fallando: {e}");
               return Ok(CL.Message);
            }


        }
        }
}

