using ServiceReferenceMoto;
using AppMobileMoto.Utils;
namespace AppMobileMoto.Models
{
    public class Item
    {
        public int IdAnnouncement { get; set; }
        public int IdUser { get; set; }
        public int IdBrand { get; set; }
        public int IdModel { get; set; }
        public int IdBodyType { get; set; }
        public int IdColor { get; set; }
        public string UserName { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Negotiable { get; set; }
        public int? ProDate { get; set; }
        public int? Mileage { get; set; }
        public int? StrokeCapacity { get; set; }
        public int? Power { get; set; }
        public bool IsActive { get; set; }
        public Item() { }
        public Item(AnnouncementForView a)
        {
            this.CopyProperties(a);
        }
    }
}