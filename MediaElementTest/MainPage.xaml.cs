using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using System.Diagnostics;

namespace MediaElementTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            mediaElement.StateChanged += MediaElement_StateChanged;
        }

        private void MediaElement_StateChanged(object? sender, MediaStateChangedEventArgs e)
        {
            Debug.WriteLine($"{e.PreviousState} => {e.NewState}");

            var source = mediaElement.Source.ToString();
            if (e.NewState == MediaElementState.Stopped && source == "Uri: https://onlinetestcase.com/wp-content/uploads/2023/06/500-KB-MP3.mp3")
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    mediaElement.ShouldAutoPlay = true;
                    mediaElement.Source = MediaSource.FromUri("https://onlinetestcase.com/wp-content/uploads/2023/06/100-KB-MP3.mp3");
                });
            }
        }
    }
}
