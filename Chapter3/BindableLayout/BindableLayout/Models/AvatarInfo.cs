namespace BindableLayout.Models;

public class AvatarInfo
{
    public Details Detials { get; }
    
    public AvatarInfo()
    {
        Detials = new Details
        {
            Name = "Lord Horace Batchelor",
            AvatarPics = new string[]
            {
                "pic1.png", "pic2.png", "pic3.png", "pic4.png", "pic5.png", "pic6.png"
            },
            RandomInfo = new string[]
            {
                "hanz-", "knitz-", "und-", "bumpsadaisy"
            }
        };
    }
}

public class Details
{
    public string Name { get; set; }
    public IEnumerable<string> AvatarPics { get; set; }
    public IEnumerable<string> RandomInfo { get; set; }
}