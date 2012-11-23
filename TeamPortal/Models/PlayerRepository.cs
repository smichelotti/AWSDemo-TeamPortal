using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data.Entity.Infrastructure;

namespace TeamPortal.Models
{
    public class PlayerRepository : IPlayerRepository
    {
        TeamPortalWebContext context = new TeamPortalWebContext();

        public List<Player> FindByTeam(int teamId)
        {
            return context.Players.Where(x => x.TeamId == teamId).ToList();
        }

        public Player Find(int teamId, Guid id)
        {
            return context.Players.Find(id);
        }

        public void InsertOrUpdate(Player player)
        {
            if (player.Id == default(Guid)) {
                // New entity
                player.Id = Guid.NewGuid();
                context.Players.Add(player);
            } else {
                // Existing entity
                context.Entry(player).State = EntityState.Modified;
            }
        }

        public void Delete(int teamId, Guid id)
        {
            var player = context.Players.Find(id);
            context.Players.Remove(player);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

    public interface IPlayerRepository
    {
        Player Find(int teamId, Guid id);
        List<Player> FindByTeam(int teamId);
        void InsertOrUpdate(Player player);
        void Delete(int teamId, Guid id);
        void Save();
    }
}