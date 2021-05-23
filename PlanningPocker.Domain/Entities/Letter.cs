using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Domain.Entities
{
    public class Letter
    {
        protected Letter()
        {
        }
        public Letter(string value)
        {
            Value = value;
        }
        public void Update(string value)
        {
            Value = value;
        }

        public Guid Id { get; set; }
        public string Value { get; private set; }
    }
}
