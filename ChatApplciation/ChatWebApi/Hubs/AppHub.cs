using ChatWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatWebApi.Hubs
{
    public class AppHub:Hub
    {
        public async Task HubNewMessage (string from,string to, int id, string content ,string created,bool sent)
        {
            ParametersForSendAsyncNewMessage hubParams = new ParametersForSendAsyncNewMessage() { from = from, to=to ,id = id, content = content,created=created,sent=sent };
            await Clients.All.SendAsync("MessageReceived", hubParams);
        }

        public async Task HubNewContact(string to,JsonResult jsonConversation )
        {
            //ParametersForSendAsyncNewContact hubParams=new ParametersForSendAsyncNewContact() { }
            ParametersForSendAsyncNewContact hunParams = new ParametersForSendAsyncNewContact() { to = to, conversations = jsonConversation };
            await Clients.All.SendAsync("NewContactAdded", hunParams);
        }
    }
}
