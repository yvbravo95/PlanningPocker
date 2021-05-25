using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Persistance.Context;
using PlanningPocker.Services.ILetterServices.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanningPocker.Services.ILetterServices
{
    public interface ILetterService
    {
        Task<Result<Letter>> Create(CreateLetterModel model);
        Task<Result<List<Letter>>> GetAll();
    }

    public class LetterService: ILetterService
    {
        private readonly PlanningPockerContext _context;
        public LetterService(PlanningPockerContext context)
        {
            _context = context;
        }

        public async Task<Result<Letter>> Create(CreateLetterModel model)
        {
            var letter = new Letter(model.Value);
            _context.Attach(letter);
            await _context.SaveChangesAsync();

            return Result.Success(letter);
        }

        public async Task<Result<List<Letter>>> GetAll()
        {
            return Result.Success(await _context.Letters.ToListAsync());
        }
    }
}
