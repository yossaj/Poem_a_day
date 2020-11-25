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

    }

   
}
