using System.Collections.Generic;
using System.ServiceModel;
using WcfMoto.ViewModels;

namespace WcfMoto
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMotoService" in both code and config file together.
    [ServiceContract]
    public interface IMotoService
    {
        [OperationContract]
        List<AnnouncementForView> GetAnnouncements();

        [OperationContract]
        bool AddOrUpdateAnnouncements(AnnouncementForView announcement);

        [OperationContract]
        List<AnnouncementForView> GetAnnoucementSortByTitle();
        [OperationContract]
        List<UserForView> GetUsers();

        [OperationContract]
        List<UserForView> GetUsersSortByUsername();

        [OperationContract]
        bool AddOrUpdateUser(UserForView User);

        [OperationContract]
        List<BillForView> GetBills();
        [OperationContract]
        List<BillForView> GetUserBills(int id);
        [OperationContract]
        List<MessageForView> GetUserMessages(int id);
        [OperationContract]
        List<MessageForView> GetUserInAnnouncementMessages(int iduser, int idannouncement);
        [OperationContract]
        List<BrandForView> GetBrands();
        [OperationContract]
        bool AddAnnouncements(int iduser, int idbrand, int idmodel, int bodytype, int color, 
            string title, string des, int price, bool neg, int prodate, int mileage, int stcap, int power);
        [OperationContract]
        bool AddBill(int idservice, int idanno, int iduser, decimal finalv);
        [OperationContract]
        bool AddMsg( int idanno, int iduser, string message, bool fromuser);



        // TODO: Add your service operations here
    }
}
