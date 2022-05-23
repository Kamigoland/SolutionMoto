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


        // TODO: Add your service operations here
    }
}
