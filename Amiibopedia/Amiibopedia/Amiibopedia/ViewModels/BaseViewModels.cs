

namespace Amiibopedia.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;


    //como parte de la programacion el xamarin forms se debe de crear
    //un clase base para propositos de uso diverso.

    //implementar la interfaz INotifyPropertyChanged

    public class BaseViewModels : INotifyPropertyChanged

    {
        #region Atributtes

        private bool _isBusy;

        #endregion

        #region Properties
        //esta propiedad sirve para identificar
        //que se esta creando alguna tarea y mostrar
        //algun tipo de retroalimentacion al user.

        public bool IsBusy
        {
            //letura
            get => _isBusy;
            //escritura
            set
            {
                _isBusy = value;
                //cuando se haga cambio a esta propiedad se
                //notificara OnPropertyChanged
                OnPropertyChanged();
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }
    }

}
