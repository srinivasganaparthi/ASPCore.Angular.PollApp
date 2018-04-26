using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollDemo.Controllers
{
    [Route("api/Team")]
    public class TeamController : Controller
    {
        TeamDataAccessLayer objTeam = new TeamDataAccessLayer();

        [HttpGet]
        [Route("Index")]
        public IEnumerable<Ipl> Index()
        {
            return objTeam.GetAllTeams();
        }

        [HttpGet]
        [Route("TotalVotes")]
        public int TotalVotes()
        {
            return objTeam.GetTotalVoteCount();
        }

        [HttpPut]
        [Route("UpdateVoteCount")]
        public int UpdateVoteCount([FromBody] Ipl obj)
        {
            return objTeam.RecordVote(obj);
        }

    }
}
