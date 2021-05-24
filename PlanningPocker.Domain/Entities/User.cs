using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanningPocker.Domain.Entities
{
    public class User: IdentityUser<Guid>
    {
        protected User()
        {
        }

        public User(string name, string userName, string email)
        {
            Name = name;
            UserName = userName;
            Email = email;
        }

        public void Update(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
