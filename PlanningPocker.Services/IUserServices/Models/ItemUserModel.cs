using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningPocker.Services.IUserServices.Models
{
    public class ItemUserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
