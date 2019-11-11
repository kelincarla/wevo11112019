using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Service;

namespace Web.Controllers
{
    public class UsuarioMemoriaController : Controller
    {
        // GET: UsuarioMemoria
        public ActionResult Index()
        {
            var service = new UsuarioService();
            var model = service.GetUsuarios("api/usuariosmemory");
            
            return View(model);
        }

        

        // GET: UsuarioMemoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioMemoria/Create
        [HttpPost]
        public async Task<ActionResult> Create(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    UsuarioService service = new UsuarioService();
                    await service.SaveUsuario(model, "api/usuariosmemory");

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }


            return View(model);
        }

        // GET: UsuarioMemoria/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioViewModel model = new UsuarioViewModel();
            try
            {
                var service = new UsuarioService();
                model = service.GetUsuario(id, "api/usuariosmemory");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        // POST: UsuarioMemoria/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    UsuarioService service = new UsuarioService();
                    await service.UpdateUsuario(model, string.Format("api/usuariosmemory/{0}", id));

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }

            return View(model);
        }

        // GET: UsuarioMemoria/Delete/5
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

        // POST: UsuarioMemoria/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add insert logic here
                UsuarioService service = new UsuarioService();
                await service.DeleteUsuario(id, "api/usuariosmemory");

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
