namespace Calculator;

public partial class BoardPage : ContentPage
{
	public BoardPage(int difficulty)
	{
		InitializeComponent();
        Difficulty.Text = difficulty.ToString();

    }
}