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
    public class MainPageViewModel : BaseViewModels
    {
        private ObservableCollection<Amiibo> _amiibos;

        //creo una propiedad de tipo
        //ObservableCollection y que reciba de CHARACTER
        #region Properties
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> Amiibos
        {
            get => _amiibos;
            set
            {
                _amiibos = value;
                //parte de la propiedad para la lista de los Amiibos
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }
        #endregion

        public MainPageViewModel()
        {
            //expresion lambda
            SearchCommand =
                new Command(async (param) =>
                {
                    var character = param as Character;
                    if (character != null)
                    {
                        //$ se define cadena interpolada
                        string url = $"http://www.amiiboapi.com/api/amiibo/?character={character.name}";
                        var service =
                        new HttpHelpers<Amiibos>();
                        var amiibos =
                        await service.GetRestServiceDataAsync(url);
                        Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                    }

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
