using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.viewModels;

namespace MVCCrud.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (SampleEntityFrameworkEntities db = new SampleEntityFrameworkEntities())
            {
                lst = (from d in db.tabla
                       select new ListTablaViewModel()
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Correo = d.correo,
                           Fecha_nacimiento = d.fecha_nacimiento
                       }
                       ).ToList();

            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SampleEntityFrameworkEntities db = new SampleEntityFrameworkEntities())
                    {
                        var oTabla = new tabla();
                        oTabla.nombre = model.Nombre;
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;
                        db.tabla.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/Tabla");
                }
                return View(model);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using(SampleEntityFrameworkEntities db= new SampleEntityFrameworkEntities())
            {
                var oTabla = db.tabla.Find(id);
                model.Nombre = oTabla.nombre;
                model.Correo = oTabla.correo;
                model.Fecha_Nacimiento = oTabla.fecha_nacimiento;
                model.Id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SampleEntityFrameworkEntities db = new SampleEntityFrameworkEntities())
                    {
                        var oTabla = db.tabla.Find(model.Id);
                        oTabla.nombre = model.Nombre;
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Tabla");
                }
                return View(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        
        
        public ActionResult Eliminar(int id)
        {
            
            using (SampleEntityFrameworkEntities db = new SampleEntityFrameworkEntities())
            {
                var oTabla = db.tabla.Find(id);
                if (oTabla != null)
                {
                    db.tabla.Remove(oTabla);
                    db.SaveChanges();
                }
                

            }
            return Redirect("/Tabla");

        }
    }
}