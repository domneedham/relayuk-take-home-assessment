using System.ComponentModel;
using System.Windows.Input;
using TakeHomeAssessment.Views;

namespace TakeHomeAssessment.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
  
    /// <summary>
    /// The current main button text.
    /// </summary>
    private string _buttonText = "Open Quotes Page";

    public MainPageViewModel()
    {
        this.NavigateToQuotesCommand = new Command(this.NavigateToQuotes);       
    }

    /// <inheritdoc/>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Gets the command handler for the main button click.
    /// </summary>
    public ICommand NavigateToQuotesCommand { get; init; }

    /// <summary>
    /// Gets and sets the main button text.
    /// </summary>
    public string ButtonText
    {
        get => this._buttonText;
        set
        {
            this._buttonText = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ButtonText)));
        }
    }

    /// <summary>
    /// This is the navigation to the quotes page. 
    /// </summary>
    private async void NavigateToQuotes()
    {
        await Shell.Current.GoToAsync(nameof(QuotesPage));
    }
}
