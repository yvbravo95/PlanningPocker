using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanningPocker.Services.IUserServices.Models
{
    public class CreateUserModel
    {
        [Required] public string Name { get; set; }
        [Required] [DataType(DataType.EmailAddress)] public string Email { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}
