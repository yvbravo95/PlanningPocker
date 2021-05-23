using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Domain.Entities
{
    public class Vote
    {
        protected Vote()
        {
        }

        public Vote(User user, Letter letter, UserHistory history)
        {
            User = user;
            Letter = letter;
            History = history;
        }

        public void Update(User user, Letter letter, UserHistory history)
        {
            User = user;
            Letter = letter;
            History = history;
        }

        public Guid Id { get; set; }
        public User User { get; private set; }
        public Letter Letter { get; private set; }
        public UserHistory History { get; private set; }
    }
}
