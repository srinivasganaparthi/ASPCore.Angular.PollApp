using System;
using System.Collections.Generic;

namespace PollDemo.Models
{
    public partial class Ipl
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int VoteCount { get; set; }
    }
}
