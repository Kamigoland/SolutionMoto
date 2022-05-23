using AppMobileMoto.Models;
using System;

namespace AppMobileMoto.ViewModels
{
    public class NewItemViewModel : ANewItemViewModel<Item>
    {
        private string text;
        private string description;
        public NewItemViewModel()
            : base()
        {

        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public override Item SetItem()
        {
            Item newItem = new Item()
            {
                IdAnnouncement = 1,
                Title = Text,
                Description = Description
            };
            return newItem;
        }
    }

}
