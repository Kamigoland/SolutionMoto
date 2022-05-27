using AppMobileMoto.Models;
using ServiceReferenceMoto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class MessageDetailViewModel : ANewItemViewModel<Messages>
    {
        public Command LoadItemsCommand { get; }
        public List<Messages> allMessages = new List<Messages>();
        private int userId, annoId;
        private bool fromUser = true;

        private string usermessage;
        //private List<MessForView> messForView = new List<MessForView>();
        private List<string> messForView = new List<string>();
        public MessageDetailViewModel() : base()
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //allMessages = DependencyService.Get<IMotoService>().GetUserInAnnouncementMessages(
            //    new GetUserInAnnouncementMessagesRequest(userId, annoId)).GetUserInAnnouncementMessagesResult.
            //    Select(u=>new Messages(u)).ToList();
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                //var item = await DataStore.GetItemAsync(annoId);
                //if (annoId == userId)
                //{
                //    userId = item.IdUser;
                //    fromUser = false;
                //}
                //getMessages();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void getMessages()
        {
            allMessages = DependencyService.Get<IMotoService>().GetUserInAnnouncementMessages(
                new GetUserInAnnouncementMessagesRequest(userId, annoId)).GetUserInAnnouncementMessagesResult.
                Select(u => new Messages(u)).ToList();
        }
        public int ItemId
        {
            get
            {
                return annoId;
            }
            set
            {
                annoId = value;
                userId = LoginViewModel.SessionId;
                LoadItemId(annoId);
                getMessages();
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                if (annoId == userId)
                {
                    userId = item.IdUser;
                    fromUser = false;
                }


            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        //public class MessForView
        //{
        //    private string[] who = new string[]{"You: ", "Seler: ", "Buyer: "};
        //    public string message;
        //    public MessForView(int i, string message)
        //    {
        //        this.message = who[i] + message;
        //    }
        //    public string MessageV { get { return message; } }
        //}
        public List<string> MessForViews
        {
            get
            {
                //List<string> messForView = new List<string>();
                //messForView = new List<MessForView>();
                foreach (var item in allMessages)
                {
                    if (fromUser)
                    {
                        if (item.FromUser)
                        {
                            messForView.Add("You: " + item.Message);
                            //messForView.Add(new MessForView(0, item.Message));
                        }
                        else
                        {
                            messForView.Add("Seller: " + item.Message);
                            //essForView.Add(new MessForView(1, item.Message));
                        }
                    }
                    else
                    {
                        if (item.FromUser)
                        {
                            messForView.Add("Buyer: " + item.Message);
                            //messForView.Add(new MessForView(2, item.Message));
                        }
                        else
                        {
                            messForView.Add("You: " + item.Message);
                            //messForView.Add(new MessForView(0, item.Message));
                        }
                    }
                }
                foreach (var item in messForView)
                {
                    Console.WriteLine(item);
                }
                return messForView;
            }
        }
        public int IdAnnouncement
        {
            get => annoId;
            set => SetProperty(ref annoId, value);
        }
        public int IdUser
        {
            get => userId;
            set => SetProperty(ref userId, value);
        }
        public string Message
        {
            get => usermessage;
            set => SetProperty(ref usermessage, value);
        }
        public bool FromUser
        {
            get => fromUser;
            set => SetProperty(ref fromUser, value);
        }

        public override Messages SetItem()
        {
            Messages message = new Messages()
            {
                IdAnnouncement = IdAnnouncement,
                IdUser = IdUser,
                Message = Message,
                FromUser = FromUser
            };
            return message;
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
