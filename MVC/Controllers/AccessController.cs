using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//iomportpo el modelo
using MVC.Models;

namespace MVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string pass)
        {

            try
            {
                using (mvcEntities db = new mvcEntities())
                {
                    var lista = from d in db.userr
                                where d.correo == user && d.passsword == pass && d.idstate == 1
                                select d;

                    if (lista.Count()>0)
                    {
                        userr User = lista.First();
                        Session["User"] = User;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido");
                    }

                }

               
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error "+ex.Message);
            }
        }
    }
}