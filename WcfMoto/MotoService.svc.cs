using System;
using System.Collections.Generic;
using System.Linq;
using WcfMoto.Model;
using WcfMoto.ViewModels;
using WcfMoto.Utils;

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
        List<UserForView> IMotoService.GetUsers()
        {
            var dbContext = new MotoEntities();
            var query = from Users in dbContext.Users select Users;
            return query.ToList()
                .Select(Users => new UserForView(Users))
                .ToList();
        }

        List<UserForView> IMotoService.GetUsersSortByUsername()
        {
            var dbContext = new MotoEntities();
            var query = from Users in dbContext.Users select Users;
            query = query.OrderBy(Users => Users.Username);
            return query.ToList()
                .Select(Users => new UserForView(Users))
                .ToList();
        }

        public bool AddOrUpdateAnnouncements(AnnouncementForView announcement)
        {
            try
            {
                var db = new MotoEntities();
                if (announcement.IdAnnouncement != 0 && db.Announcements.Any(a=>a.IdAnnouncement==announcement.IdAnnouncement))
                {
                    var modified = db.Announcements.FirstOrDefault(a => a.IdAnnouncement == announcement.IdAnnouncement);
                    modified.CopyProperties(announcement);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                var bestId = (db.Announcements.OrderByDescending(a => a.IdAnnouncement).FirstOrDefault()?.IdAnnouncement ?? 0) +1;
                announcement.IdAnnouncement = bestId;

                db.Announcements.Add(announcement);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }

        }

        public bool AddOrUpdateUser(UserForView user)
        {
            try
            {
                var db = new MotoEntities();
                if (user.IdUser != 0 && db.Users.Any(a => a.IdUser == user.IdUser))
                {
                    var modified = db.Users.FirstOrDefault(a => a.IdUser == user.IdUser);
                    modified.CopyProperties(user);
                    db.Entry(modified).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                var bestId = (db.Users.OrderByDescending(a => a.IdUser).FirstOrDefault()?.IdUser ?? 0) + 1;
                user.IdUser = bestId;

                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine($"Exception occured {e.Message}");
                return false;
            }
        }
    }
}
