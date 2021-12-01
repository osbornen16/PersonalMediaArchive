using PMA.Models;
using PMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMA.WebMVC.Controllers
{
    public class TypeController : Controller
    {
        public ActionResult Index()
        {
            var service = new TypeService();
            var model = service.GetTypes();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TypeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            TypeService service = CreateTypeService();
            if (service.CreateType(model))
            {
                return RedirectToAction("Index");
            };
            return View(model);
        }
        public ActionResult Details(int typeId)
        {
            var service = CreateTypeService();
            var model = service.GetTypeById(typeId);
            return View(model);
        }
        public ActionResult Edit(int typeId)
        {
            var service = CreateTypeService();
            var detail = service.GetTypeById(typeId);
            var model = new TypeEdit
            {
                TypeId = detail.TypeId,
                TypeName = detail.TypeName,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int typeId, TypeEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.TypeId != typeId)
            {
                ModelState.AddModelError("", "Genre not found");
                return View(model);
            }
            var service = CreateTypeService();
            if (service.UpdateType(model))
            {
                TempData["SaveResult"] = "Your genre was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your genre could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int typeId)
        {
            var service = CreateTypeService();
            var model = service.GetTypeById(typeId);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int typeId)
        {
            var service = CreateTypeService();
            service.DeleteType(typeId);
            TempData["SaveResult"] = "Your genre was deleted";
            return RedirectToAction("Index");
        }

        private static TypeService CreateTypeService()
        {
            return new TypeService();
        }
    }
}