using AppMobileMoto.Models;
using AppMobileMoto.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppMobileMoto.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class MessageDetailViewModel : BaseViewModel
    {
        public IDataStore<Messages> DataStore => DependencyService.Get<IDataStore<Messages>>();
    }
}
