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
        public IActionResult LoginUsers(Client client)
        {
            string message;
            try
            {
                var DadaValide = logica.Datavalider(client.Email, client.UserPassword);
                if (DadaValide)
                {
                    var Respuesta = logica.LoginUsers(client);
                    if (Respuesta)
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    CL.Message="Inserta los datos porfavor ";
                    return Ok(message);
                }
            }
            catch(Exception e)
            {
               CL.Message=($"Algo esta fallando: {e}");
               return Ok(CL.Message);
            }
            message = "Alfue muy mal ";
            return Ok(message);

        }
        }
}

