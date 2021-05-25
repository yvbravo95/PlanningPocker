using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlanningPocker.Services.ILetterServices.Models
{
    public class CreateLetterModel
    {
        [Required] public string Value { get; set; }
    }
}
