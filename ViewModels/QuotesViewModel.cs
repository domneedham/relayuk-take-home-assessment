using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using TakeHomeAssessment.Models;
using Microsoft.Maui.Networking;
using System.Diagnostics;


namespace TakeHomeAssessment.ViewModels
{
    
    public class QuotesViewModel : INotifyPropertyChanged
    {

        private string _quote;
        private string _author;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Quote
        {
            get => _quote;
            set => SetProperty(ref _quote, value);
        }

        public string Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }


        private QuotesService service;
        public IConnectivity connectivity;

        public QuotesViewModel(QuotesService quotesService, IConnectivity connectivity)
        {
            this.service = quotesService;
            RandomizeQuoteTextCommand = new Command(RandomizeQuoteText);
            this.connectivity = connectivity;
        }

        public ICommand RandomizeQuoteTextCommand { get; }

        private async void RandomizeQuoteText()
        {
            if (connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    QuoteDTO quote = await service.GetQuote();
                    Quote = quote.Content;
                    Author = quote.Author;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("No Internet Connection", $"Please check internet and try again.", "OK");

                return;
            }
            

            
        }



        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


