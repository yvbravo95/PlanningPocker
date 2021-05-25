using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Persistance.Context;
using PlanningPocker.Services.IUserServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningPocker.Services.IUserServices
{
    public interface IUserService
    {
        Task<Result<User>> Register(CreateUserModel model);
        Task<Result> VerifyLogin(LoginUserModel model);
        Task<Result<List<ItemUserModel>>> GetAll();
    }

    public class UserService : PasswordValidator<User>, IUserService
    {
        private readonly PlanningPockerContext _context;
        private readonly UserManager<User> _userManager;
        public UserService(PlanningPockerContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Result<User>> Register(CreateUserModel model)
        {
            var isUserNameRepeated = await _context.Users.AnyAsync(x => x.UserName == model.Username);
            if (isUserNameRepeated)
                return Result.Failure<User>("Username is in use");

            var user = new User(model.Name, model.Username, model.Email);
            var createUser = await _userManager.CreateAsync(user, model.Password);

            if (createUser.Succeeded)
                return Result.Success(user);

            return Result.Failure<User>("The user has not been created");
        }

        public async Task<Result> VerifyLogin(LoginUserModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == model.Username);
            if (user == null) return Result.Failure("Username does not exist");

            var validate = await base.ValidateAsync(_userManager, user, model.Password);

            if (!validate.Succeeded)
                return Result.Failure("Password is incorrect");

            return Result.Success();

        }

        public async Task<Result<List<ItemUserModel>>> GetAll()
        {
            return Result.Success(await _context.Users.Select(x => new ItemUserModel
            {
                UserId = x.Id,
                Name = x.Name,
                UserName = x.UserName
            }).ToListAsync());
        }
    }
}
