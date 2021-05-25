using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Models.Response.Vote;
using PlanningPocker.Services.IVoteServices;
using PlanningPocker.Services.IVoteServices.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningPocker.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService _voteService;
        public VotesController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost]
        public async Task<ActionResult<VoteModelResponse>> Create(CreateVoteModel request)
        {
            try
            {
                var response = await _voteService.Create(request);
                if (response.IsFailure)
                    return BadRequest(response.Error);
                return Ok(new VoteModelResponse
                {
                    History = response.Value.History,
                    Letter = response.Value.Letter,
                    User = new User_VoteResponse
                    {
                        Id = response.Value.User.Id,
                        Name = response.Value.User.Name,
                        UserName = response.Value.User.UserName
                    },
                    VoteId = response.Value.Id
                });
            }
            catch (Exception e)
            {
                Serilog.Log.Fatal(e, "Server Error");
                return BadRequest("The vote could not be created");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemVoteModel>>> GetAllByUser()
        {
            try
            {
                var response = await _voteService.GetAllByUser();
                if (response.IsFailure)
                    return BadRequest(response.Error);
                return Ok(response.Value);
            }
            catch (Exception e)
            {
                Serilog.Log.Fatal(e, "Server Error");
                return BadRequest("The votes could not be obtained");
            }
        }
    }
}
