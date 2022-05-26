using AppMobileMoto.Models;
using ServiceReferenceMoto;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppMobileMoto.Services
{
    public class ItemDataStore : AbstractDataStore<Item>
    {
        public ItemDataStore()
            : base()
        {
            //items = MotoService.GetAnnouncements(new GetAnnouncementsRequest()).GetAnnouncementsResult.Select(u => new Item(u)).ToList();
            Refresh();
        }
        public void Refresh()
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
        public override async Task<bool> AddItemAsync(Item item)
        {
            var passed = MotoService.AddAnnouncements(new AddAnnouncementsRequest(item.IdUser, item.IdBrand,
                item.IdModel, item.IdBodyType, item.IdColor, item.Title,
                item.Description, item.Price, item.Negotiable, item.ProDate.Value,
                item.Mileage.Value, item.StrokeCapacity.Value, item.Power.Value)).AddAnnouncementsResult;
            if (!passed)
            {
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
