using System;
using System.Linq;
using System.Threading.Tasks;
using CL4PTR4P.Data;
using CL4PTR4P.Data.Models;
using CL4PTR4P.Data.Models.JoinEntities;
using CL4PTR4P.Services.Common;
using CL4PTR4P.Services.Interfaces;

namespace CL4PTR4P.Services
{
    public class GroupFinderService : IGroupFinderService
    {
        private readonly GroupFinderContext _groupFinderContext;

        public GroupFinderService(GroupFinderContext groupFinderContext)
        {
            _groupFinderContext = groupFinderContext;
        }

        public async Task<ServiceResponse> AddListingAsync(ulong userId, string gameName)
        {
            var user = _groupFinderContext.Users.SingleOrDefault(p => p.UserId == userId);
            if (user == null)
            {
                user = new User
                {
                    UserId = userId
                };
                _groupFinderContext.Add(user);
            }

            var game = _groupFinderContext.Games.SingleOrDefault(g => string.Equals(g.Name, gameName, StringComparison.InvariantCultureIgnoreCase));
            if (game == null)
            {
                game = new Game
                {
                    Name = gameName
                };
                _groupFinderContext.Add(game);
            }

            var result = new ServiceResponse();

            var gameUser = user.GameUsers.SingleOrDefault(gu => gu.Game == game);
            if (gameUser == null)
            {
                gameUser = new GameUser { User = user, Game = game };
                _groupFinderContext.Add(gameUser);
                result.IsSuccesful = true;
            }
            else
            {
                result.IsSuccesful = false;
                result.Message = "Game already in list for user.";
            }

            await _groupFinderContext.SaveChangesAsync();
            return result;
        }

        public Task FindListingAsync(string gameName)
        {
            throw new NotImplementedException();
        }

        public Task GetListingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}