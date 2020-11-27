using PoemaDay.model;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace PoemaDay
{
    public partial class SavedPoems : ContentPage
    {
        public SavedPoems()
        {
            InitializeComponent();
            GetSavedPoems();
        }


        private void GetSavedPoems()
        {
            var poems = Poem.GetSavedPoems();
            SavePoemCollection.ItemsSource = poems;
            //foreach (Poem poem in poems)
            //{
            //    AddPoemsToView(poem);
            //};
        }

        private void AddPoemsToView(Poem poem)
        {


            //SwipeView swipeContainer = new SwipeView()
            //{
            //    Margin = new Thickness(10,5,10,0),
            //    BackgroundColor = Color.Transparent

            //};
            //ISwipeItem swipeItem = new SwipeItem()
            //{
            //    Text = "Delete",
            //    BackgroundColor = Color.Orange
            //};
            //swipeContainer.RightItems.Add(swipeItem);
            //Label title = new Label()
            //{
            //    Text = poem.title,
            //Margin = new Thickness(10, 10, 10, 0)
            //};
            //Label author = new Label()
            //{
            //    Text = poem.author,
            //    TextColor = (Color)App.Current.Resources["offBlack"],
            //    Margin = new Thickness(10, 0, 10, 10)
            //};
            //PancakeView pancakeView = new PancakeView()
            //{
            //    //BackgroundColor = (Color)App.Current.Resources["secondaryColor"],
            //    BackgroundColor = Color.Transparent,
            //    CornerRadius = new CornerRadius(30, 0, 0, 30)
            //};
            //var poemDetailTap = new TapGestureRecognizer();
            //poemDetailTap.Tapped += (s, e) => NavigateToDetailPage(poem);
            //pancakeView.GestureRecognizers.Add(poemDetailTap);

            //StackLayout innerContainer = new StackLayout()
            //{
            //    Margin = 10
            //};

            //innerContainer.Children.Add(title);
            //innerContainer.Children.Add(author);

            //pancakeView.Content = innerContainer;

            //StackLayout parent = PoemList;
            //swipeContainer.Content = pancakeView;
            //parent.Children.Add(swipeContainer);
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
