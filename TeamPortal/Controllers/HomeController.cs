using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamPortal.Models;

namespace TeamPortal.Controllers
{
    public class HomeController : Controller
    {
        private ITeamRepository teamRepository;

        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        /// <param name="teamRepository"></param>
        public HomeController(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public ActionResult Index()
        {
            //this.ViewData.Model = this.teamRepository.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var team = this.teamRepository.Find(id);
            this.Session.SetCurrentTeam(team);
            return this.RedirectToAction("Index");
        }
    }
}
