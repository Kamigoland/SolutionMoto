using System.Runtime.Serialization;
using WcfMoto.Model;
using WcfMoto.Utils;

namespace WcfMoto.ViewModels
{
    [DataContract]
    public class AnnouncementForView
    {
        [DataMember]
        public int IdAnnouncement { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string BrandName { get; set; }
        [DataMember]
        public string ModelName { get; set; }
        [DataMember]
        public string BodyTypeName { get; set; }
        [DataMember]
        public string ColorName { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public bool Negotiable { get; set; }
        [DataMember]
        public int? ProDate { get; set; }
        [DataMember]
        public int? Mileage { get; set; }
        [DataMember]
        public int? StrokeCapacity { get; set; }
        [DataMember]
        public int? Power { get; set; }
        public bool IsActive { get; set; }
        public static implicit operator Announcements(AnnouncementForView announcement)
        {
            var res = new Announcements();
            res.CopyProperties(announcement);
            return res;
        }
        public AnnouncementForView() { }
        public AnnouncementForView(Announcements Announcement)
        {
            UserName = Announcement.Users.Username;
            BrandName = Announcement.Models.Brands.Name;
            ModelName = Announcement.Models.Name;
            BodyTypeName = Announcement.BodyTypes.Name;
            ColorName = Announcement.Colors.Name;
            this.CopyProperties(Announcement);
        }



    }
}