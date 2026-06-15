using Toidupaevik.ViewModels;

namespace Toidupaevik.Views;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadFoodsAsync();
    }

    private void OnPlaceTapped(object sender, TappedEventArgs e)
    {
        var position = e.GetPosition(PlaceArea);

        if (position == null)
            return;

        AbsoluteLayout.SetLayoutBounds(
            FoodIcon,
            new Rect(
                position.Value.X - 30,
                position.Value.Y - 30,
                60,
                60));
    }
}
