using CL4PTR4P.Data;
using CL4PTR4P.Data.Enums;
using CL4PTR4P.Data.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using CL4PTR4P.Data.Models.JoinEntities;

namespace CL4PTR4P.Services
{
    public class TournamentService : ITournamentService
    { 
        private readonly TournamentContext _tournamentContext;

        public TournamentService(TournamentContext tournamentContext)
        {
            _tournamentContext = tournamentContext;
        }

        public async Task CreateAsync(string tournamentName, TournamentFormat format)
        {
            var tournament = _tournamentContext.Tournaments.SingleOrDefault(t => t.Name == tournamentName);
            if (tournament != null)
            {
                //return an error
                return;
            }

            tournament = new Tournament { Format = format, Name = tournamentName };

            _tournamentContext.Add(tournament);
            await _tournamentContext.SaveChangesAsync();
        }

        public async Task SignUpAsync(string tournamentName, ulong playerId)
        {
            //check if tournament exists
            var tournament = _tournamentContext.Tournaments.SingleOrDefault(t => t.Name == tournamentName);            
            if (tournament == null)
            {
                //return an error
                return;
            }

            if (tournament.HasStarted)
            {
                //return an error
                return;
            }

            //check if player is in db, if not add them
            var player = _tournamentContext.Players.SingleOrDefault(p => p.PlayerId == playerId);
            if (player == null)
            {
                player = new Player
                {
                    PlayerId = playerId
                };
                _tournamentContext.Add(player);
            }

            //check if player is in tournament, if not add them
            if (tournament.PlayerTournaments.Any(pt => pt.Player == player))
            {
                // return an error
                return;
            }

            tournament.PlayerTournaments.Add(new PlayerTournament { Tournament = tournament, Player = player });
            await _tournamentContext.SaveChangesAsync();
        }

        public async Task StartTournamentAsync(string tournamentName)
        {
            var tournament = _tournamentContext.Tournaments.SingleOrDefault(t => t.Name == tournamentName);
            if (tournament == null)
            {
                //return an error
                return;
            }

            if (tournament.HasStarted)
            {
                //return an error
                return;
            }

            tournament.HasStarted = true;

            switch (tournament.Format)
            {
                case TournamentFormat.FFA:
                    {
                        var match = new Match { Tournament = tournament };
                        foreach (var player in tournament.PlayerTournaments)
                        {
                            match.PlayerMatches.Add(new PlayerMatch { Match = match, Player = player.Player });
                        }
                        tournament.Matches.Add(match);
                        break;
                    }                    
                case TournamentFormat.Solo:
                    break;
                case TournamentFormat.Team:
                    break;
                case TournamentFormat.None:
                    break;
                default:
                    break;
            }

            await _tournamentContext.SaveChangesAsync();
        }
    }

    public interface ITournamentService
    {
        Task CreateAsync(string tournamentName, TournamentFormat format);

        Task SignUpAsync(string tournamentName, ulong playerId);

        Task StartTournamentAsync(string tournamentName);
    }
}