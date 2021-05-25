using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Services.ILetterServices;
using PlanningPocker.Services.ILetterServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningPocker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LettersController : ControllerBase
    {
        private readonly ILetterService _letterService;
        public LettersController(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [HttpPost]
        public async Task<ActionResult<Letter>> Create(CreateLetterModel request)
        {
            try
            {
                var response = await _letterService.Create(request);
                if (response.IsFailure)
                    return BadRequest(response.Error);
                else
                    return Ok(response.Value);
            }
            catch(Exception e)
            {
                Serilog.Log.Fatal(e, "Server Error");
                return BadRequest("The letter could not be created");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Letter>>> GetAll()
        {
            try
            {
                var response = await _letterService.GetAll();
                if (response.IsFailure)
                    return BadRequest(response.Error);
                else
                    return Ok(response.Value);
            }
            catch(Exception e)
            {
                Serilog.Log.Fatal(e, "Server Error");
                return BadRequest("The letters could not be obtained");
            }
        }
    }
}
