using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
//using Microsoft.ApplicationServer.Caching;

namespace TeamPortal.Models
{ 
    public class StateRepository : IStateRepository
    {
        TeamPortalWebContext context = new TeamPortalWebContext();

        public List<State> GetStates()
        {
            return this.context.States.ToList();
        }
    }
}