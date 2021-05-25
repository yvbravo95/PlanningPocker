using CSharpFunctionalExtensions;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Persistance.Context;
using PlanningPocker.Services.IVoteServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlanningPocker.Common.Services.IUserResolverServices;

namespace PlanningPocker.Services.IVoteServices
{
    public interface IVoteService
    {
        Task<Result<Vote>> Create(CreateVoteModel model);
        Task<Result<List<ItemVoteModel>>> GetAllByUser();
    }

    public class VoteService: IVoteService
    {
        private readonly PlanningPockerContext _context;
        private readonly User _user;
        public VoteService(PlanningPockerContext context, IUserResolverService userResolverService)
        {
            _context = context;
            _user = userResolverService.GetUser();
        }

        public async Task<Result<Vote>> Create(CreateVoteModel model)
        {
            if (_user == null) 
                return Result.Failure<Vote>("The user not exist");

            var letter = await _context.Letters.FindAsync(model.LetterId);
            if (letter == null)
                return Result.Failure<Vote>("The letter not exist");

            var userHistory = await _context.UserHistories.FindAsync(model.UserHistryId);
            if (userHistory == null)
                return Result.Failure<Vote>("The history not exist");

            var vote = new Vote(_user, letter, userHistory);

            _context.Attach(vote);
            await _context.SaveChangesAsync();

            return Result.Success(vote);
        }
    
        public async Task<Result<List<ItemVoteModel>>> GetAllByUser()
        {
            if(_user == null)
                return Result.Failure<List<ItemVoteModel>>("The user not exist");
            return Result.Success(await _context.Votes
                .Include(x => x.User)
                .Include(x => x.Letter)
                .Include(x => x.History)
                .Where(x => x.User.Id == _user.Id)
                .Select(x => new ItemVoteModel
                {
                    User = new UserVoteModel { Name = x.User.Name, UserId = x.User.Id, UserName = x.User.UserName},
                    History = x.History,
                    Letter = x.Letter,
                    VoteId = x.Id
                }).ToListAsync());
        }
    }
}
