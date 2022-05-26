using System;
using System.Runtime.Serialization;
using WcfMoto.Model;
using WcfMoto.Utils;

namespace WcfMoto.ViewModels
{
    [DataContract]
    public class BillForView
    {
        [DataMember]
        public int IdBill { get; set; }
        [DataMember]
        public int IdService { get; set; }
        [DataMember]
        public int IdAnnouncement { get; set; }
        [DataMember]
        public string AnnouncementTitle { get; set; }
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public decimal FinalValue { get; set; }
        [DataMember]
        public DateTime DateTo { get; set; }
        public static implicit operator Bills(BillForView bill)
        {
            var res = new Bills();
            res.CopyProperties(bill);
            return res;
        }
        public BillForView() { }
        public BillForView(BillForView bill)
        {
            this.CopyProperties(bill);
        }
        public BillForView(Bills bill)
        {
            AnnouncementTitle = bill.Announcements.Title;
            this.CopyProperties(bill);
        }
    }
}