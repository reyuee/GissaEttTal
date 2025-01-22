namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int selectedIndex = 0;

        public MainPage()
        {
            InitializeComponent();
            CreatePickerList();
            picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;
        }

        private async void OnStartGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoardPage(selectedIndex));
        }

        private void CreatePickerList()
        {
            var difficulty = new List<string>();
            difficulty.Add("Svårt");
            difficulty.Add("Medium");
            difficulty.Add("Lätt");

            Picker picker = new Picker { Title = "välja svårighetsgrad" };
            picker.ItemsSource = difficulty;

            picker.SelectedIndexChanged += OnPickerSelectedIndexChanged;

        }
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                monkeyNameLabel.Text = (string)picker.ItemsSource[selectedIndex];
            }
            else
            {
                monkeyNameLabel.Text = "Välj en svårighetsgrad";
            }
        }
    }

}
