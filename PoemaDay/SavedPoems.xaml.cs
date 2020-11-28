using PoemaDay.model;
using PoemaDay.viewmodel;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace PoemaDay
{
    public partial class SavedPoems : ContentPage
    {
        SavedPoemVM viewModel;

        public SavedPoems()
        {
         
            InitializeComponent();
            viewModel = new SavedPoemVM();
            BindingContext = viewModel;

            MessagingCenter.Subscribe<Poem>(this, "Favorited", (f) =>
            {
                Poem.DeletePoem(f);
                DisplayAlert("Deleted", $"{f.Title} has been deleted!", "Thanks");
            });
        }

        private async void NavigateToDetailPage(Poem poem)
        {
            PoemDetail poemDetail = new PoemDetail
            {
                BindingContext = poem
            };
            await Navigation.PushAsync(poemDetail);
            
        }
    }
}
