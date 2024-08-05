using TakeHomeAssessment.ViewModels;

namespace TakeHomeAssessment.Views;

public partial class QuotesPage : ContentPage
{
    private static readonly string[] Images = { "quote_image_one.svg", "quote_image_two.svg" };

    public QuotesPage(QuotesViewModel quotesViewModel)
    {
        InitializeComponent();
        BindingContext = quotesViewModel;
        SetRandomImage();
    }

    private void SetRandomImage()
    {
        var random = new Random();
        int index = random.Next(Images.Length);
        quoteImage.Source = Images[index];
    }
}

