using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TeamPortal.Models
{ 
    public class TeamRepository : ITeamRepository
    {
        TeamPortalWebContext context = new TeamPortalWebContext();

        public List<Team> GetAll()
        {            
            return context.Teams.ToList(); 
        }

        public Team Find(int id)
        {
            return context.Teams.Find(id);
        }
    }

    public interface ITeamRepository
    {
        List<Team> GetAll();
        Team Find(int id);
    }
}