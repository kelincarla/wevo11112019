using Dto.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Web.Models;
using Web.Service;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {

        

        // GET: Usuario
        public ActionResult Index()
        {
            var service = new UsuarioService();
            var model = service.GetUsuarios("api/usuarios");

            return View(model);
        }

       

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]        
        public async Task<ActionResult> Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    UsuarioService service = new UsuarioService();
                    await service.SaveUsuario(model, "api/usuarios");

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }

            
            return View(model);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioViewModel model = new UsuarioViewModel();
            try
            {
                var service = new UsuarioService();
                model = service.GetUsuario(id, "api/usuarios");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    UsuarioService service = new UsuarioService();
                    await service.UpdateUsuario(model, string.Format("api/usuarios/{0}",id));

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }

            return View(model);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioViewModel model = null;
            try
            {
                var service = new UsuarioService();
                model = service.GetUsuario(id, "api/usuarios");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioService service = new UsuarioService();
                await service.DeleteUsuario(id, "api/usuarios");

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);

            }

            return View();
        }

        
    }
}
