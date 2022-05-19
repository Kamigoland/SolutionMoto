using System.Collections.Generic;
using System.Linq;
using WcfMoto.Model;
using WcfMoto.ViewModels;

namespace WcfMoto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MotoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MotoService.svc or MotoService.svc.cs at the Solution Explorer and start debugging.
    public class MotoService : IMotoService
    {
        List<AnnouncementForView> IMotoService.GetAnnouncements()
        {
            var dbContext = new MotoEntities();
            var query = from Announcement in dbContext.Announcements select Announcement;
            return query.ToList()
                .Select(Announcement => new AnnouncementForView(Announcement))
                .ToList();
        }

        List<AnnouncementForView> IMotoService.GetAnnoucementSortByTitle()
        {
            var dbContext = new MotoEntities();
            var query = from Announcement in dbContext.Announcements select Announcement;
            query = query.OrderBy(Announcements => Announcements.Title);

            return query.ToList()
                .Select(Announcement => new AnnouncementForView(Announcement))
                .ToList();

        }
    }
}
