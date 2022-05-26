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

        public List<BillForView> GetBills()
        {
            var dbContext = new MotoEntities();
            var query = from Bills in dbContext.Bills select Bills;
            return query.ToList()
                .Select(Bills => new BillForView(Bills))
                .ToList();
        }
        public List<BillForView> GetUserBills(int id)
        {
            var dbContext = new MotoEntities();
            var query = from Bills in dbContext.Bills where Bills.IdUser==id select Bills;
            return query.ToList()
                .Select(Bills => new BillForView(Bills))
                .ToList();
        }

        public List<MessageForView> GetUserMessages(int id)
        {
            var dbContext = new MotoEntities();
            var queryfinale = from Messages in dbContext.Messages 
                        where Messages.IdUser == id 
                        select Messages;
            return queryfinale.ToList()
                .Select(Messages => new MessageForView(Messages))
                .ToList();
        }

        public List<MessageForView> GetUserInAnnouncementMessages(int iduser, int idannouncement)
        {
            var dbContext = new MotoEntities();
            var queryfinale = from Messages in dbContext.Messages
                              where Messages.IdUser == iduser
                              where Messages.IdAnnouncement == idannouncement
                              select Messages;
            return queryfinale.ToList()
                .Select(Messages => new MessageForView(Messages))
                .ToList();
        }

        public List<BrandForView> GetBrands()
        {
            var dbContext = new MotoEntities();
            var query = from Brands in dbContext.Brands select Brands;
            return query.ToList()
                .Select(Brands => new BrandForView(Brands))
                .ToList();
        }

        public bool AddAnnouncements(int iduser, int idbrand, int idmodel, int bodytype, int color, string title, string des, int price, bool neg, int prodate, int mileage, int stcap, int power)
        {
            try
            {
                var db = new MotoEntities();
                var bestId = (db.Announcements.OrderByDescending(a => a.IdAnnouncement).FirstOrDefault()?.IdAnnouncement ?? 0) + 1;
                Announcements announcement = new Announcements();
                announcement.IdAnnouncement = bestId;
                announcement.IdUser = iduser;
                announcement.IdBrand = idbrand;
                announcement.IdModel = idmodel;
                announcement.IdBodyType = bodytype;
                announcement.IdColor = color;
                announcement.Title = title;
                announcement.Description = des;
                announcement.Price = price;
                announcement.Negotiable = neg;
                announcement.ProDate = prodate;
                announcement.Mileage = mileage;
                announcement.StrokeCapacity = stcap;
                announcement.Power = power;
                announcement.IsActive = true;

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
    }
}
