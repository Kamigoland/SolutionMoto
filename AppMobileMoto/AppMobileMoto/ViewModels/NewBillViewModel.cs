using AppMobileMoto.Models;
using ServiceReferenceMoto;
using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    class NewBillViewModel : ANewItemViewModel<Bill>
    {
        public List<Item> userInActiveAnnouncements;
        public List<string> titles = new();

        private int idAnnouncement;
        private int idService;
        private decimal finalValue;

        public NewBillViewModel() : base()
        {
            userInActiveAnnouncements = DependencyService.Get<IMotoService>().GetAnnouncements(new GetAnnouncementsRequest()).GetAnnouncementsResult.Select(u => new Item(u)).ToList();
        }
        public List<string> UIAA//tlt
        {
            get
            {
                foreach (Item item in userInActiveAnnouncements)
                {
                    titles.Add(item.Title);
                }
                return titles;
            }
        }

        public int IdAnnouncement
        {
            get => idAnnouncement;
            set => SetProperty(ref idAnnouncement, value);
        }
        public int IdService
        {
            get => idService;
            set => SetProperty(ref idService, value);
        }
        public decimal FinalValue
        {
            get => finalValue;
            set => SetProperty(ref finalValue, value);
        }
        public override Bill SetItem()
        {
            Bill bill = new Bill()
            {
                IdAnnouncement = IdAnnouncement,
                IdService = IdService,
                IdUser = LoginViewModel.SessionId,
                FinalValue = FinalValue
            };
            return bill;
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
