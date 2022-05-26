using AppMobileMoto.Models;
using AppMobileMoto.ViewModels;
using ServiceReferenceMoto;
using System.Linq;

namespace AppMobileMoto.Services
{
    class MessagesDataStore : AbstractDataStore<Messages>
    {
        public MessagesDataStore() : base()
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
    }
}
