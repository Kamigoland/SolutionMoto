using System.Runtime.Serialization;
using WcfMoto.Model;
using WcfMoto.Utils;

namespace WcfMoto.ViewModels
{
    [DataContract]
    public class MessageForView
    {
        [DataMember]
        public int IdMessage { get; set; }
        [DataMember]
        public int IdAnnouncement { get; set; }
        [DataMember]
        public int IdAnnouncementUser { get; set; }
        [DataMember]
        public string AnnouncementTitle { get; set; }
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool FromUser { get; set; }
        [DataMember]
        public System.DateTime Date { get; set; }
        public static implicit operator Messages(MessageForView Message)
        {
            var res = new Messages();
            res.CopyProperties(Message);
            return res;
        }
        public MessageForView() { }
        public MessageForView(MessageForView Message)
        {
            this.CopyProperties(Message);
        }
        public MessageForView(Messages Message)
        {
            IdAnnouncementUser = Message.Announcements.IdUser;
            AnnouncementTitle = Message.Announcements.Title;
            this.CopyProperties(Message);
        }
    }
}