using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanningPocker.Domain.Entities
{
    public class UserHistory
    {
        protected UserHistory()
        {
        }
        public UserHistory(string description)
        {
            Description = description;
        }
        public void Update(string description)
        {
            Description = description;
        }

        [Key] public Guid Id { get; set; }
        public string Description { get; private set; }
    }
}
