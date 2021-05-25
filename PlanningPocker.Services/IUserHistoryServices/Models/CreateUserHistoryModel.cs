using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanningPocker.Services.IUserHistoryServices.Models
{
    public class CreateUserHistoryModel
    {
        [Required] public string Description { get; set; }
    }
}
