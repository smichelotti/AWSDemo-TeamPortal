using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamPortal.Models;

namespace TeamPortal
{
    public class SessionInitializer
    {
        public SessionInitializer()
        {
            // hard-code a default team for demo purposes
            var teamRepository = new TeamRepository();
            var defaultTeam = teamRepository.GetAll().Single(x => x.TeamName == "Sharks");
            HttpContext.Current.Session.SetCurrentTeam(defaultTeam);
        }
    }
}