namespace EntryEditor;

public partial class MainPage : ContentPage
{
    string lipsum;

    public string Lipsum
    {
        get => lipsum;
        set => lipsum = value;
    }

    public string User { get; set; } = "";
    public string Pass { get; set; } = "";
    public string UserPass { get; set; } = "";

    bool userpassSet = false;

    public MainPage()
    {
        InitializeComponent();
        Lipsum =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        BindingContext = this;
    }

    void Entry_OnCompleted(object? sender, EventArgs e)
    {
        var entry = (Entry)sender;
        switch (entry.ClassId)
        {
            case "username":
                User = entry.Text;
                userpassSet = SetUserPass;
                UserPass = userpassSet ? $"{User}-{Pass}" : "";
                break;
            case "password":
                Pass = entry.Text;
                userpassSet = SetUserPass;
                UserPass = userpassSet ? $"{User}-{Pass}" : "";
                break;
        }

        uiLabel.Text = UserPass;
    }

    bool SetUserPass => !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Pass);

    void Editor_OnCompleted(object? sender, EventArgs e)
    {
        uiLabel2.Text = "Completed event raised";
    }
}