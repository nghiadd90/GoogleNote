using System.Threading.Tasks;
using GoogleNote.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace GoogleNote.Hubs
{
    public class ChatHub : Hub
    {
        public async Task UpdateNote(Note note)
        {
            await Clients.All.SendAsync("UpdateNote", note);
        }
    }
}