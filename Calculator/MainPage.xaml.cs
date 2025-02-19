namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int selectedIndex = -1;

        public MainPage()
        {
            InitializeComponent();
            picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                monkeyNameLabel.Text = (string)picker.ItemsSource[selectedIndex];
                startGameButton.IsEnabled = true;

               


                FeedbackMessage.Opacity = 0;
            }
            else
            {
                monkeyNameLabel.Text = "Välj en svårighetsgrad";
                startGameButton.IsEnabled = false;
            }
        }


        private async void OnStartGameClicked(object sender, EventArgs e)
        {
            if (selectedIndex != -1)
            {
                string selectedDifficulty = (string)picker.ItemsSource[selectedIndex];
                await Navigation.PushAsync(new BoardPage(selectedDifficulty));
            }
            else
            {
                FeedbackMessage.Text = "Vänligen välj en svårighetsgrad!";
                FeedbackMessage.Opacity = 1;

                await DisplayAlert("Info", "Välj en svårighetsgrad först!", "OK");
            }
        }

    }
}
