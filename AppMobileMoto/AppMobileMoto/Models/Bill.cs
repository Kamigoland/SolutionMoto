using AppMobileMoto.Utils;
using ServiceReferenceMoto;
using System;

namespace AppMobileMoto.Models
{
    public class Bill
    {
        public int IdBill { get; set; }
        public int IdService { get; set; }
        public int IdAnnouncement { get; set; }
        public string AnnouncementTitle { get; set; }
        public int IdUser { get; set; }
        public decimal FinalValue { get; set; }
        public DateTime DateTo { get; set; }
        public Bill() { }

        public static implicit operator BillForView(Bill bill)
        {
            var res = new BillForView();
            res.CopyProperties(bill);
            return res;
        }
        public Bill(BillForView bill)
        {
            this.CopyProperties(bill);
        }
    }

}
