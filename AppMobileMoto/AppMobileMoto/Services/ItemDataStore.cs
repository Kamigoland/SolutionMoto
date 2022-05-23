using AppMobileMoto.Models;
using ServiceReferenceMoto;
using System.Linq;

namespace AppMobileMoto.Services
{
    public class ItemDataStore : AbstractDataStore<Item>
    {
        public ItemDataStore()
            : base()
        {
            items = MotoService.GetAnnouncements(new GetAnnouncementsRequest()).GetAnnouncementsResult.Select(u => new Item(u)).ToList();

        }
        public override Item Find(Item item)
        {
            return items.Where((Item arg) => arg.IdAnnouncement == item.IdAnnouncement).FirstOrDefault();
        }
        public override Item Find(int id)
        {
            return items.Where((Item arg) => arg.IdAnnouncement == id).FirstOrDefault();
        }
    }

}
