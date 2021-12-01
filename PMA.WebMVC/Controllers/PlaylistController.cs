using PMA.Models;
using PMA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMA.WebMVC.Controllers
{
    public class PlaylistController : Controller
    {
        public ActionResult Index()
        {
            var service = new PlaylistService();
            var model = service.GetPlaylists();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PlaylistCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            PlaylistService service = CreatePlaylistService();
            if (service.CreatePlaylist(model))
            {
                return RedirectToAction("Index");
            };
            return View(model);
        }
        public ActionResult Details(int playlistId)
        {
            var service = CreatePlaylistService();
            var model = service.GetPlaylistById(playlistId);
            return View(model);
        }
        public ActionResult Edit(int playlistId)
        {
            var service = CreatePlaylistService();
            var detail = service.GetPlaylistById(playlistId);
            var model = new PlaylistEdit
            {
                PlaylistId = detail.PlaylistId,
                PlaylistName = detail.PlaylistName,
                Description = detail.Description,
                Rating = detail.Rating,
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int PlaylistId, PlaylistEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.PlaylistId != PlaylistId)
            {
                ModelState.AddModelError("", "Entry not found");
                return View(model);
            }
            var service = CreatePlaylistService();
            if (service.UpdatePlaylist(model))
            {
                TempData["SaveResult"] = "Your playlist was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your playlist could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int playlistId)
        {
            var service = CreatePlaylistService();
            var model = service.GetPlaylistById(playlistId);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int playlistId)
        {
            var service = CreatePlaylistService();
            service.DeletePlaylist(playlistId);
            TempData["SaveResult"] = "Your playlist was deleted";
            return RedirectToAction("Index");
        }

        private static PlaylistService CreatePlaylistService()
        {
            return new PlaylistService();
        }
    }
}