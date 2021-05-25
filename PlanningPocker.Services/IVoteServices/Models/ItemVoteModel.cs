using PlanningPocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Services.IVoteServices.Models
{
    public class ItemVoteModel
    {
        public Guid VoteId { get; set; }
        public UserVoteModel User { get; set; }
        public Letter Letter { get; set; }
        public UserHistory History { get; set; }
    }

    public class UserVoteModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
   
}
