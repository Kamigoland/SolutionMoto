using AppMobileMoto.Utils;
using ServiceReferenceMoto;
using System;

namespace AppMobileMoto.Models
{
    public class Messages
    {
        public int IdMessage { get; set; }
        public int IdAnnouncement { get; set; }
        public int IdAnnouncementUser { get; set; }
        public string AnnouncementTitle { get; set; }
        public int IdUser { get; set; }
        public string Message { get; set; }
        public bool FromUser { get; set; }
        public DateTime Date { get; set; }
        public Messages() { }

        public static implicit operator MessageForView(Messages Messages)
        {
            var res = new MessageForView();
            res.CopyProperties(Messages);
            return res;
        }
        public Messages(MessageForView Messages)
        {
            this.CopyProperties(Messages);
        }
    }
}
