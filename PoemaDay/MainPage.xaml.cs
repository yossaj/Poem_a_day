using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using PoemaDay.model;
using PoemaDay.services;
using PoemaDay.viewmodel;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PoemaDay
{
    public partial class MainPage : ContentPage
    {
        Poem poem;
        MainPageVM viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageVM();
            
            SetPoem();
            
        }

        private async void SetPoem() {
            viewModel.poem = await Poem.GetPoem();
            BindingContext = viewModel;
        }

        void SaveButton_Clicked(System.Object sender, System.EventArgs e) => SavePoem();

        private void SavePoem()
        {
                if (Poem.SavePoem(viewModel.poem))
                {
                    DisplayAlert("Success", "Poem saved" , "OK");
                }
                else
                {
                    DisplayAlert("Something Went Wrong", "Poem not saved", "OK");
                }
        }
    }

   
}
