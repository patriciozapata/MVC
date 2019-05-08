using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Models.TableViewModels;
using MVC.Models.ViewModels;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModels> lista = null;
            using (mvcEntities db = new mvcEntities())
            {
               lista = (from d in db.userr
                      where d.idstate == 1
                      orderby d.correo
                      select new  UserTableViewModels
                      {
                          Correo = d.correo,
                          Id = d.id,

                      }).ToList();
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model) {

            if (!ModelState.IsValid)
            {
                return View(model);

            }

            using (var db = new mvcEntities())
            {
                userr User = new userr();
                User.idstate = 1;
                User.correo = model.Correo;
                User.passsword = model.Password;

                db.userr.Add(User);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        public ActionResult Edit(int Id) {

            EditUserViewModel model = new EditUserViewModel();

            using (var db = new mvcEntities())
            {
                var User = db.userr.Find(Id);
                model.Correo = User.correo;
                model.id = User.id;
                //no pongo password
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model ) {
            if (!ModelState.IsValid)
            {
                return View(model);

            }

            using (var db = new mvcEntities())
            {
                var User = db.userr.Find(model.id);
                User.correo = model.Correo;
                //no pongo password
                if (model.Password!= null && model.Password.Trim()!="")
                {
                    User.passsword = model.Password;
                }

                db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {


            using (var db = new mvcEntities())
            {
                var User = db.userr.Find(id);
                User.idstate = 3;


                db.Entry(User).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return Content("1");
        }
    }
}