using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HShelper_server.Models;
using HShelper_server.Services;

namespace HShelper_server.HubConfig
{
    public class LobbyHub: Hub
    {
        private readonly LobbyService _lobbyService;
        public LobbyHub(LobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }
        public void JoinLobby(string id, string btag)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, id);
            Clients.Group(id).SendAsync("Join", btag);
        }
        public void LeaveLobby(string id, string btag)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, id);
            Clients.Group(id).SendAsync("Leave", btag);
        }
        public void getNick(string battleTag, Lobby lobby, string id)
        {
            var newPlayer = new Player
            {
                btag = battleTag
            };
            var findPlayer = lobby.players.Find(p => p.btag == battleTag);
            if (findPlayer == null)
            {
                lobby.players.Add(newPlayer);
            }
            if(lobby.players.Count() == 2)
            {
                lobby.status = "picks";
            }
             Clients.Group(id).SendAsync("Players", lobby);
        }
        public void CheckPicks(string battleTag, List<string> picks, Lobby lobby, string id)
        {
            var index = lobby.players.FindIndex(p => p.btag == battleTag);
            if (index == -1 || lobby.players.Count() < 2)
            {
                lobby.players.Add(new Player
                {
                    btag = "unknown",
                    picks = new List<string>(),
                    bans = new List<string>()
                });
                index = lobby.players.Count() - 1;
            }
            if (lobby.config.picks == picks.Count())
            {
                lobby.players[index].picks = picks;
            }
            lobby.players.ForEach(p =>
            {
                if (p.picks == null)
                    p.picks = new List<string>();
                if (p.bans == null)
                    p.bans = new List<string>();
            });
            if(lobby.players.All(p => p.picks.Count() == lobby.config.picks))
            {
                if (lobby.config.bans == 0)
                    lobby.status = "summary";
                else
                    lobby.status = "bans";
            }
            Clients.Group(id).SendAsync("Picks", lobby);
        }
        public void CheckBans(string battleTag, List<string> bans, Lobby lobby, string id)
        {
            var index = lobby.players.FindIndex(p => p.btag != battleTag);
            if (lobby.config.bans == bans.Count())
            {
                lobby.players[index].bans = bans;
            }
            if (lobby.players.All(p => p.bans.Count() == lobby.config.bans))
            {
                lobby.status = "summary";
            }
            Clients.Group(id).SendAsync("Bans", lobby);
        }
    }
}
