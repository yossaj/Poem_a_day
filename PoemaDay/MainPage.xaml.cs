using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MvvmCross.Forms.Views;
using Newtonsoft.Json;
using PoemaDay.model;
using PoemaDay.services;
using PoemaDay.viewmodel;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PoemaDay
{
    public partial class MainPage : MvxContentPage<MainPageVM>
    {

        public MainPage()
        {
            InitializeComponent();
        }

    }

   
}
