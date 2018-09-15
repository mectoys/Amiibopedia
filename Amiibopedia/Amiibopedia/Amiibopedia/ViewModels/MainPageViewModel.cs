using Amiibopedia.Helpers;
using Amiibopedia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Amiibopedia.ViewModels
{
  public  class MainPageViewModel : BaseViewModels
    {
        //creo una propiedad de tipo
        //ObservableCollection y que reciba de CHARACTER
        #region Properties
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> Amiibos { get; set; }

        public ICommand SearchCommand { get; set; }
        #endregion

        public MainPageViewModel()
        {
            //expresion lambda
            SearchCommand =
                new Command(async (text) =>
                {
                    //$ se define cadena interpolada
                    string url = $"http://www.amiiboapi.com/api/amiibo/?character={text}";
                    var service =
                    new HttpHelpers<Amiibos>();
                    var amiibos =
                    await service.GetRestServiceDataAsync(url);
                    Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                });
        }
        #region Methods
        public async Task LoadCharacters()
        {
            var url = "http://www.amiiboapi.com/api/character";

            var service =
                new HttpHelpers<Characters>();

            var characters = await service.GetRestServiceDataAsync(url);

            Characters = new ObservableCollection<Character>(characters.amiibo);
        } 
        #endregion

    }
}
