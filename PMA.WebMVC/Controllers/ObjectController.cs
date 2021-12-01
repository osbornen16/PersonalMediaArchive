using PMA.Models;
using PMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMA.WebMVC.Controllers
{
    public class ObjectController : Controller
    {
        public ActionResult Index()
        {
            var service = new ObjectService();
            var model = service.GetObjects();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ObjectCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ObjectService service = CreateObjectService();
            if (service.CreateObject(model))
            {
                return RedirectToAction("Index");
            };
            return View(model);
        }
        public ActionResult Details(int objectId)
        {
            var service = CreateObjectService();
            var model = service.GetObjectById(objectId);
            return View(model);
        }
        public ActionResult Edit(int objectId)
        {
            var service = CreateObjectService();
            var detail = service.GetObjectById(objectId);
            var model = new ObjectEdit
            {
                ObjectId = detail.ObjectId,
                ObjectName = detail.ObjectName,
                Description = detail.Description,
                TypeId = detail.TypeId,
                PlaylistId = detail.PlaylistId
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int objectId, ObjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ObjectId != objectId)
            {
                ModelState.AddModelError("", "Entry not found");
                return View(model);
            }
            var service = CreateObjectService();
            if (service.UpdateObject(model))
            {
                TempData["SaveResult"] = "Your entry was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your entry could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int objectId)
        {
            var service = CreateObjectService();
            var model = service.GetObjectById(objectId);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int objectId)
        {
            var service = CreateObjectService();
            service.DeleteObject(objectId);
            TempData["SaveResult"] = "Your entry was deleted";
            return RedirectToAction("Index");
        }

        private static ObjectService CreateObjectService()
        {
            return new ObjectService();
        }
    }
}