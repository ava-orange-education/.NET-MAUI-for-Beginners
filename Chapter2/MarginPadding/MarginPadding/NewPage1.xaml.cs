namespace MarginPadding;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
	
	void ChangeLabelText(string text)
	{
		uiLabel.Text = text;
	}
}