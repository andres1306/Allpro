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
        Logica logica = new Logica();
        Client CL = new Client();

        public IActionResult LoginUsers()
        {
            return View();
        }
        [HttpPost]
        public bool LoginUsers(string username, string password)
        {
            bool LoginValider = false;
            try
            {
                var Respuesta = logica.LoginUsers(username, password);
                if (Respuesta.UserValideter)
                {
                    LoginValider = true;
                }
                return LoginValider;
            }
            catch (Exception e)
            {
                CL.Message = ($"Algo esta fallando: {e}");
                return LoginValider;
            }


        }
        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public bool NewUser(Client client)
        {
            bool newuser = false;
            try
            {
                var Respuesta = logica.NewUser(client);
                if (Respuesta)
                {
                    newuser = true;
                }
                return newuser;
            }
            catch (Exception e)
            {
                return newuser;
            }
        }
    }
}
