using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using ServiceReferenceMoto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppMobileMoto.Services
{
    class MessagesDataStore : AbstractDataStore<Messages>
    {
        public MessagesDataStore() : base()
        {
            Refresh();
            //items = MotoService.GetUserMessages(new GetUserMessagesRequest(LoginViewModel.SessionId)).GetUserMessagesResult.Select(m => new Messages(m)).ToList();
        }
        public void Refresh()
        {
            items = MotoService.GetUserMessages(new GetUserMessagesRequest(LoginViewModel.SessionId)).GetUserMessagesResult.Select(m => new Messages(m)).ToList();
        }
        public override Messages Find(Messages item)
        {
            return items.Where((Messages arg) => arg.IdMessage == item.IdMessage).FirstOrDefault();
        }

        public override Messages Find(int id)
        {
            return items.Where((Messages arg) => arg.IdMessage == id).FirstOrDefault();
        }
        public override async Task<bool> AddItemAsync(Messages message)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAA");
            var passed = MotoService.AddMsg(new AddMsgRequest(message.IdAnnouncement,
                message.IdUser, message.Message, message.FromUser)).AddMsgResult;
            if (!passed)
            {
                Refresh();
                return await Task.FromResult(false);
            }
            else
            {
                Refresh();
                return await Task.FromResult(true);
            }
        }
    }
}
