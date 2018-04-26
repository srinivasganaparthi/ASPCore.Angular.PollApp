using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PollDemo.Models
{
    public class TeamDataAccessLayer
    {
        int i = 10;
        myTestDBContext db = new myTestDBContext();

        public IEnumerable<Ipl> GetAllTeams()
        {
            try
            {
                return db.Ipl.ToList();
            }
            catch
            {
                throw;
            }
        }

        public int GetTotalVoteCount()
        {
            try
            {
                return db.Ipl.Sum(t => t.VoteCount);
            }
            catch
            {
                throw;
            }
        }
        public int RecordVote(Ipl ipl)
        {
            try
            {

                db.Database.ExecuteSqlCommand("update ipl set VoteCount = VoteCount + 1 where TeamID = {0}", parameters: ipl.TeamId);

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
