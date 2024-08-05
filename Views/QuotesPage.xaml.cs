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
        SetPlatformSpecificBackgroundColor();
    }

    private void SetRandomImage()
    {
        var random = new Random();
        int index = random.Next(Images.Length);
        quoteImage.Source = Images[index];
    }

    private void SetPlatformSpecificBackgroundColor()
    {
        if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            this.BackgroundColor = Colors.LightBlue;
        }
        else if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            this.BackgroundColor = Colors.LightGreen;
        }
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            this.BackgroundColor = Colors.LightCoral;
        }
        else
        {
            this.BackgroundColor = Colors.White; // Default color
        }
    }
}

