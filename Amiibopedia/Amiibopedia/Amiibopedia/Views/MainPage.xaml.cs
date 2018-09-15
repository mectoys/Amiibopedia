﻿using Amiibopedia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Amiibopedia
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async  void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new MainPageViewModel();
            await ViewModel.LoadCharacters();
            this.BindingContext = ViewModel;
        }

        private void SfAutoComplete_SelectionChanged(object sender, Syncfusion.SfAutoComplete.XForms.SelectionChangedEventArgs e)
        {

        }
    }
}