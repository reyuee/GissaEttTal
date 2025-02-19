namespace Calculator
{
    public partial class BoardPage : ContentPage
    {
        private string selectedDifficulty;
        private int randomNumber;
        private int attempts = 0;
        private int score = 0;
        private bool isGameWon = false;
        Random random = new Random();

        public BoardPage(string difficulty)
        {
            InitializeComponent();
            selectedDifficulty = difficulty;
            GenerateRandomNumber();
            DifficultyLabel.Text = $"Sv�righetsgrad: {selectedDifficulty}";

            ShowDifficultyLevel();
            UpdateScore();
        }

        private void ShowDifficultyLevel()
        {
            if (selectedDifficulty == "L�tt")
                selectedIndex.Text = selectedDifficulty + " 0-25";
            else if (selectedDifficulty == "Medium")
                selectedIndex.Text = selectedDifficulty + " 0-50";
            else if (selectedDifficulty == "Sv�rt")
                selectedIndex.Text = selectedDifficulty + " 0-100";
        }

        private void GenerateRandomNumber()
        {
            switch (selectedDifficulty)
            {
                case "L�tt":
                    randomNumber = random.Next(1, 26);
                    break;
                case "Medium":
                    randomNumber = random.Next(1, 51);
                    break;
                case "Sv�rt":
                    randomNumber = random.Next(1, 101);
                    break;
                default:
                    randomNumber = 0;
                    break;
            }
        }

        private void OnSubmitGuessClicked(object sender, EventArgs e)
        {
            if (isGameWon)
            {
                submitGuessButton.IsEnabled = false;
                return;
            }

            string userGuess = guessEntry.Text;

            if (!int.TryParse(userGuess, out int guess))
            {
                FeedbackMessage.Text = "Skriv in ett giltigt heltal.";
                FeedbackMessage.Opacity = 1;
                return;
            }

            attempts++;
            AttemptsLabel.Text = $"Antal f�rs�k: {attempts}";

            if (guess == randomNumber)
            {
                isGameWon = true;
                submitGuessButton.IsEnabled = false;
                playAgainButton.IsEnabled = true;

                FeedbackIndicator.BackgroundColor = Colors.Green;
                FeedbackMessage.Text = $"Duktig! Du gissade r�tt :)! Numret var {randomNumber}.";

                UpdateScore();
            }
            else
            {
                FeedbackIndicator.BackgroundColor = Colors.Red;

                if (guess < randomNumber)
                    FeedbackMessage.Text = "Fel! Din gissning �r f�r l�g.";
                else
                    FeedbackMessage.Text = "Fel! Din gissning �r f�r h�g.";
            }

            FeedbackIndicator.IsVisible = true;
            FeedbackMessage.Opacity = 1;
        }

        private void UpdateScore()
        {
            if (attempts == 1)
                score += 10;
            else if (attempts <= 3)
                score += 7;
            else if (attempts <= 5)
                score += 5;
            else
                score += 3;

            ScoreLabel.Text = $"Po�ng: {score}";
        }

        private void OnPlayAgainClicked(object sender, EventArgs e)
        {
            attempts = 0;
            isGameWon = false;
            submitGuessButton.IsEnabled = true;
            playAgainButton.IsEnabled = false;

            FeedbackIndicator.IsVisible = false;
            FeedbackMessage.Opacity = 0;

            GenerateRandomNumber();
            AttemptsLabel.Text = "Antal f�rs�k: 0";
            guessEntry.Text = string.Empty;
        }
    }
}
