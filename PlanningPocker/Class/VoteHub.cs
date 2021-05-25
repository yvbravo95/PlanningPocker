using Microsoft.AspNetCore.SignalR;
using PlanningPocker.Persistance.Context;
using System.Threading.Tasks;

namespace PlanningPocker.Class
{
    public class VoteHub : Hub
    {
        private readonly PlanningPockerContext _context;
        public VoteHub(PlanningPockerContext context)
        {
            _context = context;
        }
        public Task SendAllVotes()
        {
            var votes = _context.Votes;
            return Clients.All.SendAsync("SendAllVotes", votes);
        }
    }
}
