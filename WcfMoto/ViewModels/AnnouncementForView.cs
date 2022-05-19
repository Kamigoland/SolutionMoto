using System.Runtime.Serialization;
using WcfMoto.Model;

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
        public AnnouncementForView() { }
        public AnnouncementForView(Announcements Announcement)
        {
            IdAnnouncement = Announcement.IdAnnouncement;
            UserName = Announcement.Users.Username;
            BrandName = Announcement.Models.Brands.Name;
            ModelName = Announcement.Models.Name;
            BodyTypeName = Announcement.BodyTypes.Name;
            ColorName = Announcement.Colors.Name;
            Title = Announcement.Title;
            Description = Announcement.Description;
            Price = Announcement.Price;
            Negotiable = Announcement.Negotiable;
            ProDate = Announcement.ProDate;
            Mileage = Announcement.Mileage;
            StrokeCapacity = Announcement.StrokeCapacity;
            Power = Announcement.Power;
            IsActive = Announcement.IsActive;
        }



    }
}