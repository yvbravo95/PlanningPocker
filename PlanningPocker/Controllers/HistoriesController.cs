using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Services.IUserHistoryServices;
using PlanningPocker.Services.IUserHistoryServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningPocker.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly IUserHistoryService _historyService;
        public HistoriesController(IUserHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpPost]
        public async Task<ActionResult<UserHistory>> Create(CreateUserHistoryModel request)
        {
            try
            {
                var response = await _historyService.Create(request);
                if (response.IsFailure)
                    return BadRequest(response.Error);
                return Ok(response.Value);
            }
            catch(Exception e)
            {
                Serilog.Log.Fatal(e, "Server Error");
                return BadRequest("History could not be created");
            }
        }
    
        [HttpGet]
        public async Task<ActionResult<List<UserHistory>>> GetAll()
        {
            try
            {
                var response = await _historyService.GetAll();
                if (response.IsFailure)
                    return BadRequest(response.Error);
                return Ok(response.Value);
            }
            catch(Exception e)
            {
                Serilog.Log.Fatal(e, "Server Error");
                return BadRequest("The stories could not be obtained");
            }
        }
    }
}
