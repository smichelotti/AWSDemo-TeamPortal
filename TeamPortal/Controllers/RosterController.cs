using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamPortal.Infrastructure;
using TeamPortal.Models;

namespace TeamPortal.Controllers
{
    public class RosterController : Controller
    {
		private readonly IPlayerRepository playerRepository;
        private readonly IStateRepository stateRepository;
        private readonly IBlobAgent blobAgent;

        public RosterController(IPlayerRepository playerRepository, IStateRepository stateRepository, IBlobAgent blobAgent)
        {
			this.playerRepository = playerRepository;
            this.stateRepository = stateRepository;
            this.blobAgent = blobAgent;
        }

        public ViewResult Index()
        {
            var teamId = this.Session.CurrentTeam().Id;
            this.ViewData.Model = playerRepository.FindByTeam(teamId).OrderBy(m => m.FirstName);
            return View();
        }

        public ViewResult Details(Guid id)
        {
            return View(playerRepository.Find(this.Session.CurrentTeam().Id, id));
        }

        public ActionResult Create()
        {
            ViewBag.States = this.stateRepository.GetStates();
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid) {
                AddPostedFiles(player);
                playerRepository.InsertOrUpdate(player);
                playerRepository.Save();
                return RedirectToAction("Index");
            } else {
                ViewBag.States = this.stateRepository.GetStates();
				return View();
			}
        }
        
        public ActionResult Edit(Guid id)
        {
            ViewBag.States = this.stateRepository.GetStates();
            var player = this.playerRepository.Find(this.Session.CurrentTeam().Id, id);
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid) {
                AddPostedFiles(player);
                playerRepository.InsertOrUpdate(player);
                playerRepository.Save();
                return RedirectToAction("Index");
            } else {
                ViewBag.States = this.stateRepository.GetStates();
				return View();
			}
        }

        public ActionResult Delete(Guid id)
        {
            return View(playerRepository.Find(this.Session.CurrentTeam().Id, id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            playerRepository.Delete(this.Session.CurrentTeam().Id, id);
            playerRepository.Save();

            return RedirectToAction("Index");
        }

        #region Private Methods

        private void AddPostedFiles(Player player)
        {
            if (Request.Files.Count == 0)
            {
                return;
            }

            // assume only 1 file posted
            HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;

            if (hpf.ContentLength == 0)
                return;
            string extension = Path.GetExtension(hpf.FileName);
            string newFileName = Guid.NewGuid().ToString() + extension;

            var blob = this.blobAgent.GetContainer().GetBlobReference(newFileName);
            blob.Properties.ContentType = BlobAgent.GetContentTypeFromExtension(extension);
            blob.UploadFromStream(hpf.InputStream);
            player.PhotoUri = blob.Uri.AbsolutePath;

            //string serverFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "roster-images", newFileName);
            //hpf.SaveAs(serverFileName);
            //player.PhotoUri = "/roster-images/" + newFileName;
        }

        #endregion
    }
}

