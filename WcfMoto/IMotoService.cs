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
        List<AnnouncementForView> GetAnnoucementSortByTitle();

        // TODO: Add your service operations here
    }
}
