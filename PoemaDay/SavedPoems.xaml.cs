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
        }

    }
}
