using System;
using System.Collections.Generic;
using PoemaDay.model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace PoemaDay
{
    public partial class SavedPoems : ContentPage
    {
        public SavedPoems()
        {
            InitializeComponent();

        }


        private void GetSavedPoems()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Poem>();
                var poems = conn.Table<Poem>().ToList();
                foreach(Poem poem in poems)
                {
                    AddPoemsToView(poem);
                };
                
            }
        }

        private void AddPoemsToView(Poem poem)
        {


            Label title = new Label()
            {
                Text = poem.title,
                Margin = 5
            };
            Label author = new Label()
            {
                Text = poem.author,
                Margin = 5
            };
            PancakeView pancakeView = new PancakeView()
            {
                BackgroundColor = (Color)App.Current.Resources["secondaryColor"],
                Margin = 10,
                CornerRadius = new CornerRadius(30, 0, 0, 30)
            };
            StackLayout innerContainer = new StackLayout()
            {
                Margin = 10
            };
            innerContainer.Children.Add(title);
            innerContainer.Children.Add(author);
           
            pancakeView.Content = innerContainer;
            //PoemList.Chidren.Add
            StackLayout parent = PoemList;
            parent.Children.Add(pancakeView);
       
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetSavedPoems();
        }
    }
}
