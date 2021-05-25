using PlanningPocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningPocker.Models.Response.Vote
{
    public class VoteModelResponse
    {
        public Guid VoteId { get; set; }
        public Letter Letter { get; set; }
        public UserHistory History { get; set; }
        public User_VoteResponse User { get; set; }
    }

    public class User_VoteResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
