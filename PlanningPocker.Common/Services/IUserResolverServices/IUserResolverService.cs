using Microsoft.AspNetCore.Http;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanningPocker.Common.Services.IUserResolverServices
{
    public interface IUserResolverService
    {
        User GetUser();
    }
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly PlanningPockerContext _context;
        public UserResolverService(IHttpContextAccessor contextAccessor, PlanningPockerContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public User GetUser()
        {
            string userName = _contextAccessor.HttpContext.User?.Identity?.Name;
            return _context.Users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
