using CapaENT;
using Microsoft.AspNetCore.SignalR;

namespace CrudPracticaExamen.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(clsMensajeUsuario mensajeInfo)
        {
            await Clients.All.SendAsync("ReceiveMessage", mensajeInfo);
        }
    }
}
