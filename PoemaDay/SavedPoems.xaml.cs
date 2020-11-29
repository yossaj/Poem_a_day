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
            if (Device.RuntimePlatform == Device.Android)
            {
                
                SavePoemCollection.ItemTemplate = (DataTemplate)SavedPoemsPage.Resources["SavedPoemItemAndroid"];
            }
            else
            {
                SavePoemCollection.ItemTemplate = (DataTemplate)SavedPoemsPage.Resources["SavedPoemItem"];
            }

            viewModel = new SavedPoemVM();
            BindingContext = viewModel;
        }

    }
}
