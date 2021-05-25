using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Services.IVoteServices.Models
{
    public class CreateVoteModel
    {
        public Guid LetterId { get; set; }
        public Guid UserHistryId { get; set; }
    }
}
