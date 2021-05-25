using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Persistance.Context;
using PlanningPocker.Services.IUserHistoryServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningPocker.Services.IUserHistoryServices
{
    public interface IUserHistoryService
    {
        Task<Result<UserHistory>> Create(CreateUserHistoryModel model);
        Task<Result<List<UserHistory>>> GetAll();
    }

    public class UserHistoryService: IUserHistoryService
    {
        private readonly PlanningPockerContext _context;
        public UserHistoryService(PlanningPockerContext context)
        {
            _context = context;
        }

        public async Task<Result<UserHistory>> Create(CreateUserHistoryModel model)
        {
            var userHistory = new UserHistory(model.Description);
            _context.Attach(userHistory);
            await _context.SaveChangesAsync();

            return Result.Success(userHistory);
        }

        public async Task<Result<List<UserHistory>>> GetAll()
        {
            return Result.Success(await _context.UserHistories.ToListAsync());
        }
    }
}
